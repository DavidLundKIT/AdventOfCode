using AdventOfCode2019;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day11SpacePoliceUnitTests
    {
        [Fact]
        public void Day11Part1_TestSoulution()
        {
            List<long> pgm = DayDataUtilities.ReadMagicSmokePgmFromFile("day11.txt");
            Assert.NotNull(pgm);
            var sut = new HullPainterRobot(pgm);

            int actual = sut.GoPaint();

            Assert.Equal(2021, actual);
        }

        [Fact]
        public void Day11Part2_TestSoulution()
        {
            List<long> pgm = DayDataUtilities.ReadMagicSmokePgmFromFile("day11.txt");
            Assert.NotNull(pgm);
            var sut = new HullPainterRobot(pgm);
            Point firstWhite = new Point(0, 0);
            sut.HullDict.Add(firstWhite, 1);
            int actual = sut.GoPaint();

            Assert.Equal(249, actual);

            int maxX = sut.HullDict.Keys.Max(p => p.X);
            int minX = sut.HullDict.Keys.Min(p => p.X);
            int maxY = sut.HullDict.Keys.Max(p => p.Y);
            int minY = sut.HullDict.Keys.Min(p => p.Y);
            for (int y = maxY; y >= minY; y--)
            {
                for (int i = 0; i < 4; i++)
                {

                    for (int x = minX; x <= maxX; x++)
                    {
                        Point p = new Point(x, y);
                        if (sut.HullDict.ContainsKey(p))
                        {
                            if (sut.HullDict[p] == 1)
                            {
                                Debug.Write("....");
                            }
                            else
                            {
                                Debug.Write("####");
                            }
                        }
                        else
                        {
                            Debug.Write("####");
                        }
                    }
                    Debug.WriteLine("=");
                }
            }
            Assert.Equal(-5, minY);
        }
    }
}
