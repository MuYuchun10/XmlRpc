using System.Net;
using XmlRpcMatrixServer;

const string url = "http://localhost:5050/";

using var listener = new HttpListener();
listener.Prefixes.Add(url);
listener.Start();

Console.WriteLine($"XML-RPC server started at {url}");
Console.WriteLine("Press Ctrl+C to stop.");

while (true)
{
    try
    {
        var context = listener.GetContext();
        var service = new MatrixRpcService();

        // XmlRpcListenerService формирует корректный XML-RPC response,
        // включая fault-ответы для XmlRpcFaultException.
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
