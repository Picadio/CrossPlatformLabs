namespace Lab1.Util;

public class Parser(List<string?> lines)
{
    public int N { get; private set; }
    public int K { get; private set; }
    public bool IsDataCorrect { get; private set; }
    public void Parse()
    {
        if (lines.Count != 2)
        {
            IsDataCorrect = false;
            return;
        }
        var isParsed = int.TryParse(lines[0], out var firstNumber);
        isParsed = int.TryParse(lines[1], out var secondNumber) && isParsed;
        N = firstNumber;
        K = secondNumber;
        IsDataCorrect = isParsed;
    }
}