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
                    jsonResponse = HandlePostRegister(request, out int statusCode);
                    response.StatusCode = statusCode;
                }
                else if (request.HttpMethod == "GET" && request.Url.AbsolutePath == "/highscore")
                {
                    jsonResponse = HandleGetHighScore(out int statusCode);
                    response.StatusCode = statusCode;
                }
                else if (request.HttpMethod == "GET" && request.Url.AbsolutePath == "/connection")
                {
                    jsonResponse = HandleConnectionTest(out int statusCode);
                    response.StatusCode = statusCode;
                }
                else
                {
                    jsonResponse = "{\"error\": \"Endpoint not found.\"}";
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                }

                // Send the response
                SendResponse(response, jsonResponse);

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

        private string HandlePostRegister(HttpListenerRequest request, out int statusCode)
        {
            try
            {
                using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    string requestBody = reader.ReadToEnd();
                    dynamic userData = Newtonsoft.Json.JsonConvert.DeserializeObject(requestBody);
                    string name = userData["name"]?.ToString();

                    if (!string.IsNullOrEmpty(name))
                    {
                        int userId = DataBase.idNumber();
                        string generatedUsername = $"{name}#" + userId;

                        // Insert into the database
                        string command = $"INSERT INTO Users (user_id, user_name) VALUES ({userId}, '{generatedUsername}')";
                        string result = DataBase.userAdd(command);

                        if (result.Equals("Success"))
                        {
                            statusCode = (int)HttpStatusCode.Created;
                            return $"{{\"username\": \"{generatedUsername}\"}}";
                        }
                        else
                        {
                            statusCode = (int)HttpStatusCode.InternalServerError;
                            return "{\"error\": \"Failed to register user.\"}";
                        }
                    }
                    else
                    {
                        statusCode = (int)HttpStatusCode.BadRequest;
                        return "{\"error\": \"Name cannot be empty.\"}";
                    }
                }
            }
            catch (Exception ex)
            {
                statusCode = (int)HttpStatusCode.InternalServerError;
                return $"{{\"error\": \"Error processing registration: {ex.Message}\"}}";
            }
        }

        private string HandleGetHighScore(out int statusCode)
        {
            try
            {
                string command = "SELECT TOP 1 Username, HighScore FROM Users ORDER BY HighScore DESC";
                DataTable dt = DataBase.show(command);

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    string username = row["Username"].ToString();
                    int highScore = Convert.ToInt32(row["HighScore"]);

                    statusCode = (int)HttpStatusCode.OK;
                    return $"{{\"username\": \"{username}\", \"highscore\": {highScore}}}";
                }
                else
                {
                    statusCode = (int)HttpStatusCode.NotFound;
                    return "{\"message\": \"No high scores available.\"}";
                }
            }
            catch (Exception ex)
            {
                statusCode = (int)HttpStatusCode.InternalServerError;
                return $"{{\"error\": \"Error retrieving high score: {ex.Message}\"}}";
            }
        }

        private string HandleConnectionTest(out int statusCode)
        {
            statusCode = (int)HttpStatusCode.OK;
            return "{\"message\": \"Connected\"}";
        }

        private void SendResponse(HttpListenerResponse response, string jsonResponse)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(jsonResponse);
            response.ContentLength64 = buffer.Length;

            using (Stream output = response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
            }

            Console.WriteLine($"Response sent: {jsonResponse}");
        }
    }
}
