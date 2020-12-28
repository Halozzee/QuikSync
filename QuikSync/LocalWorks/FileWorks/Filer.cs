using System.IO;
using System.Linq;
using System.Collections.Generic;

// typedef for better understanding and not using <>.
using StringList = System.Collections.Generic.List<string>;
using System;
using System.Security.Cryptography;
using QuikSync.NetWorks.ConflictWorks;

namespace QuikSync.LocalWorks.FileWorks
{
    /// <summary>
    /// Enum for showing if file was deleted, changed(downloaded), or Untouched
    /// </summary>
    public enum FileModifiedStatus 
    {
        Deleted,
        Changed,
        Untouched
    }

    /// <summary>
    /// Class that represents all the data about file.
    /// </summary>
    public class FileData
    {
        /// <summary>
        /// Files Local path.
        /// </summary>
        public string localPath;
        /// <summary>
        /// Files Relative path.
        /// </summary>
        public string relativePath;
        /// <summary>
        /// Files hash.
        /// </summary>
        public string hashMD5;

        /// <summary>
        /// File size and last time modified data.
        /// </summary>
        public TimeSize ts;

        /// <summary>
        /// Files modified status.
        /// </summary>
        public FileModifiedStatus fms;

        /// <summary>
        /// Constructor for FileData that got from Local.
        /// </summary>
        /// <param name="SyncPath">Path to the directory that has to be syncronized.</param>
        /// <param name="localpath">Local path to a file.</param>
        public FileData(string SyncPath, string localpath) 
        {
            localPath = localpath;
            relativePath = localPath.Replace(SyncPath, "");
            hashMD5 = "";
            fms = FileModifiedStatus.Untouched;

            FileInfo fi = new FileInfo(localpath);
            ts = new TimeSize(fi.Length, fi.LastWriteTime.ToString("MM/dd/yyyy HH:mm"));
        }

        /// <summary>
        /// Constructor for FileData that got from Remote.
        /// </summary>
        /// <param name="relativepath">Relative path got from Host.</param>
        /// <param name="hashmd5">Hash got from Host.</param>
        /// <param name="fileSize">Size of the Host file in bytes.</param>
        /// <param name="lastWriteTime">"MM/dd/yyyy HH:mm" format of time file was last modified.</param>
        public FileData(string relativepath, string hashmd5, long fileSize, string lastWriteTime)
        {
            localPath = "";
            relativePath = relativepath;
            hashMD5 = hashmd5;
            fms = FileModifiedStatus.Untouched;
            ts = new TimeSize(fileSize, lastWriteTime);
        }
    }

    /// <summary>
    /// Class that made for file working on device. Main purpose is to take "relative" pathes from "local" ones.
    /// </summary>
    public class Filer
    {
        /// <summary>
        /// Path to a directory that need to be syncronized.
        /// </summary>
        public string RootPath { get; private set; }

        public List<FileData> FilesData = new List<FileData>();

        /// <summary>
        /// The constructor that initializes Filer class, filling both of the Relative and Local lists.
        /// </summary>
        /// <param name="pathToDir">Path to a directory that has to be syncronized.</param>
        public Filer(string pathToDir, string relatedHashDictionary)
        {
            RootPath = pathToDir;
            List<string> LocalPathesToFillData = Directory.GetFiles(pathToDir, "*.*", SearchOption.AllDirectories).ToList();

            for (int i = 0; i < LocalPathesToFillData.Count; i++)
            {
                FilesData.Add(new FileData(RootPath, LocalPathesToFillData[i]));
            }

            UIHandler.WriteLog("Reading hashes...");

            // Trying to read hashes from file.
            FilerHashesIO.ReadHashesFromFile(relatedHashDictionary, RootPath, this);

            UIHandler.WriteLog("Calculating hashes...");

            // If there's none hashes for some file -> compute them.
            for (int i = 0; i < FilesData.Count; i++)
            {
                if (FilesData[i].hashMD5 == "")
                {
                    FilesData[i].hashMD5 = CalculateMD5(FilesData[i].localPath);
                }
            }

            UIHandler.WriteLog("Saving hashes...");
            FilerHashesIO.WriteHashesToFile(relatedHashDictionary, this);
        }

      
        /// <summary>
        /// Function that finds Relative equivalent based on Local path.
        /// </summary>
        /// <param name="loc">Local path to find Relative equivalent of.</param>
        /// <returns>Relative equivalent of given Local path.</returns>
        public string GetRelativeFromLocal(string loc)
        {
            for (int i = 0; i < FilesData.Count; i++)
            {
                if (FilesData[i].localPath == loc)
                    return FilesData[i].relativePath;
            }

            return "?FileNotFound?";
        }

        /// <summary>
        /// Function that finds Local equivalent based on Relative path.
        /// </summary>
        /// <param name="loc">Relative path to find Local equivalent of.</param>
        /// <returns>Local equivalent of given Relative path.</returns>
        public string GetLocalFromRelative(string rel)
        {
            for (int i = 0; i < FilesData.Count; i++)
            {
                if (FilesData[i].relativePath == rel)
                    return FilesData[i].localPath;
            }

            return "?FileNotFound?";
        }

        /// <summary>
        /// Function that looks if file exists in a Relative list based on given value.
        /// </summary>
        /// <param name="rel">Given value to check existance of.</param>
        /// <returns>true if file does exist, false if it's not.</returns>
        public bool CheckFileExistanceFromRelative(string rel)
        {
            for (int i = 0; i < FilesData.Count; i++)
            {
                if (FilesData[i].relativePath == rel)
                    return true;
            }

            return false;
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

        /// <summary>
        /// Function of calculating MD5 hash for a specific Local file.
        /// </summary>
        /// <param name="filename">Local file namme.</param>
        /// <returns>String that represent calculated value of MD5 hash.</returns>
        public static string CalculateMD5(string filename)
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
        /// Function that changes FileData based on based Relative path.
        /// </summary>
        /// <param name="rel">Relative path to file.</param>
        /// <param name="f">Status that has to be set.</param>
        public void ChangeFileModifiedStatusByRelativePath(string rel, FileModifiedStatus f) 
        {
            for (int i = 0; i < FilesData.Count; i++)
            {
                if (FilesData[i].relativePath == rel) 
                {
                    FilesData[i].fms = f;
                    return;
                }
            }
        }

        /// <summary>
        /// Function that recomputes all hashes if file has Changed status and deletes data if file has Deleted status.
        /// </summary>
        public void RecomputeHashesBasedOnModifiedStatus() 
        {
            for (int i = 0; i < FilesData.Count; i++)
            {
                switch (FilesData[i].fms)
                {
                    case FileModifiedStatus.Deleted:
                        FilesData.RemoveAt(i);
                        i--;
                        break;
                    case FileModifiedStatus.Changed:
                        FilesData[i].hashMD5 = CalculateMD5(FilesData[i].localPath);
                        break;
                    case FileModifiedStatus.Untouched:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}