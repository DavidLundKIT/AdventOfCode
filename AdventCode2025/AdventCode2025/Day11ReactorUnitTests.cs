using AdventCode2025.Models;

namespace AdventCode2025;

public class Day11ReactorUnitTests
{
    [Fact]
    public void Day11_TestData_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day11test.txt");
        Assert.Equal(10, lines.Length);

        var sut = new DataPathMapper(lines);
        Assert.Equal(10, sut.DeviceOutputs.Count);
        Assert.True(sut.DeviceOutputs.ContainsKey("you"));

        var actual = sut.CountAllDataPathsFromDevice("you");
        Assert.Equal(5, actual);
    }

    [Fact]
    public void Day11_Part1_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day11.txt");
        Assert.Equal(647, lines.Length);

        var sut = new DataPathMapper(lines);
        Assert.Equal(647, sut.DeviceOutputs.Count);
        Assert.True(sut.DeviceOutputs.ContainsKey("you"));

        var actual = sut.CountAllDataPathsFromDevice("you");
        Assert.Equal(555, actual);
    }

    [Fact]
    public void Day11_TestData2_Svr_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day11test2.txt");
        Assert.Equal(13, lines.Length);

        var sut = new DataPathMapper(lines);
        Assert.Equal(13, sut.DeviceOutputs.Count);
        Assert.True(sut.DeviceOutputs.ContainsKey("svr"));

        var actual = sut.CountPathsViaDacFftFromDevice("svr", false, false, string.Empty);
        Assert.Equal(2, actual);
    }

    [Fact]
    public void Day11_Part1_Solution_using_svr_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day11.txt");
        Assert.Equal(647, lines.Length);

        var sut = new DataPathMapper(lines);
        Assert.Equal(647, sut.DeviceOutputs.Count);
        Assert.True(sut.DeviceOutputs.ContainsKey("svr"));

        var actual = sut.CountAllDataPathsFromDevice("svr");
        Assert.Equal(555, actual);
    }
    [Fact]
    public void Day11_Part2_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day11.txt");
        Assert.Equal(647, lines.Length);

        var sut = new DataPathMapper(lines);
        Assert.Equal(647, sut.DeviceOutputs.Count);
        Assert.True(sut.DeviceOutputs.ContainsKey("svr"));

        var actual = sut.CountPathsViaDacFftFromDevice("svr", false, false, string.Empty);
        Assert.Equal(5, actual);
    }
}
