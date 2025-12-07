using AdventCode2025.Models;

namespace AdventCode2025;

public class Day07LaboratoriesUnitTests
{
    [Fact]
    public void TachyonTracer_TestSplits_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day07test.txt");
        Assert.Equal(16, lines.Length);

        var tracer = new TachyonTracer(lines);
        var actual = tracer.TotalSplits();
        Assert.Equal(21, actual);
    }

    [Fact]
    public void Day07_Part1_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day07.txt");
        Assert.Equal(142, lines.Length);

        var tracer = new TachyonTracer(lines);
        var actual = tracer.TotalSplits();
        Assert.Equal(1537, actual);
    }

    [Fact]
    public void TachyonTracer_TestTimelines_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day07test.txt");
        Assert.Equal(16, lines.Length);

        var tracer = new TachyonTracer(lines);
        var actual = tracer.TotalTimelines();
        Assert.Equal(40, actual);
    }

    [Fact]
    public void Day07_Part2_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day07.txt");
        Assert.Equal(142, lines.Length);

        var tracer = new TachyonTracer(lines);
        var actual = tracer.TotalTimelines();
        Assert.Equal(0, actual);
    }
}
