using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TCPSharpFileSync.Forms;
using TCPSharpFileSync.LocalWorks.FileWorks;
using TCPSharpFileSync.LocalWorks.SessionWorks;
using TCPSharpFileSync.LocalWorks.SetupWorks;
using TCPSharpFileSync.NetWorks;

namespace TCPSharpFileSync
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

        int selectedIndex;

        TCPSettings currentTcpSettings;

        public Form1()
        {
            InitializeComponent();
            InitializeUIHandler();

            // Checking if all the needed folders does exist.
            FolderHandler.InitializeNeededDirectories();

            if (SessionHandler.CheckSessionsStoryExistance())
            {
                SessionHandler.TryReadSessionData();
                SessionHandler.LoadSessionDataListToDataOnDataGridView(ref dataGridView1);
            }

            // Initialization of the TCPSetting being used for work.
            // "//" used for skipping through the validation that were throwing out exceptions of out of index.
            //currentTcpSettings = new TCPSettings("//", "", 0, true, true, false, false, (int)timeOutNumericUpDown.Value);
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
            UIHandler.IncrementProgressBar = () => circularProgressBar.Invoke(new MethodInvoker(() => circularProgressBar.Value++));
            UIHandler.ResetProgressBar = () => circularProgressBar.Invoke(new MethodInvoker(() => circularProgressBar.Value = 0));
            UIHandler.ProgressBarVisibility = (bool vs) => circularProgressBar.Invoke(new MethodInvoker(() => 
            {
                circularProgressBar.Visible = vs;
            }));
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
            if (nsf.ShowDialog() == DialogResult.OK)
            {
                SessionHandler.DisplayThisSessionDataOnDataGridView(ref dataGridView1, nsf.SD);
                SessionHandler.SDList.Add(nsf.SD);
                SetupFileHandler.WriteTCPSettingToFile("Setups\\" + nsf.SD.SessionName + ".ini", nsf.SD.SessionName + ".HaDI", new TCPSettings(nsf.SD, 100000));
                SessionHandler.WriteAllSessionData();
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

        private void HostBtn_Click(object sender, EventArgs e)
        {
            SessionHandler.SDList[selectedIndex].LastTimeUsed = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            SessionHandler.SDList[selectedIndex].LA = LaunchedAs.Host;
            UIHandler.ToggleProgressBarVisibility();
            s = new Host(currentTcpSettings);
        }

        private void JoinBtn_Click(object sender, EventArgs e)
        {
            SessionHandler.SDList[selectedIndex].LastTimeUsed = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            SessionHandler.SDList[selectedIndex].LA = LaunchedAs.Joined;
            UIHandler.ToggleProgressBarVisibility();
            c = new Joined(currentTcpSettings);
            // Starting syncronization as a background thread so it does not freeze the main form.
            Thread InstanceCaller = new Thread(new ThreadStart(c.Syncronize));
            InstanceCaller.IsBackground = true;
            // Start the thread.
            InstanceCaller.Start();
        }

        private void removeSelectedBtn_Click(object sender, EventArgs e)
        {
            // Not effective. Has to be reworked.
            SessionHandler.RemoveSessionDataAndRelatedFiles(selectedIndex);
            SessionHandler.LoadSessionDataListToDataOnDataGridView(ref dataGridView1);
            SessionHandler.WriteAllSessionData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Filer f = new Filer(currentTcpSettings.directoryPath, currentTcpSettings.hashDictionaryName);
        }
    }
}