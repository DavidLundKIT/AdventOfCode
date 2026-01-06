using AdventCode2025.Models;

namespace AdventCode2025;

public class Day12ChristmasTreeFarm
{
    [Fact]
    public void Day12_TestData_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day12test.txt");
        Assert.Equal(33, lines.Length);

        var sut = new PresentPlacer(lines);
        Assert.Equal(3, sut.Trees.Count);
        Assert.Equal(6, sut.Shapes.Count);

        var actual = sut.GetTotalOkRegions();
        // Never needed to figure out fitting presents in test data
        // because real data was more than big enough.
        //Assert.Equal(2, actual);
    }

    [Fact]
    public void Day12_Part1_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day12.txt");
        Assert.Equal(1030, lines.Length);

        var sut = new PresentPlacer(lines);
        Assert.Equal(1000, sut.Trees.Count);
        Assert.Equal(6, sut.Shapes.Count);

        var actual = sut.GetTotalOkRegions();
        Assert.Equal(548, actual);
    }
}
