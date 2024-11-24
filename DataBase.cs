using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace Math_Game_Server
{
    internal class DataBase
    {
        private static string dataBasePath = @"Data Source=.\SQLEXPRESS; Initial Catalog=Math_Game; Integrated Security=SSPI";
        public static DataTable show(String commandString)
        {
            DataTable dt = new DataTable();
            using(SqlConnection conn = new SqlConnection(dataBasePath))
            {
                using(SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = commandString;
                    try
                    {
                        conn.Open();
                        using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return dt;
        }
        public static int idNumber()
        {
            int amount = 0;
            using(SqlConnection conn = new SqlConnection(dataBasePath))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(*) FROM Users";
                    try
                    {
                        conn.Open();
                        amount = (int)command.ExecuteScalar();
                        conn.Close();
                        return amount;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return amount;
                    }
                }
            }
        }
        public static String userAdd(String commandString)
        {
            String response;
            using(SqlConnection conn = new SqlConnection(dataBasePath))
            {
                using(SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = commandString;
                    try
                    {
                        conn.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if(rowsAffected > 0)
                        {
                            response = "Success";
                        }
                        else
                        {
                            response = "Wrong Sql";
                        }
                    }
                    catch(SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        response = "Something whent wrong with the Sql";
                    }
                }
            }
            return response;
        }
        public static void delet(String commandString)
        {
            using (SqlConnection conn = new SqlConnection(dataBasePath))
            {
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = commandString;
                    try
                    {
                        conn.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if(rowsAffected > 0)
                        {
                            Console.WriteLine("Record deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No records were deleted.");
                        }
                    }
                    catch(SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
