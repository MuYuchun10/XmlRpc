using Horizon.XmlRpc.Core;

namespace XmlRpcMatrixClient;

public static class Program
{
    public static void Main()
    {
        const string serverUrl = "http://127.0.0.1:5050/";

        try
        {
            int[][] matrix = MatrixInputHelper.ReadSquareMatrix();
            MatrixProcessingResultDto result = MatrixRpcClient.ProcessMatrix(serverUrl, matrix);
            MatrixOutputHelper.PrintResult(result);
        }
        catch (XmlRpcFaultException ex)
        {
            Console.WriteLine($"XML-RPC Fault: {ex.FaultCode} - {ex.FaultString}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
