using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPSharpFileSync.LocalWorks.Attributes
{
    /// <summary>
    /// Attribute made for easy saving object to ini file.
    /// </summary>
    public class Saving : Attribute
    {
        public string Section;
    }
}
