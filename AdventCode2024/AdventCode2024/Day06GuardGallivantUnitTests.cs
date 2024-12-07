using AdventCode2024.Models;

namespace AdventCode2024;

public class Day06GuardGallivantUnitTests
{
    [Fact]
    public void GuardGallivanting_GetBoard_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day06test.txt");
        int count = 10;
        Assert.Equal(count, lines.Length);

        var gg = new GuardGallivanter(lines);
        Assert.Equal(4, gg.Guard.X);
        Assert.Equal(6, gg.Guard.Y);
        Assert.Equal(Direction.Up, gg.Guard.Direction);

        gg.WalkTheRoom();
        count = gg.HowManyXs();
        Assert.Equal(41, count);
    }

    [Fact]
    public void Day06_Step1_GuardGallivanting_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day06.txt");
        int count = 130;
        Assert.Equal(count, lines.Length);

        var gg = new GuardGallivanter(lines);
        Assert.Equal(36, gg.Guard.X);
        Assert.Equal(52, gg.Guard.Y);
        Assert.Equal(Direction.Up, gg.Guard.Direction);

        gg.WalkTheRoom();
        count = gg.HowManyXs();
        Assert.Equal(4988, count);
    }
}
