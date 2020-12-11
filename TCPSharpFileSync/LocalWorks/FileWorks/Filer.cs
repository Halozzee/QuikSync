using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPSharpFileSync
{
    public class Filer
    {
        public string rootPath { get; private set; }
        private List<string> filePathes;
        private List<string> relativeFilePathes;

        public Filer(string pathToDir) 
        {
            rootPath = pathToDir;
            filePathes = Directory.GetFiles(pathToDir, "*.*", SearchOption.AllDirectories).ToList();
            FillCuttedPathes();
        }

        public List<string> GetLocalFiles() 
        {
            return filePathes;
        }

        public List<string> GetRelativeFiles()
        {
            return relativeFilePathes;
        }
        private void FillCuttedPathes() 
        {
            relativeFilePathes = new List<string>();

            for (int i = 0; i < filePathes.Count; i++)
            {
                string s = filePathes[i].Replace(rootPath, "");
                relativeFilePathes.Add(s);
            }
        }
        public string GetRelativeFromLocal(string loc) 
        {
            return relativeFilePathes[filePathes.FindIndex(x => x == loc)];
        }
        public string GetLocalFromRelative(string rel)
        {
            rel.Replace("?", "");
            return filePathes[relativeFilePathes.FindIndex(x => x == rel)];
        }
        public bool CheckFileExistanceFromRelative(string rel) 
        {
            return relativeFilePathes.FindIndex(x => x == rel) != -1;
        }

        public FileInfo GetLocalFileInfoFromRelative(string rel) 
        {
            FileInfo fi = new FileInfo(GetLocalFromRelative(rel));

            return fi;
        }
    }
}