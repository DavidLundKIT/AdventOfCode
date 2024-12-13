using AdventCode2024.Models;
using System.Diagnostics;

namespace AdventCode2024;

public class Day11PlutonianPebblesUnitTests
{
    private string Data = "5 62914 65 972 0 805922 6521 1639064";
    private string TestData1 = "0 1 10 99 999";
    private string TestData2 = "125 17";

    [Fact]
    public void PlutonianPebbles_TestData1_OK()
    {
        var ppr = new PlutonianPebbleRules(TestData1);
        Assert.NotNull(ppr);
        Assert.Equal(5, ppr.Stones.Count);
        ppr.DoBlink();

        var expected = "1 2024 1 0 9 9 2021976".Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => long.Parse(s)).ToList();
        int idx = 0;
        foreach (var val in ppr.Stones)
        {
            Assert.Equal(expected[idx++], val);
        }
    }

    [Fact]
    public void PlutonianPebbles_TestData2_blink6_OK()
    {
        var ppr = new PlutonianPebbleRules(TestData2);
        Assert.NotNull(ppr);
        Assert.Equal(2, ppr.Stones.Count);
        for (int i = 0; i < 6; i++)
        {
            ppr.DoBlink();
        }

        var expected = "2097446912 14168 4048 2 0 2 4 40 48 2024 40 48 80 96 2 8 6 7 6 0 3 2".Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => long.Parse(s)).ToList();
        int idx = 0;
        foreach (var val in ppr.Stones)
        {
            Assert.Equal(expected[idx++], val);
        }
        Assert.Equal(22, ppr.Stones.Count);
    }

    [Fact]
    public void PlutonianPebbles_TestData2_Blink25_OK()
    {
        var ppr = new PlutonianPebbleRules(TestData2);
        Assert.NotNull(ppr);
        Assert.Equal(2, ppr.Stones.Count);
        for (int i = 0; i < 25; i++)
        {
            ppr.DoBlink();
        }

        Assert.Equal(55312, ppr.Stones.Count);
    }

    [Fact]
    public void Day11_Part1_PlutonianPebbles_OK()
    {
        var ppr = new PlutonianPebbleRules(Data);
        Assert.NotNull(ppr);
        Assert.Equal(8, ppr.Stones.Count);

        for (int i = 0; i < 25; i++)
        {
            ppr.DoBlink();
        }

        Assert.Equal(199753, ppr.Stones.Count);
    }

    [Fact(Skip = "Ran forever")]
    public void Day11_Part2_PlutonianPebbles_OK()
    {
        var ppr = new PlutonianPebbleRules(Data);
        Assert.NotNull(ppr);
        Assert.Equal(8, ppr.Stones.Count);

        for (int i = 0; i < 75; i++)
        {
            ppr.DoBlink();
        }

        Assert.Equal(199753, ppr.Stones.Count);
    }

    [Fact]
    public void Day11_Part2_OnlyOne_PlutonianPebbles_OK()
    {
        var oneAtATime = Data.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        long actual = 0;
        foreach (var one in oneAtATime)
        {
            Debug.WriteLine($"For one: {one}");
            var ppr = new PlutonianPebbleRules(one);

            for (int i = 0; i < 25; i++)
            {
                ppr.DoBlink();
            }
            int count = ppr.Stones.Count;
            Debug.WriteLine($"For one: {one}, count is: {count}");
            actual += ppr.Stones.Count;
        }

        Assert.Equal(199753, actual);
    }

    [Theory]
    [InlineData(1, 3)]
    [InlineData(2, 4)]
    [InlineData(3, 5)]
    [InlineData(4, 9)]
    [InlineData(5, 13)]
    [InlineData(6, 22)]
    [InlineData(25, 55312)]
    public void PlutonianPebblesRecursive_TestData2_Blink25_OK(int blinks, long expected)
    {
        var ppr = new PlutonianPebblesRecursive(TestData2);
        Assert.NotNull(ppr);
        Assert.Equal(2, ppr.StartValues.Count);

        long actual = ppr.DoBlinks(blinks);

       Assert.Equal(expected, actual);
    }

    [Fact]
    public void Day11_Part1_PlutonianPebblesRecursive_OK()
    {
        var ppr = new PlutonianPebblesRecursive(Data);
        Assert.NotNull(ppr);
        Assert.Equal(8, ppr.StartValues.Count);

        long actual = ppr.DoBlinks(25);

        Assert.Equal(199753, actual);
    }

    [Fact]
    public void Day11_Part2_PlutonianPebblesRecursive_OK()
    {
        var ppr = new PlutonianPebblesRecursive(Data);
        Assert.NotNull(ppr);
        Assert.Equal(8, ppr.StartValues.Count);

        long actual = ppr.DoBlinks(75);

        Assert.Equal(0, actual);
    }
}
