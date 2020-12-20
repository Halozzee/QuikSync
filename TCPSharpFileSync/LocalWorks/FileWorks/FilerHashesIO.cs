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
                    // We write LastWriteTime to make sure if the next time we access this file we get hash of THE SAME FILE
                    // if LastWriteTime will be different from that we write -> recompute hash.
                    FileInfo fi = new FileInfo(Filed.FilesData[i].localPath);
                    sw.Write(Filed.FilesData[i].relativePath + "?" + Filed.FilesData[i].hashMD5 + "?" + fi.LastWriteTime);

                    if (i != Filed.FilesData.Count - 1)
                    {
                        sw.Write("\n");
                    }
                }
            }
        }

        /// <summary>
        /// Function that read Hasher object from specific file.
        /// </summary>
        /// <param name="fileName">File that will be read for data. Has to has .HaDi extension.</param>
        /// <param name="syncDirPath">Path to a directory that has to be syncronized.</param>
        /// <param name="Filed">A Filer object that will help to decide which hashes are goes and which are not for Hasher (if file doesnt exist hash doesnt go to hasher).</param>
        public static void ReadHashesFromFile(string fileName, string syncDirPath ,Filer Filed)
        {
            // Check if file doesnt exist, then Ok.
            if (File.Exists("HashDictionaries\\"+fileName))
            {
                using (StreamReader sr = new StreamReader("HashDictionaries\\" + fileName)) 
                {
                    while (sr.Peek() >= 0)
                    {

                        string[] splitted = sr.ReadLine().Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries);

                        // We take LastWriteTime to make sure if the next time we access this file we get hash of THE SAME FILE
                        // if LastWriteTime will be different from that we write -> recompute hash.
                        FileInfo fi = new FileInfo(syncDirPath + splitted[0]);
                        int index = Filed.FilesData.FindIndex(x => x.relativePath == splitted[0]);

                        string fiSL = fi.LastWriteTime.ToString();

                        if (index != -1 && fiSL == splitted[2])
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