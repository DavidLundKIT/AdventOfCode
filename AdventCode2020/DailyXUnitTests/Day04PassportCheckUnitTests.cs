using AdventOfCode2020;
using Xunit;

namespace DailyXUnitTests
{
    public class Day04PassportCheckUnitTests
    {
        [Fact(Skip = "Daily completed")]
        public void Day04ReadForestData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day04Data.txt");
            Assert.Equal(1069, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void Day04ReadForestTestData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day04TestData.txt");
            Assert.Equal(13, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void Day04_ValidPassports_TestData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day04TestData.txt");

            var sut = new PassportChecker();
            int actual = sut.ProcessPassports(lines, false);
            Assert.Equal(2, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day04_ValidPassports_Part1_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day04Data.txt");

            var sut = new PassportChecker();
            int actual = sut.ProcessPassports(lines, false);
            Assert.Equal(202, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day04_ValidPassports_TestDataPart2_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day04TestData2.txt");

            var sut = new PassportChecker();
            int actual = sut.ProcessPassports(lines, true);
            Assert.Equal(4, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day04_ValidPassports_Part2_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day04Data.txt");

            var sut = new PassportChecker();
            int actual = sut.ProcessPassports(lines, true);
            Assert.Equal(137, actual);
        }

    }
}
