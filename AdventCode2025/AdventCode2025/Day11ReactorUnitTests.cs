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

        var actual = sut.CountAllDataPathsFromDevice("you", "out");
        Assert.Equal(555, actual);
    }

    [Fact]
    public void Day11_TestData_NewMethod_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day11test.txt");
        Assert.Equal(10, lines.Length);

        var sut = new DataPathMapper(lines);
        Assert.Equal(10, sut.DeviceOutputs.Count);
        Assert.True(sut.DeviceOutputs.ContainsKey("you"));

        var visited = new HashSet<string>();
        var actual = sut.CountAllDataPathsFromDevice("you", "out", visited);
        Assert.Equal(5, actual);
    }

    [Fact]
    public void Day11_Part1_Solution_NewMethod_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day11.txt");
        Assert.Equal(647, lines.Length);

        var sut = new DataPathMapper(lines);
        Assert.Equal(647, sut.DeviceOutputs.Count);
        Assert.True(sut.DeviceOutputs.ContainsKey("you"));

        var actual = sut.CountAllDataPathsFromDevice("you", "out");
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

    [Theory]
    [InlineData("svr", "fft", 1)]
    [InlineData("svr", "dac", 2)]
    [InlineData("dac", "fft", 0)]
    [InlineData("fft", "dac", 1)]
    [InlineData("dac", "out", 2)]
    [InlineData("fft", "out", 4)]
    public void Day11_TestData2_Svr_NewMethod_parts_OK(string startDevice, string endDevice, int expectedCount)
    {
        var lines = Utils.ReadLinesFromFile("Day11test2.txt");
        Assert.Equal(13, lines.Length);

        var sut = new DataPathMapper(lines);
        Assert.Equal(13, sut.DeviceOutputs.Count);
        Assert.True(sut.DeviceOutputs.ContainsKey("svr"));

        var actual = sut.CountAllDataPathsFromDevice(startDevice, endDevice);
        Assert.Equal(expectedCount, actual);
    }

    [Fact]
    public void Day11_TestData2_Svr_NewMethod_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day11test2.txt");
        Assert.Equal(13, lines.Length);

        var sut = new DataPathMapper(lines);
        Assert.Equal(13, sut.DeviceOutputs.Count);
        Assert.True(sut.DeviceOutputs.ContainsKey("svr"));

        var actual = (sut.CountAllDataPathsFromDevice("svr", "dac") * sut.CountAllDataPathsFromDevice("dac", "fft") * sut.CountAllDataPathsFromDevice("fft", "out"));
        actual += (sut.CountAllDataPathsFromDevice("svr", "fft") * sut.CountAllDataPathsFromDevice("fft", "dac") * sut.CountAllDataPathsFromDevice("dac", "out"));
        Assert.Equal(2, actual);
    }


    [Fact(Skip = "Not ending")]
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

    [Fact(Skip = "Not ending")]
    public void Day11_Part2_Solution_not_working_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day11.txt");
        Assert.Equal(647, lines.Length);

        var sut = new DataPathMapper(lines);
        Assert.Equal(647, sut.DeviceOutputs.Count);
        Assert.True(sut.DeviceOutputs.ContainsKey("svr"));

        var actual = sut.CountPathsViaDacFftFromDevice("svr", false, false, string.Empty);
        Assert.Equal(5, actual);
    }

    [Theory]
    [InlineData("svr", "fft", 16279)]
    [InlineData("svr", "dac", 300856682806)]
    [InlineData("dac", "fft", 0)]
    [InlineData("fft", "dac", 3408588)]
    [InlineData("dac", "out", 9055)]
    [InlineData("fft", "out", 2345470204960)]
    public void Day11_Part2_Svr_NewMethod_parts_OK(string startDevice, string endDevice, long expectedCount)
    {
        var lines = Utils.ReadLinesFromFile("Day11.txt");
        Assert.Equal(647, lines.Length);

        var sut = new DataPathMapper(lines);
        Assert.Equal(647, sut.DeviceOutputs.Count);
        Assert.True(sut.DeviceOutputs.ContainsKey("svr"));

        var actual = sut.CountAllDataPathsFromDevice(startDevice, endDevice);
        Assert.Equal(expectedCount, actual);
    }

    [Fact]
    public void Day11_Part2_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day11.txt");
        Assert.Equal(647, lines.Length);

        var sut = new DataPathMapper(lines);
        Assert.Equal(647, sut.DeviceOutputs.Count);
        Assert.True(sut.DeviceOutputs.ContainsKey("svr"));

        var actual = (sut.CountAllDataPathsFromDevice("svr", "dac") * sut.CountAllDataPathsFromDevice("dac", "fft") * sut.CountAllDataPathsFromDevice("fft", "out"));
        actual += (sut.CountAllDataPathsFromDevice("svr", "fft") * sut.CountAllDataPathsFromDevice("fft", "dac") * sut.CountAllDataPathsFromDevice("dac", "out"));
        Assert.Equal(502447498690860, actual);
    }

}
