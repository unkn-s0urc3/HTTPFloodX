using System.Net;
using HTTPFloodX.Flooders.Interfaces;

namespace HTTPFloodX.Flooders
{
    // Class representing an HTTP request
    public class HTTPRequest : IHTTPRequest
    {
        // URL to send the request to and the number of the request
        private string _url;
        private int _requestNumber;

        // Constructor to initialize the URL and request number
        public HTTPRequest(string url, int requestNumber)
        {
            this._url = url;
            this._requestNumber = requestNumber;
        }

        // Method to send the HTTP request asynchronously
        public async Task<bool> SendRequestAsync()
        {
            try
            {
                // Create a WebClient instance to send the request
                WebClient client = new WebClient();
                
                // Asynchronously download the string from the specified URL
                await client.DownloadStringTaskAsync(_url);
                
                // Display a message indicating that the HTTP request has been sent
                Console.WriteLine($"Request flood: HTTP request sent: {_url}");
                
                // Return true to indicate successful sending of the request
                return true;
            }
            catch (Exception ex)
            {
                // If an exception occurs, display an error message
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Request flood: Error sending HTTP request: {ex.Message}");
                
                // Return false to indicate failure in sending the request
                return false;
            }
        }
    }
}