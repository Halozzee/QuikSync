
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewImageColumn();
            this.RelativePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostTimeModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientTimeModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostBtn = new System.Windows.Forms.Button();
            this.joinedBtn = new System.Windows.Forms.Button();
            this.skipBtn = new System.Windows.Forms.Button();
            this.newCloneBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action,
            this.RelativePath,
            this.HostSize,
            this.ClientSize,
            this.HostTimeModified,
            this.ClientTimeModified});
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dataGridView1.Location = new System.Drawing.Point(21, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(550, 421);
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
            // HostSize
            // 
            this.HostSize.HeaderText = "Host size";
            this.HostSize.Name = "HostSize";
            // 
            // ClientSize
            // 
            this.ClientSize.HeaderText = "Joined size";
            this.ClientSize.Name = "ClientSize";
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
            this.hostBtn.Location = new System.Drawing.Point(6, 23);
            this.hostBtn.Name = "hostBtn";
            this.hostBtn.Size = new System.Drawing.Size(83, 23);
            this.hostBtn.TabIndex = 1;
            this.hostBtn.Text = "Host";
            this.hostBtn.UseVisualStyleBackColor = true;
            // 
            // joinedBtn
            // 
            this.joinedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinedBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.joinedBtn.Location = new System.Drawing.Point(6, 52);
            this.joinedBtn.Name = "joinedBtn";
            this.joinedBtn.Size = new System.Drawing.Size(83, 23);
            this.joinedBtn.TabIndex = 2;
            this.joinedBtn.Text = "Joined";
            this.joinedBtn.UseVisualStyleBackColor = true;
            // 
            // skipBtn
            // 
            this.skipBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.skipBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.skipBtn.Location = new System.Drawing.Point(6, 81);
            this.skipBtn.Name = "skipBtn";
            this.skipBtn.Size = new System.Drawing.Size(83, 23);
            this.skipBtn.TabIndex = 3;
            this.skipBtn.Text = "Skip";
            this.skipBtn.UseVisualStyleBackColor = true;
            // 
            // newCloneBtn
            // 
            this.newCloneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newCloneBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.newCloneBtn.Location = new System.Drawing.Point(6, 110);
            this.newCloneBtn.Name = "newCloneBtn";
            this.newCloneBtn.Size = new System.Drawing.Size(83, 23);
            this.newCloneBtn.TabIndex = 4;
            this.newCloneBtn.Text = "New Clone";
            this.newCloneBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.skipBtn);
            this.groupBox1.Controls.Add(this.newCloneBtn);
            this.groupBox1.Controls.Add(this.joinedBtn);
            this.groupBox1.Controls.Add(this.hostBtn);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Menu;
            this.groupBox1.Location = new System.Drawing.Point(569, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(97, 145);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // doneBtn
            // 
            this.doneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.doneBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.doneBtn.Location = new System.Drawing.Point(569, 299);
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
            this.Size = new System.Drawing.Size(700, 405);
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
        private System.Windows.Forms.DataGridViewImageColumn Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelativePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostTimeModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientTimeModified;
        private System.Windows.Forms.Button doneBtn;
    }
}