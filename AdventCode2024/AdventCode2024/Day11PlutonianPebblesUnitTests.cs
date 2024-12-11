using AdventCode2024.Models;

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
}
