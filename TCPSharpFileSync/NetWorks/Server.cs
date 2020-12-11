using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using WatsonTcp;

namespace TCPSharpFileSync
{
    public class Server : TCPFileWorker
    {
        WatsonTcpServer servH;
        // list clients
        List<string> clients;
        string DownloadFileTo;
        public Server(TCPSettings c)
        {
            ts = c;
            ts.ip = GetLocalIPAddress();
            msBeforeTimeOut = ts.timeouter;
            servH = new WatsonTcpServer(ts.ip, ts.port);
            servH.Events.ClientConnected += ClientConnected;
            servH.Events.ClientDisconnected += ClientDisconnected;
            servH.Events.StreamReceived += StreamReceived;
            servH.Callbacks.SyncRequestReceived += SyncSolver;

            servH.Keepalive.EnableTcpKeepAlives = true;
            servH.Keepalive.TcpKeepAliveInterval = 10;
            servH.Keepalive.TcpKeepAliveTime = 10;
            servH.Keepalive.TcpKeepAliveRetryCount = 10;

            FileScan(ts.pathToSyncDir);
            servH.Start();
            LogHandler.WriteLog($"Server started!", Color.Green);
        }

        //======Client requests======
        //!qq = Exit
        //!getHash *relative path to file* = get file hash to client
        //!getFile *relative path to file* = upload file to client
        //!catchFile *relative path to file* = get file from client
        //!exists *relative path to file* = check if file exists on servers side and then answer for client
        //!getFileList = get all relative pathes and send it to client
        //!sessiondone = updates servers Filer and Hasher
        //!rm *relative path to file* = remove file on server side
        //!getFileInfo *relative path to file* = get file info from server

        //======Server Respones======
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
            else if (cmd.Contains("!getHashes "))
            {
                cmd = cmd.Replace("!getHashes ", "");
                string hashes = GetAllAskedHashesToSeparatedString(cmd);
                sr = new SyncResponse(arg, GetBytesFromString(hashes));
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

                DownloadFileTo = filer.rootPath + cmd.Replace("!catchFile ", "");
                sr = new SyncResponse(arg, GetBytesFromString("!dd"));
                servH.Events.StreamReceived += StreamReceived;
            }
            else if (cmd.Contains("!exists "))
            {
                cmd = cmd.Replace("!exists ", "");
                if (filer.CheckFileExistanceFromRelative(cmd))
                    sr = new SyncResponse(arg, GetBytesFromString("!Yes"));
                else
                    sr = new SyncResponse(arg, GetBytesFromString("!No"));
            }
            else if (cmd.Contains("!getFileList"))
            {
                cmd = cmd.Replace("!getFileList", "");
                sr = SendFileList(arg);
            }
            else if (cmd.Contains("!sessiondone"))
            {
                cmd = cmd.Replace("!sessiondone", "");
                filer = new Filer(filer.rootPath);
                hasher.UpdateHasherBasedOnUpdatedFiler(filer);
                sr = new SyncResponse(arg, GetBytesFromString("!dd"));
                LogHandler.WriteLog("Session done!", Color.Green);
            }
            else if (cmd.Contains("!rm "))
            {
                cmd = cmd.Replace("!rm ", "");
                File.Delete(filer.GetLocalFromRelative(cmd));
                sr = new SyncResponse(arg, GetBytesFromString("!dd"));
            }
            else if (cmd.Contains("!getFileInfo "))
            {
                cmd = cmd.Replace("!getFileInfo ", "");
                FileInfo fi = filer.GetLocalFileInfoFromRelative(cmd);
                sr = new SyncResponse(arg, GetBytesFromString($"{fi.Length}\n{fi.LastAccessTime.ToString()}"));
            }
            return sr;
        }

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

            LogHandler.WriteLog($"Downloaded {DownloadFileTo.Replace(filer.rootPath, "")}", Color.Green);

            DownloadFileTo = "";
            servH.Events.StreamReceived -= StreamReceived;
            gettingFile = false;
        }

        private string GetAllAskedHashesToSeparatedString(string requested)
        {
            string response = "";
            List<string> toBeProcessed = requested.Split(new string[] { "?" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> recievedHashes = new List<string>();

            foreach (var item in toBeProcessed)
            {
                if (File.Exists(filer.rootPath + item))
                {
                    recievedHashes.Add(hasher.GetHashMD5FromLocal(filer.rootPath + item));
                }
                else
                    recievedHashes.Add("-");
            }

            response = string.Join("?", recievedHashes.ToArray());

            return response;
        }

        public void UploadFile(string IpPost, string rel)
        {
            string loc = filer.GetLocalFromRelative(rel);

            using (FileStream fs = new FileStream(loc, FileMode.Open))
            {
                servH.Send(IpPost, fs.Length, fs);
            }
            LogHandler.WriteLog($"Uploaded {rel}", Color.Green);
        }
        private void ClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            clients = servH.ListClients().ToList();
            LogHandler.WriteLog(e.IpPort + $" disconnected! (Reason: {e.Reason})", Color.Red);
        }

        private void ClientConnected(object sender, ClientConnectedEventArgs e)
        {
            clients = servH.ListClients().ToList();
            LogHandler.WriteLog($"{e.IpPort} connected!", Color.Green);
        }

        private SyncResponse SendFileList(SyncRequest arg)
        {
            var fileList = filer.GetRelativeFiles();
            string sendString = "";

            for (int i = 0; i < fileList.Count; i++)
            {
                sendString += fileList[i];

                if (i != fileList.Count - 1)
                    sendString += "\n";
            }

            byte[] b = GetBytesFromString(sendString);

            return new SyncResponse(arg, b);
        }
    }
}