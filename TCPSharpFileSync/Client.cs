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
        WatsonTcpClient clientH;
        string DownloadFileTo;

        List<string> filesGotFromServer;
        List<string> hashesGotFromServer;
        public Client(TCPSettings c)
        {
            ts = c;
            msBeforeTimeOut = ts.timeouter;
            clientH = new WatsonTcpClient(ts.ip, ts.port);
            clientH.Events.ServerConnected += ServerConnected;
            clientH.Events.ServerDisconnected += ServerDisconnected;
            clientH.Events.StreamReceived += StreamReceived;
            //clientH.Events.MessageReceived += MessageReceived;
            //clientH.Callbacks.SyncRequestReceived = SyncRequestReceived;
            FileScan(ts.pathToSyncDir);
            clientH.Connect();
        }

        //private void MessageReceived(object sender, MessageReceivedFromServerEventArgs e)
        //{
        //    string recieved = GetStringFromBytes(e.Data);
        //    LogHandler.WriteLog($"Server: {recieved}");
        //}

        private void ServerDisconnected(object sender, EventArgs e)
        {
            LogHandler.WriteLog($"Disconnected from server!", Color.Red);
        }

        private void ServerConnected(object sender, EventArgs e)
        {
            LogHandler.WriteLog($"Connected to server!", Color.Green);
        }

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

        public void UploadFile(string rel)
        {
            string loc = filer.GetLocalFromRelative(rel);

            SyncResponse sr = SendMessage("!catchFile " + rel);

            using (FileStream fs = new FileStream(loc, FileMode.Open))
            {
                clientH.Send(fs.Length, fs);
            }

            LogHandler.WriteLog($"Uploaded {rel}", Color.Green);
        }

        public void DownloadFile(string rel)
        {
            while (gettingFile && clientH.Connected)
            {

            }

            DownloadFileTo = filer.rootPath + rel;
            SyncResponse sr = SendMessage("!getFile " + rel);
            clientH.Events.StreamReceived += StreamReceived;
            LogHandler.WriteLog($"Downloaded {rel}", Color.Green);
        }
        public void GetServersFileListOfRelatieves()
        {
            SyncResponse sr = SendMessage("!getFileList");
            filesGotFromServer = GetStringFromBytes(sr.Data).Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = 0; i < filesGotFromServer.Count; i++)
            {
                filesGotFromServer[i].Replace("?", "");
            }
        }

        public bool AskServerForFileExistance(string rel)
        {
            SyncResponse sr = SendMessage($"!exists {rel}");
            return GetStringFromBytes(sr.Data) == "!Yes";
        }

        public List<string> GetAllExistingOnLocalHashesFromServer()
        {
            List<string> diffList = new List<string>();
            List<string> locFiles = filer.GetRelativeFiles();

            hashesGotFromServer = new List<string>();

            //foreach (var item in locFiles)
            //{
            //    if (filesGotFromServer.FindIndex(x => x == item) == -1)
            //    {
            //        SyncResponse sr = SendMessage("!getHash " + item);
            //        hashesGotFromServer.Add(GetStringFromBytes(sr.Data));
            //    }
            //    else
            //    { 
            //        if (AskServerForFileExistance(item))
            //        {
            //            SyncResponse sr = SendMessage("!getHash " + item);
            //            hashesGotFromServer.Add(GetStringFromBytes(sr.Data));
            //        }
            //        else
            //        {
            //            hashesGotFromServer.Add("-");
            //            diffList.Add(item);
            //        } 
            //    }
            //}

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

        public void SolveConflicted(List<int> conflicted)
        {
            List<string> rels = filer.GetRelativeFiles();
            List<string> fiLoc = new List<string>();
            List<string> fiServer = new List<string>();
            List<string> fiNames = new List<string>();

            for (int i = 0; i < conflicted.Count; i++)
            {
                string confFile = rels[conflicted[i]];
                fiNames.Add(confFile);

                FileInfo locfi = new FileInfo(filer.GetLocalFromRelative(confFile));

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
                    File.Delete(filer.GetLocalFromRelative(csf.getFromServer[i]));
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
                    File.Delete(filer.rootPath + csf.removeEverywhere[i]);
                }
            }
        }

        public void DeleteOnServer(string rel)
        {
            SyncResponse sr = SendMessage($"!rm {rel}");
        }

        public SyncResponse SendMessage(string msg)
        {
            byte[] b = Encoding.Convert(Encoding.Default, Encoding.BigEndianUnicode, Encoding.Default.GetBytes(msg));
            return clientH.SendAndWait(msBeforeTimeOut, b);
        }

        public void Syncronize()
        {
            GetServersFileListOfRelatieves();
            LogHandler.WriteLog($"Recieved server file list!", Color.Green);
            List<string> doesntExist = GetAllExistingOnLocalHashesFromServer();
            LogHandler.WriteLog($"Recieved server hash list!", Color.Green);
            Syncronizer sync = new Syncronizer(filer.GetRelativeFiles(), filesGotFromServer, hasher.hashesMD5, hashesGotFromServer);

            HashSet<string> hs = new HashSet<string>(doesntExist);

            foreach (var item in sync.FilesDoesntExistInSecond)
            {
                hs.Add(item);
            }

            List<int> conflicted = sync.FindConflicts();
            SolveConflicted(conflicted);

            if (ts.doDownload && !ts.rmIfnDefOnClient)
            {
                foreach (var item in sync.FilesDoesntExistInFirst)
                {
                    DownloadFile(item);
                }
            }

            if (ts.rmIfnDefOnClient)
            {
                foreach (var item in sync.FilesDoesntExistInFirst)
                {
                    DeleteOnServer(item);
                }
            }

            List<string> ls = hs.ToList();

            if (ts.doUpload && !ts.rmIfnDefOnServer)
            {
                foreach (var item in ls)
                {
                    UploadFile(item);
                }
            }

            if (ts.rmIfnDefOnServer)
            {
                foreach (var item in ls)
                {
                    File.Delete(filer.GetLocalFromRelative(item));
                }
            }

            SyncResponse sr = SendMessage("!sessiondone");
            filer = new Filer(filer.rootPath);
            hasher.UpdateHasherBasedOnUpdatedFiler(filer);
        }
    }
}