using AdventCode2025.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventCode2025;

public class Day03LobbyUnitTests
{
    [Theory]
    [InlineData("987654321111111", 98)]
    [InlineData("811111111111119", 89)]
    [InlineData("234234234234278", 78)]
    [InlineData("818181911112111", 92)]
    public void TestJoltageCalculator_OK(string battery, int joltage)
    {
        var calculator = new JoltageCalculator();
        var calculatedJoltage = calculator.CalculateJoltage(battery);
        Assert.Equal(joltage, calculatedJoltage);
    }

    [Fact]
    public void TestJoltageCalculator_Sum_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day03test.txt");
        Assert.Equal(4, lines.Length);

        var calculator = new JoltageCalculator();
        int sumJoltage = 0; 
        foreach (var line in lines)
        {
            sumJoltage += calculator.CalculateJoltage(line);
        }
        Assert.Equal(357, sumJoltage);
    }

    [Fact]
    public void Day03_Part1_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day03.txt");
        Assert.Equal(200, lines.Length);

        var calculator = new JoltageCalculator();
        int sumJoltage = 0;
        foreach (var line in lines)
        {
            sumJoltage += calculator.CalculateJoltage(line);
        }
        Assert.Equal(17694, sumJoltage);
    }
}
