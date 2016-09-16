//-----------------------------------------------------------------------
// <copyright file="Form1.cs" company="LU">
//     Copyright (c) Shahood Mirza. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FileSearcher
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// This class contains the main UI form for the application
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the Form1 class
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        /// <summary>
        /// Action event for starting threaded operations
        /// </summary>
        public event Action<string, string> StartOp;

        /// <summary>
        /// Action event for ending threaded operations
        /// </summary>
        public event Action CancelOp;

        /// <summary>
        /// Update list of results from search
        /// </summary>
        /// <param name="matchLine">string where the match was found</param>
        /// <param name="lineNumber">line number of the matched string</param>
        public void UpdateResultsList(string matchLine, int lineNumber)
        {
            this.resultsBox.Items.Add("Line " + lineNumber + ": " + matchLine);
        }

        /// <summary>
        /// Update progress bar and match count
        /// </summary>
        /// <param name="progress">progress percentage (out of 100)</param>
        /// <param name="matchCount">number of total matches found</param>
        public void UpdateProgress(double progress, int matchCount)
        {
            this.matchCountLbl.Text = matchCount.ToString();
            this.progressPcntLbl.Text = ((int)progress).ToString() + "%";
            this.searchProgressBar.Value = (int)progress;

            if (progress >= 100)
            {
                this.Cursor = Cursors.Default;
                this.searchBtn.Enabled = true;
                this.openBtn.Enabled = true;
                this.clrBtn.Enabled = true;
                this.cancelBtn.Enabled = false;
            }
        }

        /// <summary>
        /// Commands to run when form is initially loaded
        /// </summary>
        /// <param name="sender">default sender object</param>
        /// <param name="e">default event args</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.searchBtn.Enabled = false;
            this.cancelBtn.Enabled = false;
        }

        /// <summary>
        /// Begin search when user presses search button
        /// </summary>
        /// <param name="sender">default sender object</param>
        /// <param name="e">default event args</param>
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            this.UpdateProgress(0, 0);

            this.searchBtn.Enabled = false;
            this.openBtn.Enabled = false;
            this.clrBtn.Enabled = false;
            this.cancelBtn.Enabled = true;

            this.resultsBox.Items.Clear();

            this.Cursor = Cursors.AppStarting;

            if (this.StartOp != null)
            {
                this.StartOp(this.ofd.FileName, this.searchBox.Text);
            }
        }
                
        /// <summary>
        /// Open file dialog when user presses open button
        /// </summary>
        /// <param name="sender">default sender object</param>
        /// <param name="e">default event args</param>
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Data Files|*.txt;*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath.Text = ofd.SafeFileName;
                searchBtn.Enabled = true;
            }
        }

        /// <summary>
        /// Cancel search when user presses stop button
        /// </summary>
        /// <param name="sender">default sender object</param>
        /// <param name="e">default event args</param>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (this.CancelOp != null)
            {
                this.CancelOp();
                this.Cursor = Cursors.Default;
                searchBtn.Enabled = true;
                clrBtn.Enabled = true;
                openBtn.Enabled = true;
                cancelBtn.Enabled = false;
            }
        }

        /// <summary>
        /// Clear results list when user presses clear button
        /// </summary>
        /// <param name="sender">default sender object</param>
        /// <param name="e">default event args</param>
        private void ClrBtn_Click(object sender, EventArgs e)
        {
            resultsBox.Items.Clear();
        }
    }
}
