namespace Lab1.Util;

public class MathUtil
{
    public static int Fact(int n)
    {
        var factorial = 1;
        for (var i = 2; i <= n; i++)
        {
            factorial *= i;
        }

        return factorial;
    }
    public static List<int> GetFilledList(int n)
    {
        var allNumbers = new List<int>();
        for (var i = 1; i <= n; i++)
        {
            allNumbers.Add(i);
        }

        return allNumbers;
    }
}