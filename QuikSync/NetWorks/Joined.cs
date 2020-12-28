using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using QuikSync.LocalWorks.FileWorks;
using QuikSync.NetWorks.ConflictWorks;
using WatsonTcp;

namespace QuikSync.NetWorks
{
    public class Joined : TCPFileWorker
    {
        /// <summary>
        /// WatsonTcpClient class for wrap TCP works.
        /// </summary>
        WatsonTcpClient clientH;
        /// <summary>
        /// Variable that represents a Local path that's the current file is downloading to.
        /// </summary>
        string DownloadFileTo;

        List<FileData> FDGotFromServer;

        /// <summary>
        /// Constructor that initializes Joined object based on given TCPSettings.
        /// </summary>
        /// <param name="c">TCPSettings for Joined work.</param>
        public Joined(TCPSettings c)
        {
            ts = c;
            msBeforeTimeOut = ts.msTimeout;
            clientH = new WatsonTcpClient(ts.ip, ts.port);
            clientH.Events.ServerConnected += JoinedConnected;
            clientH.Events.ServerDisconnected += JoinedDisconnected;
            clientH.Events.StreamReceived += StreamReceived;
            //clientH.Events.MessageReceived += MessageReceived;
            //clientH.Callbacks.SyncRequestReceived = SyncRequestReceived;

            UIHandler.StopColorfulBarAnimation();
        }

        public void Connect()
        {
            UIHandler.PlayColorfulBarAnimation(true);
            FileScan(ts.directoryPath);
            clientH.Connect();
        }

        public void Disconnect()
        {
            UIHandler.StopColorfulBarAnimation();
            clientH.Disconnect();
        }

        private void JoinedDisconnected(object sender, EventArgs e)
        {
            UIHandler.WriteLog($"Disconnected from Host!", Color.Red);
        }
        private void JoinedConnected(object sender, EventArgs e)
        {
            UIHandler.WriteLog($"Connected to Host!", Color.Green);
        }

        /// <summary>
        /// Event handler for receiving stream from Joined. Currently made for downloading files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void StreamReceived(object sender, StreamReceivedFromServerEventArgs args)
        {
            UIHandler.WriteLog($"Downloading {DownloadFileTo.Replace(Filed.RootPath, "")}...");
            gettingFile = true;

            UIHandler.ResetProgressBar();

            long bytesRemaining = args.ContentLength;
            int bytesRead = 0;
            byte[] buffer = new byte[bufferSize];

            UIHandler.SetProgressBarMaxValue((int)bytesRemaining);

            Directory.CreateDirectory(Path.GetDirectoryName(DownloadFileTo));

            using (FileStream fs = new FileStream(DownloadFileTo, FileMode.CreateNew))
            {
                while (bytesRemaining > 0)
                {
                    bytesRead = args.DataStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        fs.Write(buffer, 0, bytesRead);
                        UIHandler.IncrementProgressBarValue(bytesRead);
                        bytesRemaining -= bytesRead;
                    }
                }
            }

            DownloadFileTo = "";
            clientH.Events.StreamReceived -= StreamReceived;

            gettingFile = false;
        }

        /// <summary>
        /// Function that uploads file to a Joined based on Relative path and IP:Port that it has to upload to.
        /// </summary>
        /// <param name="IpPost">IP:Port that it has to upload to.</param>
        /// <param name="rel"> Relative path of uploading file.</param>
        public void UploadFile(string rel)
        {
            string loc = Filed.GetLocalFromRelative(rel);

            SyncResponse sr = SendMessage("!catchFile " + rel);

            using (FileStream fs = new FileStream(loc, FileMode.Open))
            {
                clientH.Send(fs.Length, fs);
            }

            UIHandler.WriteLog($"Uploaded {rel}", Color.Green);
        }

        /// <summary>
        /// Function that send a request to a Host for downloading file.
        /// </summary>
        /// <param name="rel">Relative path to download from Host.</param>
        public void DownloadFile(string rel)
        {
            // Infinite cycle to prevent downloading several files in the same time.
            while (gettingFile && clientH.Connected)
            {

            }

            DownloadFileTo = Filed.RootPath + rel;
            SyncResponse sr = SendMessage("!getFile " + rel);
            clientH.Events.StreamReceived += StreamReceived;
            UIHandler.WriteLog($"Downloaded {rel}", Color.Green);
        }

        /// <summary>
        /// Function that send a request to a Host for downloading file to a specific location.
        /// </summary>
        /// <param name="rel">Relative path to download from Host.</param>
        public void DownloadFile(string rel, string relLocation)
        {
            // Infinite cycle to prevent downloading several files in the same time.
            while (gettingFile && clientH.Connected)
            {

            }

            DownloadFileTo = Filed.RootPath + relLocation;
            SyncResponse sr = SendMessage("!getFile " + rel);
            clientH.Events.StreamReceived += StreamReceived;
            UIHandler.WriteLog($"Downloaded {rel}", Color.Green);
        }

