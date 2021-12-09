using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class Day09SmokeBasinTests
    {
        public string[] TestLines { get; set; }

        public Day09SmokeBasinTests()
        {
            TestLines = new string[]
            {
                "2199943210",
                "3987894921",
                "9856789892",
                "8767896789",
                "9899965678"
            };
        }

        [Fact]
        public void Test_ReadSegments_Ok()
        {
            Assert.Equal(5, TestLines.Length);

            var sut = new SmokeDetector(TestLines);
            int actual = sut.FindTotalRiskLevel();
            Assert.Equal(15, actual);
            long lactual = sut.FindTop3BasinValues();
            Assert.Equal(1134, lactual);
        }

        [Fact]
        public void Day09_Puzzle1_and_2_Ok()
        {
            var lines = Utils.ReadLinesFromFile("Day09.txt");
            Assert.Equal(100, lines.Length);
            var sut = new SmokeDetector(lines);
            int actual = sut.FindTotalRiskLevel();
            Assert.Equal(588, actual);
            long lactual = sut.FindTop3BasinValues();
            Assert.Equal(964712, lactual);
        }
    }
}
