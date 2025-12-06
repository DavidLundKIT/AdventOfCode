using AdventCode2025.Models;

namespace AdventCode2025;

public class Day06TrashCompactorUnitTests
{
    [Fact]
    public void Day06_TestData_Read_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day06test.txt");
        Assert.Equal(4, lines.Length);

        var sut = new CephalapodCalculator(lines);
        Assert.Equal(3, sut.Factors.Count);
        foreach (var factorList in sut.Factors)
        {
            Assert.Equal(factorList.Count, sut.Operands.Count);
        }
    }

    [Theory]
    [InlineData(0, 33210)]
    [InlineData(1, 490)]
    [InlineData(2, 4243455)]
    [InlineData(3, 401)]
    public void Day06_TestData_values_OK(int index, long expected)
    {
        var lines = Utils.ReadLinesFromFile("Day06test.txt");
        Assert.Equal(4, lines.Length);

        var sut = new CephalapodCalculator(lines);
        Assert.Equal(3, sut.Factors.Count);
        foreach (var factorList in sut.Factors)
        {
            Assert.Equal(factorList.Count, sut.Operands.Count);
        }
        var actual = sut.CalculateProblem(index);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Day06_TestData_Sum_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day06test.txt");
        Assert.Equal(4, lines.Length);

        var sut = new CephalapodCalculator(lines);
        var actual = sut.CalculateSumOfAllProblems();
        Assert.Equal(4277556, actual);
    }

    [Fact]
    public void Day06_Part1_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day06.txt");
        Assert.Equal(5, lines.Length);

        var sut = new CephalapodCalculator(lines);
        Assert.Equal(4, sut.Factors.Count);
        foreach (var factorList in sut.Factors)
        {
            Assert.Equal(factorList.Count, sut.Operands.Count);
        }

        var actual = sut.CalculateSumOfAllProblems();
        Assert.Equal(4805473544166, actual);
    }

    [Fact]
    public void Day06_TestData_V2_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day06test.txt");
        Assert.Equal(4, lines.Length);

        var sut = new CephalapodCalculatorV2(lines);

        long totalSum = 0;
        for (int i = 0; i < sut.Operands.Count; i++)
        {
            var actual = sut.CalculateNextProblem();
            totalSum += actual;
        }
        Assert.Equal(3263827, totalSum);
    }

    [Fact]
    public void Day06_Part2_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day06.txt");
        Assert.Equal(5, lines.Length);

        var sut = new CephalapodCalculatorV2(lines);

        long totalSum = 0;
        for (int i = 0; i < sut.Operands.Count; i++)
        {
            var actual = sut.CalculateNextProblem();
            totalSum += actual;
        }
        Assert.Equal(8907730960817, totalSum);
    }
}
