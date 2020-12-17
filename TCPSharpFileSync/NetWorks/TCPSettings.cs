using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        [Saving(Section = "Client")]
        [Reading(Section = "Client")]
        public string ip;
        /// <summary>
        /// Port value that program will be listening to/send messages out.
        /// </summary>
        [Saving(Section = "General")]
        [Reading(Section = "General")]
        public int port;
        /// <summary>
        /// Flag that represents if client will be downloading files.
        /// </summary>
        [Saving(Section = "Client")]
        [Reading(Section = "Client")]
        public bool doDownload;
        /// <summary>
        /// Flag that represents if client will be uploading files.
        /// </summary>
        [Saving(Section = "Client")]
        [Reading(Section = "Client")]
        public bool doUpload;
        /// <summary>
        /// Time in milliseconds before timeout exception come up.
        /// </summary>
        [Saving(Section = "General")]
        [Reading(Section = "General")]
        public int msTimeout;
        /// <summary>
        /// Flag that represents if the files that doesnt exist on client side will be deleted on server.
        /// </summary>
        [Saving(Section = "Client")]
        [Reading(Section = "Client")]
        public bool removeIfNotOnClient;
        /// <summary>
        /// Flag that represents if the files that doesnt exist on server side will be deleted on client.
        /// </summary>
        [Saving(Section = "Client")]
        [Reading(Section = "Client")]
        public bool removeIfNotOnServer;

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
        /// Constructor made for client that contain all client params.
        /// </summary>
        /// <param name="ptd">Path to directory that has to be syncronized.</param>
        /// <param name="i">IP value the connection is going to establish to/listen to.</param>
        /// <param name="p">Port value that program will be listening to/send messages out</param>
        /// <param name="dd">Flag that represents if client will be downloading files.</param>
        /// <param name="du">Flag that represents if client will be uploading files.</param>
        /// <param name="rmifndefc">Flag that represents if the files that doesnt exist on client side will be deleted on server.</param>
        /// <param name="rmifndefs">Flag that represents if the files that doesnt exist on server side will be deleted on client.</param>
        /// <param name="msToTimeout">Time in milliseconds before timeout exception come up.</param>
        public TCPSettings(string ptd, string i, int p, bool dd, bool du, bool rmifndefc, bool rmifndefs, int msToTimeout)
        {
            directoryPath = ptd;
            ip = i;
            port = p;
            doDownload = dd;
            doUpload = du;
            msTimeout = msToTimeout;
            removeIfNotOnClient = rmifndefc;
            removeIfNotOnServer = rmifndefs;
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
