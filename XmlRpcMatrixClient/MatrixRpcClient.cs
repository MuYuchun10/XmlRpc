using Horizon.XmlRpc.Client;
using Horizon.XmlRpc.Core;

namespace XmlRpcMatrixClient;

public interface IMatrixRpcProxy : IXmlRpcProxy
{
    [XmlRpcMethod("processMatrix")]
    MatrixProcessingResultDto ProcessMatrix(int[][] matrix);
}

public static class MatrixRpcClient
{
    public static MatrixProcessingResultDto ProcessMatrix(string endpointUrl, int[][] matrix)
    {
        IMatrixRpcProxy proxy = XmlRpcProxyGen.Create<IMatrixRpcProxy>();
        proxy.Url = endpointUrl;
        return proxy.ProcessMatrix(matrix);
    }
}

public sealed class MatrixProcessingResultDto
{
    public int[][] OriginalMatrix { get; set; } = Array.Empty<int[]>();
    public int[][] ResultMatrix { get; set; } = Array.Empty<int[]>();
    public int MinimumElement { get; set; }
    public string SelectedDiagonal { get; set; } = "Main";
}
