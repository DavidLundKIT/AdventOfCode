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

        var direction = gg.WalkTheRoom();
        count = gg.HowManyXs();
        Assert.Equal(41, count);
        Assert.Equal(Direction.Done, direction);
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

        var direction = gg.WalkTheRoom();
        count = gg.HowManyXs();
        Assert.Equal(4988, count);
        Assert.Equal(Direction.Done, direction);
    }

    [Theory]
    [InlineData(3, 6, true)]
    [InlineData(6, 7, true)]
    [InlineData(7, 7, true)]
    [InlineData(1, 8, true)]
    [InlineData(3, 8, true)]
    [InlineData(7, 9, true)]
    [InlineData(8, 9, false)]
    public void GuardGallivanting_GetBoard_FindLoopSpots_OK(int x, int y, bool expected)
    {
        var lines = Utils.ReadLinesFromFile("Day06test.txt");
        int count = 10;
        Assert.Equal(count, lines.Length);

        var gg = new GuardGallivanter(lines);
        Assert.Equal(4, gg.Guard.X);
        Assert.Equal(6, gg.Guard.Y);
        Assert.Equal(Direction.Up, gg.Guard.Direction);

        var point = new Point(x, y);
        gg.Puzzle[point].Type = '#';

        var direction = gg.WalkTheRoom();
        if (expected)
            Assert.Equal(Direction.Loop, direction);
        else
            Assert.Equal(Direction.Done, direction);
    }

    [Fact]
    public void GuardGallivanting_FindLoopSpots_FromFirstRun_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day06test.txt");
        int count = 10;
        Assert.Equal(count, lines.Length);

        var gg = new GuardGallivanter(lines);
        Assert.Equal(4, gg.Guard.X);
        Assert.Equal(6, gg.Guard.Y);
        Assert.Equal(Direction.Up, gg.Guard.Direction);

        var direction = gg.WalkTheRoom();
        Assert.Equal(Direction.Done, direction);

        List<Point> points = gg.Puzzle.Where(p => p.Value.Type == 'X').Select(k=> k.Key).ToList();
        points.Remove(gg.Start);

        count = 0;
        foreach (var point in points)
        {
            var gg2 = new GuardGallivanter(lines);
            Assert.Equal(4, gg2.Guard.X);
            Assert.Equal(6, gg2.Guard.Y);
            Assert.Equal(Direction.Up, gg2.Guard.Direction);
            gg2.Puzzle[point].Type = '#';

            direction = gg2.WalkTheRoom();
            if (direction == Direction.Loop)
                count++;
        }
        Assert.Equal(6, count);
    }

    [Fact(Skip = "Takes 41-43 secs")]
    public void Day06_Step2_GuardGallivanting_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day06.txt");

        var gg = new GuardGallivanter(lines);

        var direction = gg.WalkTheRoom();
        Assert.Equal(Direction.Done, direction);

        List<Point> points = gg.Puzzle.Where(p => p.Value.Type == 'X').Select(k => k.Key).ToList();
        Assert.Equal(4988, points.Count);
        points.Remove(gg.Start);

        int count = 0;
        foreach (var point in points)
        {
            var gg2 = new GuardGallivanter(lines);
            gg2.Puzzle[point].Type = '#';

            direction = gg2.WalkTheRoom();
            if (direction == Direction.Loop)
                count++;
        }
        Assert.Equal(1697, count);
    }
}
