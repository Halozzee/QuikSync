using System.IO;
using System.Linq;

// typedef for better understanding and not using <>.
using StringList = System.Collections.Generic.List<string>;

namespace TCPSharpFileSync.LocalWorks.FileWorks
{
    /// <summary>
    /// Class that made for file working on device. Main purpose is to take "relative" pathes from "local" ones.
    /// </summary>
    public class Filer
    {
        /// <summary>
        /// Path to a directory that need to be syncronized.
        /// </summary>
        public string RootPath { get; private set; }

        /// <summary>
        /// List of strings. Each string represents path to a file on this device (full path included RootPath).
        /// </summary>
        public StringList LocalPathes { get; private set; }

        /// <summary>
        /// List of strings. Each string represents path to a file inside the syncronization filesystem (RootPath cutted out).
        /// </summary>
        public StringList RelativePathes { get; private set; }

        /// <summary>
        /// The constructor that initializes Filer class, filling both of the Relative and Local lists.
        /// </summary>
        /// <param name="pathToDir">Path to a directory that has to be syncronized.</param>
        public Filer(string pathToDir)
        {
            RootPath = pathToDir;
            LocalPathes = Directory.GetFiles(pathToDir, "*.*", SearchOption.AllDirectories).ToList();
            FillRelativePathes();
        }

        /// <summary>
        /// Procedure that fills the RelativeFilePathes based on LocalFilePathes.
        /// </summary>
        private void FillRelativePathes()
        {
            RelativePathes = new StringList();

            for (int i = 0; i < LocalPathes.Count; i++)
            {
                string s = LocalPathes[i].Replace(RootPath, "");
                RelativePathes.Add(s);
            }
        }

        /// <summary>
        /// Function that finds Relative equivalent based on Local path.
        /// </summary>
        /// <param name="loc">Local path to find Relative equivalent of.</param>
        /// <returns>Relative equivalent of given Local path.</returns>
        public string GetRelativeFromLocal(string loc)
        {
            return RelativePathes[LocalPathes.FindIndex(x => x == loc)];
        }

        /// <summary>
        /// Function that finds Local equivalent based on Relative path.
        /// </summary>
        /// <param name="loc">Relative path to find Local equivalent of.</param>
        /// <returns>Local equivalent of given Relative path.</returns>
        public string GetLocalFromRelative(string rel)
        {
            rel.Replace("?", "");
            return LocalPathes[RelativePathes.FindIndex(x => x == rel)];
        }

        /// <summary>
        /// Function that looks if file exists in a Relative list based on given value.
        /// </summary>
        /// <param name="rel">Given value to check existance of.</param>
        /// <returns>true if file does exist, false if it's not.</returns>
        public bool CheckFileExistanceFromRelative(string rel)
        {
            return RelativePathes.FindIndex(x => x == rel) != -1;
        }

        /// <summary>
        /// Function that returns FileInfo object based of given Relative path.
        /// </summary>
        /// <param name="rel">Relative path for looking FileInfo.</param>
        /// <returns>FileInfo object, that represents information about Local file found from given Relative value.</returns>
        public FileInfo GetLocalFileInfoFromRelative(string rel)
        {
            FileInfo fi = new FileInfo(GetLocalFromRelative(rel));

            return fi;
        }

        public string MakeLocalPathFromRelative(string rel) 
        {
            return (RootPath + rel);
        }
    }
}