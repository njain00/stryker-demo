// See https://aka.ms/new-console-template for more information

using DemoConsole;

Logger logger = new Logger();
Timer timer = new(callback, null, 0, 2000);
ActualWork work = new(logger);
await work.Process();

void callback(object? state)
{
    _ = logger.Log("Application is running");
}
