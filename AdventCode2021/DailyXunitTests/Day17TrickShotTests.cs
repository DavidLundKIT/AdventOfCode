using AdventCode2021;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

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
        [InlineData(7, 40, true)]
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
    }
}
