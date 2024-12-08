using AdventCode2024.Models;

namespace AdventCode2024;

public class Day08ResonantCollinearityUnitTests
{
    [Fact]
    public void ResonantCollinearity_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day08test.txt");
        int count = 12;
        Assert.Equal(count, lines.Length);

        var rc = new ResonantColinearityMapper(lines);
        Assert.Equal(12, rc.MaxX);
        Assert.Equal(12, rc.MaxY);

        rc.MapAntiNodes();
        Assert.Equal(14, rc.Antinodes.Count);
    }

    [Fact]
    public void Day08_Part1_ResonantCollinearity_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day08.txt");
        int count = 50;
        Assert.Equal(count, lines.Length);

        var rc = new ResonantColinearityMapper(lines);
        Assert.Equal(50, rc.MaxX);
        Assert.Equal(50, rc.MaxY);

        rc.MapAntiNodes();
        Assert.Equal(413, rc.Antinodes.Count);
    }
}
