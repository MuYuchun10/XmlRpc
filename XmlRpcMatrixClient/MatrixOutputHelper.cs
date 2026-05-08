namespace XmlRpcMatrixClient;

public static class MatrixOutputHelper
{
    public static void PrintResult(MatrixProcessingResultDto result)
    {
        Console.WriteLine("\nИсходная матрица:");
        PrintMatrix(result.OriginalMatrix);

        Console.WriteLine($"\nМинимальный элемент выбранной диагонали: {result.MinimumElement}");
        Console.WriteLine($"Выбранная диагональ: {result.SelectedDiagonal}");

        Console.WriteLine("\nРезультирующая матрица:");
        PrintMatrix(result.ResultMatrix);
    }

    private static void PrintMatrix(int[][] matrix)
    {
        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join("\t", row));
        }
    }
}
