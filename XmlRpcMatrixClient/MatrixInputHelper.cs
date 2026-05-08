namespace XmlRpcMatrixClient;

public static class MatrixInputHelper
{
    public static int[][] ReadMatrixFromConsole()
    {
        Console.Write("Введите размер квадратной матрицы n (>0): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            throw new ArgumentException("Размер матрицы должен быть целым числом больше нуля.");
        }

        var matrix = new int[n][];
        Console.WriteLine("Введите элементы матрицы построчно (через пробел):");

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Строка {i + 1}: ");
            string? line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentException("Строка матрицы не должна быть пустой.");
            }

            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != n)
            {
                throw new ArgumentException($"В строке должно быть ровно {n} элементов.");
            }

            matrix[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                if (!int.TryParse(parts[j], out int value))
                {
                    throw new ArgumentException("Все элементы матрицы должны быть целыми числами.");
                }

                matrix[i][j] = value;
            }
        }

        return matrix;
    }
}
