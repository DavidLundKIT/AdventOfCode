using AdventCode2024.Models;

namespace AdventCode2024;

public class Day05PrintQueueUnitTests
{
    [Fact]
    public void ReadInData_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day05test.txt");
        Assert.Equal(28, lines.Length);

        var checker = new PageQueueOrderChecker(lines);
        Assert.Equal(21, checker.Rules.Count);
        Assert.Equal(6, checker.Manuals.Count);

        int actual = checker.CheckPageOrderOfManuals();
        Assert.Equal(143, actual);
    }

    [Fact]
    public void Day05_Step1_PrintQueue_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day05.txt");
        Assert.Equal(1375, lines.Length);

        var checker = new PageQueueOrderChecker(lines);
        Assert.Equal(1176, checker.Rules.Count);
        Assert.Equal(198, checker.Manuals.Count);

        int actual = checker.CheckPageOrderOfManuals();
        Assert.Equal(5639, actual);
    }
}
