//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="LU">
//     Copyright (c) Shahood Mirza. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace FileSearcher
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// Main Program Class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// initializing form for threading
        /// </summary>
        private static Form1 myForm;

        /// <summary>
        /// initializing thread
        /// </summary>
        private static Thread t;

        /// <summary>
        /// boolean used to stop the executing thread (stop searching)
        /// </summary>
        private static bool threadCancel = false;
                
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            myForm = new Form1();
            myForm.StartOp += OnStartOp;
            myForm.CancelOp += OnCancelOp;

            Application.Run(myForm);
        }

        /// <summary>
        /// Starting the thread for the file searcher
        /// </summary>
        /// <param name="filePath">File to search within</param>
        /// <param name="searchTerm">Term to search for in the file</param>
        private static void OnStartOp(string filePath, string searchTerm)
        {
            threadCancel = false;
            t = new Thread(() => Callback(filePath, searchTerm));
            t.Start();
        }

        /// <summary>
        /// Ending the running thread (stopping the search)
        /// </summary>
        private static void OnCancelOp()
        {
            threadCancel = true;
        }

        /// <summary>
        /// Main searching method (threaded)
        /// </summary>
        /// <param name="filePath">File to search within</param>
        /// <param name="searchTerm">Term to search for in the file</param>
        private static void Callback(string filePath, string searchTerm)
        {
            int matchCounter = 0;
            string line;

            double currentLine = 1; // use doubles for line counter since we need it in percent calculations
            double totalLines = File.ReadLines(filePath).Count();

            // read the file line by line, check matches per line
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);

            Regex match = new Regex(searchTerm, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            while ((line = file.ReadLine()) != null && !threadCancel)
            {
                // create a match collection for all the matches in  line based on the typed regular expression
                MatchCollection matches = match.Matches(line);
                matchCounter += WriteMatches(line, matches, currentLine);

                // use invoke to ensure called method runs in the thread that controls it
                // here progress bar and progress percentage is updated
                myForm.Invoke((Action)(() => myForm.UpdateProgress((currentLine / totalLines) * 100, matchCounter)));
                currentLine++;
            }

            file.Close();
        }

        /// <summary>
        /// Executing and formatting the search and its results
        /// </summary>
        /// <param name="text">Current line to search through</param>
        /// <param name="matches">Collection of matches found</param>
        /// <param name="currentLine">Line number of the current line</param>
        /// <returns>Count of matches in the searched line</returns>
        private static int WriteMatches(string text, MatchCollection matches, double currentLine)
        {
            Console.WriteLine("No. of matches: " + matches.Count);
            foreach (Match nextMatch in matches)
            {
                // for each match we display 5 chars before and after (10 chars total)
                // we can then use this to display in the box of all found results
                int index = nextMatch.Index;
                string result = nextMatch.ToString();
                int charsBefore = (index < 5) ? index : 5;
                int fromEnd = text.Length - index - result.Length;
                int charsAfter = (fromEnd < 5) ? fromEnd : 5;
                int charsToDisplay = charsBefore + charsAfter + result.Length;

                // use invoke to ensure called method runs in the thread that controls it
                // here the results list is updated with matches
                myForm.Invoke((Action)(() => myForm.UpdateResultsList(text.Substring(index - charsBefore, charsToDisplay), (int)currentLine)));
            }

            return matches.Count;
        }
    }
}
