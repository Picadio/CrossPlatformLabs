namespace Lab1;

public class Parser(List<string?> lines)
{
    public int N { get; private set; }
    public int K { get; private set; }

    public bool Parse()
    {
        if (lines.Count != 2)
        {
            return false;
        }
        var isParsed = int.TryParse(lines[0], out var firstNumber);
        isParsed = int.TryParse(lines[1], out var secondNumber) && isParsed;
        N = firstNumber;
        K = secondNumber;
        return isParsed;

    }
}