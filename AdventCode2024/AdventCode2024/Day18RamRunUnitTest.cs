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
    }

    [Fact]
    public void Day18_Part1_RamRun_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day18.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(3450, lines.Count());
    }
}
