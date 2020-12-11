
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
            this.serverListBox = new System.Windows.Forms.ListBox();
            this.clientListBox = new System.Windows.Forms.ListBox();
            this.currentFileNameTextBox = new System.Windows.Forms.TextBox();
            this.clientFileInfoTextBox = new System.Windows.Forms.TextBox();
            this.serverFileInfoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chooseServerVarbtn = new System.Windows.Forms.Button();
            this.chooseClientVarbtn = new System.Windows.Forms.Button();
            this.chooseSkipBtn = new System.Windows.Forms.Button();
            this.removeOnAllBtn = new System.Windows.Forms.Button();
            this.skipListBox = new System.Windows.Forms.ListBox();
            this.removeEverywhereListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverListBox
            // 
            this.serverListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serverListBox.FormattingEnabled = true;
            this.serverListBox.Location = new System.Drawing.Point(249, 43);
            this.serverListBox.Name = "serverListBox";
            this.serverListBox.Size = new System.Drawing.Size(211, 182);
            this.serverListBox.TabIndex = 0;
            // 
            // clientListBox
            // 
            this.clientListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clientListBox.FormattingEnabled = true;
            this.clientListBox.Location = new System.Drawing.Point(6, 43);
            this.clientListBox.Name = "clientListBox";
            this.clientListBox.Size = new System.Drawing.Size(211, 182);
            this.clientListBox.TabIndex = 1;
            // 
            // currentFileNameTextBox
            // 
            this.currentFileNameTextBox.Location = new System.Drawing.Point(12, 24);
            this.currentFileNameTextBox.Name = "currentFileNameTextBox";
            this.currentFileNameTextBox.ReadOnly = true;
            this.currentFileNameTextBox.Size = new System.Drawing.Size(274, 20);
            this.currentFileNameTextBox.TabIndex = 2;
            // 
            // clientFileInfoTextBox
            // 
            this.clientFileInfoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clientFileInfoTextBox.Location = new System.Drawing.Point(5, 23);
            this.clientFileInfoTextBox.Multiline = true;
            this.clientFileInfoTextBox.Name = "clientFileInfoTextBox";
            this.clientFileInfoTextBox.Size = new System.Drawing.Size(144, 208);
            this.clientFileInfoTextBox.TabIndex = 3;
            // 
            // serverFileInfoTextBox
            // 
            this.serverFileInfoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serverFileInfoTextBox.Location = new System.Drawing.Point(173, 23);
            this.serverFileInfoTextBox.Multiline = true;
            this.serverFileInfoTextBox.Name = "serverFileInfoTextBox";
            this.serverFileInfoTextBox.Size = new System.Drawing.Size(144, 208);
            this.serverFileInfoTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Client";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Server";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.serverFileInfoTextBox);
            this.groupBox1.Controls.Add(this.clientFileInfoTextBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 243);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FileInfo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.removeEverywhereListBox);
            this.groupBox2.Controls.Add(this.skipListBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.clientListBox);
            this.groupBox2.Controls.Add(this.serverListBox);
            this.groupBox2.Location = new System.Drawing.Point(335, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 422);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File variant";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Server";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Client";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Current File name";
            // 
            // chooseServerVarbtn
            // 
            this.chooseServerVarbtn.Location = new System.Drawing.Point(208, 299);
            this.chooseServerVarbtn.Name = "chooseServerVarbtn";
            this.chooseServerVarbtn.Size = new System.Drawing.Size(87, 23);
            this.chooseServerVarbtn.TabIndex = 10;
            this.chooseServerVarbtn.Text = "Server variant";
            this.chooseServerVarbtn.UseVisualStyleBackColor = true;
            this.chooseServerVarbtn.Click += new System.EventHandler(this.chooseServerVarbtn_Click);
            // 
            // chooseClientVarbtn
            // 
            this.chooseClientVarbtn.Location = new System.Drawing.Point(41, 299);
            this.chooseClientVarbtn.Name = "chooseClientVarbtn";
            this.chooseClientVarbtn.Size = new System.Drawing.Size(87, 23);
            this.chooseClientVarbtn.TabIndex = 11;
            this.chooseClientVarbtn.Text = "Client variant";
            this.chooseClientVarbtn.UseVisualStyleBackColor = true;
            this.chooseClientVarbtn.Click += new System.EventHandler(this.chooseClientVarbtn_Click);
            // 
            // chooseSkipBtn
            // 
            this.chooseSkipBtn.Location = new System.Drawing.Point(41, 337);
            this.chooseSkipBtn.Name = "chooseSkipBtn";
            this.chooseSkipBtn.Size = new System.Drawing.Size(87, 21);
            this.chooseSkipBtn.TabIndex = 12;
            this.chooseSkipBtn.Text = "Skip";
            this.chooseSkipBtn.UseVisualStyleBackColor = true;
            this.chooseSkipBtn.Click += new System.EventHandler(this.chooseSkipBtn_Click);
            // 
            // removeOnAllBtn
            // 
            this.removeOnAllBtn.Location = new System.Drawing.Point(193, 337);
            this.removeOnAllBtn.Name = "removeOnAllBtn";
            this.removeOnAllBtn.Size = new System.Drawing.Size(115, 21);
            this.removeOnAllBtn.TabIndex = 13;
            this.removeOnAllBtn.Text = "Remove everywhere";
            this.removeOnAllBtn.UseVisualStyleBackColor = true;
            this.removeOnAllBtn.Click += new System.EventHandler(this.removeOnAllBtn_Click);
            // 
            // skipListBox
            // 
            this.skipListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.skipListBox.FormattingEnabled = true;
            this.skipListBox.Location = new System.Drawing.Point(6, 260);
            this.skipListBox.Name = "skipListBox";
            this.skipListBox.Size = new System.Drawing.Size(211, 156);
            this.skipListBox.TabIndex = 8;
            // 
            // removeEverywhereListBox
            // 
            this.removeEverywhereListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.removeEverywhereListBox.FormattingEnabled = true;
            this.removeEverywhereListBox.Location = new System.Drawing.Point(242, 260);
            this.removeEverywhereListBox.Name = "removeEverywhereListBox";
            this.removeEverywhereListBox.Size = new System.Drawing.Size(211, 156);
            this.removeEverywhereListBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(89, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Skip";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Remove everywhere";
            // 
            // ConflictSolverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.removeOnAllBtn);
            this.Controls.Add(this.chooseSkipBtn);
            this.Controls.Add(this.chooseClientVarbtn);
            this.Controls.Add(this.chooseServerVarbtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.currentFileNameTextBox);
            this.Name = "ConflictSolverForm";
            this.Text = "ConflictSolverForm";
            this.Load += new System.EventHandler(this.ConflictSolverForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox serverListBox;
        private System.Windows.Forms.ListBox clientListBox;
        private System.Windows.Forms.TextBox currentFileNameTextBox;
        private System.Windows.Forms.TextBox clientFileInfoTextBox;
        private System.Windows.Forms.TextBox serverFileInfoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button chooseServerVarbtn;
        private System.Windows.Forms.Button chooseClientVarbtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox removeEverywhereListBox;
        private System.Windows.Forms.ListBox skipListBox;
        private System.Windows.Forms.Button chooseSkipBtn;
        private System.Windows.Forms.Button removeOnAllBtn;
    }
}