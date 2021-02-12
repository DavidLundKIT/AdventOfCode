using AdventOfCode2020;
using Xunit;

namespace DailyXUnitTests
{
    public class Day06CustomFormUnitTests
    {
        [Fact(Skip = "Daily completed")]
        public void Day06ReadCustomFormsData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day06Data.txt");
            Assert.Equal(2057, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void Day06ReadCustomFormsTestData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day06TestData.txt");
            Assert.Equal(15, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void Day06ReadCustomForms_SumUniqueAnswersPerGroup_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day06TestData.txt");
            Assert.Equal(15, lines.Length);

            var sut = new CustomFormChecker();
            int sum = sut.ProcessForms(lines);
            Assert.Equal(11, sum);
        }

        [Fact(Skip = "Daily completed")]
        public void Day06ReadCustomForms_Part1_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day06Data.txt");

            var sut = new CustomFormChecker();
            int sum = sut.ProcessForms(lines);
            Assert.Equal(6170, sum);
        }

        [Fact(Skip = "Daily completed")]
        public void Day06ReadCustomForms_SumEveryoneAnsweredPerGroup_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day06TestData.txt");
            Assert.Equal(15, lines.Length);

            var sut = new CustomFormChecker();
            int sum = sut.ProcessFormsAdvanced(lines);
            Assert.Equal(6, sum);
        }

        [Fact(Skip = "Daily completed")]
        public void Day06ReadCustomForms_Part2_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day06Data.txt");

            var sut = new CustomFormChecker();
            int sum = sut.ProcessFormsAdvanced(lines);
            Assert.Equal(2947, sum);
        }
    }
}
