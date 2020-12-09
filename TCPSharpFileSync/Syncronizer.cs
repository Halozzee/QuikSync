using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatsonTcp;

namespace TCPSharpFileSync
{
    public class Syncronizer
    {
        public List<string> FilesDoesntExistInFirst { get; private set; }
        public List<string> FilesDoesntExistInSecond { get; private set; }

        List<string> LocalFiles = new List<string>();
        List<string> RemoteFiles = new List<string>();
        List<string> LocalHashes = new List<string>();
        List<string> RemoteHashes = new List<string>();
        private List<string> GetDifferenceListBasedOnFirst(List<string> First, List<string> Second)
        {
            HashSet<string> diff = new HashSet<string>();

            for (int i = 0; i < Second.Count; i++)
            {
                if (First.FindIndex(x => x == Second[i]) == -1)
                {
                    diff.Add(Second[i]);
                }
            }

            return diff.ToList();
        }
        public Syncronizer(List<string> First, List<string> Second, List<string> localhashes, List<string> remotehashes)
        {
            FilesDoesntExistInFirst = GetDifferenceListBasedOnFirst(First, Second);
            FilesDoesntExistInSecond = GetDifferenceListBasedOnFirst(Second, First);
            LocalFiles = First;
            RemoteFiles = Second;
            LocalHashes = localhashes;
            RemoteHashes = remotehashes;
        }
        public List<string> CompareHashes()
        {
            List<string> RetVal = new List<string>();

            for (int i = 0; i < LocalHashes.Count; i++)
            {
                if (LocalHashes[i] != RemoteHashes[i])
                {
                    RetVal.Add(LocalHashes[i]);
                }
            }

            return RetVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns the list of indexes on local files that hashes does not match hashes from server</returns>
        public List<int> FindConflicts()
        {
            List<int> ls = new List<int>();
            for (int i = 0; i < LocalHashes.Count; i++)
            {
                int indexRemote = RemoteFiles.FindIndex(x => x == LocalFiles[i]);

                if (indexRemote != -1)
                {
                    if (RemoteHashes[i] != LocalHashes[i] && RemoteHashes[i] != "-")
                        ls.Add(i);
                }
            }

            return ls;
        }
    }
}