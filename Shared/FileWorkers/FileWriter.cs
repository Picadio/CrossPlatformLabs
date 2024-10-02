namespace Shared.FileWorkers;

public class FileWriter(string path)
{
    public void Write(string line)
    {
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }
        using var streamWriter = new StreamWriter(path);
        
        streamWriter.WriteLine(line);
    }
}