using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuikSync.LocalWorks.SetupWorks;

namespace QuikSync.LocalWorks.SessionWorks
{
    public static class SessionHandler
    {
        public static List<SessionData> SDList = new List<SessionData>();

        /// <summary>
        /// Function that checks if the sessions story file exists, and creates it if it's not.
        /// </summary>
        /// <returns>If exists - true, if it's not - false.</returns>
        public static bool CheckSessionsStoryExistance()
        {
            if (File.Exists("Sessions.txt"))
            {
                return true;
            }
            else
            {
                using (StreamWriter wr = new StreamWriter("Sessions.txt"))
                { }
                return false;
            }
        }

        /// <summary>
        /// Function that tries to initialize the list of SessionDatas by reading them from file.
        /// </summary>
        public static void TryReadSessionData()
        {
            using (StreamReader sr = new StreamReader("Sessions.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    SDList.Add(ParseRowDataForSessionData(sr.ReadLine()));
                }
            }
        }

        /// <summary>
        /// Function that saves SessionDatas to a file.
        /// </summary>
        public static void WriteAllSessionData()
        {
            using (StreamWriter sw = new StreamWriter("Sessions.txt"))
            {
                for (int i = 0; i < SDList.Count; i++)
                {
                    string actionMade;
                    if (SDList[i].LA != LaunchedAs.None)
                        actionMade = (SDList[i].LA == LaunchedAs.Joined ? "joined" : "hosted");
                    else
                        actionMade = "none";

                    sw.WriteLine(SDList[i].SessionName + "?" + SDList[i].Directory + "?" + SDList[i].Ip + "?" + SDList[i].Port + "?" + actionMade
                        + "?" + SDList[i].LastTimeUsed + "?" + SDList[i].SetupFileName);
                }
            }
        }

        /// <summary>
        /// Function that parse raw read data from sessions data file to get it into SessionData class object.
        /// </summary>
        /// <param name="raw">Raw string just read from file.</param>
        /// <returns>Initialized SessionData class object.</returns>
        private static SessionData ParseRowDataForSessionData(string raw)
        {
            // Raw string example:
            // SessionName?C:/Dir?192.168.0.0?10000?joined?06/01/2008 00:00?test.ini

            // Splitting by ? separator.
            string[] splittedTags = raw.Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries);

            return new SessionData(splittedTags[0], splittedTags[1], splittedTags[2], int.Parse(splittedTags[3]), splittedTags[4], splittedTags[5], splittedTags[6]);
        }

        /// <summary>
        /// Function that load specific SessionsData to DataGridView argument.
        /// </summary>
        /// <param name="dgv">>DataGridView that has to be displaying SessionsData.</param>
        /// <param name="sd">SessionsData that has to be displayed of DataGridView.</param>
        public static void DisplayThisSessionDataOnDataGridView(ref DataGridView dgv, SessionData sd)
        {
            dgv.Rows.Add(sd.SessionName, sd.Directory, sd.Ip + ":" + sd.Port.ToString(), sd.LastTimeUsed);
        }

        /// <summary>
        /// Function that load all the SessionsData from SDList to DataGridView argument.
        /// </summary>
        /// <param name="dgv">DataGridView that has to be displaying SessionsDatas.</param>
        public static void LoadSessionDataListToDataOnDataGridView(ref DataGridView dgv)
        {
            dgv.Rows.Clear();
            foreach (var sd in SDList)
            {
                dgv.Rows.Add(sd.SessionName, sd.Directory, sd.Ip + ":" + sd.Port.ToString(), sd.LastTimeUsed);
            }
        }

        /// <summary>
        /// Functio that clears up SessionData and Setup file with it HashDictionary.
        /// </summary>
        /// <param name="index">Index of the SessionData that has to be cleared out.</param>
        public static void RemoveSessionDataAndRelatedFiles(int index) 
        {
            if (index < SDList.Count)
            {
                SetupFileHandler.DeleteSetupFileAndItsHashDictionary(SDList[index].SetupFileName);
                SDList.RemoveAt(index);
            }
        }

        /// <summary>
        /// Function that return true of false based on existance of session recording.
        /// </summary>
        /// <param name="recordingName">Session name that has to be checked.</param>
        /// <returns>True if recording does exist, false if it's not.</returns>
        public static bool CheckRecordingExistance(string recordingName)
        {
            foreach (var item in SDList)
            {
                if (item.SessionName == recordingName)
                    return true;
            }
            return false;
        }
    }
}