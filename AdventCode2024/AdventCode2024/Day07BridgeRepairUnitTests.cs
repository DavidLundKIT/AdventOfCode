using AdventCode2024.Models;

namespace AdventCode2024;

public class Day07BridgeRepairUnitTests
{

    [Theory]
    [InlineData("190: 10 19", true)]
    [InlineData("3267: 81 40 27", true)]
    [InlineData("83: 17 5", false)]
    [InlineData("156: 15 6", false)]
    [InlineData("7290: 6 8 6 15", false)]
    [InlineData("161011: 16 10 13", false)]
    [InlineData("192: 17 8 14", false)]
    [InlineData("21037: 9 7 18 13", false)]
    [InlineData("292: 11 6 16 20", true)]
    public void BridgeCalculations_OK(string line, bool expected)
    {
        var bc = new BridgeCalculator(line);

        var actual = bc.Calculate();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BridgeCalculations_Sum_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day07test.txt");
        int count = 9;
        Assert.Equal(count, lines.Length);

        long total = 0;
        foreach (var line in lines)
        {
            var bc = new BridgeCalculator(line);

            if (bc.Calculate())
            {
                total += bc.Expected;
            }
        }
        Assert.Equal(3749, total);
    }

    [Theory]
    [InlineData("190: 10 19", true)]
    [InlineData("3267: 81 40 27", true)]
    [InlineData("83: 17 5", false)]
    [InlineData("156: 15 6", true)]
    [InlineData("7290: 6 8 6 15", true)]
    [InlineData("161011: 16 10 13", false)]
    [InlineData("192: 17 8 14", true)]
    [InlineData("21037: 9 7 18 13", false)]
    [InlineData("292: 11 6 16 20", true)]
    public void BridgeCalculations_ThirdOperand_OK(string line, bool expected)
    {
        var bc = new BridgeCalculator(line);

        var actual = bc.Calculate(true);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Day07_Step1_BridgeRepairCalculations_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day07.txt");
        int count = 850;
        Assert.Equal(count, lines.Length);

        long total = 0;
        foreach (var line in lines)
        {
            var bc = new BridgeCalculator(line);

            if (bc.Calculate())
            {
                total += bc.Expected;
            }
        }
        Assert.Equal(1545311493300, total);
    }

    [Fact]
    public void Day07_Step2_BridgeRepairCalculations_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day07.txt");
        int count = 850;
        Assert.Equal(count, lines.Length);

        long total = 0;
        foreach (var line in lines)
        {
            var bc = new BridgeCalculator(line);

            if (bc.Calculate(true))
            {
                total += bc.Expected;
            }
        }
        Assert.Equal(169122112716571, total);
    }
}
