using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuikSync.LocalWorks.SetupWorks;

namespace QuikSync.LocalWorks.SessionWorks
{
    /// <summary>
    /// Class that represents container for displaying data on main form about sessions.
    /// </summary>
    public class SessionData
    {
        /// <summary>
        /// Name of the session.
        /// </summary>
        public string SessionName { get; set; }
        /// <summary>
        /// Path to directory that has to be syncronized.
        /// </summary>
        public string Directory { get; set; }
        /// <summary>
        /// Ip that used for connection to Host.
        /// </summary>
        public string Ip { get; set; }
        /// <summary>
        /// Port that used for connection to Host or hosting Host.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Last time that session used.
        /// </summary>
        public string LastTimeUsed { get; set; }

        /// <summary>
        /// Flag that shows how the last time that session used as a Host or a Joined.
        /// </summary>
        public LaunchedAs LA { get; set; }

        /// <summary>
        /// Setup file name that will be used if that session will be choosed.
        /// </summary>
        public string SetupFileName { get; set; }

        /// <summary>
        /// Constuctor for SessionData.
        /// </summary>
        /// <param name="dir">Path to directory that has to be syncronized.</param>
        /// <param name="ip">Ip that used for connection to Host.</param>
        /// <param name="port">Port that used for connection to Host or hosting Host.</param>
        /// <param name="lasttimeused">Last time that session used.</param>
        /// <param name="lauchedas">Flag that shows how the last time that session used as a Host or a Joined. (hosted/joined - possible values)</param>
        /// <param name="sfn">Setup file name that will be used if that session will be choosed.</param>
        public SessionData(string sn, string dir, string ip, int port, string lauchedas, string lasttimeused, string sfn) 
        {
            SessionName = sn;
            Directory = dir;
            Ip = ip;
            Port = port;

            if (lauchedas != "hosted" && lauchedas != "joined" && lauchedas != "none")
            {
                throw new Exception("Not correct value! It has to be hosted or joined!");
            }

            LastTimeUsed = lasttimeused;

            if (lauchedas != "none")
                LA = lauchedas == "joined" ? LaunchedAs.Joined : LaunchedAs.Host;
            else
                LA = LaunchedAs.None;

            // ======NOT USING CURRENTLY========
            // ?AssignNewFile? is the code word for making new setup file.
            if (SetupFileName == "?AssignNewFile?") 
            {
                
            }
            else 
            {
                SetupFileName = sfn;
            }
        }
    }
}
