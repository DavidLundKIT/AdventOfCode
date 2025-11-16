using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay25UnitTests
{
    [Fact]
    public void Day25_TestRun01()
    {
        Day25Turing sut = new Day25Turing();

        int value;
        for (int i = 0; i < 6; i++)
        {
            value = sut.TuringStep();
        }

        Assert.Equal(3, sut.CheckSum());
    }

    [Fact]
    public void Day25_TestSolutionA()
    {
        Day25TuringA sut = new Day25TuringA();

        int value;
        for (int i = 0; i < 12861455; i++)
        {
            value = sut.TuringStep();
        }

        Assert.Equal(3578, sut.CheckSum());
    }
}
