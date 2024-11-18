using System;
using System.Collections.Generic;
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

                // Get the incoming request
                HttpListenerContext context = _httpListener.EndGetContext(result);
                HttpListenerRequest request = context.Request;

                Console.WriteLine($"Request received: {request.HttpMethod} {request.Url}");

                // Respond to the client
                HttpListenerResponse response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.OK;

                // Create the JSON message
                string jsonResponse = "{ \"message\": \"Good morning\" }";

                // Write the JSON to the response
                byte[] buffer = Encoding.UTF8.GetBytes(jsonResponse);
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();

                Console.WriteLine("Response sent successfully.");

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
