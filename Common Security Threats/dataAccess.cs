namespace Threats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data;     
    using System.Web;
    using Npgsql;
    using NpgsqlTypes;

    /// <summary>
    /// Summary description for dataAccess
    /// </summary>
    public class dataAccess
    {
        public dataAccess() {}

	    public static void CreateSafe(string name, string GPA)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432; Database=Test.MainDB; User Id=postgres; Password=testing;");
            
            conn.Open();

            using (NpgsqlCommand command = new NpgsqlCommand("insert into students (name, gpa) values (:nameP, :GPAP)", conn))
            {
                command.Parameters.Add(new NpgsqlParameter("nameP", NpgsqlDbType.Varchar));
                command.Parameters.Add(new NpgsqlParameter("GPAP", NpgsqlDbType.Real));
                
                command.Parameters[0].Value = name;
                command.Parameters[1].Value = Convert.ToSingle(GPA);                
                    
                int rowsaffected;

                try
                {
                    rowsaffected = command.ExecuteNonQuery();

                    Console.WriteLine("It was added {0} lines in the table animals", rowsaffected);
                }
                finally
                {
                    conn.Close();
                }
            }            
        }

        public static void CreateUnsafe(string name, string GPA) 
        {
            float gpaP = Convert.ToSingle(GPA); 

            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432; Database=Test.MainDB; User Id=postgres; Password=testing;");

            conn.Open();

            using (NpgsqlCommand command = new NpgsqlCommand("insert into students (name, gpa) values ('" + name + "'," + gpaP + ")", conn))
            {
                int rowsaffected;

                try
                {
                    rowsaffected = command.ExecuteNonQuery();

                    Console.WriteLine("It was added {0} lines in the table animals", rowsaffected);
                }

                finally
                {
                    conn.Close();
                }
            }  
        }

        public static List<student> Read()
        {
            List<student> list_students = new List<student>();

            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432; Database=Test.MainDB; User Id=postgres; Password=testing;");

            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("select * from students order by id", conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list_students.Add(new student { Id = (int)reader[0], Name = (string)reader[1], Gpa = (float)reader[2]});
            }

            conn.Close();

            return list_students;
        }

        public static List<float> readGPAs()
        {
            List<float> GPAList= new List<float>();

            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1; Port=5432; Database=Test.MainDB; User Id=postgres; Password=testing;");

            conn.Open();

            NpgsqlCommand cmd = new NpgsqlCommand("select GPA from students", conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                GPAList.Add((float)reader[0]);
            }

            conn.Close();       

            return GPAList;
        }
        
    }
}
