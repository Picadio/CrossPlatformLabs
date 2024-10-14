using Lab2.Util;

namespace Lab2.Tests;

public class UnitTest1
{
    [Fact]
    public void TestCalculate()
    {
        var answer = Program.Calculate(3, new [,]{{8, 2, 1}, {1, 2, 6}, {2, 7, 2}});
        Assert.True(answer == 14);
    }
    [Fact]
    public void TestCalculate2()
    {
        var answer = Program.Calculate(1, new [,]{{1}});
        Assert.True(answer == 1);
    }
    [Fact]
    public void TestCalculate3()
    {
        var answer = Program.Calculate(2, new [,]{{1, 3}, {3, 2}});
        Assert.True(answer == 4);
    }
    [Fact]
    public void TestCalculate4()
    {
        var answer = Program.Calculate(4, new [,]{{1, 3, 5, 6}, {3, 2, 3, 2}, {1, 2, 3, 4}, {10, 12, 100, 1}});
        Assert.True(answer == 100);
    }
    [Fact]
    public void TestParser()
    {
        var lines = new List<string?> { "1", "1" };
        var parser = new Parser(lines);
        parser.Parse();
        Assert.True(parser.IsDataCorrect);
        lines.Add("wd");
        parser.Parse();
        Assert.False(parser.IsDataCorrect);
        lines.Remove("wd");
        lines.Add("3");
        parser.Parse();
        Assert.False(parser.IsDataCorrect);
    }
}