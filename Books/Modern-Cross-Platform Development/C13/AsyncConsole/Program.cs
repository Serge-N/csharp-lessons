using System.Net.Http;
using System.Threading.Tasks;
using static System.Console;

namespace AsyncConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://www.apple.com/");
            
            WriteLine("Apple's home page has {0:N0} Kilobytes.", response.Content.Headers.ContentLength/1024);

            // Do not perform long-running tasks on the UI thread.

            // Do not access UI elements on any thread except the UI thread.
        }
    }
}
