using Lab1.Util;

namespace Lab1.Tests;

public class Lab1Tests
{
    [Fact]
    public void TestFactorial()
    {
        Assert.True(MathUtil.Fact(5) == 120);
        Assert.True(MathUtil.Fact(1) == 1);
        Assert.True(MathUtil.Fact(12) == 479001600);
        Assert.True(MathUtil.Fact(3) == 6);
    }
    [Fact]
    public void TestParser()
    {
        var lines = new List<string?> { "1", "2" };
        var parser = new Parser(lines);
        Assert.True(parser.Parse());
        lines.Add("wd");
        Assert.False(parser.Parse());
        lines.Remove("wd");
        lines.Add("3");
        Assert.False(parser.Parse());
    }
    [Fact]
    public void TestCalculate()
    {
        var answer = Program.Calculate(3, 2);
        var answerStr = answer.Aggregate("", (current, i) => current + (i + " "));
        Assert.True(answerStr.Trim() == "1 3 2");
    }
}