namespace Lab2.Util;

public class Parser(List<string?> lines)
{
    public int N { get; private set; }
    public int[,] Matrix { get; private set; }
    public bool IsDataCorrect { get; private set; }
    public void Parse()
    {
        if (lines.Count == 0)
        {
            Console.WriteLine("File is empty");
            IsDataCorrect = false;
            return;
        }
        var lineIndex = 1;
        foreach (var line in lines)
        {
            if (lineIndex == 1)
            {
                IsDataCorrect = int.TryParse(line, out var firstNumber);
                N = firstNumber;
                Matrix = new int[N+1, N+1];
                if (N < 1 || N > 50)
                {
                    Console.WriteLine("N must be between 1 and 50");
                    IsDataCorrect = false;
                    return;
                }
            }
            else
            {
                if (line == null)
                {
                    Console.WriteLine("Line is empty");
                    IsDataCorrect = false;
                    return;
                }
                var numbersArr = line.Split(" ");
                if(numbersArr.Length == 1) continue;
                if (numbersArr.Length != N)
                {
                    Console.WriteLine("Count of columns not equal N");
                    IsDataCorrect = false;
                    return;
                }
                for (int columnIndex = 1; columnIndex <= N; columnIndex++)
                {
                    IsDataCorrect = int.TryParse(numbersArr[columnIndex - 1], out var matrixVal) && IsDataCorrect;
                    if (matrixVal < 1 || matrixVal > 50)
                    {
                        Console.WriteLine("The weight of the mosquito must be between 1 and 50");
                        IsDataCorrect = false;
                        return;
                    }
                    Matrix[lineIndex-1, columnIndex] = matrixVal;
                }
            }

            lineIndex++;
        }
    }
}