using AdventCode2024.Models;

namespace AdventCode2024;


public class Day13ClawContraptionUnitTests
{
    [Fact]
    public void ClawContraption_Test_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day13test.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(15, lines.Count());

        var cc = new ClawCalculator(lines);
        Assert.NotNull(cc);
        Assert.Equal(4, cc.ClawStates.Count());

        long actual = cc.FindTokenPrizeCost();
        Assert.Equal(480, actual);
    }

    [Fact]
    public void Day13_Part1_ClawContraption_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day13.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(1279, lines.Count());

        var cc = new ClawCalculator(lines);
        Assert.NotNull(cc);
        Assert.Equal(320, cc.ClawStates.Count());

        long actual = cc.FindTokenPrizeCost();
        Assert.Equal(29522, actual);
    }

    [Fact(Skip = "Not working")]
    public void ClawContraption_Test_Offset_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day13test.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(15, lines.Count());

        var cc = new ClawCalculator(lines, 10000000000000);
        Assert.NotNull(cc);
        Assert.Equal(4, cc.ClawStates.Count());

        long actual = cc.FindTokenPrizeCost();
        Assert.Equal(0, actual);
    }

    [Fact(Skip = "Not working")]
    public void Day13_Part2_ClawContraption_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day13.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(1279, lines.Count());

        var cc = new ClawCalculator(lines, 10000000000000);
        Assert.NotNull(cc);
        Assert.Equal(320, cc.ClawStates.Count());

        long actual = cc.FindTokenPrizeCost();
        Assert.Equal(29522, actual);
    }
}
