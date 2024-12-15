using AdventCode2024.Models;

namespace AdventCode2024;

public class Day10HoofItUnitTests
{
    [Fact]
    public void TrailHeadScore_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day10test.txt");
        int count = 8;
        Assert.Equal(count, lines.Length);

        var mapper = new TrailMapper(lines);
        count = mapper.FindAllTrails();
        Assert.Equal(81, count);
        int actual = mapper.Trails.Count();
        Assert.Equal(36, actual);
    }

    [Fact]
    public void Day10_Part1_HoofIt_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day10.txt");
        int count = 40;
        Assert.Equal(count, lines.Length);

        var mapper = new TrailMapper(lines);
        count = mapper.FindAllTrails();
        //Assert.Equal(81, count);
        int actual = mapper.Trails.Count();
        Assert.Equal(468, actual);
    }
}
