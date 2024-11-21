using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Game_Server
{
    internal class Server
    {
        private HttpListener _httpListener;
        private string _prefix;

        public Server(string prefix)
        {
            _prefix = prefix;
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add(_prefix);
        }

        public void Start()
        {
            try
            {
                _httpListener.Start();
                Console.WriteLine($"Server started at {_prefix}");

                // Begin listening for client connections
                _httpListener.BeginGetContext(OnRequest, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting server: {ex.Message}");
                throw;
            }
        }

        public void Stop()
        {
            try
            {
                if (_httpListener != null && _httpListener.IsListening)
                {
                    _httpListener.Stop();
                    _httpListener.Close();
                    Console.WriteLine("Server stopped.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error stopping server: {ex.Message}");
            }
        }

        private void OnRequest(IAsyncResult result)
        {
            try
            {
                if (_httpListener == null || !_httpListener.IsListening) return;

                HttpListenerContext context = _httpListener.EndGetContext(result);
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                response.ContentType = "application/json";
                string jsonResponse = string.Empty;

                // Route the request based on the URL and HTTP method
                if (request.HttpMethod == "POST" && request.Url.AbsolutePath == "/register")
                {
                    // Handle user registration
                    using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        string requestBody = reader.ReadToEnd();
                        try
                        {
                            dynamic userData = Newtonsoft.Json.JsonConvert.DeserializeObject(requestBody);
                            string name = userData["name"]?.ToString();

                            if (!string.IsNullOrEmpty(name))
                            {
                                // Generate random ID
                                Random random = new Random();
                                int randomId = random.Next(100, 1000); // Generate a 3-digit random number
                                int userId = DataBase.idNumber();
                                string generatedUsername = $"{name}#" + userId;

                                // Insert into the database
                                string command = $"INSERT INTO Users (user_id, user_name) VALUES ({userId}, '{generatedUsername}')";
                                string resolt = DataBase.userAdd(command);

                                if (resolt.Equals("Success"))
                                {
                                    jsonResponse = $"{{\"username\": \"{generatedUsername}\"}}";
                                    response.StatusCode = (int)HttpStatusCode.Created;
                                }
                                else
                                {
                                    jsonResponse = "{\"error\": \"Failed to register user.\"}";
                                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                }
                            }
                            else
                            {
                                jsonResponse = "{\"error\": \"Name cannot be empty.\"}";
                                response.StatusCode = (int)HttpStatusCode.BadRequest;
                            }
                        }
                        catch (Exception ex)
                        {
                            jsonResponse = $"{{\"error\": \"Error processing registration: {ex.Message}\"}}";
                            response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        }
                    }

                }
                else if (request.HttpMethod == "GET" && request.Url.AbsolutePath == "/highscore")
                {
                    // Handle high score retrieval
                    try
                    {
                        string command = "SELECT TOP 1 Username, HighScore FROM Users ORDER BY HighScore DESC";
                        DataTable dt = DataBase.show(command);

                        if (dt.Rows.Count > 0)
                        {
                            var row = dt.Rows[0];
                            string username = row["Username"].ToString();
                            int highScore = Convert.ToInt32(row["HighScore"]);

                            jsonResponse = $"{{\"username\": \"{username}\", \"highscore\": {highScore}}}";
                            response.StatusCode = (int)HttpStatusCode.OK;
                        }
                        else
                        {
                            jsonResponse = "{\"message\": \"No high scores available.\"}";
                            response.StatusCode = (int)HttpStatusCode.NotFound;
                        }
                    }
                    catch (Exception ex)
                    {
                        jsonResponse = $"{{\"error\": \"Error retrieving high score: {ex.Message}\"}}";
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    }
                }
                else
                {
                    jsonResponse = "{\"error\": \"Endpoint not found.\"}";
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                }

                // Send the response
                byte[] buffer = Encoding.UTF8.GetBytes(jsonResponse);
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();

                Console.WriteLine($"Response sent: {jsonResponse}");

                // Keep listening for other requests
                _httpListener.BeginGetContext(OnRequest, null);
            }
            catch (HttpListenerException ex)
            {
                Console.WriteLine($"Listener error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
