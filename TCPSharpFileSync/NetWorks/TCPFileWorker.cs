using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPSharpFileSync
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
        /// Empty constructor for empty initialization.
        /// </summary>
        public TCPSettings()
        {

        }

        /// <summary>
        /// Constructor made for server that contain only server params.
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
            doDownload = false;
            doUpload = false;
            msTimeout = msToTimeout;
            removeIfNotOnClient = false;
            removeIfNotOnServer = false;
            ValidateTheDirPathSlashes();
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

    /// <summary>
    /// Represent a parent class made for working with local files. Contains Data and Variables that Server and Client both using.
    /// </summary>
    public abstract class TCPFileWorker
    {
        /// <summary>
        /// Filer that contain everything filer should but for this TCPFileWorker
        /// </summary>
        protected Filer Filed { get; set; }
        /// <summary>
        /// Hasher that contain all the Hasher should but for this TCPFileWorker 
        /// </summary>
        protected Hasher Hashed { get; set; }

        /// <summary>
        /// This TCPFileWorker
        /// </summary>
        protected TCPSettings ts;

        /// <summary>
        /// Flag that says if the TCPFileWorker downloading files or not.
        /// </summary>
        protected bool gettingFile = false;

        /// <summary>
        /// Package size that goes through server and client. 
        /// </summary>
        public long bufferSize = 65556;
        public static int msBeforeTimeOut = 5000;

        /// <summary>
        /// Procedure for initializing the Filer and Hasher for this TCPFileWorker
        /// </summary>
        /// <param name="pathToDir"></param>
        protected void FileScan(string pathToDir)
        {
            Filed = new Filer(pathToDir);
            Hashed = new Hasher(Filed.LocalFilePathes);
        }

        /// <summary>
        /// Function that returns string from byte array in unicode encoding.
        /// </summary>
        /// <param name="s">Byte array to get string from.</param>
        /// <returns>String from given byte array.</returns>
        protected string GetStringFromBytes(byte[] b)
        {
            return Encoding.Unicode.GetString(b);
        }

        /// <summary>
        /// Function that returns byte array from string in unicode encoding.
        /// </summary>
        /// <param name="s">String to get bytes from.</param>
        /// <returns>Byte array from given string.</returns>
        public byte[] GetBytesFromString(string s)
        {
            return Encoding.Unicode.GetBytes(s);
        }

        /// <summary>
        /// Getting Local IP address. (Used for server in local network, so it could be easily got without any additional moves).
        /// </summary>
        /// <returns>Local IP address.</returns>
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}