using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPSharpFileSync
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Server object that used for containing everything if the program runs as server.
        /// </summary>
        Server s;
        /// <summary>
        /// Client object that used for containing everything if the program runs as client.
        /// </summary>
        Client c;

        public Form1()
        {
            InitializeComponent();
            InitializeLogHandler();

            // Initialization of the TCPSetting being used for work.
            // "//" used for skipping through the validation that were throwing out exceptions of out of index.
            currentTcpSettings = new TCPSettings("//", "", 0, true, true, false, false, (int)timeOutNumericUpDown.Value);
        }

        /// <summary>
        /// Procedure that initialize LogHandler static object.
        /// </summary>
        private void InitializeLogHandler()
        {
            LogHandler.RichTextBoxWriteDelegate = (string s, Color color) => logRichTextBox.BeginInvoke(new MethodInvoker(() =>
            {
                logRichTextBox.SelectionStart = logRichTextBox.TextLength;
                logRichTextBox.SelectionLength = 0;

                logRichTextBox.SelectionColor = color;
                logRichTextBox.AppendText(s + "\n");
                logRichTextBox.SelectionColor = logRichTextBox.ForeColor;
            }));
            LogHandler.SetProgressBarMax = (int max) => progressBar.Invoke(new MethodInvoker(() => progressBar.Maximum = max));
            LogHandler.IncrementProgressBar = () => progressBar.Invoke(new MethodInvoker(() => progressBar.Value++));
            LogHandler.ResetProgressBar = () => progressBar.Invoke(new MethodInvoker(() => progressBar.Value = 0));
        }

        private void syncBtn_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void WriteInRichBox(string s, Color color) 
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        TCPSettings currentTcpSettings;

        private void syncBtn_Click_1(object sender, EventArgs e)
        {
            // If starting as server.
            if (asServerRadioButton.Checked)
            {
                ipTextBox.Text = TCPFileWorker.GetLocalIPAddress();
                s = new Server(currentTcpSettings);
            }
            // If starting as client.
            else
            {
                c = new Client(currentTcpSettings);

                // Starting syncronization as a background thread so it does not freeze the main form.
                Thread InstanceCaller = new Thread(new ThreadStart(c.Syncronize));
                InstanceCaller.IsBackground = true;
                // Start the thread.
                InstanceCaller.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void asClientRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Showing every client input field for starting program as client.
            actionsGroupBox.Visible         = true;
            ifndefOnClientCheckBox.Visible  = true;
            ifndefOnServerCheckBox.Visible  = true;
        }

        private void asServerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Hiding every client input field for starting program as server.
            actionsGroupBox.Visible         = false;
            ifndefOnClientCheckBox.Visible  = false;
            ifndefOnServerCheckBox.Visible  = false;
        }

        private void localDirTextBox_TextChanged(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = localDirTextBox.Text;
            currentTcpSettings.directoryPath = localDirTextBox.Text;
        }

        private void chooseDirBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                localDirTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void setupFromFilebtn_Click(object sender, EventArgs e)
        {
            // If the dialog goes with OK result.
            if (setupFileOpenDialog.ShowDialog() == DialogResult.OK)
            {
                // General - is a section for information for both server and client.
                try
                {
                    // Getting what are we going to read data for server or client.
                    DealingWithDataOf goFor = asServerRadioButton.Checked ? DealingWithDataOf.Server : DealingWithDataOf.Client;

                    currentTcpSettings = IniParserWrapper.ReadTCPSettingsFromFile(setupFileOpenDialog.FileName, DealingWithDataOf.Client);

                    portTextBox.Text                    = currentTcpSettings.port.ToString();
                    localDirTextBox.Text                = currentTcpSettings.directoryPath;
                    timeOutNumericUpDown.Value          = currentTcpSettings.msTimeout;

                    // If we are dealing with client on this launch - then read some extra data.
                    if (goFor == DealingWithDataOf.Client)
                    {
                        ipTextBox.Text                  = currentTcpSettings.ip;
                        doUploadCheckBox.Checked        = currentTcpSettings.doUpload;
                        doDownloadCheckBox.Checked      = currentTcpSettings.doDownload;
                        ifndefOnServerCheckBox.Checked  = currentTcpSettings.removeIfNotOnServer;
                        ifndefOnClientCheckBox.Checked  = currentTcpSettings.removeIfNotOnClient;
                    }
                }
                catch (Exception ex)
                {
                    // If the file isnt loading for some reason - show the exception text in messagebox.
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Saving setup file
            if (MessageBox.Show("Saving setup", "Do you want this setup to be saved?", MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                if (saveSetupFileDialog.ShowDialog() == DialogResult.OK)
                {
                    IniParserWrapper.WriteTCPSettingToFile(saveSetupFileDialog.FileName, currentTcpSettings);
                }
            }
        }

        private void ipTextBox_TextChanged(object sender, EventArgs e)
        {
            currentTcpSettings.ip = ipTextBox.Text;
        }

        private void portTextBox_TextChanged(object sender, EventArgs e)
        {
            currentTcpSettings.port = int.Parse(portTextBox.Text);
        }

        private void ifndefOnServerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            currentTcpSettings.removeIfNotOnServer = ifndefOnServerCheckBox.Checked;
        }

        private void ifndefOnClientCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            currentTcpSettings.removeIfNotOnClient = ifndefOnClientCheckBox.Checked;
        }

        private void timeOutNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            currentTcpSettings.msTimeout = (int)timeOutNumericUpDown.Value;
        }

        private void portTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Setting Digit-only mode
            e.Handled = !(Char.IsDigit(e.KeyChar));
        }

        private void doUploadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            currentTcpSettings.doUpload = doUploadCheckBox.Checked;
        }

        private void doDownloadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            currentTcpSettings.doDownload = doDownloadCheckBox.Checked;
        }

		private void Form1_Load(object sender, EventArgs e)
		{

		}
	}
}