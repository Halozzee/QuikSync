using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
// typedef for better understanding and not using <>.
using StringList = System.Collections.Generic.List<string>;

namespace TCPSharpFileSync.LocalWorks.FileWorks
{
    /// <summary>
    /// Class that represent work with MD5 hashes based on Local pathes given.
    /// </summary>
    public class Hasher
    {
        /// <summary>
        /// List of strings. Each string represents path to a file on this device (full path included RootPath).
        /// </summary>
        public StringList LocalPathes { get; private set; }

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
            LocalPathes = lp;
            HashesMD5 = new StringList();

            for (int i = 0; i < LocalPathes.Count; i++)
            {
                HashesMD5.Add("");
            }
        }

        /// <summary>
        /// Flag that shows if read some hashes from the .hsh file.
        /// </summary>
        public bool loadedFromFile = false;

        /// <summary>
        /// Procedure that compute all of the hashes based on Local pathes stored in localPathes list. Contain Progress bar works.
        /// </summary>
        public void ComputeAllHashesBasedOnLocalPathes()
        {
            UIHandler.WriteLog("Calculating hashes...");
            UIHandler.SetProgressBarMaxValue(LocalPathes.Count);

            int startFrom = 0;

            if (loadedFromFile)
            {
                if (HashesMD5.Count > 0)
                {
                    while (HashesMD5[startFrom] != "")
                    {
                        startFrom++;

                        if (startFrom == HashesMD5.Count)
                        {
                            startFrom = 0;
                            break;
                        }
                    }
                }
            }

            for (int i = startFrom; i < LocalPathes.Count; i++)
            {
                HashesMD5[i] = CalculateMD5(LocalPathes[i]);
                UIHandler.IncrementProgressBarValue();
            }
            UIHandler.ResetProgressBarValue();
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
            return HashesMD5[LocalPathes.FindIndex(x => x == loc)];
        }

        /// <summary>
        /// Function that recalculate all the values for a NEW Filer object. 
        /// </summary>
        /// <param name="f">Updated Filer object to recalculate hashed based on its pathes.</param>
        public void UpdateHasherBasedOnUpdatedFiler(Filer f)
        {
            LocalPathes = f.LocalPathes;

            //TODO: make this NOT CALCULATING ALL THE STUFF AGAIN - TOO TIME CONSUMING

            HashesMD5 = new StringList();

            for (int i = 0; i < LocalPathes.Count; i++)
            {
                HashesMD5.Add("");
            }

            ComputeAllHashesBasedOnLocalPathes();
        }
    }
}