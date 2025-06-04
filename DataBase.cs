using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

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
        public static String getHighScores(dynamic scoredata)
        {
            Console.WriteLine("Received high score request");
            String userName = scoredata["USER_NAME"]?.ToString();
            Console.WriteLine(userName);
            String upload = scoredata["upload"]?.ToString();
            Console.WriteLine(upload);
            using (SqlConnection connection = new SqlConnection(dataBasePath))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    if (upload.Equals("true", StringComparison.OrdinalIgnoreCase))
                    {
                        int scoreID = idScore() + 1;
                        try
                        {
                            JArray scoresArray = scoredata["scores"] as JArray;
                            String sql = $"INSERT INTO Scores (score_id, user_id, score, date) VALUES ";
                            String[] splitedName = new string[2];
                            var valuesList = new List<string>();
                            foreach (JObject scoreObject in scoresArray)
                            {
                                String name = scoreObject["name"]?.ToString();
                                Console.WriteLine(name);
                                Console.WriteLine(name);
                                Console.WriteLine(name);
                                if (name == null)
                                {
                                    goto Skipped;
                                }
                                splitedName = name.Split('#');
                                int score = ( (int) scoreObject["score"]);
                                String date = scoreObject["date"]?.ToString();

                                valuesList.Add($"('{scoreID}', '{splitedName[1]}', '{score}', '{date}')");
                                scoreID++;
                            }
                            sql += string.Join(",", valuesList);
                            connection.Open();
                            command.CommandText = sql;
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex);
                        }

                    }
                    Skipped: 
                    command.CommandText = "SELECT TOP 5 user_name, score, date FROM Scores INNER JOIN Users ON Scores.user_id = Users.user_id ORDER BY score DESC;";
                    String formatedDate = "";
                    String data = "{ \"Scores\": [";
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["date"] != DBNull.Value && reader["date"] is DateTime)
                                {
                                    DateTime datetime = Convert.ToDateTime(reader["date"]);
                                    formatedDate = datetime.ToString("dd/MM/yyyy");
                                }
                                data += "{\"USER_NAME\": \"" + reader["user_name"].ToString() + "\", ";
                                data += "\"Score\": " + reader["score"].ToString() + ", ";
                                data += "\"Date\": \"" + formatedDate + "\"}, ";
                            }
                            connection.Close();
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                    if (userName == null)
                    {
                        goto Valami;
                    }
                    if (userName != null || !userName.Equals("Guest"))
                    {
                        try
                        {
                            connection.Open();
                            command.CommandText = "SELECT TOP 1 user_name, score, date FROM Scores INNER JOIN Users ON Scores.user_id = Users.user_id WHERE user_name = \'" + userName + "\';";
                            using (SqlDataReader readUser = command.ExecuteReader())
                            {
                                readUser.Read();
                                if (readUser["date"] != DBNull.Value)
                                {
                                    DateTime datetime = Convert.ToDateTime(readUser["date"]);
                                    formatedDate = datetime.ToString("dd/MM/yyyy");
                                }
                                data += "{\"USER_NAME\": \"" + readUser["user_name"].ToString() + "\", ";
                                data += "\"Score\": " + readUser["score"].ToString() + ", ";
                                data += "\"Date\": \"" + formatedDate + "\"}";
                            }
                            connection.Close();
                            data += "]}";
                            Console.WriteLine(data);
                            return data;
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine(data);
                            return null;
                        }
                    }
                    Valami:
                    int lstIndex = data.LastIndexOf(", ");
                    data = data.Remove(lstIndex, 2);
                    data += "]}";
                    return data;
                }
            }
        }
    }
}
