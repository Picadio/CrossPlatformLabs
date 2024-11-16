using System.ComponentModel.DataAnnotations;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils;

namespace Lab4;
[Subcommand(typeof(VersionCommand), typeof(RunCommand), typeof(SetPathCommand))]
public class Program
{
    public static void Main(string[] args)
    {
        CommandLineApplication.Execute<Program>(args);
    }
    private void OnExecute()
    {
        Console.WriteLine("Select the command:");
        Console.WriteLine("dotnet run {labName} - run the application");
        Console.WriteLine("dotnet run version - display information about the application");
        Console.WriteLine("dotnet run set-path - set the default path to the lab directory");
    }
}
[Command(Name = "version", Description = "Display information about the application")]
class VersionCommand
{
    private void OnExecute()
    {
        Console.WriteLine("Author: Бедрик Олександр ІПЗ-32");
        Console.WriteLine("Version: 1.0");
    }
}
[Command(Name = "run", Description = "Run the application")]
class RunCommand
{
    [Argument(0, "lab", "Specify lab to run(lab1, lab2, lab3)")]
    [Required]
    public string? Lab { get; }
    
    [Option("-I|--input", "Input file",CommandOptionType.SingleValue)]
    public string? InputPath { get; private set; }
    [Option("-o|--output", "Output file",CommandOptionType.SingleValue)]
    public string? OutputPath { get; private set; }
    
    private void OnExecute()
    {
        try
        {
            var labExecutor = new LabExecutor(Lab, FindPath(InputPath, "input.txt"),
                FindPath(OutputPath, "output.txt"));
            labExecutor.Execute();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private string FindPath(string? definedPath, string fileName)
    {
        if (definedPath != null && File.Exists(definedPath))
        {
            return definedPath;
        }
        var env = Environment.GetEnvironmentVariable("LAB_PATH", EnvironmentVariableTarget.User);
        if (env != null && Directory.Exists(env))
        {
            var fullPath = Path.Combine(env, fileName);
            if (File.Exists(fullPath))
            {
                return fullPath;
            }
        }
        var homePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            fileName);

        if (File.Exists(homePath))
        {
            return homePath;
        }

        throw new Exception("File not found");
    }
    
}

[Command(Name = "set-path", Description = "Set the default path to the lab directory")]
class SetPathCommand
{
    [Option("-P|--path", "Folder with input/output file", CommandOptionType.SingleValue)]
    [Required]
    public string? Path { get; }
    
    private void OnExecute()
    {
        Environment.SetEnvironmentVariable("LAB_PATH", Path, EnvironmentVariableTarget.User);
        Console.WriteLine("Default path set: " + Path);
    }
}