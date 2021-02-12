using AdventOfCode2020;
using Xunit;

namespace DailyXUnitTests
{
    public class Day15RambuntiousRecitationsUnitTests
    {
        private long[] day15Data = new long[] { 10, 16, 6, 0, 1, 17 };

        [Theory(Skip = "Daily completed")]
        [InlineData(4, 0)]
        [InlineData(5, 3)]
        [InlineData(6, 3)]
        [InlineData(7, 1)]
        [InlineData(8, 0)]
        [InlineData(9, 4)]
        [InlineData(10, 0)]
        [InlineData(2020, 436)]
        public void Day15_Example1_OK(long turnDesired, long expected)
        {
            long[] data = new long[] { 0, 3, 6 };

            var sut = new ElfMemoryGame();
            sut.SeedStartNumbers(data);
            long actual = sut.RunToTurn(turnDesired);
            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day15_Part1_OK()
        {
            //long[] data = new long[] { 0, 3, 6 };

            var sut = new ElfMemoryGame();
            sut.SeedStartNumbers(day15Data);
            long actual = sut.RunToTurn(2020);
            Assert.Equal(412, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day15_Part2_OK()
        {
            //long[] data = new long[] { 0, 3, 6 };

            var sut = new ElfMemoryGame();
            sut.SeedStartNumbers(day15Data);
            long actual = sut.RunToTurn(30000000);
            Assert.Equal(243, actual);
        }
    }
}
