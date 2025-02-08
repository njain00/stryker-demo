using System.IO.Abstractions;

namespace DemoConsole;

public class Logger(IFileSystem fileSystem) : ILogger
{
    public virtual async Task Log(string message)
    {
        string path = "/home/nishant/Documents/workspace/dotnet-playground/StrykerDemo/logfile.txt";

        if (!File.Exists(path))
        {
            using (StreamWriter sw = fileSystem.File.CreateText(path))
            {
                await sw.WriteLineAsync(message);
            }
            Console.WriteLine(message);
            return;
        }

        using (StreamWriter sw = fileSystem.File.AppendText(path))
        {
            await sw.WriteLineAsync(message);
        }
        Console.WriteLine(message);
    }
}

public interface ILogger
{
    Task Log(string message);
}
