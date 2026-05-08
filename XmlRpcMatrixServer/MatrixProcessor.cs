namespace XmlRpcMatrixServer;

public static class MatrixProcessor
{
    public static MatrixProcessingResult Process(int[][] matrix)
    {
        int size = matrix.Length;
        int[][] source = matrix.Select(row => row.ToArray()).ToArray();
        int[][] result = matrix.Select(row => row.ToArray()).ToArray();

        int mainMin = int.MaxValue;
        int secondaryMin = int.MaxValue;

        for (int i = 0; i < size; i++)
        {
            mainMin = Math.Min(mainMin, source[i][i]);
            secondaryMin = Math.Min(secondaryMin, source[i][size - 1 - i]);
        }

        bool mainSelected = mainMin <= secondaryMin;

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                if (mainSelected)
                {
                    if (row == col)
                    {
                        result[row][col] = 0;
                        continue;
                    }

                    if (row > col)
                    {
                        result[row][col] *= result[row][col];
                    }

                    continue;
                }

                if (row + col == size - 1)
                {
                    result[row][col] = 0;
                    continue;
                }

                if (row + col > size - 1)
                {
                    result[row][col] *= result[row][col];
                }
            }
        }

        return new MatrixProcessingResult
        {
            OriginalMatrix = source,
            ResultMatrix = result,
            MinimumElement = mainSelected ? mainMin : secondaryMin,
            SelectedDiagonal = mainSelected ? "Main" : "Secondary"
        };
    }
}
