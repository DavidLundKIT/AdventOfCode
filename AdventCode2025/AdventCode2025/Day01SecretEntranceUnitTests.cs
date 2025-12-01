using AdventCode2025.Models;

namespace AdventCode2025;

public class Day01SecretEntranceUnitTests
{
    [Fact]
    public void SecretEntrance_TestData_OK()
    {             
        //var secretEntrance = new Day01SecretEntrance();
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

        Assert.Equal(3, actual);
    }
}
