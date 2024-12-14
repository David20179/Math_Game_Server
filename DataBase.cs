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
        public static int idScore() 
        {
            int amount = 0;
            using(SqlConnection connection = new SqlConnection(dataBasePath))
            {
                using ( SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(*) FROM Scores";
                    try
                    {
                        connection.Open();
                        amount = (int)command.ExecuteScalar();
                        connection.Close();
                        return amount;
                    }
                    catch(SqlException ex)
                    {
                        Console.WriteLine("SqlException: " + ex);
                        return amount;
                    }
                }
            }
        }
        public static int userID(String username)
        {
            int userId = -1;
            using (SqlConnection connection = new SqlConnection(dataBasePath))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    try
                    {
                        command.CommandText = "SELECT user_id FROM Users WHERE user_name = \'" + username + "\'";
                        connection.Open();
                        userId = (int)command.ExecuteScalar();
                        connection.Close();
                        return userId;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SqlException: " + ex.Message);
                        return -1;
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
        public static String scoreAdd(int scoreID, int nameID, int score)
        {
            using(SqlConnection connection = new SqlConnection(dataBasePath))
            {
                using(SqlCommand command =  connection.CreateCommand())
                {
                    try
                    {
                        String sql = $"INSERT INTO Scores (score_id, user_id, score, date) VALUES ({scoreID + 1}, {nameID}, {score}, '{DateTime.Now.ToString("yyyy-MM-dd")}')";
                        Console.WriteLine("SQL: " + sql);
                        command.CommandText = sql;
                        connection.Open();
                        int rowAffected = command.ExecuteNonQuery();
                        if(rowAffected > 0)
                        {
                            Console.WriteLine("Success");
                            return "Success";
                        }
                        else
                        {
                            Console.WriteLine("Faild");
                            return "Faild";
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SqlException: " + ex);
                        return "Something whent wrong with the Sql";
                    }
                }
            }
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
        public static String highScores()
        {
            using (SqlConnection connection = new SqlConnection(dataBasePath))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT TOP 5 user_name, score, date FROM Scores INNER JOIN Users ON Scores.user_id = Users.user_id ORDER BY score DESC;";
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            String data = "[";
                            Boolean first = true;
                            while (reader.Read())
                            {
                                if (first)
                                {
                                    first = false;
                                }
                                else
                                {
                                    data += ",";
                                }
                                String formatedDate = "";
                                if (reader["date"] != DBNull.Value)
                                {
                                    DateTime datetime = Convert.ToDateTime(reader["date"]);
                                    formatedDate = datetime.ToString("dd/MM/yyyy");
                                }
                                data += "{\"USER_NAME\": \"" + reader["user_name"].ToString() + "\", ";
                                data += "\"Score\": " + reader["score"].ToString() + ", ";
                                data += "\"Date\": \"" + formatedDate + "\"} ";
                            }
                            data += "]";
                            return data;
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
            }
        }
    }
}
