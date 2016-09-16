namespace Threats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;     

    /// <summary>
    /// Summary description for student
    /// </summary>
    public class student
    {
        /// <summary>
        /// Stores student ID
		/// </summary> 
        private int id;

        /// <summary>
        /// Stores student name
		/// </summary> 
        private string name;

        /// <summary>
        /// Stores student GPA
		/// </summary> 
        private float GPA;

        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Gets or sets GPA
        /// </summary>
        public float Gpa
        {
            get
            {
                return GPA;
            }

            set
            {
                GPA = value;
            }
        }
    }
}
