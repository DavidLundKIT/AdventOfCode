using AdventCode2023.Models;
using System.Text.RegularExpressions;

namespace AdventCode2023
{
    public class Day03GearRatiosUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day03.txt");
            int expected = 140;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day03test.txt");
            int expected = 11;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("467..114..", 2)]
        [InlineData("...*......", 0)]
        [InlineData("..35..633.", 2)]
        [InlineData("......#...", 0)]
        [InlineData("617*......", 1)]
        [InlineData(".....+.58.", 1)]
        [InlineData("..592.....", 1)]
        [InlineData("......755.", 1)]
        [InlineData("...$.*....", 0)]
        [InlineData(".664.598..", 2)]
        [InlineData("-664.598..", 2)]
        public void TestRegex_OK(string line, int expected)
        {
            var matches = Regex.Matches(line, @"\d+");
            Assert.NotNull(matches);
            Assert.Equal(expected, matches.Count);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    int val = int.Parse(match.Value);
                    Assert.True(val > 0);
                }
            }
        }

        [Fact]
        public void FindPartsIn_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day03test.txt");
            int expected = 11;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new SchematicScanner(lines);

            sut.ScanSchematic();
            Assert.Equal(8, sut.Parts.Count);

            actual = sut.Parts.Sum();
            Assert.Equal(4361, actual);
        }

        [Fact]
        public void Day03_Part1_GearRatios_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day03.txt");
            int expected = 140;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new SchematicScanner(lines);
            sut.ScanSchematic();
            actual = sut.Parts.Sum();
            Assert.Equal(540212, actual);
        }

        [Fact]
        public void FindGearRatiosIn_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day03test.txt");
            int expected = 11;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new SchematicScanner(lines);

            sut.GetGearRatios();
            Assert.Equal(3, sut.GearRatios.Count);

            actual = sut.GearRatioSum();
            Assert.Equal(467835, actual);
        }

        [Fact]
        public void Day03_Part2_GearRatios_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day03.txt");
            int expected = 140;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new SchematicScanner(lines);
            sut.GetGearRatios();
            actual = sut.GearRatioSum();
            Assert.Equal(87605697, actual);
        }
    }
}
