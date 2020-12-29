namespace QuikSync
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.HostBtn = new System.Windows.Forms.Button();
            this.JoinBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SessionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Directory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP_PORT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastTimeUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.removeSelectedBtn = new System.Windows.Forms.Button();
            this.newSessionBtn = new System.Windows.Forms.Button();
            this.actionLabel = new System.Windows.Forms.Label();
            this.circularProgressBar = new CircularProgressBar.CircularProgressBar();
            this.colorfulBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.closeWindowBtn = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // HostBtn
            // 
            this.HostBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HostBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HostBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.HostBtn.Location = new System.Drawing.Point(652, 44);
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
            this.JoinBtn.Location = new System.Drawing.Point(652, 92);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SessionName,
            this.Directory,
            this.IP_PORT,
            this.LastTimeUsed});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(58)))));
            this.dataGridView1.Location = new System.Drawing.Point(12, 44);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(621, 394);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            // 
            // SessionName
            // 
            this.SessionName.HeaderText = "Session name";
            this.SessionName.Name = "SessionName";
            this.SessionName.ReadOnly = true;
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
            this.LastTimeUsed.ReadOnly = true;
            // 
            // removeSelectedBtn
            // 
            this.removeSelectedBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeSelectedBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeSelectedBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.removeSelectedBtn.Location = new System.Drawing.Point(652, 308);
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
            this.newSessionBtn.Location = new System.Drawing.Point(652, 181);
            this.newSessionBtn.Name = "newSessionBtn";
            this.newSessionBtn.Size = new System.Drawing.Size(152, 44);
            this.newSessionBtn.TabIndex = 5;
            this.newSessionBtn.Text = "New session";
            this.newSessionBtn.UseVisualStyleBackColor = true;
            this.newSessionBtn.Click += new System.EventHandler(this.newSessionBtn_Click);
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.ForeColor = System.Drawing.SystemColors.Menu;
            this.actionLabel.Location = new System.Drawing.Point(51, 448);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(0, 13);
            this.actionLabel.TabIndex = 6;
            // 
            // circularProgressBar
            // 
            this.circularProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar.AnimationSpeed = 10;
            this.circularProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.circularProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.circularProgressBar.InnerMargin = 2;
            this.circularProgressBar.InnerWidth = -1;
            this.circularProgressBar.Location = new System.Drawing.Point(18, 440);
            this.circularProgressBar.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar.Name = "circularProgressBar";
            this.circularProgressBar.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(80)))));
            this.circularProgressBar.OuterMargin = -25;
            this.circularProgressBar.OuterWidth = 25;
            this.circularProgressBar.ProgressColor = System.Drawing.Color.MediumTurquoise;
            this.circularProgressBar.ProgressWidth = 2;
            this.circularProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularProgressBar.Size = new System.Drawing.Size(27, 27);
            this.circularProgressBar.StartAngle = 270;
            this.circularProgressBar.Step = 1;
            this.circularProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.circularProgressBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar.SubscriptText = ".23";
            this.circularProgressBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar.SuperscriptText = "°C";
            this.circularProgressBar.TabIndex = 7;
            this.circularProgressBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar.Value = 68;
            this.circularProgressBar.Visible = false;
            // 
            // colorfulBar
            // 
            this.colorfulBar.Location = new System.Drawing.Point(-8, -8);
            this.colorfulBar.Name = "colorfulBar";
            this.colorfulBar.Size = new System.Drawing.Size(830, 10);
            this.colorfulBar.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Menu;
            this.label1.Location = new System.Drawing.Point(31, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "QUIKSYNC";
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackgroundImage = global::QuikSync.Properties.Resources.minimize_btn_removebg_preview;
            this.minimizeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.minimizeBtn.FlatAppearance.BorderSize = 0;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.ForeColor = System.Drawing.SystemColors.Menu;
            this.minimizeBtn.Location = new System.Drawing.Point(765, 6);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(20, 18);
            this.minimizeBtn.TabIndex = 10;
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // closeWindowBtn
            // 
            this.closeWindowBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeWindowBtn.BackgroundImage")));
            this.closeWindowBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeWindowBtn.FlatAppearance.BorderSize = 0;
            this.closeWindowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeWindowBtn.Location = new System.Drawing.Point(791, 6);
            this.closeWindowBtn.Name = "closeWindowBtn";
            this.closeWindowBtn.Size = new System.Drawing.Size(20, 18);
            this.closeWindowBtn.TabIndex = 9;
            this.closeWindowBtn.UseVisualStyleBackColor = true;
            this.closeWindowBtn.Click += new System.EventHandler(this.closeWindowBtn_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.logoPictureBox.Image = global::QuikSync.Properties.Resources.LogoNotext;
            this.logoPictureBox.Location = new System.Drawing.Point(10, 7);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(25, 25);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 8;
            this.logoPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(816, 479);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colorfulBar);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.closeWindowBtn);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.circularProgressBar);
            this.Controls.Add(this.actionLabel);
            this.Controls.Add(this.newSessionBtn);
            this.Controls.Add(this.removeSelectedBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.JoinBtn);
            this.Controls.Add(this.HostBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "QuikSync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label actionLabel;
        private CircularProgressBar.CircularProgressBar circularProgressBar;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button closeWindowBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.Panel colorfulBar;
        private System.Windows.Forms.Label label1;
    }
}

