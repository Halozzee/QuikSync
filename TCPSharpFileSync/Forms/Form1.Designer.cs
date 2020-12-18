namespace TCPSharpFileSync
{
    partial class Form1
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
            this.HostBtn = new System.Windows.Forms.Button();
            this.JoinBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SessionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Directory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP_PORT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastTimeUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.removeSelectedBtn = new System.Windows.Forms.Button();
            this.newSessionBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // HostBtn
            // 
            this.HostBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HostBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HostBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.HostBtn.Location = new System.Drawing.Point(652, 12);
            this.HostBtn.Name = "HostBtn";
            this.HostBtn.Size = new System.Drawing.Size(152, 42);
            this.HostBtn.TabIndex = 1;
            this.HostBtn.Text = "Host";
            this.HostBtn.UseVisualStyleBackColor = true;
            this.HostBtn.Click += new System.EventHandler(this.HostBtn_Click);
            // 
            // JoinBtn
            // 
            this.JoinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.JoinBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.JoinBtn.Location = new System.Drawing.Point(652, 60);
            this.JoinBtn.Name = "JoinBtn";
            this.JoinBtn.Size = new System.Drawing.Size(152, 42);
            this.JoinBtn.TabIndex = 2;
            this.JoinBtn.Text = "Join";
            this.JoinBtn.UseVisualStyleBackColor = true;
            this.JoinBtn.Click += new System.EventHandler(this.JoinBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SessionName,
            this.Directory,
            this.IP_PORT,
            this.LastTimeUsed});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(58)))));
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(621, 455);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // SessionName
            // 
            this.SessionName.HeaderText = "Session name";
            this.SessionName.Name = "SessionName";
            // 
            // Directory
            // 
            this.Directory.HeaderText = "Directory";
            this.Directory.Name = "Directory";
            this.Directory.ReadOnly = true;
            // 
            // IP_PORT
            // 
            this.IP_PORT.HeaderText = "Address";
            this.IP_PORT.Name = "IP_PORT";
            this.IP_PORT.ReadOnly = true;
            // 
            // LastTimeUsed
            // 
            this.LastTimeUsed.HeaderText = "Last time used";
            this.LastTimeUsed.Name = "LastTimeUsed";
            // 
            // removeSelectedBtn
            // 
            this.removeSelectedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeSelectedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeSelectedBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.removeSelectedBtn.Location = new System.Drawing.Point(652, 291);
            this.removeSelectedBtn.Name = "removeSelectedBtn";
            this.removeSelectedBtn.Size = new System.Drawing.Size(152, 23);
            this.removeSelectedBtn.TabIndex = 4;
            this.removeSelectedBtn.Text = "Remove selected";
            this.removeSelectedBtn.UseVisualStyleBackColor = true;
            this.removeSelectedBtn.Click += new System.EventHandler(this.removeSelectedBtn_Click);
            // 
            // newSessionBtn
            // 
            this.newSessionBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newSessionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newSessionBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.newSessionBtn.Location = new System.Drawing.Point(652, 149);
            this.newSessionBtn.Name = "newSessionBtn";
            this.newSessionBtn.Size = new System.Drawing.Size(152, 44);
            this.newSessionBtn.TabIndex = 5;
            this.newSessionBtn.Text = "New session";
            this.newSessionBtn.UseVisualStyleBackColor = true;
            this.newSessionBtn.Click += new System.EventHandler(this.newSessionBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(816, 479);
            this.Controls.Add(this.newSessionBtn);
            this.Controls.Add(this.removeSelectedBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.JoinBtn);
            this.Controls.Add(this.HostBtn);
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button HostBtn;
        private System.Windows.Forms.Button JoinBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button removeSelectedBtn;
        private System.Windows.Forms.Button newSessionBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SessionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Directory;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP_PORT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastTimeUsed;
    }
}

