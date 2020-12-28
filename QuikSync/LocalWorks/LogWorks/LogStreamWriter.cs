using LogScripter.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogScripter
{
    public class LogStreamWriter
    {
        StreamWriter sw;
        LogCondition lc;

        public LogStreamWriter(string path, LogCondition LC)
        {
            sw = new StreamWriter(path);
            lc = LC;
            Write("LogStreamWritter started by constructor!", "OwnWillMessage");
        }

        public void Close() 
        {
            Write("LogStreamWritter shutdown by close calling!", "OwnWillMessage");
            sw.Close();
            sw.Dispose();
        }

        public void Write(string s, params string[] additionalContext) 
        {
            string message = "";

            message += "[" + DateTime.Now + "]";

            if (additionalContext.Length > 0)
            {
                message += String.Join("][", additionalContext).Insert(0, "[");
                message = message.Insert(message.Length, "]");
            }

            message += ": ";

            if (s != null)
            {
                message += s;
            }
            else
            {
                message += "*null*";
            }

            sw.WriteLine(message);
            sw.Flush();
        }

        public void Write(Exception ex, params string[] additionalContext)
        {
            Write(ex.Message + (ex.StackTrace != null ? " | " : "") + ex.StackTrace, additionalContext);
        }

        public void Write<T>(T cl, params string[] additionalContext) 
        {
            Type type = cl.GetType();
            string message = "";

            FieldInfo[] fi = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            message += "*"+type.FullName+"*";

            if (cl != null)
            {
                message += "\n";
                for (int i = 0; i < fi.Length; i++)
                {
                    var attr = (LogFriendly[])fi[i].GetCustomAttributes(typeof(LogFriendly), false);

                    switch (lc)
                    {
                        case LogCondition.LogFriendlyAttribute:
                            if (attr.Length == 0)
                                continue;
                            break;
                        case LogCondition.None:
                            break;
                        default:
                            break;
                    }

                    object val = fi[i].GetValue(cl);
                    message += $"({fi[i].FieldType}){fi[i].Name}: {(val == null ? "null" : val)}" + " ";

                    if (i != fi.Length - 1)
                        message += " | ";
                }
            }
            else 
            {
                message += ": null";
            }
            Write(message, additionalContext);
        }
    }
}
