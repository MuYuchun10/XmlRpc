using Horizon.XmlRpc.Core;

namespace XmlRpcMatrixServer;

public static class MatrixValidator
{
    public static void EnsureValidSquare(int[][]? matrix)
    {
        if (matrix is null)
        {
            throw new XmlRpcFaultException(100, "Matrix must not be null.");
        }

        if (matrix.Length == 0)
        {
            throw new XmlRpcFaultException(101, "Matrix must not be empty.");
        }

        int size = matrix.Length;
        for (int row = 0; row < size; row++)
        {
            if (matrix[row] is null)
            {
                throw new XmlRpcFaultException(102, $"Row {row} is null.");
            }

            if (matrix[row].Length != size)
            {
                throw new XmlRpcFaultException(103, "Matrix must be square.");
            }
        }
    }
}
