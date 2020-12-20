using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using TCPSharpFileSync.LocalWorks.FileWorks;
using WatsonTcp;

namespace TCPSharpFileSync.NetWorks
{
    public class Host : TCPFileWorker
    {
        /// <summary>
        /// WatsonTcpServer class for wrap TCP works.
        /// </summary>
        WatsonTcpServer servH;
        /// <summary>
        /// List of all clients.
        /// </summary>
        List<string> clients;
        /// <summary>
        /// Variable that represents a Local path that's the current file is downloading to.
        /// </summary>
        string DownloadFileTo;

        /// <summary>
        /// Constructor that initializes Host object based on given TCPSettings.
        /// </summary>
        /// <param name="c">TCPSettings for Host work.</param>
        public Host(TCPSettings c)
        {
            ts = c;
            msBeforeTimeOut = ts.msTimeout;
            servH = new WatsonTcpServer(ts.ip, ts.port);
            servH.Events.ClientConnected += JoinedConnected;
            servH.Events.ClientDisconnected += JoinedDisconnected;
            servH.Events.StreamReceived += StreamReceived;
            servH.Callbacks.SyncRequestReceived += SyncSolver;

            servH.Keepalive.EnableTcpKeepAlives = true;
            servH.Keepalive.TcpKeepAliveInterval = 10;
            servH.Keepalive.TcpKeepAliveTime = msBeforeTimeOut;
            servH.Keepalive.TcpKeepAliveRetryCount = 10;

            UIHandler.ToggleProgressBarVisibility();
            FileScan(ts.directoryPath);
            servH.Start();
            UIHandler.WriteLog($"Host started!", Color.Green);
            UIHandler.ToggleProgressBarVisibility();
        }

        /// <summary>
        /// Event handler for SyncRequest being received by Host.
        /// </summary>
        /// <param name="arg">The SyncRequest that recieved.</param>
        /// <returns></returns>
        //======Joined requests======
        //!qq = Exit
        //!getFile *relative path to file* = upload file to Joined
        //!catchFile *relative path to file* = get file from Joined
        //!exists *relative path to file* = check if file exists on servers side and then answer for Joined
        //!getFileDataList = get all relative pathes and hashes to it and send it to Joined
        //!sessiondone = updates servers Filer and Hasher
        //!rm *relative path to file* = remove file on Host side
        //!getFileInfo *relative path to file* = get file info from Host

        //======Host Respones======
        //!dd = ready for next operation
        //!Yes = answer for file existance if it does exist
        //!No = answer for file existance if it does not exist
        private SyncResponse SyncSolver(SyncRequest arg)
        {
            servH.Events.StreamReceived -= StreamReceived;
            string cmd = GetStringFromBytes(arg.Data);
            SyncResponse sr = new SyncResponse(arg, GetBytesFromString("NotRecognized"));
            if (cmd.Contains("!qq"))
            {
                servH.DisconnectClients();
                servH.Stop();
                servH.Dispose();
            }
            else if (cmd.Contains("!getFile "))
            {
                cmd = cmd.Replace("!getFile ", "");
                UploadFile(arg.IpPort, cmd);
                sr = new SyncResponse(arg, GetBytesFromString("!dd"));
            }
            else if (cmd.Contains("!catchFile "))
            {
                while (gettingFile)
                {

                }

                DownloadFileTo = Filed.RootPath + cmd.Replace("!catchFile ", "");
                sr = new SyncResponse(arg, GetBytesFromString("!dd"));
                servH.Events.StreamReceived += StreamReceived;
            }
            else if (cmd.Contains("!exists "))
            {
                cmd = cmd.Replace("!exists ", "");
                if (Filed.CheckFileExistanceFromRelative(cmd))
                    sr = new SyncResponse(arg, GetBytesFromString("!Yes"));
                else
                    sr = new SyncResponse(arg, GetBytesFromString("!No"));
            }
            else if (cmd.Contains("!getFileDataList"))
            {
                cmd = cmd.Replace("!getFileDataList", "");
                sr = new SyncResponse(arg, GetBytesFromString(GetFileList()));
            }
            else if (cmd.Contains("!sessiondone"))
            {
                cmd = cmd.Replace("!sessiondone", "");
                Filed.RecomputeHashesBasedOnModifiedStatus();
                FilerHashesIO.WriteHashesToFile(ts.hashDictionaryName, Filed);
                sr = new SyncResponse(arg, GetBytesFromString("!dd"));
                UIHandler.WriteLog("Session done!", Color.Green);
            }
            else if (cmd.Contains("!rm "))
            {
                cmd = cmd.Replace("!rm ", "");
                if (Filed.GetLocalFromRelative(cmd) != "?FileNotFound?")
                {
                    File.Delete(Filed.GetLocalFromRelative(cmd));
                    Filed.ChangeFileModifiedStatusByRelativePath(cmd, FileModifiedStatus.Deleted);
                }
                sr = new SyncResponse(arg, GetBytesFromString("!dd"));
            }
            else if (cmd.Contains("!getFileInfo "))
            {
                cmd = cmd.Replace("!getFileInfo ", "");
                FileInfo fi = Filed.GetLocalFileInfoFromRelative(cmd);
                sr = new SyncResponse(arg, GetBytesFromString($"{fi.Length}\n{fi.LastAccessTime.ToString()}"));
            }
            return sr;
        }

