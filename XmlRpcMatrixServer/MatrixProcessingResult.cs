namespace XmlRpcMatrixServer;

public class MatrixProcessingResult
{
    public int[][] OriginalMatrix { get; set; } = Array.Empty<int[]>();

    public int[][] ResultMatrix { get; set; } = Array.Empty<int[]>();

    public int MinimumElement { get; set; }

    public string SelectedDiagonal { get; set; } = "Main";
}
