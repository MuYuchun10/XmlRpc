using CookComputing.XmlRpc;
using XmlRpcMatrixServer;

const string url = "http://localhost:5050/";

var listener = new HttpListener();
listener.Prefixes.Add(url);
listener.Start();

Console.WriteLine($"XML-RPC server started at {url}");
Console.WriteLine("Press Ctrl+C to stop.");

while (true)
{
    var context = listener.GetContext();
    try
    {
        var service = new MatrixRpcService();
        service.ProcessRequest(context);
    }
    catch (XmlRpcFaultException ex)
    {
        context.Response.StatusCode = 500;
        await using var writer = new StreamWriter(context.Response.OutputStream);
        await writer.WriteAsync($"XML-RPC Fault: {ex.FaultCode} - {ex.FaultString}");
        context.Response.Close();
    }
    catch (Exception ex)
    {
        context.Response.StatusCode = 500;
        await using var writer = new StreamWriter(context.Response.OutputStream);
        await writer.WriteAsync($"Server error: {ex.Message}");
        context.Response.Close();
    }
}
