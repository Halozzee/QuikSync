using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;

// typedef for better understanding and not using <>.
using StringList = System.Collections.Generic.List<string>;

namespace TCPSharpFileSync
{
    /// <summary>
    /// Class that represent work with MD5 hashes based on Local pathes given.
    /// </summary>
    public class Hasher
    {
        /// <summary>
        /// List of strings. Each string represents path to a file on this device (full path included RootPath).
        /// </summary>
        StringList localPathes;

        /// <summary>
        /// List of strings. Each string represents MD5 hash related to a Local path with the same index the hash has.
        /// </summary>
        public StringList HashesMD5 { get; private set; }

        /// <summary>
        /// The constructor that initializes Hasher class, filling both of the localPath and HashesMD5 lists.
        /// </summary>
        /// <param name="lp">List of Local pathes.</param>
        public Hasher(StringList lp)
        {
            localPathes = lp;
            HashesMD5 = new StringList();
            ComputeAllHashesBasedOnLocalPathes();
        }

        /// <summary>
        /// Procedure that compute all of the hashes based on Local pathes stored in localPathes list. Contain Progress bar works.
        /// </summary>
        public void ComputeAllHashesBasedOnLocalPathes() 
        {
            LogHandler.WriteLog("Calculating hashes...");
            LogHandler.SetProgressBarMaxValue(localPathes.Count);
            foreach (var item in localPathes)
            {
                HashesMD5.Add(CalculateMD5(item));
                LogHandler.IncrementProgressBarValue();
            }
            LogHandler.ResetProgressBarValue();
        }

        /// <summary>
        /// Function of calculating MD5 hash for a specific Local file.
        /// </summary>
        /// <param name="filename">Local file namme.</param>
        /// <returns>String that represent calculated value of MD5 hash.</returns>
        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        /// <summary>
        /// Function that gives MD5 hash based on given Local path.
        /// </summary>
        /// <param name="loc">Local path to get hash of.</param>
        /// <returns>String that represent calculated value of MD5 hash related to the given Local path.</returns>
        public string GetHashMD5FromLocal(string loc) 
        {
            return HashesMD5[localPathes.FindIndex(x => x == loc)];
        }

        /// <summary>
        /// Function that recalculate all the values for a NEW Filer object. 
        /// </summary>
        /// <param name="f">Updated Filer object to recalculate hashed based on its pathes.</param>
        public void UpdateHasherBasedOnUpdatedFiler(Filer f) 
        {
            List<string> updatedLocs = f.LocalFilePathes;

            //TODO: make this NOT CALCULATING ALL THE STUFF AGAIN - TOO TIME CONSUMING

            HashesMD5 = new List<string>();
            ComputeAllHashesBasedOnLocalPathes();
        }
    }
}