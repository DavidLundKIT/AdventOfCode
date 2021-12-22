using AdventCode2021;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace DailyXunitTests
{
    public class Day17TrickShotTests
    {
        public const string TestData = "target area: x=20..30, y=-10..-5";
        public const string Data = "target area: x=185..221, y=-122..-74";


        public Target TestTarget { get; set; }
        public Target PuzzleTarget { get; set; }

        public Day17TrickShotTests()
        {
            TestTarget = new Target(20, 30, -10, -5);
            PuzzleTarget = new Target(185, 221, -122, -74);
        }

        [Theory]
        [InlineData(7, 2, true)]
        [InlineData(7, 40, false)]
        [InlineData(6, 3, true)]
        [InlineData(9, 0, true)]
        [InlineData(17, -4, false)]
        [InlineData(6, 9, true)]
        public void Day17_TestProbe_shots_OK(int vx, int vy, bool expected)
        {
            var target = TestTarget;
            var probe = new TrickShotProbe(vx, vy);
            bool inside = false;
            int count = 0;
            do
            {
                probe.DoSecond();
                count++;
                inside = target.Inside(probe.X, probe.Y);
                if (inside)
                    break;
            } while (probe.Y >= target.Y1);

            Assert.Equal(expected, inside);
        }

        [Fact]
        public void Day17_Puzzle1_FindX_OK()
        {
            var target = PuzzleTarget;
            Dictionary<int, List<Tuple<int, int, int>>> dictVoT = new Dictionary<int, List<Tuple<int, int, int>>>();

            foreach (var velX in Enumerable.Range(10, target.X2))
            {
                var sut = new TrickShotProbe(velX, 0);
                int sec = 0;
                do
                {
                    sec++;
                    sut.DoSecondX();
                    if (target.InsideX(sut.X))
                    {
                        Debug.WriteLine($"velX: {velX}, t: {sec}, X: {sut.X}");
                        if (!dictVoT.ContainsKey(velX))
                            dictVoT.Add(velX, new List<Tuple<int, int, int>>());

                        dictVoT[velX].Add(new Tuple<int, int, int>(velX, sec, sut.X));
                    }

                } while (sut.X <= target.X2 && sut.Velx > 0);
            }
            Assert.NotEmpty(dictVoT);
        }

        [Fact]
        public void Day17_Puzzle1_FindY_OK()
        {
            var target = PuzzleTarget;
            Dictionary<int, List<Tuple<int, int, int>>> dictVoT = new Dictionary<int, List<Tuple<int, int, int>>>();

            foreach (var velY in Enumerable.Range(1, 1000))
            {
                var sut = new TrickShotProbe(0, velY);
                int sec = 0;
                int maxY = 0;
                do
                {
                    sec++;
                    sut.DoSecondY();
                    if (sut.Y > maxY)
                        maxY = sut.Y;
                    if (target.InsideY(sut.Y))
                    {
                        Debug.WriteLine($"velY: {velY}, t: {sec}, Y: {sut.Y},  maxY: {maxY}");
                        if (!dictVoT.ContainsKey(velY))
                            dictVoT.Add(velY, new List<Tuple<int, int, int>>());

                        dictVoT[velY].Add(new Tuple<int, int, int>(velY, sec, maxY));
                    }

                } while (sut.Y >= target.Y1);
            }
            // Look in the dictionary for highest max value.
            Assert.NotEmpty(dictVoT);
        }
    }
}
