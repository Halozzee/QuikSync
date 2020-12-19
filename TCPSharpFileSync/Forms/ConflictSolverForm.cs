using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TCPSharpFileSync.NetWorks.ConflictWorks;
using TCPSharpFileSync.Properties;

namespace TCPSharpFileSync
{
    public partial class ConflictSolverForm : Form
    {
        public List<FileDiffData> diffs;
        public List<SyncAction> actions;

        public ConflictSolverForm(List<FileDiffData> fdd)
        {
            InitializeComponent();
            diffs = fdd;

            actions = new List<SyncAction>();

            for (int i = 0; i < diffs.Count; i++)
            {
                actions.Add(SyncAction.NotChosen);
            }

            DisplayFileDiffData();
            ((DataGridViewImageColumn)(dataGridView1.Columns[0])).ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
       
        private void ConflictSolverForm_Load(object sender, EventArgs e)
        {

        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void DisplayFileDiffData() 
        {
            foreach (var item in diffs)
            {
                dataGridView1.Rows.Add(Resources.NotChosen, item.FileRelativePath, item.Host.byteSize, item.Joined.byteSize, item.Host.lastTime, item.Joined.lastTime);
            }
        }

        private void SetForSelectedRowsAction(SyncAction sa) 
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                actions[dataGridView1.SelectedRows[i].Index] = sa;

                // Assign action image 
                switch (sa)
                {
                    case SyncAction.GetFromHost:
                        dataGridView1.Rows[dataGridView1.SelectedRows[i].Index].Cells[0].Value = Resources.Host;
                        break;
                    case SyncAction.GetFromJoined:
                        dataGridView1.Rows[dataGridView1.SelectedRows[i].Index].Cells[0].Value = Resources.Joined;
                        break;
                    case SyncAction.Skip:
                        dataGridView1.Rows[dataGridView1.SelectedRows[i].Index].Cells[0].Value = Resources.Skip;
                        break;
                    case SyncAction.GetNewClone:
                        dataGridView1.Rows[dataGridView1.SelectedRows[i].Index].Cells[0].Value = Resources.Clone;
                        break;
                    case SyncAction.NotChosen:
                        dataGridView1.Rows[dataGridView1.SelectedRows[i].Index].Cells[0].Value = Resources.NotChosen;
                        break;
                    case SyncAction.Delete:
                        dataGridView1.Rows[dataGridView1.SelectedRows[i].Index].Cells[0].Value = Resources.Delete;
                        break;
                    default:
                        break;
                }
            }
        }

        private void hostBtn_Click(object sender, EventArgs e)
        {
            SetForSelectedRowsAction(SyncAction.GetFromHost);
        }

        private void joinedBtn_Click(object sender, EventArgs e)
        {
            SetForSelectedRowsAction(SyncAction.GetFromJoined);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            SetForSelectedRowsAction(SyncAction.Delete);
        }

        private void newCloneBtn_Click(object sender, EventArgs e)
        {
            SetForSelectedRowsAction(SyncAction.GetNewClone);
        }

        private void skipBtn_Click(object sender, EventArgs e)
        {
            SetForSelectedRowsAction(SyncAction.Skip);
        }
    }
}
