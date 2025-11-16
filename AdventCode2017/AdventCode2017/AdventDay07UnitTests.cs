using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay07UnitTests
{
    string pathdata = "Advent07.txt";
    string pathtest = "Advent07test.txt";

    public Day07RecursiveCircus sut { get; set; }

    public AdventDay07UnitTests()
    {
        sut = new Day07RecursiveCircus();
    }

    [Fact]
    public void Day07_TestRun01()
    {
        List<pgm> result = sut.ReadData(pathtest);
        Assert.NotNull(result);
        Assert.Equal(13, result.Count);

        var root = sut.FindRoot(result);
        Assert.NotNull(root);
        Assert.Equal("tknk", root.Name);

        int actual = sut.WeightSum(root);
        Assert.Equal(778, actual);
    }

    [Fact]
    public void Day07_TestRun02_SolutionA()
    {
        List<pgm> result = sut.ReadData(pathdata);
        Assert.NotNull(result);
        Assert.Equal(1452, result.Count);

        var root = sut.FindRoot(result);
        Assert.NotNull(root);
        Assert.Equal("veboyvy", root.Name);

        int actual = sut.WeightSum(root);
        Assert.Equal(377179, actual);
    }
}
