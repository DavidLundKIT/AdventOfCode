using AdventCode2024.Models;

namespace AdventCode2024;

public class Day04CeresSearchUnitTests
{
    [Fact]
    public void CeresSearchXmas_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day04test.txt");
        int count = 10;
        Assert.Equal(count, lines.Length);

        var search = new CeresSearch(lines);
        var actual = search.FindAllXmas();

        Assert.Equal(18, actual);
    }

    [Fact]
    public void Day04_Step1_CeresSearchXmas_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day04.txt");
        int count = 140;
        Assert.Equal(count, lines.Length);

        var search = new CeresSearch(lines);
        var actual = search.FindAllXmas();

        Assert.Equal(2514, actual);
    }

}
