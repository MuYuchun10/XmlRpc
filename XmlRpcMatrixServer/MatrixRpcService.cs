using Horizon.XmlRpc.Core;
using Horizon.XmlRpc.Server;

namespace XmlRpcMatrixServer;

public interface IMatrixRpcContract
{
    [XmlRpcMethod("processMatrix")]
    MatrixProcessingResult ProcessMatrix(int[][] matrix);
}

public sealed class MatrixRpcService : XmlRpcListenerService, IMatrixRpcContract
{
    [XmlRpcMethod("processMatrix")]
    public MatrixProcessingResult ProcessMatrix(int[][] matrix)
    {
        MatrixValidator.EnsureValidSquare(matrix);
        return MatrixProcessor.Process(matrix);
    }
}
