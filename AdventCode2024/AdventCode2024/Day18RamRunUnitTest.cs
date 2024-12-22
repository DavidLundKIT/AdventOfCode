using AdventCode2024.Models;

namespace AdventCode2024;

public class Day18RamRunUnitTest
{
    [Fact]
    public void RamRun_TestData_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day18test.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(25, lines.Count());

        var rrm = new RamRunMapper(lines, 7, 7);
        rrm.DropBytes(0, 12);
        rrm.ShowMap();
        int actual = rrm.MapWalk();
        Assert.Equal(22, actual);
    }

    [Fact]
    public void Day18_Part1_RamRun_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day18.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(3450, lines.Count());

        var rrm = new RamRunMapper(lines, 71, 71);
        rrm.DropBytes(0, 1024);
        rrm.ShowMap();
        int actual = rrm.MapWalk();
        Assert.Equal(432, actual);
    }

    [Fact]
    public void RamRun_TestData_UntilBlocked_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day18test.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(25, lines.Count());

        // worked with 12 bytes
        for (int iByteBomb = 13; iByteBomb < lines.Count(); iByteBomb++)
        {
            var rrm = new RamRunMapper(lines, 7, 7);
            rrm.DropBytes(0, iByteBomb);
            rrm.ShowMap();
            int actual = rrm.MapWalk();
            if (actual == -666)
            {
                var blockingByte = rrm.ByteBombs[iByteBomb - 1];
                var sActual = $"{blockingByte.X},{blockingByte.Y}";
                Assert.Equal("6,1", sActual);
                break;
            }
        }
    }

    [Fact(Skip ="Takes 3,3 minutes")]
    public void Day18_Part2_RamRun_Blocked_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day18.txt");
        Assert.NotEmpty(lines);

        // worked with 1024 bytes
        for (int iByteBomb = 1025; iByteBomb < lines.Count(); iByteBomb++)
        {
            var rrm = new RamRunMapper(lines, 71, 71);
            rrm.DropBytes(0, iByteBomb);
            //rrm.ShowMap();
            int actual = rrm.MapWalk();
            if (actual == -666)
            {
                var blockingByte = rrm.ByteBombs[iByteBomb - 1];
                var sActual = $"{blockingByte.X},{blockingByte.Y}";
                Assert.Equal("56,27", sActual);
                break;
            }
        }
    }
}
