using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using WatsonTcp;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace TCPSharpFileSync
{
    public class Client : TCPFileWorker
    {
        /// <summary>
        /// WatsonTcpClient class for wrap TCP works.
        /// </summary>
        WatsonTcpClient clientH;
        /// <summary>
        /// Variable that represents a Local path that's the current file is downloading to.
        /// </summary>
        string DownloadFileTo;

        /// <summary>
        /// List of string. Each string represents a Relative path to a file existing on server.
        /// </summary>
        List<string> filesGotFromServer;
        /// <summary>
        /// List of string. Each string represents a hash of file the same index that each of filesGotFromServer has.
        /// </summary>
        List<string> hashesGotFromServer;

        /// <summary>
        /// Constructor that initializes Client object based on given TCPSettings.
        /// </summary>
        /// <param name="c">TCPSettings for client work.</param>
        public Client(TCPSettings c)
        {
            ts = c;
            msBeforeTimeOut = ts.msTimeout;
            clientH = new WatsonTcpClient(ts.ip, ts.port);
            clientH.Events.ServerConnected += ServerConnected;
            clientH.Events.ServerDisconnected += ServerDisconnected;
            clientH.Events.StreamReceived += StreamReceived;
            //clientH.Events.MessageReceived += MessageReceived;
            //clientH.Callbacks.SyncRequestReceived = SyncRequestReceived;
            FileScan(ts.directoryPath);
            clientH.Connect();
        }

        private void ServerDisconnected(object sender, EventArgs e)
        {
            LogHandler.WriteLog($"Disconnected from server!", Color.Red);
        }

        private void ServerConnected(object sender, EventArgs e)
        {
            LogHandler.WriteLog($"Connected to server!", Color.Green);
        }

        /// <summary>
        /// Event handler for receiving stream from client. Currently made for downloading files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void StreamReceived(object sender, StreamReceivedFromServerEventArgs args)
        {
            gettingFile = true;

            long bytesRemaining = args.ContentLength;
            int bytesRead = 0;
            byte[] buffer = new byte[bufferSize];

            Directory.CreateDirectory(Path.GetDirectoryName(DownloadFileTo));

            using (FileStream fs = new FileStream(DownloadFileTo, FileMode.CreateNew))
            {
                while (bytesRemaining > 0)
                {
                    bytesRead = args.DataStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        fs.Write(buffer, 0, bytesRead);
                        bytesRemaining -= bytesRead;
                    }
                }
            }

            DownloadFileTo = "";
            clientH.Events.StreamReceived -= StreamReceived;

            gettingFile = false;
        }

        /// <summary>
        /// Function that uploads file to a client based on Relative path and IP:Port that it has to upload to.
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

            LogHandler.WriteLog($"Uploaded {rel}", Color.Green);
        }

        /// <summary>
        /// Function that send a request to a server for downloading file.
        /// </summary>
        /// <param name="rel">Relative path to download from server.</param>
        public void DownloadFile(string rel)
        {
            // Infinite cycle to prevent downloading several files in the same time.
            while (gettingFile && clientH.Connected)
            {

            }

            DownloadFileTo = Filed.RootPath + rel;
            SyncResponse sr = SendMessage("!getFile " + rel);
            clientH.Events.StreamReceived += StreamReceived;
            LogHandler.WriteLog($"Downloaded {rel}", Color.Green);
        }

        /// <summary>
        /// Function that send a request to a server for getting list of all the existing files on server.
        /// </summary>
        public void GetServersFileListOfRelatieves()
        {
            SyncResponse sr = SendMessage("!getFileList");
            filesGotFromServer = GetStringFromBytes(sr.Data).Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < filesGotFromServer.Count; i++)
            {
                filesGotFromServer[i].Replace("?", "");
            }
        }

        /// <summary>
        /// Function that send a request to a server for checking if file does exist or not.
        /// </summary>
        /// <param name="rel">Relative path to the file to check existance of.</param>
        /// <returns>true if does exist, false if it's not.</returns>
        public bool AskServerForFileExistance(string rel)
        {
            SyncResponse sr = SendMessage($"!exists {rel}");
            return GetStringFromBytes(sr.Data) == "!Yes";
        }

        // HAS TO BE REWORKED!
        /// <summary>
        /// Function that send a request to a server for getting list of all hashes of all the existing files on server based on asked Relative pathes.
        /// </summary>
        /// <returns>List of all hashes of all the existing files on server based on asked Relative pathes.</returns>
        public List<string> GetAllExistingOnLocalHashesFromServer()
        {
            List<string> diffList = new List<string>();
            List<string> locFiles = Filed.RelativeFilePathes;

            hashesGotFromServer = new List<string>();

            //1 billion chars is max so, you have to track these values
            // ? - is restricted char in file naming on windows so use it as separator for requests
            string askStringRequest = string.Join("?", locFiles.ToArray());

            SyncResponse sr = SendMessage("!getHashes " + askStringRequest);

            hashesGotFromServer = GetStringFromBytes(sr.Data).Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<int> indx = Enumerable.Range(0, hashesGotFromServer.Count).Where(i => hashesGotFromServer[i] == "-").ToList();

            for (int i = 0; i < indx.Count; i++)
            {
                diffList.Add(locFiles[indx[i]]);
            }

            return diffList;
        }

        /// <summary>
        /// Function for solving the conflicted files.
        /// </summary>
        /// <param name="conflicted">Indexes of Relative pathes of local devices that conflicted with remote ones.</param>
        public void SolveConflicted(List<int> conflicted)
        {
            List<string> rels = Filed.RelativeFilePathes;
            List<string> fiLoc = new List<string>();
            List<string> fiServer = new List<string>();
            List<string> fiNames = new List<string>();

            for (int i = 0; i < conflicted.Count; i++)
            {
                string confFile = rels[conflicted[i]];
                fiNames.Add(confFile);

                FileInfo locfi = new FileInfo(Filed.GetLocalFromRelative(confFile));

                SyncResponse sr = SendMessage("!getFileInfo " + confFile);

                string fileInfoFromServer = GetStringFromBytes(sr.Data);
                string fileInfoFromLocal = locfi.Length.ToString() + "\n" + locfi.LastAccessTime.ToString();

                fiLoc.Add(fileInfoFromLocal);
                fiServer.Add(fileInfoFromServer);
            }

            if (fiNames.Count > 0)
            {
                ConflictSolverForm csf = new ConflictSolverForm(fiLoc, fiServer, fiNames);
                csf.ShowDialog();

                for (int i = 0; i < csf.getFromServer.Count; i++)
                {
                    File.Delete(Filed.GetLocalFromRelative(csf.getFromServer[i]));
                    DownloadFile(csf.getFromServer[i]);
                }

                for (int i = 0; i < csf.uploadToServer.Count; i++)
                {
                    DeleteOnServer(csf.uploadToServer[i]);
                    UploadFile(csf.uploadToServer[i]);
                }

                for (int i = 0; i < csf.removeEverywhere.Count; i++)
                {
                    DeleteOnServer(csf.removeEverywhere[i]);
                    File.Delete(Filed.RootPath + csf.removeEverywhere[i]);
                }
            }
        }

        /// <summary>
        /// Function that send request to server for deleting the file based on Relative path.
        /// </summary>
        /// <param name="rel">Relative path for the file to be deleted of server.</param>
        public void DeleteOnServer(string rel)
        {
            SyncResponse sr = SendMessage($"!rm {rel}");
        }

        /// <summary>
        /// Function that sends a request to a server and get answer.
        /// </summary>
        /// <param name="msg">The message that has to be sent.</param>
        /// <returns>Server resonse.</returns>
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
            GetServersFileListOfRelatieves();
            LogHandler.WriteLog($"Recieved server file list!", Color.Green);
            List<string> doesntExist = GetAllExistingOnLocalHashesFromServer();
            LogHandler.WriteLog($"Recieved server hash list!", Color.Green);
            Syncronizer sync = new Syncronizer(Filed.RelativeFilePathes, filesGotFromServer, Hashed.HashesMD5, hashesGotFromServer);

            HashSet<string> hs = new HashSet<string>(doesntExist);

            foreach (var item in sync.FilesDoesntExistOnRemote)
            {
                hs.Add(item);
            }

            List<int> conflicted = sync.FindConflicts();
            SolveConflicted(conflicted);

            if (ts.doDownload && !ts.removeIfNotOnClient)
            {
                foreach (var item in sync.FilesDoesntExistOnLocal)
                {
                    DownloadFile(item);
                }
            }

            if (ts.removeIfNotOnClient)
            {
                foreach (var item in sync.FilesDoesntExistOnLocal)
                {
                    DeleteOnServer(item);
                }
            }

            List<string> ls = hs.ToList();

            if (ts.doUpload && !ts.removeIfNotOnServer)
            {
                foreach (var item in ls)
                {
                    UploadFile(item);
                }
            }

            if (ts.removeIfNotOnServer)
            {
                foreach (var item in ls)
                {
                    File.Delete(Filed.GetLocalFromRelative(item));
                }
            }

            SyncResponse sr = SendMessage("!sessiondone");
            Filed = new Filer(Filed.RootPath);
            Hashed.UpdateHasherBasedOnUpdatedFiler(Filed);
        }
    }
}