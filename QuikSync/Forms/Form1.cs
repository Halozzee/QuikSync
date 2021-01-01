using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using QuikSync.Forms;
using QuikSync.LocalWorks.FileWorks;
using QuikSync.LocalWorks.LogWorks;
using QuikSync.LocalWorks.SessionWorks;
using QuikSync.LocalWorks.SetupWorks;
using QuikSync.NetWorks;
using WinFormAnimation;

namespace QuikSync
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Host object that used for containing everything if the program runs as Host.
        /// </summary>
        Host s;
        /// <summary>
        /// Joined object that used for containing everything if the program runs as Joined.
        /// </summary>
        Joined c;
        /// <summary>
        /// Index of the selected row in datagridview
        /// </summary>
        int selectedIndex;

        /// <summary>
        /// Current TCP settings that were made for current session.
        /// </summary>
        TCPSettings currentTcpSettings;

        public Form1()
        {
            SplashScreen ss = new SplashScreen();
            ss.Show();
            ss.MaxValue = 5;
            ss.SetText("Making components...");
            InitializeComponent();
            ss.IncrementValue(1);
            Thread.Sleep(1000);
            ss.SetText("Initializing UI works...");
            InitializeUIHandler();
            ss.IncrementValue(1);
            Thread.Sleep(1000);

            ss.SetText("Looking for needed directories...");
            // Checking if all the needed folders does exist.
            FolderHandler.InitializeNeededDirectories();
            ss.IncrementValue(1);
            Thread.Sleep(1000);

            ss.SetText("Looking for session story...");
            if (SessionHandler.CheckSessionsStoryExistance())
            {
                ss.MaxValue = 6;
                ss.SetText("Loading session story...");
                SessionHandler.TryReadSessionData();
                SessionHandler.LoadSessionDataListToDataOnDataGridView(ref dataGridView1);
                ss.IncrementValue(1);
                Thread.Sleep(1000);
            }
            ss.IncrementValue(1);
            Thread.Sleep(1000);

            ss.SetText("Changing styles...");
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45,45,48);
            dataGridView1.EnableHeadersVisualStyles = false;
            ss.IncrementValue(1);
            Thread.Sleep(1000);

            // Initialization of the TCPSetting being used for work.
            // "//" used for skipping through the validation that were throwing out exceptions of out of index.
            //currentTcpSettings = new TCPSettings("//", "", 0, true, true, false, false, (int)timeOutNumericUpDown.Value);

            ss.SetText("Done!");
            Thread.Sleep(1000);
            ss.Close();
        }

        /// <summary>
        /// Procedure that initialize LogHandler static object.
        /// </summary>
        private void InitializeUIHandler()
        {
            UIHandler.ActionLabelSetText = (string s, Color color) => actionLabel.BeginInvoke(new MethodInvoker(() =>
            {
                actionLabel.Text = s;
            }));
            UIHandler.SetProgressBarMax = (int max) => circularProgressBar.Invoke(new MethodInvoker(() =>
            {
                circularProgressBar.Maximum = max;
                circularProgressBar.Value = 0;
            }));
            UIHandler.IncrementProgressBar = (int val) => circularProgressBar.Invoke(new MethodInvoker(() => circularProgressBar.Value+= val));
            UIHandler.ResetProgressBar = () => circularProgressBar.Invoke(new MethodInvoker(() => circularProgressBar.Value = 0));
            UIHandler.ProgressBarVisibility = (bool vs) => circularProgressBar.Invoke(new MethodInvoker(() => 
            {
                circularProgressBar.Visible = vs;
            }));

            UIHandler.ColorfulBar = colorfulBar;

            List<Path3D> pathes = new List<Path3D>();
            pathes.Add(new Path3D(Color.FromArgb(93, 245, 215).ToFloat3D(), Color.FromArgb(107, 163, 246).ToFloat3D(), 1000, 0, AnimationFunctions.CubicEaseIn));
            pathes.Add(new Path3D(Color.FromArgb(107, 163, 246).ToFloat3D(), Color.FromArgb(133, 251, 96).ToFloat3D(), 1000, 0, AnimationFunctions.CubicEaseIn));
            pathes.Add(new Path3D(Color.FromArgb(133, 251, 96).ToFloat3D(), Color.FromArgb(93, 245, 215).ToFloat3D(), 1000, 0, AnimationFunctions.CubicEaseIn));

            UIHandler.colorfulBarAnimation = new Animator3D(pathes.ToArray(), FPSLimiterKnownValues.LimitOneHundred);
        }

        //private void syncBtn_Click(object sender, EventArgs e)
        //{

        //}

        //private void radioButton1_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        //public void WriteInRichBox(string s, Color color)
        //{

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //}

        //TCPSettings currentTcpSettings;

        //private void syncBtn_Click_1(object sender, EventArgs e)
        //{
        //    // If starting as Host.
        //    if (asServerRadioButton.Checked)
        //    {
        //        ipTextBox.Text = TCPFileWorker.GetLocalIPAddress();
        //        s = new Host(currentTcpSettings);
        //    }
        //    // If starting as Joined.
        //    else
        //    {
        //        c = new Joined(currentTcpSettings);

        //        // Starting syncronization as a background thread so it does not freeze the main form.
        //        Thread InstanceCaller = new Thread(new ThreadStart(c.Syncronize));
        //        InstanceCaller.IsBackground = true;
        //        // Start the thread.
        //        InstanceCaller.Start();
        //    }
        //}

        //private void button2_Click(object sender, EventArgs e) 
        //{
        //}

        //private void textBox2_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void asClientRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    // Showing every Joined input field for starting program as Joined.
        //    actionsGroupBox.Visible = true;
        //    ifndefOnClientCheckBox.Visible = true;
        //    ifndefOnServerCheckBox.Visible = true;
        //}

        //private void asServerRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    // Hiding every Joined input field for starting program as Host.
        //    actionsGroupBox.Visible = false;
        //    ifndefOnClientCheckBox.Visible = false;
        //    ifndefOnServerCheckBox.Visible = false;
        //}

        //private void localDirTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    folderBrowserDialog.SelectedPath = localDirTextBox.Text;
        //    currentTcpSettings.directoryPath = localDirTextBox.Text;
        //}

        //private void chooseDirBtn_Click(object sender, EventArgs e)
        //{
        //    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        localDirTextBox.Text = folderBrowserDialog.SelectedPath;
        //    }
        //}

        //private void setupFromFilebtn_Click(object sender, EventArgs e)
        //{
        //    // If the dialog goes with OK result.
        //    if (setupFileOpenDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        // General - is a section for information for both Host and Joined.
        //        try
        //        {
        //            // Getting what are we going to read data for Host or Joined.
        //            DealingWithDataOf goFor = asServerRadioButton.Checked ? DealingWithDataOf.Host : DealingWithDataOf.Joined;

        //            currentTcpSettings = SetupFileHandler.ReadTCPSettingsFromFile(setupFileOpenDialog.FileName, DealingWithDataOf.Joined);

        //            portTextBox.Text = currentTcpSettings.port.ToString();
        //            localDirTextBox.Text = currentTcpSettings.directoryPath;
        //            timeOutNumericUpDown.Value = currentTcpSettings.msTimeout;

        //            // If we are dealing with Joined on this launch - then read some extra data.
        //            if (goFor == DealingWithDataOf.Joined)
        //            {
        //                ipTextBox.Text = currentTcpSettings.ip;
        //                doUploadCheckBox.Checked = currentTcpSettings.doUpload;
        //                doDownloadCheckBox.Checked = currentTcpSettings.doDownload;
        //                ifndefOnServerCheckBox.Checked = currentTcpSettings.removeIfNotOnServer;
        //                ifndefOnClientCheckBox.Checked = currentTcpSettings.removeIfNotOnClient;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // If the file isnt loading for some reason - show the exception text in messagebox.
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        //private void ipTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    currentTcpSettings.ip = ipTextBox.Text;
        //}

        //private void portTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    currentTcpSettings.port = int.Parse(portTextBox.Text);
        //}

        //private void ifndefOnServerCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    currentTcpSettings.removeIfNotOnServer = ifndefOnServerCheckBox.Checked;
        //}

        //private void ifndefOnClientCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    currentTcpSettings.removeIfNotOnClient = ifndefOnClientCheckBox.Checked;
        //}

        //private void timeOutNumericUpDown_ValueChanged(object sender, EventArgs e)
        //{
        //    currentTcpSettings.msTimeout = (int)timeOutNumericUpDown.Value;
        //}

        //private void portTextBox_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    // Setting Digit-only mode
        //    e.Handled = !(Char.IsDigit(e.KeyChar));
        //}

        //private void doUploadCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    currentTcpSettings.doUpload = doUploadCheckBox.Checked;
        //}

        //private void doDownloadCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    currentTcpSettings.doDownload = doDownloadCheckBox.Checked;
        //}

        //private void makeNewSetupBtn_Click(object sender, EventArgs e)
        //{
        //    SetupFileHandler.InitializeSetupToFile("Setups/s.ini", "test.HaDi");
        //}


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //// Saving setup file.
            //if (MessageBox.Show("Saving setup", "Do you want this setup to be saved?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    if (saveSetupFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        //SetupFileHandler.WriteTCPSettingToFile(saveSetupFileDialog.FileName, currentTcpSettings);
            //    }
            //}

            SessionHandler.WriteAllSessionData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void newSessionBtn_Click(object sender, EventArgs e)
        {
            NewSessionForm nsf = new NewSessionForm();
            nsf.StartPosition = FormStartPosition.CenterParent;
            if (nsf.ShowDialog() == DialogResult.OK)
            {
                SessionHandler.SDList.Add(nsf.SD);
                SetupFileHandler.WriteTCPSettingToFile("Setups\\" + nsf.SD.SessionName + ".ini", nsf.SD.SessionName + ".HaDI", new TCPSettings(nsf.SD, 100000));
                SessionHandler.WriteAllSessionData();
                SessionHandler.DisplayThisSessionDataOnDataGridView(ref dataGridView1, nsf.SD);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (SessionHandler.SDList.Count > selectedIndex)
            {
                selectedIndex = e.RowIndex;
                currentTcpSettings = SetupFileHandler.ReadTCPSettingsFromFile(SessionHandler.SDList[e.RowIndex].SetupFileName);
            }
        }

        // Flag for starting\closing Host
        bool Hosted = false;

        private void HostBtn_Click(object sender, EventArgs e)
        {
            if (!Hosted)
            {
                try
                {
                    SessionHandler.SDList[selectedIndex].LastTimeUsed = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                    SessionHandler.SDList[selectedIndex].LA = LaunchedAs.Host;
                    LogHandler.ChangeSession(SessionHandler.SDList[selectedIndex].SessionName);
                    UIHandler.ToggleProgressBarVisibility(true);
                    Hosted = true;
                    HostBtn.Text = "Close";
                    s = new Host(currentTcpSettings);
                    s.Start();
                    LogHandler.LCW.Write("Host started", "Host", "Start");
                }
                catch (Exception ex)
                {
                    LogHandler.LCW.Write(ex, "Host", "Start");
                    throw ex;
                }
            }
            else 
            {
                try
                {
                    Hosted = false;
                    s.Stop();
                    HostBtn.Text = "Host";
                    LogHandler.LCW.Write("Host Stopped", "Host", "Stop");
                }
                catch (Exception ex)
                {
                    LogHandler.LCW.Write(ex, "Host", "Stop");
                    throw ex;
                }
            }
        }

        //========== future feature
        bool Joined = false;
        Thread InstanceCaller;
        private void JoinBtn_Click(object sender, EventArgs e)
        {
            //if (!Joined)
            //{

            //========== future feature

            try
            {
                SessionHandler.SDList[selectedIndex].LastTimeUsed = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                SessionHandler.SDList[selectedIndex].LA = LaunchedAs.Joined;
                LogHandler.ChangeSession(SessionHandler.SDList[selectedIndex].SessionName);
                UIHandler.ToggleProgressBarVisibility(true);
                Joined = true;
                c = new Joined(currentTcpSettings);
                c.Connect();
                LogHandler.LCW.Write("Joined connected", "Joined", "Start");
                // Starting syncronization as a background thread so it does not freeze the main form.
                InstanceCaller = new Thread(new ThreadStart(c.Syncronize));
                InstanceCaller.IsBackground = true;
                // Start the thread.
                InstanceCaller.Start();
            }
            catch (Exception ex)
            {
                LogHandler.LCW.Write(ex, "Joined", "Start");
                throw ex;
            }

            //}
            //else 
            //{
            //    Joined = false;
            //    InstanceCaller.Abort();
            //    c.Disconnect();
            //}
        }

        private void removeSelectedBtn_Click(object sender, EventArgs e)
        {
            // Not effective. Has to be reworked.
            SessionHandler.RemoveSessionDataAndRelatedFiles(selectedIndex);
            SessionHandler.LoadSessionDataListToDataOnDataGridView(ref dataGridView1);
            SessionHandler.WriteAllSessionData();
        }

        #region Magic code for dragging window wihout boarder!

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #endregion

        private void closeWindowBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(38, 38, 42), 2), this.DisplayRectangle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SplashScreen ss = new SplashScreen();
            ss.ShowDialog();
        }
    }
}