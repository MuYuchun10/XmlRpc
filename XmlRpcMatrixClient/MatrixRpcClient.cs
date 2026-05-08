using CookComputing.XmlRpc;

namespace XmlRpcMatrixClient;

public interface IMatrixRpcProxy : IXmlRpcProxy
{
    [XmlRpcMethod("processMatrix")]
    MatrixProcessingResultDto ProcessMatrix(int[][] matrix);
}

public static class MatrixRpcClient
{
    public static MatrixProcessingResultDto ProcessMatrix(string serverUrl, int[][] matrix)
    {
        var proxy = XmlRpcProxyGen.Create<IMatrixRpcProxy>();
        proxy.Url = serverUrl;
        return proxy.ProcessMatrix(matrix);
    }
}

public class MatrixProcessingResultDto
{
    public int[][] OriginalMatrix { get; set; } = Array.Empty<int[]>();

    public int[][] ResultMatrix { get; set; } = Array.Empty<int[]>();

    public int MinimumElement { get; set; }

    public string SelectedDiagonal { get; set; } = "Main";
}
