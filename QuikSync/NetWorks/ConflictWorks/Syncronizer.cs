using System.Collections.Generic;
using System.Linq;
using QuikSync.LocalWorks.FileWorks;

namespace QuikSync.NetWorks.ConflictWorks
{
    /// <summary>
    /// Class made for solving file existance and hash conflicts.
    /// </summary>
    public class Syncronizer
    {
        public HashSet<FileDiffData> fdd = new HashSet<FileDiffData>();
        public List<SyncAction> saList = new List<SyncAction>();
        public HashSet<string> ProcessedRelativePathes = new HashSet<string>();

        public Syncronizer(List<FileData> Joined, List<FileData> Host)
        {
            // Computing files that could be conflicted to Host.
            for (int i = 0; i < Joined.Count; i++)
            {
                FileData fd = GetFileDataByRelativePath(Joined[i].relativePath, Host);

                // We remember all the files we processed so we dont process the same file twice.
                if (ProcessedRelativePathes.Contains(Joined[i].relativePath))
                {
                    continue;
                }
                else 
                {
                    ProcessedRelativePathes.Add(Joined[i].relativePath);
                }

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

                // We remember all the files we processed so we dont process the same file twice.
                if (ProcessedRelativePathes.Contains(Host[i].relativePath))
                {
                    continue;
                }
                else
                {
                    ProcessedRelativePathes.Add(Host[i].relativePath);
                }

                if (fd != null)
                {
                    // Hash conflict possible.
                    if (fd.hashMD5 != Host[i].hashMD5)
                    {
                        fdd.Add(new FileDiffData(Host[i].relativePath, fd.ts, Host[i].ts));
                    }
                }
                else
                {
                    fdd.Add(new FileDiffData(Host[i].relativePath, new TimeSize(-1, "-"), Host[i].ts));
                }
            }

            ConflictSolverForm conflictSolverForm = new ConflictSolverForm(fdd.ToList());
            conflictSolverForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            conflictSolverForm.ShowDialog();
            saList = conflictSolverForm.actions;
        }

        private FileData GetFileDataByRelativePath(string rel, List<FileData> l)
        {
            return l.Find(x => x.relativePath == rel);
        }
    }
}