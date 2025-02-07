namespace DemoConsole;

public class Logger : ILogger
{
    public async Task Log(string message)
    {
        string path = "/home/nishant/Documents/workspace/dotnet-playground/StrykerDemo/logfile.txt";

        if (!File.Exists(path))
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                await sw.WriteLineAsync(message);
            }
            Console.WriteLine(message);
            return;
        }

        using (StreamWriter sw = File.AppendText(path))
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
