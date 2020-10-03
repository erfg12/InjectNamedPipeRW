namespace WindowsFormsApp2
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
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.ProcIDTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WriteMsgBtn = new System.Windows.Forms.Button();
            this.WriteMsgTxtBox = new System.Windows.Forms.TextBox();
            this.DLLFilePath = new System.Windows.Forms.TextBox();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.PipeOutputTextBox = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "PID";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(287, 64);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 4;
            this.ConnectBtn.Text = "CONNECT";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // ProcIDTxtBox
            // 
            this.ProcIDTxtBox.Location = new System.Drawing.Point(61, 65);
            this.ProcIDTxtBox.Name = "ProcIDTxtBox";
            this.ProcIDTxtBox.Size = new System.Drawing.Size(220, 20);
            this.ProcIDTxtBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "MSG";
            // 
            // WriteMsgBtn
            // 
            this.WriteMsgBtn.Location = new System.Drawing.Point(287, 90);
            this.WriteMsgBtn.Name = "WriteMsgBtn";
            this.WriteMsgBtn.Size = new System.Drawing.Size(75, 23);
            this.WriteMsgBtn.TabIndex = 7;
            this.WriteMsgBtn.Text = "SEND";
            this.WriteMsgBtn.UseVisualStyleBackColor = true;
            this.WriteMsgBtn.Click += new System.EventHandler(this.WriteMsg_Click);
            // 
            // WriteMsgTxtBox
            // 
            this.WriteMsgTxtBox.Location = new System.Drawing.Point(61, 91);
            this.WriteMsgTxtBox.Name = "WriteMsgTxtBox";
            this.WriteMsgTxtBox.Size = new System.Drawing.Size(220, 20);
            this.WriteMsgTxtBox.TabIndex = 6;
            // 
            // DLLFilePath
            // 
            this.DLLFilePath.Location = new System.Drawing.Point(61, 20);
            this.DLLFilePath.Name = "DLLFilePath";
            this.DLLFilePath.Size = new System.Drawing.Size(220, 20);
            this.DLLFilePath.TabIndex = 9;
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(287, 19);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseBtn.TabIndex = 10;
            this.BrowseBtn.Text = "BROWSE";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "DLL";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // PipeOutputTextBox
            // 
            this.PipeOutputTextBox.Location = new System.Drawing.Point(27, 135);
            this.PipeOutputTextBox.Name = "PipeOutputTextBox";
            this.PipeOutputTextBox.Size = new System.Drawing.Size(335, 194);
            this.PipeOutputTextBox.TabIndex = 13;
            this.PipeOutputTextBox.Text = "";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 351);
            this.Controls.Add(this.PipeOutputTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.DLLFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WriteMsgBtn);
            this.Controls.Add(this.WriteMsgTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.ProcIDTxtBox);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Inject DLL, create named pipe, write message";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox ProcIDTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button WriteMsgBtn;
        private System.Windows.Forms.TextBox WriteMsgTxtBox;
        private System.Windows.Forms.TextBox DLLFilePath;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox PipeOutputTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

