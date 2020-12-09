using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;

namespace TCPSharpFileSync
{
    public class Hasher
    {
        List<string> localPathes;
        public List<string> hashesMD5 { get; private set; }
        public Hasher(List<string> lp)
        {
            localPathes = lp;

            hashesMD5 = new List<string>();
            ComputeAllHashesBasedOnLocalPathes();
        }

        public void ComputeAllHashesBasedOnLocalPathes() 
        {
            LogHandler.WriteLog("Calculating hashes...");
            LogHandler.SetProgressBarMaxValue(localPathes.Count);
            foreach (var item in localPathes)
            {
                hashesMD5.Add(CalculateMD5(item));
                LogHandler.IncrementProgressBarValue();
            }
            LogHandler.ResetProgressBarValue();
        }

        static string CalculateMD5(string filename)
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
        public string GetHashMD5FromLocal(string notCutted) 
        {
            return hashesMD5[localPathes.FindIndex(x => x == notCutted)];
        }

        public void UpdateHasherBasedOnUpdatedFiler(Filer f) 
        {
            List<string> updatedLocs = f.GetLocalFiles();

            //for (int i = 0; i < updatedLocs.Count; i++)
            //{
            //    int oldIndex = localPathes.FindIndex(x => updatedLocs[i] == x);
            //    int newIndex = updatedLocs.FindIndex(x => updatedLocs[i] == x);

            //    if (newIndex == -1)
            //    {
            //        if (oldIndex != -1)
            //        {
            //            hashesMD5.RemoveAt(oldIndex);
            //        }
            //    }
            //    else
            //    {
            //        if (oldIndex == -1)
            //            hashesMD5.Insert(newIndex, f.GetRelativeFromLocal(updatedLocs[newIndex]));

            //        if (oldIndex == newIndex)
            //            continue;
            //    }
            //}

            hashesMD5 = new List<string>();
            ComputeAllHashesBasedOnLocalPathes();
        }
    }
}