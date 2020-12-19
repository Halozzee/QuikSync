using System.Collections.Generic;
using System.Linq;
using TCPSharpFileSync.LocalWorks.FileWorks;

namespace TCPSharpFileSync.NetWorks.ConflictWorks
{
    /// <summary>
    /// Class made for solving file existance and hash conflicts.
    /// </summary>
    public class Syncronizer
    {
        public HashSet<FileDiffData> fdd = new HashSet<FileDiffData>();
        public List<SyncAction> saList = new List<SyncAction>();

        public Syncronizer(List<FileData> Joined, List<FileData> Host) 
        {
            // Computing files that could be conflicted to Host.
            for (int i = 0; i < Joined.Count; i++)
            {
                FileData fd = GetFileDataByRelativePath(Joined[i].relativePath, Host);

                if (fd != null)
                {
                    // Hash conflict possible.
                    if (fd.hashMD5 != Joined[i].hashMD5)
                    {
                        fdd.Add(new FileDiffData(Joined[i].relativePath, Joined[i].ts, fd.ts));
                    }
                }
                else
                {
                    fdd.Add(new FileDiffData(Joined[i].relativePath, Joined[i].ts, new TimeSize(-1, "-")));
                }
            }

            // Computing files that could be conflicted to Join.
            for (int i = 0; i < Host.Count; i++)
            {
                FileData fd = GetFileDataByRelativePath(Host[i].relativePath, Joined);

                if (fd != null)
                {
                    // Hash conflict possible.
                    if (fd.hashMD5 != Host[i].hashMD5)
                    {
                        fdd.Add(new FileDiffData(Host[i].relativePath, Host[i].ts, fd.ts));
                    }
                }
                else
                {
                    fdd.Add(new FileDiffData(Host[i].relativePath, Host[i].ts, new TimeSize(-1, "-")));
                }
            }

            ConflictSolverForm conflictSolverForm = new ConflictSolverForm(fdd.ToList());
            conflictSolverForm.ShowDialog();
            saList = conflictSolverForm.actions;
        }

        private FileData GetFileDataByRelativePath(string rel, List<FileData> l) 
        {
            return l.Find(x => x.relativePath == rel);
        }
    }
}