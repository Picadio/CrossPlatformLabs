using Lab3.Util;

namespace Lab3.Tests;

public class UnitTest1
{
    [Fact]
    public void TestParser()
    {
        var lines = new List<string?> { "1 1", ".", "1 1 1 1" };
        var parser = new Parser(lines);
        parser.Parse();
        Assert.True(parser.IsDataCorrect);
    }
    [Fact]
    public void TestParser2()
    {
        var lines = new List<string?> { "1 a", ".", "1 1 1 1" };
        var parser = new Parser(lines);
        parser.Parse();
        Assert.False(parser.IsDataCorrect);
    }
    [Fact]
    public void TestParser3()
    {
        var lines = new List<string?> { "1 1", "...da", "1 1 1 1" };
        var parser = new Parser(lines);
        parser.Parse();
        Assert.False(parser.IsDataCorrect);
    }
    [Fact]
    public void TestGraph()
    {
        var graph = new Graph();
        graph.AddEdge(1, 2, false);
        graph.AddEdge(2, 3, false);
        graph.AddEdge(3, 4, false);
        graph.AddEdge(4, 5, false);
        graph.AddEdge(5, 6, false);
        graph.AddEdge(3, 6, false);
        var distances = graph.BreadthFirstSearch(1);
        Assert.True(distances[6] == 3);
    }
    [Fact]
    public void TestGraph2()
    {
        var graph = new Graph();
        graph.AddEdge(1, 2, false);
        graph.AddEdge(2, 3, false);
        graph.AddEdge(3, 4, false);
        graph.AddEdge(4, 5, false);
        graph.AddEdge(7, 6, false);
        var distances = graph.BreadthFirstSearch(1);
        Assert.True(distances[1] == 0);
    }
}