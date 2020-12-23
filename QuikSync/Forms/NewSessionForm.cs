using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuikSync.LocalWorks.SessionWorks;
using QuikSync.LocalWorks.SetupWorks;

namespace QuikSync.Forms
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
                if (SessionHandler.CheckRecordingExistance(sessionNameTextBox.Text))
                {
                    MessageBox.Show("This session already exists!");
                }
                else
                {
                    SD = new SessionData(sessionNameTextBox.Text, dirPathTextBox.Text, ipTextBox.Text, int.Parse(portTextBox.Text), "none",
                        DateTime.Now.ToString("MM/dd/yyyy HH:mm"), sessionNameTextBox.Text + ".ini");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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

        #region Magic code for dragging window wihout boarder!

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void NewSessionForm_MouseDown(object sender, MouseEventArgs e)
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
            this.DialogResult = DialogResult.Cancel;
        }

        private void NewSessionForm_Load(object sender, EventArgs e)
        {

        }

        private void NewSessionForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(38, 38, 42), 2), this.DisplayRectangle);
        }
    }
}