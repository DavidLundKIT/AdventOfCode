using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay17UnitTests
{
    public Day17Spinlock sut { get; set; }

    public AdventDay17UnitTests()
    {
        sut = new Day17Spinlock();
    }

    [Fact]
    public void Day17_TestRun01()
    {
        sut.Factor = 3;

        sut.Spin(1);
        Assert.Equal(0, sut.Buffer[0]);
        Assert.Equal(1, sut.Buffer[1]);

        sut.Spin(2);
        Assert.Equal(0, sut.Buffer[0]);
        Assert.Equal(2, sut.Buffer[1]);
        Assert.Equal(1, sut.Buffer[2]);

        sut.Spin(3);
        Assert.Equal(0, sut.Buffer[0]);
        Assert.Equal(2, sut.Buffer[1]);
        Assert.Equal(3, sut.Buffer[2]);
        Assert.Equal(1, sut.Buffer[3]);
    }

    [Fact]
    public void Day17_TestRun02()
    {
        sut.Factor = 3;

        for (int i = 1; i < 2018; i++)
        {
            sut.Spin(i);
        }
        Assert.Equal(638, sut.Buffer[sut.Position + 1]);
    }

    [Fact]
    public void Day17_SolutionA()
    {
        sut.Factor = 376;
        for (int i = 1; i < 2018; i++)
        {
            sut.Spin(i);
        }
        Assert.Equal(777, sut.Buffer[sut.Position + 1]);
    }

    [Fact]
    public void Day17_SolutionB()
    {
        sut.Factor = 376;
        for (int i = 1; i < 50000000; i++)
        {
            sut.Spin2(i);
        }
        Assert.Equal(39289581, sut.BufPos1);
    }
}
