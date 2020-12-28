using LogScripter.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LogScripter
{
    class LogViewer
    {
        private Timer t;
        private LogStreamWriter LWS;
        LogCondition lc;
        object[] checkingFor;
        string[] adCon;
        public LogViewer(string path, LogCondition LC, params string[] additionalContext)
        {
            t = new Timer();
            LWS = new LogStreamWriter(path, LC);
            lc = LC;
            adCon = additionalContext;
        }

        public void LogTheseEachMilliseconds(int milliseconds, params object[] obj) 
        {
            checkingFor = obj;
            t.Start();
            t.Interval = milliseconds;
            t.Elapsed += T_Elapsed;
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            for (int i = 0; i < checkingFor.Length; i++)
            {
                switch (lc)
                {
                    case LogCondition.LogFriendlyAttribute:
                        LWS.Write(checkingFor[i], adCon);
                        break;
                    case LogCondition.None:
                        LWS.Write(checkingFor[i], adCon);
                        break;
                    default:
                        break;
                }
            }
        }

        public void Stop() 
        {
            t.Stop();
        }
    }
}
