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
                TCPSettings tcp = new TCPSettings(localDirTextBox.Text, "", int.Parse(textBox1.Text), (int)timeOutNumericUpDown.Value);
                s = new Server(tcp);
                textBox2.Text = Server.GetLocalIPAddress();
            }
            else
            {
                TCPSettings tcp = new TCPSettings(localDirTextBox.Text, textBox2.Text, int.Parse(textBox1.Text), 
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
            groupBox2.Visible = true;
            ifndefOnClientCheckBox.Visible = true;
            ifndefOnServerCheckBox.Visible = true;
        }

        private void asServerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            ifndefOnClientCheckBox.Visible = false;
            ifndefOnServerCheckBox.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}