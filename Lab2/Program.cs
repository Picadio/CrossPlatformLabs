using Lab2.Util;
using Shared.FileWorkers;

namespace Lab2;

public class Program
{
    private static readonly string PathInput = Path.Combine(Path.GetFullPath("Lab2"), "Files", "INPUT.txt");
    private static readonly string PathOutput = Path.Combine(Path.GetFullPath("Lab2"), "Files", "OUTPUT.txt");
    public static void Main(string[] args)
    {
        var fileReader = new FileReader(PathInput);
        var lines = fileReader.ReadAllLines();
        var parser = new Parser(lines);
        parser.Parse();
        if (parser.IsDataCorrect)
        {
            var answer = Calculate(parser.N, parser.Matrix);
            var fileWriter = new FileWriter(PathOutput);
            fileWriter.Write(answer.ToString());
        }
        else
        {
            Console.WriteLine("Invalid data in input file");
        }
    }

    public static int Calculate(int n, int[,] matrix)
    {
        var dp = new int[n + 1, n + 1];
        dp[0, 0] = 0;
        for (var i = 1; i <= n; i++)
        {
            for (var j = 0; j <= n; j++)
            {
                dp[i, j] = dp[i - 1, j];
                for (var s = 1; s <= j; s++)
                {
                    dp[i, j] = Math.Max(dp[i, j], matrix[s-1, i-1] + dp[i - 1, j - s]);
                }
            }
        }

        return dp[n, n];
    }
}