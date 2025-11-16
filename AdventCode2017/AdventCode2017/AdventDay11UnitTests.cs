using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay11UnitTests
{
    public Day11HexTiles sut { get; set; }

    private string pathdata = "adventday11.txt";

    public AdventDay11UnitTests()
    {
        sut = new Day11HexTiles();
    }

    [Fact]
    public void Day11_TestRun01()
    {
        string data = sut.ReadInputData(pathdata);
        Assert.False(string.IsNullOrEmpty(data));
        Assert.Equal(21607, data.Length);
        var cmds = sut.GetCommands(data);
        Assert.NotNull(cmds);
    }

    [Fact]
    public void Day11_TestRun02()
    {
        string data = "ne,ne,ne";
        var cmds = sut.GetCommands(data);
        Assert.Equal(3, cmds.Count);
        int steps = sut.FindSteps(cmds);
        Assert.Equal(3, steps);
    }

    [Fact]
    public void Day11_TestRun03()
    {
        string data = "ne,ne,sw,sw";
        var cmds = sut.GetCommands(data);
        Assert.Equal(4, cmds.Count);
        int steps = sut.FindSteps(cmds);
        Assert.Equal(0, steps);
    }

    [Fact]
    public void Day11_TestRun04()
    {
        string data = "ne,ne,s,s";
        var cmds = sut.GetCommands(data);
        Assert.Equal(4, cmds.Count);
        int steps = sut.FindSteps(cmds);
        Assert.Equal(2, steps);
    }

    [Fact]
    public void Day11_TestRun05()
    {
        string data = "se,sw,se,sw,sw";
        var cmds = sut.GetCommands(data);
        Assert.Equal(5, cmds.Count);
        int steps = sut.FindSteps(cmds);
        Assert.Equal(3, steps);
    }

    [Fact]
    public void Day11_TestRun_SolutionA()
    {
        string data = sut.ReadInputData(pathdata);
        Assert.False(string.IsNullOrEmpty(data));
        Assert.Equal(21607, data.Length);
        var cmds = sut.GetCommands(data);
        Assert.NotNull(cmds);
        int steps = sut.FindSteps(cmds);
        Assert.Equal(808, steps);
    }

    [Fact]
    public void Day11_TestRun_SolutionB()
    {
        string data = sut.ReadInputData(pathdata);
        Assert.False(string.IsNullOrEmpty(data));
        Assert.Equal(21607, data.Length);
        var cmds = sut.GetCommands(data);
        Assert.NotNull(cmds);
        int maxSteps = 0;

        List<string> stepsSoFar = new List<string>();
        foreach (var cmd in cmds)
        {
            stepsSoFar.Add(cmd);
            int steps = sut.FindSteps(stepsSoFar);
            maxSteps = Math.Max(steps, maxSteps);
        }
        Assert.Equal(1556, maxSteps);
    }
}
