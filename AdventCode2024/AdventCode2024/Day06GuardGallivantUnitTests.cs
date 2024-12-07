using AdventCode2024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2024;

public class Day06GuardGallivantUnitTests
{
    [Fact]
    public void GuardGallivanting_GetBoard_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day06test.txt");
        int count = 10;
        Assert.Equal(count, lines.Length);

        var gg = new GuardGallivanter(lines);
        Assert.Equal(4, gg.GuardStart.X);
        Assert.Equal(6, gg.GuardStart.Y);
    }

    [Fact]
    public void Day06_Step1_GuardGallivanting_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day06.txt");
        int count = 130;
        Assert.Equal(count, lines.Length);

        var gg = new GuardGallivanter(lines);
        Assert.Equal(36, gg.GuardStart.X);
        Assert.Equal(52, gg.GuardStart.Y);
    }
}
