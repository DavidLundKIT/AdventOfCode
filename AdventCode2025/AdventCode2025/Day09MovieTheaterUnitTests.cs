using AdventCode2025.Models;

namespace AdventCode2025;

public class Day09MovieTheaterUnitTests
{
    [Fact]
    public void Day09_TestData_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day09test.txt");
        Assert.Equal(8, lines.Length);

        var sut = new RectangleCalculator(lines);
        var result = sut.FindLargestRectangleArea();
        Assert.Equal(50, result);
    }

    [Fact]
    public void Day09_Part1_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day09.txt");
        Assert.Equal(496, lines.Length);

        var sut = new RectangleCalculator(lines);
        var result = sut.FindLargestRectangleArea();
        Assert.Equal(4764078684, result);
    }
}
