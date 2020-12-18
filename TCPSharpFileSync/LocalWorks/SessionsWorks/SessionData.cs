using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPSharpFileSync.LocalWorks.SetupWorks;

namespace TCPSharpFileSync.LocalWorks.SessionsWorks
{
    /// <summary>
    /// Class that represents container for displaying data on main form about sessions.
    /// </summary>
    public class SessionData
    {
        /// <summary>
        /// Name of the session.
        /// </summary>
        public string SessionName { get; private set; }
        /// <summary>
        /// Path to directory that has to be syncronized.
        /// </summary>
        public string Directory { get; private set; }
        /// <summary>
        /// Ip that used for connection to server.
        /// </summary>
        public string Ip { get; private set; }
        /// <summary>
        /// Port that used for connection to server or hosting server.
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Last time that session used.
        /// </summary>
        public string LastTimeUsed { get; private set; }

        /// <summary>
        /// Flag that shows how the last time that session used as a server or a client.
        /// </summary>
        public LaunchedAs LA { get; private set; }

        /// <summary>
        /// Setup file name that will be used if that session will be choosed.
        /// </summary>
        public string SetupFileName { get; private set; }

        /// <summary>
        /// Constuctor for SessionData.
        /// </summary>
        /// <param name="dir">Path to directory that has to be syncronized.</param>
        /// <param name="ip">Ip that used for connection to server.</param>
        /// <param name="port">Port that used for connection to server or hosting server.</param>
        /// <param name="lasttimeused">Last time that session used.</param>
        /// <param name="lauchedas">Flag that shows how the last time that session used as a server or a client. (hosted/joined - possible values)</param>
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
                LA = lauchedas == "joined" ? LaunchedAs.Client : LaunchedAs.Server;
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
