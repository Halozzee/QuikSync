using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPSharpFileSync
{
    /// <summary>
    /// Class that made for storing RelativePath:Hash into file. Each Pair separated with "\n". Key and value separated with ":".
    /// </summary>
    public static class HasherIO
    {
        /// <summary>
        /// Function that stores Hasher object to specific file.
        /// </summary>
        /// <param name="fileName">File that will be created and used for storing Hasher object data. Has to has .HaDi extension.</param>
        /// <param name="Hashed">A Hasher object that data will be written to the file(hashes).</param>
        /// <param name="Filed">A Filer object that data will be written to the file(Relative pathes).</param>
        public static void WriteHasherToFile(string fileName, Hasher Hashed, Filer Filed) 
        {

            // Create a file to write to.
            using (StreamWriter sw = File.CreateText("HashDictionaries\\"+fileName))
            {
                for (int i = 0; i < Hashed.HashesMD5.Count; i++)
                {
                    sw.Write(Filed.GetRelativeFromLocal(Hashed.LocalPathes[i]) + ":" + Hashed.HashesMD5[i]);

                    if(i != Hashed.HashesMD5.Count - 1)
                        sw.Write("\n");
                }
            }
        }

        /// <summary>
        /// Function that read Hasher object from specific file.
        /// </summary>
        /// <param name="fileName">File that will be read for data. Has to has .HaDi extension.</param>
        /// <param name="Hashed">A Hasher object that will recieve data from the file(hashes).</param>
        /// <param name="Filed">A Filer object that will help to decide which hashes are goes and which are not for Hasher (if file doesnt exist hash doesnt go to hasher).</param>
        public static void ReadHasherFromFile(string fileName, Hasher Hashed, Filer Filed)
        {
            // Check if file doesnt exist, then Ok.
            if (File.Exists("HashDictionaries\\"+fileName))
            {
                // Setting up the flag that says we've read data from file.
                Hashed.loadedFromFile = true;

                // Create a file to write to.
                using (StreamReader sw = File.OpenText("HashDictionaries\\" + fileName))
                {
                    while (!sw.EndOfStream)
                    {
                        // Reading line.
                        string s = sw.ReadLine();

                        // Splitting it to get key and value.
                        string[] splitted = s.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                        // Making local path to a file.
                        string localPath = Filed.MakeLocalPathFromRelative(splitted[0]);

                        // Looking for index of this local path.
                        int index = Hashed.LocalPathes.FindIndex(x => x == localPath);

                        // If this file does not exist anymore -> skip. Else -> we know hash and lets just write it.
                        if (index != -1)
                        {
                            Hashed.HashesMD5[Hashed.LocalPathes.FindIndex(x => x == localPath)] = splitted[1];
                        }
                    }
                }
            }
        }

        public static void InitializeHashDictionaryFile(string fileName) 
        {
            File.Create("HashDictionaries/"+ fileName);
        }
    }
}