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
        Server s;
        Client c;

        public Form1()
        {
            InitializeComponent();
            InitializeLogHandler();
        }

        private void InitializeLogHandler()
        {
            LogHandler.LogDelegate = (string s, Color color) => logRichTextBox.BeginInvoke(new MethodInvoker(() =>
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

        private void syncBtn_Click_1(object sender, EventArgs e)
        {
            if (asServerRadioButton.Checked)
            {
                TCPSettings tcp = new TCPSettings(localDirTextBox.Text, "", int.Parse(portTextBox.Text), (int)timeOutNumericUpDown.Value);
                s = new Server(tcp);
                ipTextBox.Text = TCPFileWorker.GetLocalIPAddress();
            }
            else
            {
                TCPSettings tcp = new TCPSettings(localDirTextBox.Text, ipTextBox.Text, int.Parse(portTextBox.Text), 
                    doDownloadCheckBox.Checked, doUploadCheckBox.Checked, ifndefOnClientCheckBox.Checked, ifndefOnServerCheckBox.Checked, (int)timeOutNumericUpDown.Value);
                c = new Client(tcp);

                Thread InstanceCaller = new Thread( new ThreadStart(c.Syncronize));
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
            actionsGroupBox.Visible         = true;
            ifndefOnClientCheckBox.Visible  = true;
            ifndefOnServerCheckBox.Visible  = true;
            timeOutNumericUpDown.Visible    = true;
            label1.Visible                  = true;
        }

        private void asServerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            actionsGroupBox.Visible         = false;
            ifndefOnClientCheckBox.Visible  = false;
            ifndefOnServerCheckBox.Visible  = false;
            timeOutNumericUpDown.Visible    = false;
            label1.Visible                  = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void localDirTextBox_TextChanged(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = localDirTextBox.Text;
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
            // If the dialog goes with OK result
            if (setupFileOpenDialog.ShowDialog() == DialogResult.OK)
            {
                // General - is a section for information for both server and client
                try
                {
                    // Getting what are we going to read data for server or client
                    string goFor = asServerRadioButton.Checked ? "Server" : "Client";

                    // Initializing parser
                    var parser = new FileIniDataParser();
                    IniData data = parser.ReadFile(setupFileOpenDialog.FileName);

                    // Reading path to directory that needs to be syncronized
                    localDirTextBox.Text = data["General"]["directoryPath"];

                    // Reading IP and Port data
                    portTextBox.Text = data["General"]["port"];

                    // If we are dealing with client on this launch - then read some extra data
                    if (goFor == "Client")
                    {
                        ipTextBox.Text = data[goFor]["ip"];
                        doUploadCheckBox.Checked = data[goFor]["upload"] == "Yes";
                        doDownloadCheckBox.Checked = data[goFor]["download"] == "Yes";
                        timeOutNumericUpDown.Value = Int32.Parse(data[goFor]["msTimeout"]);
                        ifndefOnServerCheckBox.Checked = data[goFor]["removeIfNotOnServer"] == "Yes";
                        ifndefOnClientCheckBox.Checked = data[goFor]["removeIfNotOnClient"] == "Yes";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}