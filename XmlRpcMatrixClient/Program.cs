using CookComputing.XmlRpc;
using XmlRpcMatrixClient;

const string serverUrl = "http://localhost:5050/";

try
{
    int[][] matrix = MatrixInputHelper.ReadMatrixFromConsole();
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
