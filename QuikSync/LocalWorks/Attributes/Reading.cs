using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikSync.LocalWorks.Attributes
{
    /// <summary>
    /// Attribute made for easy reading data from ini file.
    /// </summary>
    public class Reading : Attribute
    {
        public string Section;
    }
}
