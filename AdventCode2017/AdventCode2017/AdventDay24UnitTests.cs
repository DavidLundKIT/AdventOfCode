using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay24UnitTests
{
    string pathdata = "Adventday24.txt";
    string pathtest = "Adventday24test.txt";

    public Day24Bridge sut { get; set; }

    public  AdventDay24UnitTests()
    {
        sut = new Day24Bridge();
    }

    [Fact]
    public void Day24_TestRun01()
    {
        sut.ParseComponents(pathtest);
        Assert.Equal(8, sut.Components.Count);
        sut.CreateBridges();
        int actual = sut.StrongestBridge();
        Assert.Equal(31, actual);
        actual = sut.LongestStrongestBridge();
        Assert.Equal(19, actual);
    }

    [Fact]
    public void Day24_TestSolutionA()
    {
        sut.ParseComponents(pathdata);
        Assert.Equal(56, sut.Components.Count);
        sut.CreateBridges();
        int actual = sut.StrongestBridge();
        Assert.Equal(1511, actual);
        actual = sut.LongestStrongestBridge();
        Assert.Equal(1471, actual);
    }
}
