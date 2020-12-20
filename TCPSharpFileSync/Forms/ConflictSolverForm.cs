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
        public enum FileExistanceStatus
        {
            ExistsOnHost,
            ExistsOnJoined,
            ExistsOnBoth
        }

        public List<FileDiffData> diffs;
        public List<SyncAction> actions;
        public List<FileExistanceStatus> existanceStatuses;

        public ConflictSolverForm(List<FileDiffData> fdd)
        {
            InitializeComponent();
            diffs = fdd;

            actions = new List<SyncAction>();
            existanceStatuses = new List<FileExistanceStatus>();


            for (int i = 0; i < diffs.Count; i++)
            {
                actions.Add(SyncAction.NotChosen);
            }

            DisplayFileDiffData();
            ((DataGridViewImageColumn)(dataGridView1.Columns[0])).ImageLayout = DataGridViewImageCellLayout.Zoom;
        }
       
        private void ConflictSolverForm_Load(object sender, EventArgs e)
        {

        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Function that displays FileDiff list on DataGridView.
        /// </summary>
        private void DisplayFileDiffData() 
        {
            foreach (var item in diffs)
            {
                string hs = item.Host.byteSize      == -1  ? "-" : FormatBytes(item.Host.byteSize);
                string js = item.Joined.byteSize    == -1  ? "-" : FormatBytes(item.Joined.byteSize);
                dataGridView1.Rows.Add(Resources.NotChosen, item.FileRelativePath, hs, js, item.Host.lastTime, item.Joined.lastTime);

                if (hs == "-")
                {
                    existanceStatuses.Add(FileExistanceStatus.ExistsOnJoined);
                }
                else if (js == "-")
                {
                    existanceStatuses.Add(FileExistanceStatus.ExistsOnHost);
                }
                else
                {
                    existanceStatuses.Add(FileExistanceStatus.ExistsOnBoth);
                }
            }
        }

        /// <summary>
        /// Applies specific SyncOption to all selected rows.
        /// </summary>
        /// <param name="sa">Specific SyncOption to be applied.</param>
        private void SetForSelectedRowsAction(SyncAction sa) 
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                // Check if the file does exist on host or joined before assigning it's SyncAction. Bcoz we cant download the file that doesnt exist.

                bool SyncActionCouldBeAssigned = true;

                switch (sa)
                {
                    case SyncAction.GetFromHost:
                        if (existanceStatuses[dataGridView1.SelectedRows[i].Index] == FileExistanceStatus.ExistsOnJoined)
                            SyncActionCouldBeAssigned = false;
                        break;
                    case SyncAction.GetFromJoined:
                        if (existanceStatuses[dataGridView1.SelectedRows[i].Index] == FileExistanceStatus.ExistsOnHost)
                            SyncActionCouldBeAssigned = false;
                        break;
                    case SyncAction.Skip:
                        break;
                    case SyncAction.GetNewClone:
                        if (existanceStatuses[dataGridView1.SelectedRows[i].Index] == FileExistanceStatus.ExistsOnJoined)
                            SyncActionCouldBeAssigned = false;
                        break;
                    case SyncAction.Delete:
                        break;
                    case SyncAction.NotChosen:
                        break;
                    default:
                        break;
                }

                if (!SyncActionCouldBeAssigned)
                    continue;

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

        /// <summary>
        /// Function made for displaying not just Bytes but GB and MB and so on, so user could see more common things.
        /// </summary>
        /// <param name="bytes">Size that has to be formated from bytes.</param>
        /// <returns>Formated string for displaying size.</returns>
        private static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
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
