using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TCPSharpFileSync.LocalWorks.FileWorks;

namespace TCPSharpFileSync.NetWorks
{
    /// <summary>
    /// Represent a parent class made for working with local files. Contains Data and Variables that Server and Client both using.
    /// </summary>
    public abstract class TCPFileWorker
    {
        /// <summary>
        /// Filer that contain everything filer should but for this TCPFileWorker
        /// </summary>
        public Filer Filed { get; set; }
        /// <summary>
        /// Hasher that contain all the Hasher should but for this TCPFileWorker 
        /// </summary>
        public Hasher Hashed { get; set; }

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
            Hashed = new Hasher(Filed.LocalPathes);

            HasherIO.ReadHasherFromFile(ts.hashDictionaryName, Hashed, Filed);

            Hashed.ComputeAllHashesBasedOnLocalPathes();
        }

        ~TCPFileWorker() 
        {
            HasherIO.WriteHasherToFile(ts.hashDictionaryName, Hashed, Filed);
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