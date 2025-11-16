using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay19UnitTests
{
    string pathdata = "Adventday19.txt";
    string pathtest = "Adventday19test.txt";

    public Day19TubeMaze sut { get; set; }

    public AdventDay19UnitTests()
    {
        sut = new Day19TubeMaze();
    }

    [Fact]
    public void Day19_TestRun01()
    {
        var rows = DataTools.ReadAllLines(pathtest);

        sut.ParseMaze(rows);

        Assert.NotNull(sut.Maze);
        string expected = "ABCDEF";

        var actualPos = sut.FindStart();
        Assert.Equal(0, sut.Current.Y);
        Assert.Equal(5, sut.Current.X);
        Assert.Equal(Direction.Down, sut.Current.Direction);
        Assert.Equal(0, actualPos.Y);
        Assert.Equal(5, actualPos.X);
        Assert.Equal(Direction.Down, actualPos.Direction);
        string actual = sut.FindInMaze();
        Assert.Equal(expected, actual);
        Assert.Equal(38, sut.Steps);
    }

    [Fact]
    public void Day19_SoulutionA()
    {
        var rows = DataTools.ReadAllLines(pathdata);

        sut.ParseMaze(rows);

        Assert.NotNull(sut.Maze);
        string expected = "DWNBGECOMY";

        sut.FindStart();
        Assert.Equal(0, sut.Current.Y);
        Assert.Equal(55, sut.Current.X);
        Assert.Equal(Direction.Down, sut.Current.Direction);

        string actual = sut.FindInMaze();
        Assert.Equal(expected, actual);
        Assert.Equal(17228, sut.Steps);
    }
}
