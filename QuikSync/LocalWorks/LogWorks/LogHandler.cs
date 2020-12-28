using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikSync.LocalWorks.LogWorks
{
    /// <summary>
    /// Class that needs just for wrapping LogStreamWriter into a global static object (will be changed ASAP).
    /// </summary>
    public static class LogHandler
    {
        public static LogScripter.LogStreamWriter LCW;

        /// <summary>
        /// Changes the session file to write to.
        /// </summary>
        /// <param name="sessionName">Name of the session.</param>
        public static void ChangeSession(string sessionName) 
        {
            if (!Directory.Exists("Logs"))
                Directory.CreateDirectory("Logs");

            if(LCW != null)
                LCW.Close();
            LCW = new LogScripter.LogStreamWriter("Logs\\" + sessionName + ".log", LogScripter.Attributes.LogCondition.None);
        }
    }
}
