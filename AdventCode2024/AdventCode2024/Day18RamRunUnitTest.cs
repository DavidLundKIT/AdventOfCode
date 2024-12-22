using AdventCode2024.Models;

namespace AdventCode2024;

public class Day18RamRunUnitTest
{
    [Fact]
    public void RamRun_TestData_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day18test.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(25, lines.Count());

        var rrm = new RamRunMapper(lines, 7, 7);
        rrm.DropBytes(0, 12);
        rrm.ShowMap();
        int actual = rrm.MapWalk();
        Assert.Equal(22, actual);
    }

    [Fact]
    public void Day18_Part1_RamRun_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day18.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(3450, lines.Count());

        var rrm = new RamRunMapper(lines, 71, 71);
        rrm.DropBytes(0, 1024);
        rrm.ShowMap();
        int actual = rrm.MapWalk();
        Assert.Equal(432, actual);
    }
}
