using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPSharpFileSync.LocalWorks.FileWorks
{
    /// <summary>
    /// Class that made for storing RelativePath:Hash into file. Each Pair separated with "\n". Key and value separated with ":".
    /// </summary>
    public static class FilerHashesIO
    {
        /// <summary>
        /// Function that stores Hasher object to specific file.
        /// </summary>
        /// <param name="fileName">File that will be created and used for storing Hasher object data. Has to has .HaDi extension.</param>
        /// <param name="Hashed">A Hasher object that data will be written to the file(hashes).</param>
        /// <param name="Filed">A Filer object that data will be written to the file(Relative pathes).</param>
        public static void WriteHashesToFile(string fileName, Filer Filed) 
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText("HashDictionaries\\"+fileName))
            {
                for (int i = 0; i < Filed.FilesData.Count; i++)
                {
                    sw.WriteLine(Filed.FilesData[i].relativePath + ":" + Filed.FilesData[i].hashMD5);
                }
            }
        }

        /// <summary>
        /// Function that read Hasher object from specific file.
        /// </summary>
        /// <param name="fileName">File that will be read for data. Has to has .HaDi extension.</param>
        /// <param name="Hashed">A Hasher object that will recieve data from the file(hashes).</param>
        /// <param name="Filed">A Filer object that will help to decide which hashes are goes and which are not for Hasher (if file doesnt exist hash doesnt go to hasher).</param>
        public static void ReadHashesFromFile(string fileName, Filer Filed)
        {
            // Check if file doesnt exist, then Ok.
            if (File.Exists("HashDictionaries\\"+fileName))
            {
                using (StreamReader sr = new StreamReader("HashDictionaries\\" + fileName)) 
                {
                    while (sr.Peek() >= 0)
                    {
                        string[] splitted = sr.ReadLine().Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);

                        int index = Filed.FilesData.FindIndex(x => x.relativePath == splitted[0]);

                        if (index != -1)
                        {
                            Filed.FilesData[index].hashMD5 = splitted[1];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Function that initialize HashDictionary file.
        /// </summary>
        /// <param name="fileName">File name that has to be initialized.</param>
        public static void InitializeHashDictionaryFile(string fileName) 
        {
            using (StreamWriter sr = new StreamWriter("HashDictionaries/" + fileName))
            { }
        }
    }
}