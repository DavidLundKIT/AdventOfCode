using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay06UnitTests
{
    public Day06MemoryRealloc sut { get; set; }
    public List<int> testDataA { get; set; }

    public AdventDay06UnitTests()
    {
        sut = new Day06MemoryRealloc();
        testDataA = new List<int>();
        testDataA.AddRange(new int[] { 0, 2, 7, 0 });
    }

    [Fact]
    public void Day06_TestRun01()
    {
        Assert.NotNull(sut.InputA);
        Assert.Equal(16, sut.InputA.Count);
        Assert.NotNull(testDataA);
        Assert.Equal(4, testDataA.Count);
    }

    [Fact]
    public void Day06_TestRun02()
    {
        int expected = 5;
        int actual = sut.ReallocMemory(testDataA);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Day06_TestRun03()
    {
        Assert.Equal("0 2 7 0", testDataA.AsString());
        Assert.Equal(sut.input06A, sut.InputA.AsString());
    }

    [Fact]
    public void Day06_TestRun04()
    {
        int actual = sut.FindMax(testDataA);

        Assert.Equal(2, actual);
        Assert.Equal(7, testDataA[actual]);
    }

    [Fact]
    public void Day06_TestRun05()
    {
        var actual = sut.NextAllocState(testDataA);

        Assert.Equal(2, actual[0]);
        Assert.Equal(4, actual[1]);
        Assert.Equal(1, actual[2]);
        Assert.Equal(2, actual[3]);
    }

    [Fact]
    public void Day06_TestRun06_SolutionA()
    {
        int expected = 11137;
        int actual = sut.ReallocMemory(sut.InputA);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Day06_TestRun07()
    {
        int expected = 4;
        int actual = sut.ReallocMemoryNext(testDataA);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Day06_TestRun08_SolutionB()
    {
        int expected = 1037;
        int actual = sut.ReallocMemoryNext(sut.InputA);
        Assert.Equal(expected, actual);
    }
}
