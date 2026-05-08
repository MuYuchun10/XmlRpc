using CookComputing.XmlRpc;

namespace XmlRpcMatrixServer;

public interface IMatrixRpcService : IXmlRpcProxy
{
    [XmlRpcMethod("processMatrix")]
    MatrixProcessingResult ProcessMatrix(int[][] matrix);
}

public class MatrixRpcService : XmlRpcListenerService
{
    [XmlRpcMethod("processMatrix")]
    public MatrixProcessingResult ProcessMatrix(int[][]? matrix)
    {
        MatrixValidator.ValidateMatrix(matrix);
        return MatrixProcessor.Process(matrix!);
    }
}
