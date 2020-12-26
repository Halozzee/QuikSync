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


        /// <summary>
        /// Function made for validation IP addresses.
        /// </summary>
        /// <param name="ip">IP address that has to be validated.</param>
        /// <returns>Answer true if it's OK and false if there's some mistakes.</returns>
        private bool ValidateIp(string ip)
        {
            string[] splitted = ip.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);

            if (splitted.Length != 4)
                return false;

            for (int i = 0; i < splitted.Length; i++)
            {
                int crnt = 0;
                bool tried = int.TryParse(splitted[i], out crnt);

                if (!tried)
                    return false;

                if (crnt < 0 || crnt > 255)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Function made for validation Ports.
        /// </summary>
        /// <param name="port">Port that has to be validated.</param>
        /// <returns>Answer true if it's OK and false if there's some mistakes.</returns>
        private bool ValidatePort(string port)
        {
            int p;

            bool tried = int.TryParse(port, out p);

            if (!tried)
                return false;

            return p >= 0 && p < 65536;
        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            // Validating IP address
            bool validateIPAnswer = ValidateIp(ipTextBox.Text);

            // Validating Port
            bool validatePortAnswer = ValidatePort(portTextBox.Text);

            if (sessionNameTextBox.Text != "" && dirPathTextBox.Text != "" &&
                sessionNameTextBox.Text != "Your session name" && dirPathTextBox.Text != "Your directory" && validateIPAnswer && validatePortAnswer)
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
            else if (!validateIPAnswer)
            {
                MessageBox.Show("Wrong IP address!");
            }
            else if (!validatePortAnswer)
            {
                MessageBox.Show("Wrong Port!");
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