        /// <summary>
        /// Function that send a request to a Host for getting list of all the existing files on Host.
        /// </summary>
        public void GetHostFileDataList()
        {
            SyncResponse sr = SendMessage("!getFileDataList");
            List<string> filesGotFromServer = GetStringFromBytes(sr.Data).Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            FDGotFromServer = new List<FileData>();

            for (int i = 0; i < filesGotFromServer.Count; i++)
            {
                string[] splitted = filesGotFromServer[i].Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries);
                FDGotFromServer.Add(new FileData(splitted[0], splitted[1], long.Parse(splitted[2]), splitted[3]));
            }
        }

        /// <summary>
        /// Function that send a request to a Host for checking if file does exist or not.
        /// </summary>
        /// <param name="rel">Relative path to the file to check existance of.</param>
        /// <returns>true if does exist, false if it's not.</returns>
        public bool AskHostForFileExistance(string rel)
        {
            SyncResponse sr = SendMessage($"!exists {rel}");
            return GetStringFromBytes(sr.Data) == "!Yes";
        }

        /// <summary>
        /// Function that send request to Host for deleting the file based on Relative path.
        /// </summary>
        /// <param name="rel">Relative path for the file to be deleted of Host.</param>
        public void DeleteOnHost(string rel)
        {
            SyncResponse sr = SendMessage($"!rm {rel}");
        }

        /// <summary>
        /// Function that sends a request to a Host and get answer.
        /// </summary>
        /// <param name="msg">The message that has to be sent.</param>
        /// <returns>Host resonse.</returns>
        public SyncResponse SendMessage(string msg)
        {
            byte[] b = GetBytesFromString(msg);
            return clientH.SendAndWait(msBeforeTimeOut, b);
        }

        /// <summary>
        /// The main syncronization procedure.
        /// </summary>
        public void Syncronize()
        {
            UIHandler.PlayColorfulBarAnimation(true);
            GetHostFileDataList();
            UIHandler.WriteLog($"Recieved Host FileData list!", Color.Green);
            Syncronizer sync = new Syncronizer(Filed.FilesData, FDGotFromServer);

            var fddList = sync.fdd.ToList();

            for (int i = 0; i < sync.saList.Count; i++)
            {
                // Switch that makes stuff specified on what was chosen.
                switch (sync.saList[i])
                {
                    case SyncAction.GetFromHost:
                        if(File.Exists(Filed.MakeLocalPathFromRelative(fddList[i].FileRelativePath)))
                            File.Delete(Filed.MakeLocalPathFromRelative(fddList[i].FileRelativePath));
                        DownloadFile(fddList[i].FileRelativePath);
                        Filed.ChangeFileModifiedStatusByRelativePath(fddList[i].FileRelativePath, FileModifiedStatus.Changed);
                        break;
                    case SyncAction.GetFromJoined:
                        DeleteOnHost(fddList[i].FileRelativePath);
                        UploadFile(fddList[i].FileRelativePath);
                        break;
                    case SyncAction.Skip:
                        break;
                    case SyncAction.GetNewClone:
                        string tempFileName = Filed.RootPath + fddList[i].FileRelativePath;
                        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(tempFileName);
                        string extenstion = Path.GetExtension(tempFileName);
                        int cntr = 1;
                        while (File.Exists(Filed.RootPath + fileNameWithoutExtension + $"(Cloned {cntr})" + extenstion))
                        {
                            cntr++;
                        }
                        DownloadFile(fddList[i].FileRelativePath, fileNameWithoutExtension + $"(Cloned {cntr})" + extenstion);
                        Filed.FilesData.Add(new FileData(Filed.RootPath, Filed.MakeLocalPathFromRelative(fileNameWithoutExtension + $"(Cloned {cntr})" + extenstion)));
                        Filed.ChangeFileModifiedStatusByRelativePath(fileNameWithoutExtension + $"(Cloned {cntr})" + extenstion, FileModifiedStatus.Changed);
                        break;
                    case SyncAction.Delete:
                        if (File.Exists(Filed.MakeLocalPathFromRelative(fddList[i].FileRelativePath)))
                            File.Delete(Filed.MakeLocalPathFromRelative(fddList[i].FileRelativePath));
                        DeleteOnHost(fddList[i].FileRelativePath);
                        Filed.ChangeFileModifiedStatusByRelativePath(fddList[i].FileRelativePath, FileModifiedStatus.Deleted);
                        break;
                    case SyncAction.NotChosen:
                        break;
                    default:
                        break;
                }
            }

            SyncResponse sr = SendMessage("!sessiondone");
            Filed.RecomputeHashesBasedOnModifiedStatus();
            FilerHashesIO.WriteHashesToFile(ts.hashDictionaryName, Filed);
            UIHandler.WriteLog("Session done!");
            UIHandler.ToggleProgressBarVisibility(false);
            UIHandler.StopColorfulBarAnimation();
        }
    }
}