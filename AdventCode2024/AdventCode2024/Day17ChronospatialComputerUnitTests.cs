using AdventCode2024.Models;

namespace AdventCode2024;


public class Day17ChronospatialComputerUnitTests
{
    public InitialComputerState InData { get; set; } = new InitialComputerState(52042868, 0, 0, "2,4,1,7,7,5,0,3,4,4,1,7,5,5,3,0");

    [Fact]
    public void Instruction_test_1_OK()
    {
        // If register C contains 9, the program 2,6 would set register B to 1.
        var cc = new ChronoComputer(0, 0, 9, "2,6");
        Assert.NotNull(cc);
        Assert.Equal(0, cc.RegB);
        Assert.Equal(9, cc.RegC);
        cc.Run();
        Assert.Equal(1, cc.RegB);
    }

    [Fact]
    public void Instruction_test_2_OK()
    {
        // If register A contains 10, the program 5,0,5,1,5,4 would output 0,1,2.
        var cc = new ChronoComputer(10, 0, 0, "5,0,5,1,5,4");
        Assert.NotNull(cc);
        Assert.Equal(10, cc.RegA);
        cc.Run();
        Assert.NotEmpty(cc.Output);
        Assert.Equal("0,1,2", cc.ShowOutput());
    }

    [Fact]
    public void Instruction_test_3_OK()
    {
        // If register A contains 2024, the program 0,1,5,4,3,0 would
        // output 4,2,5,6,7,7,7,7,3,1,0 and leave 0 in register A.
        var cc = new ChronoComputer(2024, 0, 0, "0,1,5,4,3,0");
        Assert.NotNull(cc);
        Assert.Equal(2024, cc.RegA);
        cc.Run();
        Assert.NotEmpty(cc.Output);
        Assert.Equal(0, cc.RegA);
        Assert.Equal("4,2,5,6,7,7,7,7,3,1,0", cc.ShowOutput());
    }

    [Fact]
    public void Instruction_test_4_OK()
    {
        // If register B contains 29, the program 1,7 would set register B to 26.
        var cc = new ChronoComputer(0, 29, 0, "1,7");
        Assert.NotNull(cc);
        Assert.Equal(29, cc.RegB);
        cc.Run();
        Assert.Equal(26, cc.RegB);
    }

    [Fact]
    public void Instruction_test_5_OK()
    {
        // If register B contains 2024 and register C contains 43690, the program 4,0 would set register B to 44354.
        var cc = new ChronoComputer(0, 2024, 43690, "4,0");
        Assert.NotNull(cc);
        Assert.Equal(2024, cc.RegB);
        Assert.Equal(43690, cc.RegC);
        cc.Run();
        Assert.Equal(44354, cc.RegB);
    }

    [Fact]
    public void Instruction_test_Final_OK()
    {
        // If register B contains 2024 and register C contains 43690, the program 4,0 would set register B to 44354.
        var cc = new ChronoComputer(729, 0, 0, "0,1,5,4,3,0");
        Assert.NotNull(cc);
        Assert.Equal(729, cc.RegA);
        cc.Run();
        Assert.Equal("4,6,3,5,6,3,5,2,1,0", cc.ShowOutput());
    }

    [Fact]
    public void Day17_Part1_ChronospatialComputer_OK()
    {
        var cc = new ChronoComputer(InData);
        Assert.NotNull(cc);
        cc.Run();
        Assert.Equal("2,1,0,1,7,2,5,0,3", cc.ShowOutput());
    }

    [Fact]
    public void Instruction_test_Find_Copy_OK()
    {
        // If register B contains 2024 and register C contains 43690, the program 4,0 would set register B to 44354.
        var cc = new ChronoComputer(729, 0, 0, "0,3,5,4,3,0");
        Assert.NotNull(cc);
        long actual = cc.FindCopyOfSelf();
        Assert.Equal(117440, actual);
    }

    [Fact(Skip ="Not ending")]
    public void Day17_Part2_ChronospatialComputer_OK()
    {
        var cc = new ChronoComputer(InData);
        Assert.NotNull(cc);
        long actual = cc.FindCopyOfSelf();
        Assert.Equal(0, actual);
    }
}
