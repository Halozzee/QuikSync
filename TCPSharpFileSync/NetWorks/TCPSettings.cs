using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPSharpFileSync.LocalWorks.Attributes;
using TCPSharpFileSync.LocalWorks.SessionWorks;
using TCPSharpFileSync.LocalWorks.SetupWorks;

namespace TCPSharpFileSync.NetWorks
{
    /// <summary>
    /// Structure that represent settings for TCP actions.
    /// </summary>
    public class TCPSettings
    {
        /// <summary>
        /// Path to directory that has to be syncronized. 
        /// </summary>
        [Saving(Section = "General")]
        [Reading(Section = "General")]
        public string directoryPath;
        /// <summary>
        /// IP value the connection is going to establish to/listen to.
        /// </summary>
        [Saving(Section = "Joined")]
        [Reading(Section = "Joined")]
        public string ip;
        /// <summary>
        /// Port value that program will be listening to/send messages out.
        /// </summary>
        [Saving(Section = "General")]
        [Reading(Section = "General")]
        public int port;
        /// <summary>
        /// Time in milliseconds before timeout exception come up.
        /// </summary>
        [Saving(Section = "General")]
        [Reading(Section = "General")]
        public int msTimeout;
        /// <summary>
        /// Name of a file that contains pre-calculated hashes for pathes. It's in a HashDictionaries folder.
        /// </summary>
        [Saving(Section = "General")]
        [Reading(Section = "General")]
        public string hashDictionaryName;

        /// <summary>
        /// Empty constructor for empty initialization.
        /// </summary>
        public TCPSettings()
        {

        }

        /// <summary>
        /// Constructor made for Joined that contain all Joined params.
        /// </summary>
        /// <param name="ptd">Path to directory that has to be syncronized.</param>
        /// <param name="i">IP value the connection is going to establish to/listen to.</param>
        /// <param name="p">Port value that program will be listening to/send messages out</param>
        /// <param name="msToTimeout">Time in milliseconds before timeout exception come up.</param>
        public TCPSettings(string ptd, string i, int p, int msToTimeout)
        {
            directoryPath = ptd;
            ip = i;
            port = p;
            msTimeout = msToTimeout;
            ValidateTheDirPathSlashes();
        }

        /// <summary>
        /// Constructor for making TCPSettings straight from SessionData since they are made for different purposes.
        /// </summary>
        /// <param name="sd">Session data that stores same values.</param>
        /// <param name="msT">Time before timeout.</param>
        public TCPSettings(SessionData sd, int msT)
        {
            directoryPath = sd.Directory;
            ip = sd.Ip;
            port = sd.Port;
            msTimeout = msT;
            ValidateTheDirPathSlashes();
        }

        /// <summary>
        /// Validate if the last char is '\' or '/'
        /// </summary>
        /// <param name="dirPth">The path that needs to be validated</param>
        private void ValidateTheDirPathSlashes()
        {
            if (directoryPath[directoryPath.Length - 1] != '/' && directoryPath[directoryPath.Length - 1] != '\\')
            {
                // Checking for what type of slash has to be added 
                if (directoryPath.Contains("\\"))
                {
                    directoryPath += "\\";
                }
                else
                {
                    directoryPath += "/";
                }
            }
        }

    }
}
