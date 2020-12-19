using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TCPSharpFileSync.NetWorks.ConflictWorks;

namespace TCPSharpFileSync
{
    public partial class ConflictSolverForm : Form
    {
        List<FileDiffData> diffs;
        List<SyncAction> actions;

        public ConflictSolverForm(List<FileDiffData> fdd)
        {
            InitializeComponent();
            diffs = fdd;
        }
       
        private void ConflictSolverForm_Load(object sender, EventArgs e)
        {

        }

        private void doneBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
