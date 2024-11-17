namespace Lab3.Util;

public class Parser(List<string?> lines)
{
    public List<Query> Queries{ get; } = new();
    public Lab3 Lab3 { get; private set; }
    public bool IsDataCorrect { get; private set; } = false;
    
    public void Parse()
    {
        int h = 0, w = 0;
        char[,] board = new char[1,1];
        if (lines.Count == 0)
        {
            Console.WriteLine("File is empty");
            return;
        }

        var lineIndex = 1;
        foreach (var line in lines)
        {
            if (line == null)
            {
                Console.WriteLine("Empty line");
                return;
            }
            var array = line.Split(" ");
            if (lineIndex == 1)
            {
                if (array.Length != 2)
                {
                    Console.WriteLine("First line must have 2 numbers");
                    return;
                }
                if (!int.TryParse(array[0], out w))
                {
                    Console.WriteLine("W must be a number");
                    return;
                }
                if (!int.TryParse(array[1], out h))
                {
                    Console.WriteLine("H must be a number");
                    return;
                }

                board = new char[h, w];
            }
            else if(lineIndex > 1 && lineIndex <= h+1)
            {
                

                for (var columnIndex = 0; columnIndex < w; columnIndex++)
                {
                    if (line[columnIndex] != '.' && line[columnIndex] != 'X')
                    {
                        Console.WriteLine("Board must have only . or X");
                        return;
                    }
                    board[lineIndex-2, columnIndex] = line[columnIndex];
                }
            }
            else
            {
                if (array.Length != 4)
                {
                    Console.WriteLine("Query must have 4 numbers");
                    return;
                }

                int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
              
                if (!int.TryParse(array[0], out x1))
                {
                    return;
                }
                if (!int.TryParse(array[1], out y1))
                {
                    return;
                }
                if (!int.TryParse(array[2], out x2))
                {
                    return;
                }
                if (!int.TryParse(array[3], out y2))
                {
                    return;
                }
                
                if(x1 == y1 && x1 == x2 && x1 == y2 && x1 == 0) break;
                Queries.Add(new Query(x1, y1, x2, y2));
            }
            lineIndex++;
        }

        if (Queries.Count == 0)
        {
            return;
        }
        IsDataCorrect = true;
        Lab3 = new Lab3(h, w, board);
    }
}