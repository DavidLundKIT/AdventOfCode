using day03;
using System.Collections.Generic;
using Xunit;

namespace days.test;

public class Day03UnitTests
{
    [Fact]
    public void Day03_ParseInputFile_OK()
    {
        string datapath = "day03a.txt";
        var sut = new Day03ClaimChecker();

        List<Claim> rows = sut.ParseData(datapath);
        Assert.NotNull(rows);
        Assert.Equal(1385, rows.Count);
    }

    [Fact]
    public void Day03_ParseClaimRow()
    {
        string row = "#123 @ 3,2: 5x4";

        Claim c = Claim.MakeClaim(row);

        Assert.Equal("#123", c.ClaimId);
        Assert.Equal(3, c.X);
        Assert.Equal(2, c.Y);
        Assert.Equal(5, c.Width);
        Assert.Equal(4, c.Height);
    }

    [Fact]
    public void Day03_MarkUpCloth_Part1_answer()
    {
        string datapath = "day03a.txt";
        var sut = new Day03ClaimChecker();

        List<Claim> claims = sut.ParseData(datapath);
        Assert.NotNull(claims);
        Assert.Equal(1385, claims.Count);
        int[,] cloth = new int[1000, 1000];

        sut.MarkupCloth(cloth, claims);
        int expected = 116491;
        int actual = sut.OverlappingInches(cloth, 1000, 1000);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Day03_MarkUpCloth_Part2_answer()
    {
        string datapath = "day03a.txt";
        var sut = new Day03ClaimChecker();

        List<Claim> claims = sut.ParseData(datapath);
        Assert.NotNull(claims);
        Assert.Equal(1385, claims.Count);
        int[,] cloth = new int[1000, 1000];

        sut.MarkupCloth(cloth, claims);
        int expected = 116491;
        int actual = sut.OverlappingInches(cloth, 1000, 1000);
        Assert.Equal(expected, actual);
        string claimExpected = "#707";
        string claimActual = string.Empty;


        foreach (var claim in claims)
        {
            if (!sut.DoesClaimOverlap(cloth, claim))
            {
                claimActual = claim.ClaimId;
            }
        }
        Assert.Equal(claimExpected, claimActual);
    }
}
