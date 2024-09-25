namespace Lab1.Util;

public class ValidateUtil
{
    public static bool Validate(int count, int number)
    {
        if (count < 1 || count > 12)
        {
            Console.WriteLine("Invalid value for N");
            return false;
        }

        if (number < 1 || number > MathUtil.Fact(count))
        {
            Console.WriteLine("Invalid value for K");
            return false;
        }

        return true;
    }
}