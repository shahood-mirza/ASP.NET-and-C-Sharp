namespace FileSearcher
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
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.searchProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.matchCountLbl = new System.Windows.Forms.Label();
            this.progressPcntLbl = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.filePath = new System.Windows.Forms.Label();
            this.openBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.resultsBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clrBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(12, 59);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(221, 20);
            this.searchBox.TabIndex = 0;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(239, 58);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 1;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // searchProgressBar
            // 
            this.searchProgressBar.Location = new System.Drawing.Point(12, 125);
            this.searchProgressBar.Name = "searchProgressBar";
            this.searchProgressBar.Size = new System.Drawing.Size(383, 23);
            this.searchProgressBar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Matches Found:";
            // 
            // matchCountLbl
            // 
            this.matchCountLbl.AutoSize = true;
            this.matchCountLbl.Location = new System.Drawing.Point(90, 109);
            this.matchCountLbl.Name = "matchCountLbl";
            this.matchCountLbl.Size = new System.Drawing.Size(13, 13);
            this.matchCountLbl.TabIndex = 4;
            this.matchCountLbl.Text = "0";
            // 
            // progressPcntLbl
            // 
            this.progressPcntLbl.AutoSize = true;
            this.progressPcntLbl.Location = new System.Drawing.Point(374, 109);
            this.progressPcntLbl.Name = "progressPcntLbl";
            this.progressPcntLbl.Size = new System.Drawing.Size(21, 13);
            this.progressPcntLbl.TabIndex = 5;
            this.progressPcntLbl.Text = "0%";
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // filePath
            // 
            this.filePath.AutoSize = true;
            this.filePath.Location = new System.Drawing.Point(149, 19);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(27, 13);
            this.filePath.TabIndex = 6;
            this.filePath.Text = "N/A";
            // 
            // openBtn
            // 
            this.openBtn.Location = new System.Drawing.Point(280, 14);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(75, 23);
            this.openBtn.TabIndex = 7;
            this.openBtn.Text = "Open File";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.OpenBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(320, 58);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Stop";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // resultsBox
            // 
            this.resultsBox.FormattingEnabled = true;
            this.resultsBox.Location = new System.Drawing.Point(12, 169);
            this.resultsBox.Name = "resultsBox";
            this.resultsBox.Size = new System.Drawing.Size(383, 108);
            this.resultsBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Searching in File:";
            // 
            // clrBtn
            // 
            this.clrBtn.Location = new System.Drawing.Point(113, 287);
            this.clrBtn.Name = "clrBtn";
            this.clrBtn.Size = new System.Drawing.Size(178, 23);
            this.clrBtn.TabIndex = 11;
            this.clrBtn.Text = "Clear Results";
            this.clrBtn.UseVisualStyleBackColor = true;
            this.clrBtn.Click += new System.EventHandler(this.ClrBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 319);
            this.Controls.Add(this.clrBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resultsBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.openBtn);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.progressPcntLbl);
            this.Controls.Add(this.matchCountLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchProgressBar);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchBox);
            this.Name = "Form1";
            this.Text = "File Search";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.ProgressBar searchProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label matchCountLbl;
        private System.Windows.Forms.Label progressPcntLbl;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Label filePath;
        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ListBox resultsBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clrBtn;
    }
}

