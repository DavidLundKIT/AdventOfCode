using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay05UnitTests
{
    public Day05JumpMaze sut { get; set; }

    string path = "AdventDay05a.txt";

    public AdventDay05UnitTests()
    {
        sut = new Day05JumpMaze();
        // (0) 3  0  1  -3 for tests
        sut.Jumps.AddRange(new int[] { 0, 3, 0, 1, -3 });
    }

    [Fact]
    public void Day05_TestRunAdvent01()
    {
        List<int> jumps = sut.ReadJumpStack(path);
        int expected = 1044;
        Assert.NotNull(jumps);
        Assert.Equal(expected, jumps.Count);
    }

    [Fact]
    public void Day05_TestRunAdvent02()
    {
        Assert.NotNull(sut.Jumps);
        Assert.Equal(0, sut.Jumps[0]);
        Assert.Equal(3, sut.Jumps[1]);
        Assert.Equal(0, sut.Jumps[2]);
        Assert.Equal(1, sut.Jumps[3]);
        Assert.Equal(-3, sut.Jumps[4]);
    }

    [Fact]
    public void Day05_TestRunAdvent03()
    {
        // (0) 3  0  1  -3
        int actual = sut.StepsUntilExits();
        Assert.Equal(5, actual);
        //2  5  0  1  -2
    }

    [Fact]
    public void Day05_TestRunAdvent04_SolutionA()
    {
        List<int> jumps = sut.ReadJumpStack(path);
        int expected = 1044;
        Assert.NotNull(jumps);
        Assert.Equal(expected, jumps.Count);
        sut.Jumps = jumps;
        int actual = sut.StepsUntilExits();
        Assert.Equal(342669, actual);
    }

    [Fact]
    public void Day05_TestRun05()
    {
        // (0) 3  0  1  -3
        int actual = sut.StepsUntilExitsB();
        Assert.Equal(10, actual);
        // 2 3 2 3 -1
    }

    [Fact]
    public void Day05_TestRunAdvent06_SolutionB()
    {
        List<int> jumps = sut.ReadJumpStack(path);
        int expected = 1044;
        Assert.NotNull(jumps);
        Assert.Equal(expected, jumps.Count);
        sut.Jumps = jumps;
        int actual = sut.StepsUntilExitsB();
        Assert.Equal(25136209, actual);
    }
}
