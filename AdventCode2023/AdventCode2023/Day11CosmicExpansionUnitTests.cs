using AdventCode2023.Models;

namespace AdventCode2023
{
    public class Day11CosmicExpansionUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day11.txt");
            long expectedLineCount = 140;
            long actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day11test1.txt");
            long expectedLineCount = 10;
            long actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var cosmos = new CosmicExpansionMapper(lines);

            Assert.Equal(9, cosmos.Stars.Count());

            cosmos.ExpandTheCosmos(1);

            Assert.Equal(9, cosmos.ExpandedStars.Count());

            actual = cosmos.CalcGalaxyLengths();

            Assert.Equal(374, actual);
        }

        [Fact]
        public void Day11_Part1_CosmicExpansion_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day11.txt");
            long expectedLineCount = 140;
            long actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var cosmos = new CosmicExpansionMapper(lines);

            Assert.Equal(461, cosmos.Stars.Count());

            cosmos.ExpandTheCosmos(1);

            Assert.Equal(461, cosmos.ExpandedStars.Count());

            actual = cosmos.CalcGalaxyLengths();

            Assert.Equal(10490062, actual);
        }

        [Theory]
        [InlineData(1, 374)]
        [InlineData(10, 1030)]
        [InlineData(100, 8410)]
        public void Factor_10_Test_OK(int factor, long expected)
        {
            var lines = Utils.ReadLinesFromFile("Day11test1.txt");
            long expectedLineCount = 10;
            long actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var cosmos = new CosmicExpansionMapper(lines);

            cosmos.ExpandTheCosmos(factor);

            actual = cosmos.CalcGalaxyLengths();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Day11_Part2_CosmicExpansion_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day11.txt");
            long expectedLineCount = 140;
            long actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var cosmos = new CosmicExpansionMapper(lines);

            Assert.Equal(461, cosmos.Stars.Count());

            cosmos.ExpandTheCosmos(1000000);

            Assert.Equal(461, cosmos.ExpandedStars.Count());

            actual = cosmos.CalcGalaxyLengths();

            // too high 382980107092
            Assert.Equal(382979724122, actual);
        }

    }
}
