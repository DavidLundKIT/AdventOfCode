using AdventCode2021;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

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
            var dictVoT = TrickShotProbe.FindValidVelocityXs(PuzzleTarget);
            Assert.NotEmpty(dictVoT);
            int actual = dictVoT.Values.Max(l => l.Max(t => t.Item2));
            Assert.Equal(20, actual);
        }

        [Fact]
        public void Day17_Puzzle1_FindMaxY_OK()
        {
            var dictVoT = TrickShotProbe.FindValidVelocityYs(PuzzleTarget);
            // Look in the dictionary for highest max value.
            Assert.NotEmpty(dictVoT);
            int actual = dictVoT.Values.Max(l => l.Max(t => t.Item3));
            int maxT = dictVoT.Values.Max(l => l.Max(t => t.Item2));
            Assert.Equal(7381, actual);
            Assert.Equal(244, maxT);
        }

        [Fact]
        public void Day17_Puzzle2_OK()
        {
            var dictVelXs = TrickShotProbe.FindValidVelocityXs(PuzzleTarget);
            Assert.NotEmpty(dictVelXs);
            var dictVelYs = TrickShotProbe.FindValidVelocityYs(PuzzleTarget);
            Assert.NotEmpty(dictVelXs);

            Dictionary<Point, int> dictVels = new Dictionary<Point, int>();

            var velXs = new List<Tuple<int, int, int>>();
            foreach (var list in dictVelXs.Values)
            {
                velXs.AddRange(list);
            }
            // find VelX that stop in target.
            var stopVelx = velXs.Where(vx => vx.Item1 == vx.Item2).ToList();
            Assert.Equal(2, stopVelx.Count);
            int minTxs = stopVelx.Min(t => t.Item2);

            var velYs = new List<Tuple<int, int, int>>();
            foreach (var list in dictVelYs.Values)
            {
                velYs.AddRange(list);
            }
            var velYsOverMaxXTime = velYs.Where(vy => vy.Item2 >= minTxs);

            foreach (var vy in velYsOverMaxXTime)
            {
                foreach (var vx in stopVelx)
                {
                    var p = new Point(vx.Item1, vy.Item1);
                    if (!dictVels.ContainsKey(p))
                        dictVels.Add(p, 1);
                    else
                        dictVels[p]++;
                }
            }

            foreach (var vx in velXs)
            {
                foreach (var vy in velYs.Where(t => t.Item2 == vx.Item2))
                {
                    var p = new Point(vx.Item1, vy.Item1);
                    if (!dictVels.ContainsKey(p))
                        dictVels.Add(p, 1);
                    else
                        dictVels[p]++;
                }
            }
            int actual = dictVels.Count;
            Assert.Equal(3019, actual);
        }
    }
}
