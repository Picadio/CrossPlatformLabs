namespace Lab1;

public class FileReader(string path)
{
    public List<string?> ReadAllLines()
    {
        var lines = new List<string?>();
        using var streamReader = new StreamReader(path);

        while (streamReader.ReadLine() is {} line)
        {
            lines.Add(line);
        }

        return lines;
    }
}