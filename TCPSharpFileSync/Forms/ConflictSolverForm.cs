using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPSharpFileSync
{
    public partial class ConflictSolverForm : Form
    {
        //======Inputs======
        //fi is FileInfo
        /// <summary>
        /// fi representing client files.
        /// </summary>
        private List<string> fiClient;
        /// <summary>
        /// fi representing server files.
        /// </summary>
        private List<string> fiServer;
        /// <summary>
        /// Relative path on both server and client.
        /// </summary>
        private List<string> fileName;

        //======Outputs======
        /// <summary>
        /// List of strings. Each string represents Relative path that will be downloaded from server.
        /// </summary>
        public List<string> getFromServer;
        /// <summary>
        /// List of strings. Each string represents Relative path that will be uploaded from server.
        /// </summary>
        public List<string> uploadToServer;
        /// <summary>
        /// List of strings. Each string represents Relative path that will be skipped.
        /// </summary>
        public List<string> skips;
        /// <summary>
        /// List of strings. Each string represents Relative path that will be removed from both server and client.
        /// </summary>
        public List<string> removeEverywhere;

        /// <summary>
        /// Counter for showing fileName from the list.
        /// </summary>
        int solverCounter = 0;
        /// <summary>
        /// The "barrier" value for showing with solverCounter.
        /// </summary>
        int limit = 0;

        public ConflictSolverForm(List<string> fiC, List<string> fiS, List<string> fn)
        {
            InitializeComponent();

            fiClient = fiC;
            fiServer = fiS;
            fileName = fn;

            limit = fiC.Count;

            AskForSolve(solverCounter);
        }

        /// <summary>
        /// Asks user for how the current fileName[i] conflict has to be solved.
        /// </summary>
        /// <param name="i">The index of Relative path in fileName path</param>
        private void AskForSolve(int i) 
        {
            if (solverCounter != limit)
            {
                var dataClient = fiClient[solverCounter].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                var dataServer= fiServer[solverCounter].Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                currentFileNameTextBox.Text = fileName[solverCounter];
                clientFileInfoTextBox.Text = "Size: \t" + dataClient[0] + "\n" + "Last time modified: \t" + dataClient[1];
                serverFileInfoTextBox.Text = "Size: \t" + dataServer[0] + "\n" + "Last time modified: \t" + dataServer[1];

                solverCounter++;
            }
            else
            {
                getFromServer = (List<string>)serverListBox.Items.Cast<string>().ToList();
                uploadToServer = (List<string>)clientListBox.Items.Cast<string>().ToList();
                skips = (List<string>)skipListBox.Items.Cast<string>().ToList();
                removeEverywhere = (List<string>)removeEverywhereListBox.Items.Cast<string>().ToList();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ConflictSolverForm_Load(object sender, EventArgs e)
        {

        }

        //Below this line - event handlers that just adding the file to the corresponding list and asks for solving the next file name.
        //==============================================================

        private void chooseClientVarbtn_Click(object sender, EventArgs e)
        {
            clientListBox.Items.Add(currentFileNameTextBox.Text);
            AskForSolve(solverCounter);
        }

        private void chooseServerVarbtn_Click(object sender, EventArgs e)
        {
            serverListBox.Items.Add(currentFileNameTextBox.Text);
            AskForSolve(solverCounter);
        }

        private void chooseSkipBtn_Click(object sender, EventArgs e)
        {
            skipListBox.Items.Add(currentFileNameTextBox.Text);
            AskForSolve(solverCounter);
        }

        private void removeOnAllBtn_Click(object sender, EventArgs e)
        {
            removeEverywhereListBox.Items.Add(currentFileNameTextBox.Text);
            AskForSolve(solverCounter);
        }
    }
}
