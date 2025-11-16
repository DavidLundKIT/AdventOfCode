using day05;
using Xunit;

namespace days.test;

public class Day05UnitTests
{
    [Fact]
    public void Day05_parsedata_ok()
    {
        string datapath = "day05a.txt";
        //string datapath2 = @"C:\Work\fun\AdventCode2018\data\input.txt";
        var sut = new Day05Polymers();

        var rows = sut.ReadDataFile(datapath);
        Assert.NotNull(rows);

        //var rows2 = sut.ReadDataFile(datapath2);
        //Assert.NotNull(rows2);
    }

    /*
    In aA, a and A react, leaving nothing behind.
In abBA, bB destroys itself, leaving aA. As above, this then destroys itself, leaving nothing.
In abAB, no two adjacent units are of the same type, and so nothing happens.
In aabAAB, even though aa and AA are of the same type, their polarities match, and so nothing happens.
Now, consider a larger example, dabAcCaCBAcCcaDA:

dabAcCaCBAcCcaDA  The first 'cC' is removed.
dabAaCBAcCcaDA    This creates 'Aa', which is removed.
dabCBAcCcaDA      Either 'cC' or 'Cc' are removed (the result is the same).
dabCBAcaDA        No further actions can be taken.

     */
    [Theory]
    [InlineData("aA", "", 0)]
    [InlineData("abBA", "", 0)]
    [InlineData("aabAAB", "aabAAB", 6)]
    [InlineData("dabAcCaCBAcCcaDA", "dabCBAcaDA", 10)]
    public void Day05_ReactPolymers(string poly, string expected, int size)
    {
        var sut = new Day05Polymers();
        var actual = sut.React(poly);
        Assert.Equal(expected, actual);
        Assert.Equal(actual.Length, size);
    }

    [Fact]
    public void Day05_PolymerPart1_Answer()
    {
        string datapath = "day05a.txt";
        //string datapath2 = @"C:\Work\fun\AdventCode2018\data\input.txt";
        var sut = new Day05Polymers();

        var rows = sut.ReadDataFile(datapath);
        Assert.NotNull(rows);

        var reactedPoly = sut.React(rows[0]);

        Assert.Equal(10368, reactedPoly.Length);
    }

    [Theory]
    [InlineData("dabAcCaCBAcCcaDA", "a", 6)]
    [InlineData("dabAcCaCBAcCcaDA", "b", 8)]
    [InlineData("dabAcCaCBAcCcaDA", "c", 4)]
    [InlineData("dabAcCaCBAcCcaDA", "d", 6)]
    public void Day05_RemoveThenReactPolymers(string poly, string unit, int size)
    {
        var sut = new Day05Polymers();
        var temp = sut.RemoveUnit(poly, unit);
        var actual = sut.React(temp);
        Assert.Equal(actual.Length, size);
    }

    [Fact]
    public void Day05_PolymerPart2_Answer()
    {
        string datapath = "day05a.txt";
        string alphas = "abcdefghijklmnopqrstuvwxyz";
        //string datapath2 = @"C:\Work\fun\AdventCode2018\data\input.txt";
        var sut = new Day05Polymers();

        var rows = sut.ReadDataFile(datapath);
        Assert.NotNull(rows);

        int minLength = rows[0].Length;

        foreach (char ch in alphas)
        {
            string result = rows[0];
            result = sut.RemoveUnit(result, ch.ToString());
            result = sut.React(result);
            minLength = (result.Length < minLength) ? result.Length : minLength;
        }

        Assert.Equal(4122, minLength);
    }
}
