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
        private List<string> fiClient;
        private List<string> fiServer;
        private List<string> fileName;

        //======Outputs======
        public List<string> getFromServer;
        public List<string> uploadToServer;
        public List<string> skips;
        public List<string> removeEverywhere;

        int solverCounter = 0;
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
