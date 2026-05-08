namespace XmlRpcMatrixClient;

public static class MatrixInputHelper
{
    public static int[][] ReadSquareMatrix()
    {
        Console.Write("Введите размер квадратной матрицы n (>0): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            throw new ArgumentException("Размер матрицы должен быть целым числом больше нуля.");
        }

        var matrix = new int[n][];
        Console.WriteLine("Введите элементы матрицы построчно через пробел:");

        for (int row = 0; row < n; row++)
        {
            Console.Write($"Строка {row + 1}: ");
            string? line = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentException("Строка матрицы не должна быть пустой.");
            }

            string[] values = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (values.Length != n)
            {
                throw new ArgumentException($"В строке должно быть ровно {n} элементов.");
            }

            matrix[row] = new int[n];
            for (int col = 0; col < n; col++)
            {
                if (!int.TryParse(values[col], out int parsed))
                {
                    throw new ArgumentException("Все элементы матрицы должны быть целыми числами.");
                }

                matrix[row][col] = parsed;
            }
        }

        return matrix;
    }
}
