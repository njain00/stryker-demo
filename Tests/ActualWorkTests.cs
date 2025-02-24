using System.Diagnostics;
using System.IO.Abstractions;
using DemoConsole;
using NSubstitute;

namespace Tests;

public class Act
{
    private readonly Logger loggerMock = Substitute.For<Logger>(new FileSystem());

    [Fact]
    public async Task Test_SleepObserved()
    {
        ActualWork work = new(new Logger(new FileSystem()));

        Stopwatch sw = Stopwatch.StartNew();
        await work.Process(2, 2000);
        sw.Stop();
        Assert.True(sw.ElapsedMilliseconds > 3995);
    }

    [Fact]
    public async Task Test_LogCalledDuringProcess()
    {
        ActualWork work = new(loggerMock);

        await work.Process(4, 1000);
        await loggerMock.Received().Log(Arg.Any<string>());
    }

    // [Fact]
    // public async Task Test_LogCalledSameNumberOfTimesAsIteration()
    // {
    //     ActualWork work = new(loggerMock);

    //     await work.Process(4, 1000);
    //     await loggerMock.Received(4).Log(Arg.Any<string>());
    // }

}
