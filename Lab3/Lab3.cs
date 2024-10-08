using Lab3.Util;

namespace Lab3;

public class Lab3(int h, int w, char[,] board)
{
    private static Graph _graph = new();

    private void ExtendBoard(int extH, int extW)
    {
        h += extH;
        w += extW;
        var biggerBoard = new char[h,w];
        for (var i = 0; i < h; i++)
        {
            for (var j = 0; j < w; j++)
            {
                if (i == 0 || j == 0 || i == h - 1 || j == w - 1)
                {
                    biggerBoard[i, j] = '.';
                }
                else
                {
                    biggerBoard[i, j] = board[i - 1, j - 1];
                }
            }
        }

        board = biggerBoard;
    }
    public void BuildGraph()
    {
        ExtendBoard(2, 2);
        for (var i = 0; i < h; i++)
        {
            for (var j = 0; j < w; j++)
            {
                var currentIndex = CalcIndex(j, i);
                if (i != 0 && board[i-1, j] == '.')
                {
                    _graph.AddEdge(currentIndex, CalcIndex(j, i-1), board[i, j] == '.');
                }
                if (j != 0 && board[i, j-1] == '.')
                {
                    _graph.AddEdge(currentIndex, CalcIndex(j-1, i), board[i, j] == '.');
                }
                if (j != w-1 && board[i, j+1] == '.')
                {
                    _graph.AddEdge(currentIndex, CalcIndex(j+1, i), board[i, j] == '.');
                }
                if (i != h-1 && board[i+1, j] == '.')
                {
                    _graph.AddEdge(currentIndex, CalcIndex(j, i+1), board[i, j] == '.');
                }
            }
        }
    }
    
    public int Calculate(int x1, int y1, int x2, int y2)
    {
        var distances = _graph.BreadthFirstSearch(CalcIndex(x1, y1));
        var answer = int.MaxValue;
        if (distances.ContainsKey(CalcIndex(x2, y2 - 1)))
        {
            answer = Math.Min(answer, distances[CalcIndex(x2, y2-1)]);
        }
        if (distances.ContainsKey(CalcIndex(x2, y2 + 1)))
        {
            answer = Math.Min(answer, distances[CalcIndex(x2, y2+1)]);
        }
        if (distances.ContainsKey(CalcIndex(x2-1, y2)))
        {
            answer = Math.Min(answer, distances[CalcIndex(x2-1, y2)]);
        }
        if (distances.ContainsKey(CalcIndex(x2+1, y2)))
        {
            answer = Math.Min(answer, distances[CalcIndex(x2+1, y2)]);
        }

        if (answer == int.MaxValue)
        {
            answer = -1;
        }
        return answer + 1;
    }

    private int CalcIndex(int x, int y)
    {
        return y * w + x;
    }
}