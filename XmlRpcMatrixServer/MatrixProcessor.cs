namespace XmlRpcMatrixServer;

public static class MatrixProcessor
{
    public static MatrixProcessingResult Process(int[][] matrix)
    {
        int n = matrix.Length;
        int[][] original = matrix.Select(row => row.ToArray()).ToArray();
        int[][] result = matrix.Select(row => row.ToArray()).ToArray();

        int mainMin = int.MaxValue;
        int secondaryMin = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            mainMin = Math.Min(mainMin, matrix[i][i]);
            secondaryMin = Math.Min(secondaryMin, matrix[i][n - 1 - i]);
        }

        bool useMain = mainMin <= secondaryMin;
        string selected = useMain ? "Main" : "Secondary";
        int minimum = useMain ? mainMin : secondaryMin;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (useMain)
                {
                    if (i == j)
                    {
                        result[i][j] = 0;
                    }
                    else if (i > j)
                    {
                        result[i][j] *= result[i][j];
                    }
                }
                else
                {
                    if (i + j == n - 1)
                    {
                        result[i][j] = 0;
                    }
                    else if (i + j > n - 1)
                    {
                        result[i][j] *= result[i][j];
                    }
                }
            }
        }

        return new MatrixProcessingResult
        {
            OriginalMatrix = original,
            ResultMatrix = result,
            MinimumElement = minimum,
            SelectedDiagonal = selected,
        };
    }
}
