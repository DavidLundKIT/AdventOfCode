using AdventOfCode2020;
using System.Collections.Generic;
using Xunit;

namespace DailyXUnitTests
{
    public class Day09XmasCodeUnitTests
    {
        private List<long> testNumbers = new List<long>()
        {
            35,
            20,
            15,
            25,
            47,
            40,
            62,
            55,
            65,
            95,
            102,
            117,
            150,
            182,
            127,
            219,
            299,
            277,
            309,
            576
        };

        [Fact(Skip = "Daily completed")]
        public void Day09ReadDataFileAsLongs_OK()
        {
            var numbers = DailyDataUtilities.ReadLongsFromFile("Day09Data.txt");
            Assert.Equal(1000, numbers.Count);

        }

        [Fact(Skip = "Daily completed")]
        public void DayFindFirstXmasCodeFail_Ok()
        {
            var sut = new XmasDecoder(testNumbers, 5);
            long actual = sut.FindFirstFail();
            Assert.Equal(127, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day09XmasDecoder_Part1_OK()
        {
            var numbers = DailyDataUtilities.ReadLongsFromFile("Day09Data.txt");
            Assert.Equal(1000, numbers.Count);

            var sut = new XmasDecoder(numbers, 25);
            long actual = sut.FindFirstFail();
            Assert.Equal(69316178, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void DayFindFirstXmasCode_FindWeakness_Ok()
        {
            var sut = new XmasDecoder(testNumbers, 5);
            long actual = sut.FindFirstFail();
            Assert.Equal(127, actual);

            long actual2 = sut.FindMultiNumbers(actual);
            Assert.Equal(62, actual2);
        }

        [Fact(Skip = "Daily completed")]
        public void Day09XmasDecoder_FindWeakness_Part2_OK()
        {
            var numbers = DailyDataUtilities.ReadLongsFromFile("Day09Data.txt");
            Assert.Equal(1000, numbers.Count);

            var sut = new XmasDecoder(numbers, 25);
            long actual = sut.FindFirstFail();
            Assert.Equal(69316178, actual);

            long actual2 = sut.FindMultiNumbers(actual);
            Assert.Equal(9351526, actual2);
        }
    }
}
