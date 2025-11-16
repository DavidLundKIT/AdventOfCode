using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay23UnitTests
{
    private readonly string pathdata = "Adventday23.txt";

    public Day23Coprocessor sut { get; set; }

    public AdventDay23UnitTests()
    {
        sut = new Day23Coprocessor();
    }

    [Fact]
    public void Day23_Solution_PartA()
    {
        sut.ParseProgram(pathdata);
        Assert.NotNull(sut.Instructions);
        Assert.Equal(32, sut.Instructions.Count);

        sut.PlayProgram();

        Assert.Equal(6724, sut.MulCount);
        Assert.Equal(1, sut.Registers["h"]);

        var sut2 = new CoprocessorB
        {
            B = 84,
            C = 84
        };
        sut2.PlayProgram();
        Assert.Equal(1, sut2.H);
        Assert.Equal(84, sut2.B);
        Assert.Equal(84, sut2.C);
    }

    [Fact]
    public void Day23_TestRun02()
    {
        var sut2 = new CoprocessorB
        {
            B = 108400,
            C = 125400
        };
        sut2.PlayProgram();
        Assert.Equal(903, sut2.H);
        Assert.Equal(125400, sut2.B);
        Assert.Equal(125400, sut2.C);
    }
}
