using CookComputing.XmlRpc;

namespace XmlRpcMatrixServer;

public static class MatrixValidator
{
    public static void ValidateMatrix(int[][]? matrix)
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

        for (int i = 0; i < size; i++)
        {
            if (matrix[i] is null)
            {
                throw new XmlRpcFaultException(102, $"Row {i} is null.");
            }

            if (matrix[i].Length != size)
            {
                throw new XmlRpcFaultException(103, "Matrix must be square.");
            }
        }
    }
}
