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
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.asClientRadioButton = new System.Windows.Forms.RadioButton();
            this.asServerRadioButton = new System.Windows.Forms.RadioButton();
            this.syncBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.localDirTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.timeOutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.actionsGroupBox = new System.Windows.Forms.GroupBox();
            this.doDownloadCheckBox = new System.Windows.Forms.CheckBox();
            this.doUploadCheckBox = new System.Windows.Forms.CheckBox();
            this.ifndefOnServerCheckBox = new System.Windows.Forms.CheckBox();
            this.ifndefOnClientCheckBox = new System.Windows.Forms.CheckBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.chooseDirBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.setupFromFilebtn = new System.Windows.Forms.Button();
            this.setupFileOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeOutNumericUpDown)).BeginInit();
            this.actionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logRichTextBox.Location = new System.Drawing.Point(9, 219);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.Size = new System.Drawing.Size(449, 224);
            this.logRichTextBox.TabIndex = 14;
            this.logRichTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.asClientRadioButton);
            this.groupBox1.Controls.Add(this.asServerRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(268, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(78, 68);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Working as";
            // 
            // asClientRadioButton
            // 
            this.asClientRadioButton.AutoSize = true;
            this.asClientRadioButton.Location = new System.Drawing.Point(6, 42);
            this.asClientRadioButton.Name = "asClientRadioButton";
            this.asClientRadioButton.Size = new System.Drawing.Size(65, 17);
            this.asClientRadioButton.TabIndex = 1;
            this.asClientRadioButton.Text = "as Client";
            this.asClientRadioButton.UseVisualStyleBackColor = true;
            this.asClientRadioButton.CheckedChanged += new System.EventHandler(this.asClientRadioButton_CheckedChanged);
            // 
            // asServerRadioButton
            // 
            this.asServerRadioButton.AutoSize = true;
            this.asServerRadioButton.Checked = true;
            this.asServerRadioButton.Location = new System.Drawing.Point(6, 19);
            this.asServerRadioButton.Name = "asServerRadioButton";
            this.asServerRadioButton.Size = new System.Drawing.Size(70, 17);
            this.asServerRadioButton.TabIndex = 0;
            this.asServerRadioButton.TabStop = true;
            this.asServerRadioButton.Text = "as Server";
            this.asServerRadioButton.UseVisualStyleBackColor = true;
            this.asServerRadioButton.CheckedChanged += new System.EventHandler(this.asServerRadioButton_CheckedChanged);
            // 
            // syncBtn
            // 
            this.syncBtn.Location = new System.Drawing.Point(360, 14);
            this.syncBtn.Name = "syncBtn";
            this.syncBtn.Size = new System.Drawing.Size(104, 26);
            this.syncBtn.TabIndex = 12;
            this.syncBtn.Text = "Syncronize";
            this.syncBtn.UseVisualStyleBackColor = true;
            this.syncBtn.Click += new System.EventHandler(this.syncBtn_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Local Dir";
            // 
            // localDirTextBox
            // 
            this.localDirTextBox.Location = new System.Drawing.Point(9, 18);
            this.localDirTextBox.Name = "localDirTextBox";
            this.localDirTextBox.Size = new System.Drawing.Size(156, 20);
            this.localDirTextBox.TabIndex = 8;
            this.localDirTextBox.TextChanged += new System.EventHandler(this.localDirTextBox_TextChanged);
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(9, 120);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(156, 20);
            this.portTextBox.TabIndex = 16;
            this.portTextBox.TextChanged += new System.EventHandler(this.portTextBox_TextChanged);
            this.portTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.portTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Ip";
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(9, 79);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(156, 20);
            this.ipTextBox.TabIndex = 18;
            this.ipTextBox.TextChanged += new System.EventHandler(this.ipTextBox_TextChanged);
            // 
            // timeOutNumericUpDown
            // 
            this.timeOutNumericUpDown.Location = new System.Drawing.Point(360, 104);
            this.timeOutNumericUpDown.Maximum = new decimal(new int[] {
            90000000,
            0,
            0,
            0});
            this.timeOutNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeOutNumericUpDown.Name = "timeOutNumericUpDown";
            this.timeOutNumericUpDown.Size = new System.Drawing.Size(98, 20);
            this.timeOutNumericUpDown.TabIndex = 20;
            this.timeOutNumericUpDown.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.timeOutNumericUpDown.ValueChanged += new System.EventHandler(this.timeOutNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "ms before timeout";
            // 
            // actionsGroupBox
            // 
            this.actionsGroupBox.Controls.Add(this.doDownloadCheckBox);
            this.actionsGroupBox.Controls.Add(this.doUploadCheckBox);
            this.actionsGroupBox.Location = new System.Drawing.Point(179, 71);
            this.actionsGroupBox.Name = "actionsGroupBox";
            this.actionsGroupBox.Size = new System.Drawing.Size(83, 68);
            this.actionsGroupBox.TabIndex = 22;
            this.actionsGroupBox.TabStop = false;
            this.actionsGroupBox.Text = "Actions";
            this.actionsGroupBox.Visible = false;
            // 
            // doDownloadCheckBox
            // 
            this.doDownloadCheckBox.AutoSize = true;
            this.doDownloadCheckBox.Checked = true;
            this.doDownloadCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doDownloadCheckBox.Location = new System.Drawing.Point(7, 38);
            this.doDownloadCheckBox.Name = "doDownloadCheckBox";
            this.doDownloadCheckBox.Size = new System.Drawing.Size(74, 17);
            this.doDownloadCheckBox.TabIndex = 1;
            this.doDownloadCheckBox.Text = "Download";
            this.doDownloadCheckBox.UseVisualStyleBackColor = true;
            // 
            // doUploadCheckBox
            // 
            this.doUploadCheckBox.AutoSize = true;
            this.doUploadCheckBox.Checked = true;
            this.doUploadCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doUploadCheckBox.Location = new System.Drawing.Point(7, 20);
            this.doUploadCheckBox.Name = "doUploadCheckBox";
            this.doUploadCheckBox.Size = new System.Drawing.Size(60, 17);
            this.doUploadCheckBox.TabIndex = 0;
            this.doUploadCheckBox.Text = "Upload";
            this.doUploadCheckBox.UseVisualStyleBackColor = true;
            // 
            // ifndefOnServerCheckBox
            // 
            this.ifndefOnServerCheckBox.AutoSize = true;
            this.ifndefOnServerCheckBox.Location = new System.Drawing.Point(13, 159);
            this.ifndefOnServerCheckBox.Name = "ifndefOnServerCheckBox";
            this.ifndefOnServerCheckBox.Size = new System.Drawing.Size(219, 17);
            this.ifndefOnServerCheckBox.TabIndex = 23;
            this.ifndefOnServerCheckBox.Text = "If doesnt exist on server remove on client";
            this.ifndefOnServerCheckBox.UseVisualStyleBackColor = true;
            this.ifndefOnServerCheckBox.Visible = false;
            this.ifndefOnServerCheckBox.CheckedChanged += new System.EventHandler(this.ifndefOnServerCheckBox_CheckedChanged);
            // 
            // ifndefOnClientCheckBox
            // 
            this.ifndefOnClientCheckBox.AutoSize = true;
            this.ifndefOnClientCheckBox.Location = new System.Drawing.Point(238, 159);
            this.ifndefOnClientCheckBox.Name = "ifndefOnClientCheckBox";
            this.ifndefOnClientCheckBox.Size = new System.Drawing.Size(219, 17);
            this.ifndefOnClientCheckBox.TabIndex = 24;
            this.ifndefOnClientCheckBox.Text = "If doesnt exist on client remove on server";
            this.ifndefOnClientCheckBox.UseVisualStyleBackColor = true;
            this.ifndefOnClientCheckBox.Visible = false;
            this.ifndefOnClientCheckBox.CheckedChanged += new System.EventHandler(this.ifndefOnClientCheckBox_CheckedChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(9, 183);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(451, 23);
            this.progressBar.TabIndex = 25;
            // 
            // chooseDirBtn
            // 
            this.chooseDirBtn.Location = new System.Drawing.Point(171, 15);
            this.chooseDirBtn.Name = "chooseDirBtn";
            this.chooseDirBtn.Size = new System.Drawing.Size(100, 24);
            this.chooseDirBtn.TabIndex = 26;
            this.chooseDirBtn.Text = "Choose directory";
            this.chooseDirBtn.UseVisualStyleBackColor = true;
            this.chooseDirBtn.Click += new System.EventHandler(this.chooseDirBtn_Click);
            // 
            // setupFromFilebtn
            // 
            this.setupFromFilebtn.Location = new System.Drawing.Point(274, 15);
            this.setupFromFilebtn.Name = "setupFromFilebtn";
            this.setupFromFilebtn.Size = new System.Drawing.Size(70, 24);
            this.setupFromFilebtn.TabIndex = 27;
            this.setupFromFilebtn.Text = "Set up";
            this.setupFromFilebtn.UseVisualStyleBackColor = true;
            this.setupFromFilebtn.Click += new System.EventHandler(this.setupFromFilebtn_Click);
            // 
            // setupFileOpenDialog
            // 
            this.setupFileOpenDialog.Filter = "ini file|*.ini";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 450);
            this.Controls.Add(this.setupFromFilebtn);
            this.Controls.Add(this.chooseDirBtn);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ifndefOnClientCheckBox);
            this.Controls.Add(this.ifndefOnServerCheckBox);
            this.Controls.Add(this.actionsGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeOutNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ipTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.logRichTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.syncBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.localDirTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeOutNumericUpDown)).EndInit();
            this.actionsGroupBox.ResumeLayout(false);
            this.actionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox logRichTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton asClientRadioButton;
        private System.Windows.Forms.RadioButton asServerRadioButton;
        private System.Windows.Forms.Button syncBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox localDirTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.NumericUpDown timeOutNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox actionsGroupBox;
        private System.Windows.Forms.CheckBox doDownloadCheckBox;
        private System.Windows.Forms.CheckBox doUploadCheckBox;
        private System.Windows.Forms.CheckBox ifndefOnServerCheckBox;
        private System.Windows.Forms.CheckBox ifndefOnClientCheckBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button chooseDirBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button setupFromFilebtn;
        private System.Windows.Forms.OpenFileDialog setupFileOpenDialog;
    }
}

