using AdventCode2025.Models;

namespace AdventCode2025;

public class Day01SecretEntranceUnitTests
{
    [Fact]
    public void SecretEntrance_TestData_OK()
    {             
        var lines = Utils.ReadLinesFromFile("Day01test.txt");
        Assert.NotNull(lines);
        Assert.NotEmpty(lines);
        Assert.Equal(10, lines.Length);
        Assert.Equal("L68", lines[0]);
        var sut = new SecretEntranceMapper(lines);
        var actual = sut.TimesMovedToZero(50);

        Assert.Equal(3, actual);
    }

    [Fact]
    public void Day01_Part1_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day01.txt");
        Assert.NotNull(lines);
        Assert.NotEmpty(lines);
        Assert.Equal(4779, lines.Length);
        Assert.Equal("L50", lines[0]);
        var sut = new SecretEntranceMapper(lines);
        var actual = sut.TimesMovedToZero(50);

        Assert.Equal(1147, actual);
    }

    [Fact]
    public void SecretEntrance_TestData_AllZeros_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day01test.txt");
        Assert.NotNull(lines);
        Assert.NotEmpty(lines);
        Assert.Equal(10, lines.Length);
        Assert.Equal("L68", lines[0]);
        var sut = new SecretEntranceMapper(lines);
        var actual = sut.TimesPassingStoppingOnZero(50);

        Assert.Equal(6, actual);
    }

    [Fact]
    public void Day01_Part2_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day01.txt");
        Assert.NotNull(lines);
        Assert.NotEmpty(lines);
        Assert.Equal(4779, lines.Length);
        Assert.Equal("L50", lines[0]);
        var sut = new SecretEntranceMapper(lines);
        var actual = sut.TimesPassingStoppingOnZero(50);

        // 7214 wrong, too high
        // 6880 wrong too high
        Assert.Equal(1147, actual);
    }
}
