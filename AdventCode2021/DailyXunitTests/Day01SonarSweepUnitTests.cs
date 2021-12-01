using System;
using System.Collections.Generic;
using System.Text;
using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class Day01SonarSweepUnitTests
    {
        [Fact]
        public void Day01_Puzzle1_OK()
        {
            var depths = Utils.ReadIntsFromFile("Day01.txt");
            int expected = 9105;
            Assert.Equal(expected, depths[depths.Count-1]);

            int increases = 0;
            for (int ii = 1; ii < depths.Count; ii++)
            {
                if (depths[ii-1] < depths[ii])
                {
                    increases++;
                }
            }

            Assert.Equal(1692, increases);
        }

        [Fact]
        public void Day01_Puzzle2_OK()
        {
            var depths = Utils.ReadIntsFromFile("Day01.txt");
            int expected = 9105;
            Assert.Equal(expected, depths[depths.Count - 1]);

            int increases = 0;
            for (int ii = 1; ii < depths.Count+2; ii++)
            {
                if (Sum(depths, ii - 1) < Sum(depths, ii))
                {
                    increases++;
                }
            }

            Assert.Equal(1692, increases);
        }

        public int Sum(List<int> depths, int index)
        {
            int sum = 0;
            for (int ii = 0; ii < 3; ii++)
            {
                int iiNow = index - ii;
                if (iiNow >= 0 && iiNow < depths.Count)
                {
                    sum += depths[iiNow];
                }
            }
            return sum;
        }
    }
}
