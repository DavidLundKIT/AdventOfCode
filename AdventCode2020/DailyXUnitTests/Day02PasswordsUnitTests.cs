using AdventOfCode2020;
using Xunit;

namespace DailyXUnitTests
{
    public class Day02PasswordsUnitTests
    {
        [Fact(Skip = "Daily completed")]
        public void PasswordRules_ReadData_OK()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day02Data.txt");
            Assert.Equal(1000, lines.Length);
        }

        [Theory(Skip = "Daily completed")]
        [InlineData("1-3 a: abcde", 1, 3, "a", "abcde", true)]
        [InlineData("1-3 b: cdefg", 1, 3, "b", "cdefg", false)]
        [InlineData("2-9 c: ccccccccc", 2, 9, "c", "ccccccccc", true)]
        public void TestParsingPassWordChecker(string line, int min, int max, string letter, string password, bool valid)
        {
            var sut = new PasswordChecker(line);
            Assert.Equal(line, sut.Line);
            Assert.Equal(min, sut.Min);
            Assert.Equal(max, sut.Max);
            Assert.Equal(letter, sut.Letter);
            Assert.Equal(password, sut.Password);
            bool actual = sut.IsValid();
            Assert.Equal(valid, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void PasswordChecker_Part1()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day02Data.txt");
            Assert.Equal(1000, lines.Length);

            int count = 0;
            foreach (var line in lines)
            {
                var sut = new PasswordChecker(line);
                if (sut.IsValid())
                    count++;
            }

            Assert.Equal(550, count);
        }

        [Theory(Skip = "Daily completed")]
        [InlineData("1-3 a: abcde", 1, 3, "a", "abcde", true)]
        [InlineData("1-3 b: cdefg", 1, 3, "b", "cdefg", false)]
        [InlineData("2-9 c: ccccccccc", 2, 9, "c", "ccccccccc", false)]
        public void TestParsingPassWordCheckerNew(string line, int min, int max, string letter, string password, bool valid)
        {
            var sut = new PasswordChecker(line);
            Assert.Equal(line, sut.Line);
            Assert.Equal(min, sut.Min);
            Assert.Equal(max, sut.Max);
            Assert.Equal(letter, sut.Letter);
            Assert.Equal(password, sut.Password);
            bool actual = sut.IsValidNew();
            Assert.Equal(valid, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void PasswordChecker_Part2()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day02Data.txt");
            Assert.Equal(1000, lines.Length);

            int count = 0;
            foreach (var line in lines)
            {
                var sut = new PasswordChecker(line);
                if (sut.IsValidNew())
                    count++;
            }

            Assert.Equal(634, count);
        }
    }
}
