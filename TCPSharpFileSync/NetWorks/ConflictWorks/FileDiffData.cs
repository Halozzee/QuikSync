using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPSharpFileSync.NetWorks.ConflictWorks
{
    public enum SyncAction 
    {
        GetFromHost,
        GetFromJoined,
        Skip,
        GetNewClone,
        Delete,
        NotChosen
    }
    /// <summary>
    /// Structure that represents data about file.
    /// </summary>
    public struct TimeSize
    {
        /// <summary>
        /// Files byte size.
        /// </summary>
        public long byteSize;
        /// <summary>
        /// Time when file was last modified.
        /// </summary>
        public string lastTime;

        public TimeSize(long bs, string lt) 
        {
            byteSize = bs;
            lastTime = lt;
        }
    }

    /// <summary>
    /// Class that represents file difference info about Host and Local fileinfo.
    /// </summary>
    public class FileDiffData
    {
        /// <summary>
        /// Files relative path.
        /// </summary>
        public string FileRelativePath { get; private set; }
        /// <summary>
        /// Files Local fileinfo.
        /// </summary>
        public TimeSize Joined { get; private set; }
        /// <summary>
        /// Files Host fileinfo.
        /// </summary>
        public TimeSize Host { get; private set; }

        public FileDiffData(string rel, TimeSize j, TimeSize h) 
        {
            FileRelativePath = rel;
            Joined = j;
            Host = h;
        }
    }
}