        /// <summary>
        /// Event handler for receiving stream from Joined. Currently made for downloading files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void StreamReceived(object sender, StreamReceivedFromClientEventArgs args)
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

            Filed.FilesData.Add(new FileData(Filed.RootPath, DownloadFileTo));
            Filed.ChangeFileModifiedStatusByRelativePath(DownloadFileTo.Replace(Filed.RootPath, ""), FileModifiedStatus.Changed);
            UIHandler.WriteLog($"Downloaded {DownloadFileTo.Replace(Filed.RootPath, "")}", Color.Green);

            DownloadFileTo = "";
            servH.Events.StreamReceived -= StreamReceived;
            gettingFile = false;
        }

        /// <summary>
        /// Function made for collecting all requested by Joined hashed and made them into a string with delimiter.
        /// </summary>
        /// <param name="requested">String that contains Relative pathes to get hashes of.</param>
        /// <returns>String with delimited full of hashes that were asked.</returns>
        private string GetAllAskedHashesToSeparatedString(string requested)
        {
            string response = "";
            List<string> toBeProcessed = requested.Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> recievedHashes = new List<string>();

            foreach (var item in toBeProcessed)
            {
                int index = Filed.FilesData.FindIndex(x => x.relativePath == item);
                if (index != -1)
                {
                    recievedHashes.Add(Filed.FilesData[index].hashMD5);
                }
                else
                    recievedHashes.Add("-");
            }

            response = string.Join("?", recievedHashes.ToArray());

            return response;
        }

        /// <summary>
        /// Function that uploads file to a Joined based on Relative path and IP:Port that it has to upload to.
        /// </summary>
        /// <param name="IpPost">IP:Port that it has to upload to.</param>
        /// <param name="rel"> Relative path of uploading file.</param>
        public void UploadFile(string IpPost, string rel)
        {
            string loc = Filed.GetLocalFromRelative(rel);

            using (FileStream fs = new FileStream(loc, FileMode.Open))
            {
                servH.Send(IpPost, fs.Length, fs);
            }
            UIHandler.WriteLog($"Uploaded {rel}", Color.Green);
        }
        private void JoinedDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            clients = servH.ListClients().ToList();
            UIHandler.WriteLog(e.IpPort + $" disconnected! (Reason: {e.Reason})", Color.Red);
        }

        private void JoinedConnected(object sender, ClientConnectedEventArgs e)
        {
            clients = servH.ListClients().ToList();
            UIHandler.WriteLog($"{e.IpPort} connected!", Color.Green);
        }

        /// <summary>
        /// Function that makes a string full of Relative pathes of existing files on this device. 
        /// </summary>
        /// <returns>String full of Relative pathes of existing files on this device.</returns>
        private string GetFileList()
        {
            var fileList = Filed.FilesData;
            string sendString = "";

            for (int i = 0; i < fileList.Count; i++)
            {
                FileInfo fi = new FileInfo(fileList[i].localPath);
                sendString += fileList[i].relativePath + "?" + fileList[i].hashMD5 + "?" + fi.Length + "?" + fi.LastWriteTime.ToString("MM/dd/yyyy HH:mm");

                if (i != fileList.Count - 1)
                    sendString += "\n";
            }

            return sendString;
        }
    }
}