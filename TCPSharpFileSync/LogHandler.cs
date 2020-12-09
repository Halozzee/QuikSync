using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPSharpFileSync
{
    public static class LogHandler
    {
        public static Action<string, Color> LogDelegate;
        public static Action<int> SetProgressBarMax;
        public static Action IncrementProgressBar;
        public static Action ResetProgressBar;

        public static void WriteLog(string s)
        {
            LogDelegate.Invoke(s, SystemColors.WindowText);
            Application.DoEvents();
        }

        public static void WriteLog(string s, Color c)
        {
            LogDelegate.Invoke(s, c);
            Application.DoEvents();
        }

        public static void SetProgressBarMaxValue(int max) 
        {
            SetProgressBarMax.Invoke(max);
        }

        public static void IncrementProgressBarValue() 
        {
            IncrementProgressBar.Invoke();
        }

        public static void ResetProgressBarValue()
        {
            ResetProgressBar.Invoke();
        }
    }
}