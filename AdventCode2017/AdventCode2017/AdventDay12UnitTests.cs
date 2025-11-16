using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay12UnitTests
{
    string pathdata = "Adventday12.txt";
    string pathtest = "Adventday12test.txt";

    public Day12DigitalPlumber sut { get; set; }

    public AdventDay12UnitTests()
    {
        sut = new Day12DigitalPlumber();
    }

    [Fact]
    public void Day12_TestRun01()
    {
        sut.ParseFile(pathtest);
        Assert.NotNull(sut.AllProcs);
        Assert.Equal(7, sut.AllProcs.Count);
        sut.FindGroup("0");
        Assert.Equal(6, sut.Group.Count);
    }

    [Fact]
    public void Day12_TestRun02_SolutionA()
    {
        sut.ParseFile(pathdata);
        Assert.NotNull(sut.AllProcs);
        Assert.Equal(2000, sut.AllProcs.Count);
        sut.FindGroup("0");
        Assert.Equal(306, sut.Group.Count);
    }

    [Fact]
    public void Day12_TestRun03()
    {
        sut.ParseFile(pathtest);
        Assert.NotNull(sut.AllProcs);
        Assert.Equal(7, sut.AllProcs.Count);
        int actual = sut.FindAllGroups();
        Assert.Equal(2, actual);
    }

    [Fact]
    public void Day12_TestRun04_SolutionB()
    {
        sut.ParseFile(pathdata);
        Assert.NotNull(sut.AllProcs);
        Assert.Equal(2000, sut.AllProcs.Count);
        int actual = sut.FindAllGroups();
        Assert.Equal(200, actual);
    }
}
