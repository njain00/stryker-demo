namespace DemoConsole;

public class ActualWork(ILogger logger)
{
    public async Task Process(int numberOfIterations = 4, int sleepLengthMilli = 3000)
    {
        int i = 0;
        while (i < numberOfIterations)
        {
            Thread.Sleep(sleepLengthMilli); // could be actual stuff
            await logger.Log(DateTime.Now.ToString());
            i++;
        }
    }
}
