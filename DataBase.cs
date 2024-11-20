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
    }
}
