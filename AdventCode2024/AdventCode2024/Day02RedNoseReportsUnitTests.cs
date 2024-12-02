using AdventCode2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2024;

public class Day02RedNoseReportsUnitTests
{
    [Fact]
    public void Day02_Step1_SafeReports_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day02.txt");
        int count = 1000;
        Assert.Equal(count, lines.Length);

        int safeCount = 0;
        bool isSafe = false;
        var sut = new ReportHandler();
        foreach (var line in lines)
        {
            isSafe = sut.IsSafe(line);
            if (isSafe)
            {
                safeCount++;
            }
        }
        Assert.Equal(1000, safeCount);
    }

    [Theory]

    [InlineData("7 6 4 2 1", true)]
    [InlineData("1 2 7 8 9", false)]
    [InlineData("9 7 6 2 1", false)]
    [InlineData("1 3 2 4 5", false)]
    [InlineData("8 6 4 4 1", false)]
    [InlineData("1 3 6 7 9", true)]
    public void CheckIfRowIsSafe_OK(string line, bool isSafe)
    {
        var sut = new ReportHandler();
        var actual = sut.IsSafe(line);

        Assert.Equal(isSafe, actual);
    }
}
