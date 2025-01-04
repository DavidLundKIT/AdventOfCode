using AdventCode2024.Models;

namespace AdventCode2024;

public class Day16ReindeerMazeUnitTests
{
    [Fact]
    public void ReindeerMaze_Test1_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day16test.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(15, lines.Count());

        var ren = new ReindeerMazeMapper(lines);
        ren.ShowMap();
        int steps = ren.WalkMaze();
        Assert.Equal(7036, ren.Cost);
        Assert.Equal(36, steps);
    }

    [Fact]
    public void ReindeerMaze_Test2_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day16test2.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(17, lines.Count());

        var ren = new ReindeerMazeMapper(lines);
        ren.ShowMap();
        int steps = ren.WalkMaze();
        Assert.Equal(11048, ren.Cost);
        Assert.Equal(48, steps);
    }


    [Fact]
    public void Day16_Part1_ReindeerMaze_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day16.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(141, lines.Count());

        var ren = new ReindeerMazeMapper(lines);
        ren.ShowMap();
        int steps = ren.WalkMaze();
        Assert.Equal(109516, ren.Cost);
        Assert.Equal(516, steps);
    }
}
