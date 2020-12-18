using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCPSharpFileSync.LocalWorks.SessionsWorks;
using TCPSharpFileSync.LocalWorks.SetupWorks;

namespace TCPSharpFileSync.Forms
{
    public partial class NewSessionForm : Form
    {

        public SessionData SD;

        public NewSessionForm()
        {
            InitializeComponent();
        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            if (sessionNameTextBox.Text != "" && dirPathTextBox.Text != "" && ipTextBox.Text != "" && portTextBox.Text != "" &&
                sessionNameTextBox.Text != "Your session name" && dirPathTextBox.Text != "Your directory" && ipTextBox.Text != "IP address" 
                && portTextBox.Text != "Port")
            {
                SD = new SessionData(sessionNameTextBox.Text, dirPathTextBox.Text, ipTextBox.Text, int.Parse(portTextBox.Text), "none", DateTime.Now.ToString("MM/dd/yyyy HH:mm"), sessionNameTextBox.Text + ".ini");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Not everything is filled!");
            }
        }

        private void browseFolderBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) 
            {
                dirPathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
