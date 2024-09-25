
using Lab1;
using Lab1.Util;

public class Program()
{
    private static readonly string PathInput = Path.Combine(Path.GetFullPath("Lab1"), "Files", "INPUT.txt");
    private static readonly string PathOutput = Path.Combine(Path.GetFullPath("Lab1"), "Files", "OUTPUT.txt");
    public static void Main(String[] args)
    {
        if (!File.Exists(PathInput))
        {
            Console.WriteLine("Input file not exists");
            return;
        }
        var fileReader = new FileReader(PathInput);
        var lines = fileReader.ReadAllLines();
        var parser = new Parser(lines);
        if (parser.Parse())
        {
            var answerArray = Calculate(parser.N, parser.K);
            var answer = answerArray.Aggregate("", (current, i) => current + (i + " "));
            var fileWriter = new FileWriter(PathOutput);
            fileWriter.Write(answer);
        }
        else
        {
            Console.WriteLine("Invalid data in input file");
        }
    }

    public static int[] Calculate(int count, int number)
    {
        if (!ValidateUtil.Validate(count, number))
        {
            return new int[1];
        }
        var answerArray = new int[count];
        var allNumbers = MathUtil.GetFilledList(count);
        
        var indexInAnswerArray = 0;
        
        number--;
        
        for (var i = count-1; i >= 1; i--)
        {
            var factorial = MathUtil.Fact(i);
            var indexOfNumber = number / factorial;
            number %= factorial;
            
            answerArray[indexInAnswerArray] = allNumbers[indexOfNumber];
            allNumbers.Remove(answerArray[indexInAnswerArray]);
            Console.Write($"Answer array step {indexInAnswerArray + 1}: ");
            foreach (var i1 in answerArray)
            {
                 Console.Write(i1 + " ");
            }
            Console.WriteLine();
            indexInAnswerArray++;
        }

        answerArray[indexInAnswerArray] = allNumbers[0];
        Console.Write($"Answer array step {indexInAnswerArray + 1}: ");
        foreach (var i1 in answerArray)
        {
            Console.Write(i1 + " ");
        }
        Console.WriteLine();
        return answerArray;
    }
}
