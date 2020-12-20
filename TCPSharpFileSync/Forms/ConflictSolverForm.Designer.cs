
namespace TCPSharpFileSync
{
    partial class ConflictSolverForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewImageColumn();
            this.RelativePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostFS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JoinedFS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostTimeModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientTimeModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostBtn = new System.Windows.Forms.Button();
            this.joinedBtn = new System.Windows.Forms.Button();
            this.skipBtn = new System.Windows.Forms.Button();
            this.newCloneBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.doneBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action,
            this.RelativePath,
            this.HostFS,
            this.JoinedFS,
            this.HostTimeModified,
            this.ClientTimeModified});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dataGridView1.Location = new System.Drawing.Point(21, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(548, 311);
            this.dataGridView1.TabIndex = 0;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Action.Width = 40;
            // 
            // RelativePath
            // 
            this.RelativePath.HeaderText = "Relative path";
            this.RelativePath.Name = "RelativePath";
            // 
            // HostFS
            // 
            this.HostFS.HeaderText = "Host size";
            this.HostFS.Name = "HostFS";
            // 
            // JoinedFS
            // 
            this.JoinedFS.HeaderText = "Joined size";
            this.JoinedFS.Name = "JoinedFS";
            // 
            // HostTimeModified
            // 
            this.HostTimeModified.HeaderText = "Host time modified";
            this.HostTimeModified.Name = "HostTimeModified";
            // 
            // ClientTimeModified
            // 
            this.ClientTimeModified.HeaderText = "Joined time modified";
            this.ClientTimeModified.Name = "ClientTimeModified";
            // 
            // hostBtn
            // 
            this.hostBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hostBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.hostBtn.Location = new System.Drawing.Point(7, 23);
            this.hostBtn.Name = "hostBtn";
            this.hostBtn.Size = new System.Drawing.Size(83, 23);
            this.hostBtn.TabIndex = 1;
            this.hostBtn.Text = "Host";
            this.hostBtn.UseVisualStyleBackColor = true;
            this.hostBtn.Click += new System.EventHandler(this.hostBtn_Click);
            // 
            // joinedBtn
            // 
            this.joinedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinedBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.joinedBtn.Location = new System.Drawing.Point(7, 52);
            this.joinedBtn.Name = "joinedBtn";
            this.joinedBtn.Size = new System.Drawing.Size(83, 23);
            this.joinedBtn.TabIndex = 2;
            this.joinedBtn.Text = "Joined";
            this.joinedBtn.UseVisualStyleBackColor = true;
            this.joinedBtn.Click += new System.EventHandler(this.joinedBtn_Click);
            // 
            // skipBtn
            // 
            this.skipBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.skipBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.skipBtn.Location = new System.Drawing.Point(7, 81);
            this.skipBtn.Name = "skipBtn";
            this.skipBtn.Size = new System.Drawing.Size(83, 23);
            this.skipBtn.TabIndex = 3;
            this.skipBtn.Text = "Skip";
            this.skipBtn.UseVisualStyleBackColor = true;
            this.skipBtn.Click += new System.EventHandler(this.skipBtn_Click);
            // 
            // newCloneBtn
            // 
            this.newCloneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newCloneBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.newCloneBtn.Location = new System.Drawing.Point(7, 110);
            this.newCloneBtn.Name = "newCloneBtn";
            this.newCloneBtn.Size = new System.Drawing.Size(83, 23);
            this.newCloneBtn.TabIndex = 4;
            this.newCloneBtn.Text = "New Clone";
            this.newCloneBtn.UseVisualStyleBackColor = true;
            this.newCloneBtn.Click += new System.EventHandler(this.newCloneBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteBtn);
            this.groupBox1.Controls.Add(this.skipBtn);
            this.groupBox1.Controls.Add(this.newCloneBtn);
            this.groupBox1.Controls.Add(this.joinedBtn);
            this.groupBox1.Controls.Add(this.hostBtn);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Menu;
            this.groupBox1.Location = new System.Drawing.Point(575, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 172);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // deleteBtn
            // 
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.deleteBtn.Location = new System.Drawing.Point(7, 139);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(83, 23);
            this.deleteBtn.TabIndex = 5;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // doneBtn
            // 
            this.doneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.doneBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.doneBtn.Location = new System.Drawing.Point(574, 299);
            this.doneBtn.Name = "doneBtn";
            this.doneBtn.Size = new System.Drawing.Size(97, 34);
            this.doneBtn.TabIndex = 6;
            this.doneBtn.Text = "Done";
            this.doneBtn.UseVisualStyleBackColor = true;
            this.doneBtn.Click += new System.EventHandler(this.doneBtn_Click);
            // 
            // ConflictSolverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(679, 365);
            this.Controls.Add(this.doneBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ConflictSolverForm";
            this.Text = "ConflictSolverForm";
            this.Load += new System.EventHandler(this.ConflictSolverForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button hostBtn;
        private System.Windows.Forms.Button joinedBtn;
        private System.Windows.Forms.Button skipBtn;
        private System.Windows.Forms.Button newCloneBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button doneBtn;
        private System.Windows.Forms.DataGridViewImageColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelativePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostFS;
        private System.Windows.Forms.DataGridViewTextBoxColumn JoinedFS;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostTimeModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientTimeModified;
        private System.Windows.Forms.Button deleteBtn;
    }
}