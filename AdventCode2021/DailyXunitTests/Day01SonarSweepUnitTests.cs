using AdventCode2021;
using System.Collections.Generic;
using Xunit;

namespace DailyXunitTests
{
    public class Day01SonarSweepUnitTests
    {
        private List<int> testList;

        public Day01SonarSweepUnitTests()
        {
            testList = new List<int>()
            {
                199,
                200,
                208,
                210,
                200,
                207,
                240,
                269,
                260,
                263
            };
        }

        [Fact]
        public void Day01_Puzzle1_OK()
        {
            var sut = new SonarSweeper();
            var depths = Utils.ReadIntsFromFile("Day01.txt");
            int expected = 9105;
            Assert.Equal(expected, depths[depths.Count - 1]);

            int increases = sut.SimpleIncreases(depths);

            Assert.Equal(1692, increases);
        }

        [Fact]
        public void CreateSumList_OK()
        {
            var sut = new SonarSweeper();
            int expected = 263;
            Assert.Equal(expected, testList[testList.Count - 1]);

            var sums = sut.ToSumList(testList);
            Assert.Equal(8, sums.Count);
            Assert.Equal(792, sums[sums.Count - 1]);
            int increases = sut.SimpleIncreases(sums);
            Assert.Equal(5, increases);
        }

        [Fact]
        public void Day01_Puzzle2_OK()
        {
            var sut = new SonarSweeper();
            var depths = Utils.ReadIntsFromFile("Day01.txt");
            int expected = 9105;
            Assert.Equal(expected, depths[depths.Count - 1]);

            var sums = sut.ToSumList(depths);
            int increases = sut.SimpleIncreases(sums);

            Assert.Equal(1724, increases);
        }

    }
}
