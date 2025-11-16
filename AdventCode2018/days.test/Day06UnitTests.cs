using days.day06;
using Xunit;

namespace days.test;

public class Day06UnitTests
{
    [Fact]
    public void Day06_ParseData_ok()
    {
        string datapath = "day06a.txt";

        var sut = new ChronalCoordination();
        var actual = sut.ParseDataFile(datapath);
        Assert.Equal(50, actual.Count);
        Assert.Equal(123, actual[49].X);
        Assert.Equal(225, actual[49].Y);
    }

    [Fact]
    public void Day06_FindMaxXY_ok()
    {
        string datapath = "day06a.txt";

        var sut = new ChronalCoordination();
        var coords = sut.ParseDataFile(datapath);

        var max = sut.FindMaxXY(coords);
        
        Assert.Equal(359, max.X);
        Assert.Equal(351, max.Y);
    }

    [Fact]
    public void Day06_FillGrid_ok()
    {
        string datapath = "day06a.txt";

        var sut = new ChronalCoordination();
        var coords = sut.ParseDataFile(datapath);
        var max = sut.FindMaxXY(coords);
        
        Assert.Equal(359, max.X);
        Assert.Equal(351, max.Y);

        int [,] chronos = new int[max.X +1, max.Y+1];
        for (int x = 0; x < max.X+1; x++)
        {
            for (int y = 0; y < max.Y+1; y++)
            {
                chronos[x,y] = sut.ClosestCoord(x, y, coords);
                if (chronos[x,y] >= 0)
                {
                    coords[chronos[x,y]].Area+=1;
                    if (x == 0 || x == max.X || y == 0 || y == max.Y)
                    {
                        coords[chronos[x,y]].Infinite = true;
                    }
                }
            }
        }
        
        int maxArea = 0;
        foreach (var coord in coords)
        {
            if (coord.Infinite == false && coord.Area > maxArea)
            {
                maxArea = coord.Area;
            }
        }

        Assert.Equal(4475, maxArea);
    }

    [Fact]
    public void Day06_FindAreaSumUnder10000()
    {
        string datapath = "day06a.txt";

        var sut = new ChronalCoordination();
        var coords = sut.ParseDataFile(datapath);
        var max = sut.FindMaxXY(coords);
        
        Assert.Equal(359, max.X);
        Assert.Equal(351, max.Y);

        int area = 0;
        int dist = 0;
        for (int x = 0; x < max.X+1; x++)
        {
            for (int y = 0; y < max.Y+1; y++)
            {
                dist = sut.SumDistanceToCoord(x, y, coords);
                if (dist < 10000)
                {
                    area ++;
                }
            }
        }

        Assert.Equal(35237, area);
    }
}
