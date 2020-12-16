using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPSharpFileSync
{
    /// <summary>
    /// Class that represents all the works with handling creating directories.
    /// </summary>
    public static class FolderHandler
    {
        public static void InitializeNeededDirectories() 
        {
            // Checking and creating if not exists the directory that contains HashDictionaries.
            if (!Directory.Exists("HashDictionaries"))
                Directory.CreateDirectory("HashDictionaries");

            // Checking and creating if not exists the directory that contains Setup Files.
            if (!Directory.Exists("Setups"))
                Directory.CreateDirectory("Setups");
        }
    }
}
