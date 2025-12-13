using AdventCode2025.Models;

namespace AdventCode2025;

public class Day08PlaygroundUnitTests
{
    [Fact]
    public void Day08_TestData_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day08test.txt");
        Assert.Equal(20, lines.Length);


    }

    [Fact]
    public void Day08_Part1_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day08.txt");
        Assert.Equal(1000, lines.Length);

    }
}
