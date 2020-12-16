using System.Collections.Generic;
using System.Linq;

// typedef for better understanding and not using <>.
using StringList = System.Collections.Generic.List<string>;

namespace TCPSharpFileSync
{
    /// <summary>
    /// Class made for solving file existance and hash conflicts.
    /// </summary>
    public class Syncronizer
    {
        /// <summary>
        /// List of strings. Each string represents Relative path that doesnt exist on local device.
        /// </summary>
        public StringList FilesDoesntExistOnLocal { get; private set; }
        /// <summary>
        /// List of strings. Each string represents Relative path that doesnt exist on remote device.
        /// </summary>
        public StringList FilesDoesntExistOnRemote { get; private set; }

        /// <summary>
        /// List of strings. Each string represents Relative path of file that exists on local device.
        /// </summary>
        StringList LocalFiles = new StringList();
        /// <summary>
        /// List of strings. Each string represents Relative path of file that exists on remote device.
        /// </summary>
        StringList RemoteFiles = new StringList();
        /// <summary>
        /// List of strings. Each string represents hash of file that exists on local device and calculated from files with the same index from LocalFiles list. 
        /// </summary>
        StringList LocalHashes = new StringList();
        /// <summary>
        /// List of strings. Each string represents hash of file that exists on remote device and calculated from files with the same index from RemoteFiles list. 
        /// </summary>
        StringList RemoteHashes = new StringList();

        /// <summary>
        /// Function that returns list of relative pathes that doesnt exist in First but does in Second.
        /// </summary>
        /// <param name="First">List of relative pathes to find not existing from.</param>
        /// <param name="Second">List of relative pathes to find not existing in.</param>
        /// <returns></returns>
        private StringList GetDifferenceListBasedOnFirst(StringList First, StringList Second)
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
        /// <summary>
        /// Constructor that initializing Syncronizer object.
        /// </summary>
        /// <param name="local">List of strings. Each string represents Relative path of file that exists on local device.</param>
        /// <param name="remote">List of strings. Each string represents Relative path of file that exists on remote device.</param>
        /// <param name="localhashes">List of strings. Each string represents hash of file that exists on local device and calculated from files with the same index from LocalFiles list.</param>
        /// <param name="remotehashes">List of strings. Each string represents hash of file that exists on remote device and calculated from files with the same index from RemoteFiles list.</param>
        public Syncronizer(StringList local, StringList remote, StringList localhashes, StringList remotehashes)
        {
            FilesDoesntExistOnLocal = GetDifferenceListBasedOnFirst(local, remote);
            FilesDoesntExistOnRemote = GetDifferenceListBasedOnFirst(remote, local);
            LocalFiles = local;
            RemoteFiles = remote;
            LocalHashes = localhashes;
            RemoteHashes = remotehashes;
        }

        //public StringList CompareHashes()
        //{
        //    StringList RetVal = new StringList();

        //    for (int i = 0; i < LocalHashes.Count; i++)
        //    {
        //        if (LocalHashes[i] != RemoteHashes[i])
        //        {
        //            RetVal.Add(LocalHashes[i]);
        //        }
        //    }

        //    return RetVal;
        //}

        /// <summary>
        /// Function that finds conflicts based on hash values both of remote and local files.
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