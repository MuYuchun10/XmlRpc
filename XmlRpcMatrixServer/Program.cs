using System.Net;

namespace XmlRpcMatrixServer;

public static class Program
{
    public static void Main()
    {
        const string url = "http://127.0.0.1:5050/";

        using var listener = new HttpListener();
        listener.Prefixes.Add(url);
        listener.Start();

        Console.WriteLine($"Horizon XML-RPC server started at {url}");
        Console.WriteLine("Press Ctrl+C to stop.");

        while (true)
        {
            try
            {
                HttpListenerContext context = listener.GetContext();
                var service = new MatrixRpcService();
                service.ProcessRequest(context);
            }
            catch (HttpListenerException ex)
            {
                Console.WriteLine($"HTTP listener error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected server error: {ex.Message}");
            }
        }
    }
}
