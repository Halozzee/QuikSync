using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPSharpFileSync
{
    public enum DealingWithDataOf
    {
        Server,
        Client
    }

    /// <summary>
    /// Attribute made for easy saving object to ini file.
    /// </summary>
    public class Saving : Attribute
    {
        public string Section;
    }
    /// <summary>
    /// Attribute made for easy reading data from ini file.
    /// </summary>
    public class Reading : Attribute
    {
        public string Section;
    }

    public static class IniParserWrapper
    {
        /// <summary>
        /// Function that returns IniData template.
        /// </summary>
        /// <returns>IniData template with x on key values.</returns>
        public static IniData GetSectionTemplate() 
        {
            IniData id = new IniData();

            // Initializing sections.
            id.Sections.AddSection("General");
            id.Sections.AddSection("Client");
            id.Sections.AddSection("Server");

            return id;
        }

        /// <summary>
        /// Function that forms a TCPSettings object based on read setup file.
        /// </summary>
        /// <param name="setupFile">Path to a setup file.</param>
        /// <param name="ldt">Answers on a question loading server or client data.</param>
        /// <returns></returns>
        public static TCPSettings ReadTCPSettingsFromFile(string setupFile, DealingWithDataOf ldt) 
        {
            // Returnable value.
            TCPSettings tcp = new TCPSettings();

            // General - is a section for information for both server and client.
            try
            {
                // Getting what are we going to read data for server or client.
                string goFor = (ldt == DealingWithDataOf.Server ? "Server" : "Client");

                // Initializing parser.
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile(setupFile);

                // If we are dealing with client on this launch - then read some extra data.
                if (goFor == "Client")
                {
                    ExtractValuesAvoidingSomeSections(tcp, data, new List<string>() { "Server" });
                }
                else
                {
                    ExtractValuesAvoidingSomeSections(tcp, data, new List<string>() { "Client" });
                }
            }
            catch (Exception ex)
            {
                // If the file isnt loading for some reason - show the exception text in messagebox.
                MessageBox.Show(ex.Message);
            }

            return tcp;
        }

        /// <summary>
        /// Function that saves a TCPSettings object to the location new setup file path.
        /// </summary>
        /// <param name="newSetupFile">Path to a new setup file TCPSetting will be save to.</param>
        /// <param name="tcp">TCPSetting that has to be saved.</param>
        /// <returns></returns>
        public static void WriteTCPSettingToFile(string newSetupFile, TCPSettings tcp) 
        {
            IniData id = GetSectionTemplate();

            // Field data of the class that has to be filled up.
            var fields = tcp.GetType().GetFields();

            foreach (var item in fields)
            {
                // Getting if the attribute does exist on the field.
                var attr = (Reading[])item.GetCustomAttributes(typeof(Reading), false);

                // Going while several Reading sections is going. 
                foreach (var attrVal in attr)
                {
                    // Getting field type to make right cast.
                    var ft = item.FieldType;

                    // Casting to get the right value.
                    // The data in file has to be made right for this to work!
                    switch (ft.Name)
                    {
                        case "String":
                            id.Sections[attrVal.Section].AddKey(item.Name, (string)item.GetValue(tcp));
                            break;
                        case "Int32":
                            id.Sections[attrVal.Section].AddKey(item.Name, ((int)item.GetValue(tcp)).ToString());
                            break;
                        case "Boolean":
                            id.Sections[attrVal.Section].AddKey(item.Name, ((bool)item.GetValue(tcp) ? "Yes" : "No"));
                            break;
                        default:
                            break;
                    }
                }
            }

            FileIniDataParser fidp = new FileIniDataParser();
            fidp.SaveFile(newSetupFile, id);
        }

        /// <summary>
        /// Function that reads data from ini file based on existing Reading attribute on a field and that it's in not restricted section.
        /// </summary>
        /// <param name="tcp">TCPSettings the data is reading to.</param>
        /// <param name="data">Data that read from the ini file.</param>
        /// <param name="sectionsToAvoid">Sections that reading data from has to be avoided.</param>
        private static void ExtractValuesAvoidingSomeSections(TCPSettings tcp, IniData data, List<string> sectionsToAvoid)
        {
            // Field data of the class that has to be filled up.
            var fields = tcp.GetType().GetFields();

            foreach (var item in fields)
            {
                // Getting if the attribute does exist on the field.
                var attr = (Reading[])item.GetCustomAttributes(typeof(Reading), false);

                // Going while several Reading sections is going. 
                foreach (var attrVal in attr)
                {
                    // If not in avoiding list => reading.
                    if (sectionsToAvoid.FindIndex(x => x == attrVal.Section) == -1)
                    {
                        // Getting field type to make right cast.
                        var ft = item.FieldType;

                        // Casting to get the right value.
                        // The data in file has to be made right for this to work!
                        switch (ft.Name)
                        {
                            case "String":
                                item.SetValue(tcp, (string)data[attrVal.Section][item.Name]);
                                break;
                            case "Int32":
                                item.SetValue(tcp, Int32.Parse(data[attrVal.Section][item.Name]));
                                break;
                            case "Boolean":
                                item.SetValue(tcp, (data[attrVal.Section][item.Name]) == "Yes");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}