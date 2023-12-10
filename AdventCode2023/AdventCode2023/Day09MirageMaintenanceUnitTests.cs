using AdventCode2023.Models;

namespace AdventCode2023
{
    public class Day09MirageMaintenanceUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day09.txt");
            int expectedLineCount = 200;
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);
        }

        [Theory]
        [InlineData("0 3 6 9 12 15", 18)]
        [InlineData("1 3 6 10 15 21", 28)]
        [InlineData("10 13 16 21 30 45", 68)]
        public void ExtrapolateHistory_Test_OK(string line, int expected)
        {
            var sut = new MirageExtrapolator(line);
            long actual = sut.Extrapolate();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("0 3 6 9 12 15", -3)]
        [InlineData("1 3 6 10 15 21", 0)]
        [InlineData("10 13 16 21 30 45", 5)]
        public void ExtrapolateHistoryBack_Test_OK(string line, int expected)
        {
            var sut = new MirageExtrapolator(line);
            long actual = sut.ExtrapolateBack();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Day09_Part1_MirageMaintenance_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day09.txt");
            int expectedLineCount = 200;
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            long sum = 0;
            foreach (var line in lines)
            {
                var sut = new MirageExtrapolator(line);
                sum += sut.Extrapolate();
            }
            Assert.Equal(1647269739, sum);
        }

        [Fact]
        public void Day09_Part2_MirageMaintenance_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day09.txt");
            int expectedLineCount = 200;
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            long sum = 0;
            foreach (var line in lines)
            {
                var sut = new MirageExtrapolator(line);
                sum += sut.ExtrapolateBack();
            }
            Assert.Equal(864, sum);
        }
    }
}
