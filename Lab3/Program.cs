using Lab3.Util;
using Shared.FileWorkers;

public class Program
{
    private static readonly string PathInput = Path.Combine(Path.GetFullPath("Lab3"), "Files", "INPUT.txt");
    private static readonly string PathOutput = Path.Combine(Path.GetFullPath("Lab3"), "Files", "OUTPUT.txt");

    public static void Main(string[] args)
    {
        var fileReader = new FileReader(PathInput);
        var lines = fileReader.ReadAllLines();
        var parser = new Parser(lines);
        parser.Parse();
        if (parser.IsDataCorrect)
        {
            var lab3 = parser.Lab3;
            lab3.BuildGraph();
            var answerLines = new List<string>();
            foreach (var query in parser.Queries)
            {
                var answer = lab3.Calculate(query.X1, query.Y1, query.X2, query.Y2);
                answerLines.Add(answer.ToString());
            }

            var fileWriter = new FileWriter(PathOutput);
            fileWriter.WriteLines(answerLines);
        }
        else
        {
            Console.WriteLine("Invalid data in input file");
        }
    }
}