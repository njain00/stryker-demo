using System.IO.Abstractions;
using DemoConsole;
using NSubstitute;

namespace Tests;

public class Act
{
    private readonly Logger loggerMock = Substitute.For<Logger>(new FileSystem());
    [Fact]
    public async Task Test_LogCalledSameNumberOfTimesAsIteration()
    {
        ActualWork work = new(loggerMock);

        await work.Process(4, 1000);
        await loggerMock.Received(4).Log(Arg.Any<string>());
    }
}
