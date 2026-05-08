namespace XmlRpcMatrixServer;

public sealed class MatrixProcessingResult
{
    public int[][] OriginalMatrix { get; init; } = Array.Empty<int[]>();
    public int[][] ResultMatrix { get; init; } = Array.Empty<int[]>();
    public int MinimumElement { get; init; }
    public string SelectedDiagonal { get; init; } = "Main";
}
