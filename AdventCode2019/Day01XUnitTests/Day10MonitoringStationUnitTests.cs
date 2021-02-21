using AdventOfCode2019;
using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day10MonitoringStationUnitTests
    {
        [Fact]
        public void Day10Part1_Example01()
        {
            string[] map = new string[]
            {
                ".#..#",
                ".....",
                "#####",
                "....#",
                "...##"
            };

            var sut = new MonitorStation(map);
            Assert.Equal(10, sut.Asteroids.Count);

            var bestStation = sut.FindBestStation();
            Assert.Equal(3, bestStation.X);
            Assert.Equal(4, bestStation.Y);
            Assert.Equal(8, bestStation.Steps0);
        }

        [Fact]
        public void Day10Part1_TestSolution()
        {
            string[] map = DayDataUtilities.ReadLinesFromFile("day10.txt");
            Assert.NotNull(map);
            var sut = new MonitorStation(map);
            Assert.Equal(316, sut.Asteroids.Count);
            var bestStation = sut.FindBestStation();
            Assert.Equal(26, bestStation.X);
            Assert.Equal(28, bestStation.Y);
            Assert.Equal(267, bestStation.Steps0);
        }

        [Fact]
        public void Day10Part2_TestSolution()
        {
            string[] map = DayDataUtilities.ReadLinesFromFile("day10.txt");
            Assert.NotNull(map);
            var sut = new MonitorStation(map);
            var bestStation = new Point(26, 28);
            var dictLos = sut.CalculateLOS(bestStation);
            Assert.Equal(256, dictLos.Count);

            var polarPts = sut.MakeMapPolar(bestStation);
            // Start point is angle -1,5707963267948966, ie. -pi/2, wrap angle by adding 2 pi
            foreach (var pt in polarPts)
            {
                if (pt.angle < -1.5707963267948966)
                {
                    pt.angle += 2 * Math.PI;
                }
            }

            Assert.Equal(sut.Asteroids.Count - 1, polarPts.Count);
            SortedDictionary<double, List<PolarPoint>> dictPolar = sut.MakePolarLOS(polarPts);
            sut.DumpPolarLOS(dictPolar);
            Assert.Equal(267, dictPolar.Count);
            int count = 1;
            PolarPoint rock200 = null;
            foreach (var angle in dictPolar.Keys)
            {
                if (count == 200)
                {
                    rock200 = dictPolar[angle].Find(r => r.dist == dictPolar[angle].Min(p => p.dist));
                    break;
                }
                count++;
            }
            Assert.NotNull(rock200);
            Assert.Equal(1309, rock200.cartPt.Y + rock200.cartPt.X * 100);
        }
    }
}
