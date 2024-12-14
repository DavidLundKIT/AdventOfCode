using AdventCode2024.Models;

namespace AdventCode2024;

public class Day14RestroomRedoubtUnitTests
{

    [Fact]
    public void TestData_GetStartValues_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day14test.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(12, lines.Count());

        var roboTracker = new RobotTracker(lines, 11, 7);
        Assert.NotNull(roboTracker);
        Assert.NotEmpty(roboTracker.StartValues);
        Assert.Equal(12, roboTracker.StartValues.Count());

        roboTracker.MoveAllRobotsFor(100);
        Assert.NotEmpty(roboTracker.Positions);

        int actual = roboTracker.Quadrant1Count();
        int total = actual;
        Assert.Equal(1, actual);

        actual = roboTracker.Quadrant2Count();
        total *= actual;
        Assert.Equal(3, actual);
        Assert.Equal(3, total);

        actual = roboTracker.Quadrant3Count();
        total *= actual;
        Assert.Equal(4, actual);
        Assert.Equal(12, total);

        actual = roboTracker.Quadrant4Count();
        total *= actual;
        Assert.Equal(1, actual);
        Assert.Equal(12, total);

        total = roboTracker.SafetyFactor();
        Assert.Equal(12, total);
    }

    [Theory]
    [InlineData(1, 4, 1)]
    [InlineData(2, 6, 5)]
    [InlineData(3, 8, 2)]
    [InlineData(4, 10, 6)]
    [InlineData(5, 1, 3)]
    public void TestData_CheckMovement_OK(int seconds, int expectedX, int expectedY)
    {
        List<string> lines = new List<string>();
        lines.Add("p=2,4 v=2,-3");

        var roboTracker = new RobotTracker(lines.ToArray(), 11, 7);
        Assert.NotNull(roboTracker);
        Assert.NotEmpty(roboTracker.StartValues);
        Assert.Single(roboTracker.StartValues);

        var expectedPt = new Point(expectedX, expectedY);
        var actualPt = roboTracker.MoveRobotFor(seconds, roboTracker.StartValues[0]);
        Assert.Equal(expectedPt, actualPt);
    }

    [Fact]
    public void Day14_Part1_RestroomRedoubt_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day14.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(500, lines.Count());

        var roboTracker = new RobotTracker(lines, 101, 103);
        Assert.NotNull(roboTracker);
        Assert.NotEmpty(roboTracker.StartValues);
        Assert.Equal(500, roboTracker.StartValues.Count());

        roboTracker.MoveAllRobotsFor(100);
        int actual = roboTracker.SafetyFactor();
        Assert.Equal(230435667, actual);
    }

    /// <summary>
    /// First did this for every second in bunches of 1000
    /// Then thought I saw a pattern and printed the pattern 
    /// starting 1220 every 103 seconds.
    /// Until I found it. I used VS Code to peruse the files.
    /// The "view" scrollbar on the right was great.
    /// How anyone solved this quickly is beyond me.
    /// </summary>
    [Fact(Skip = "Makes file in c:\\Temp directory")]
    public void Day14_Part2_RestroomRedoubt_Looking_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day14.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(500, lines.Count());

        var roboTracker = new RobotTracker(lines, 101, 103);

        int secs = 1220;
        do
        {
            roboTracker.MoveAllRobotsFor(secs);
            roboTracker.PlotRobotPositions(secs);
            secs += 103;
        } while (secs < 300000);
    }

    [Fact]
    public void Day14_Part2_RestroomRedoubt_Found_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day14.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(500, lines.Count());

        var roboTracker = new RobotTracker(lines, 101, 103);

        int secs = 7709;
        roboTracker.MoveAllRobotsFor(secs);
        roboTracker.PlotRobotPositionWindow(secs);
    }
}
