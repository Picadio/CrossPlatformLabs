using Shared.FileWorkers;

namespace Lab4;

public class LabExecutor(string? lab, string inputPath, string outputPath)
{
    public void Execute()
    {
        switch (lab)
        {
            case "lab1":
                ExecuteLab1();
                break;
            case "lab2":
                ExecuteLab2();
                break;
            case "lab3":
                ExecuteLab3();
                break;
            default:
                break;
        }
    }

    private void ExecuteLab1()
    {
        var fileReader = new FileReader(inputPath);
        var lines = fileReader.ReadAllLines();
        var parser = new Lab1.Util.Parser(lines);
        parser.Parse();
        if (parser.IsDataCorrect)
        {
            var answerArray = Lab1.Program.Calculate(parser.N, parser.K);
            var answer = answerArray.Aggregate("", (current, i) => current + (i + " "));
            var fileWriter = new FileWriter(outputPath);
            fileWriter.Write(answer);
        }
        else
        {
            Console.WriteLine("Invalid data in input file");
        }
    }

    private void ExecuteLab2()
    {
        var fileReader = new FileReader(inputPath);
        var lines = fileReader.ReadAllLines();
        var parser = new Lab2.Util.Parser(lines);
        parser.Parse();
        if (parser.IsDataCorrect)
        {
            var answer = Lab2.Program.Calculate(parser.N, parser.Matrix);
            var fileWriter = new FileWriter(outputPath);
            fileWriter.Write(answer.ToString());
        }
        else
        {
            Console.WriteLine("Invalid data in input file");
        }
    }

    private void ExecuteLab3()
    {
        var fileReader = new FileReader(inputPath);
        var lines = fileReader.ReadAllLines();
        var parser = new Lab3.Util.Parser(lines);
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

            var fileWriter = new FileWriter(outputPath);
            fileWriter.WriteLines(answerLines);
        }
        else
        {
            Console.WriteLine("Invalid data in input file");
        }
    }
}