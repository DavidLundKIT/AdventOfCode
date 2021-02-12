using AdventOfCode2020;
using System;
using Xunit;

namespace DailyXUnitTests
{
    public class Day24LobbyLayoutUnitTests
    {
        [Fact(Skip = "Daily completed")]
        public void Day24_ReadData_ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day24Data.Txt");
            Assert.Equal(471, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void Day24_ReadDataExample1_ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day24Example1Data.Txt");
            Assert.Equal(20, lines.Length);

            var sut = new LobbyLayout();
            sut.ProcessDirections(lines);
            var actual = sut.CountBlackTiles();
            Assert.Equal(10, actual);
            Assert.Equal(15, sut.Tiles.Count);
        }

        [Theory(Skip = "Daily completed")]
        [InlineData("esew", 1, -1)]
        [InlineData("nwwswee", 0, 0)]
        public void Day24_SameTile_Ok(string directions, int x, int y)
        {
            var sut = new LobbyLayout();

            var expected = Tuple.Create(x, y);
            var actual = sut.FindTile(directions, 0, 0);
            Assert.True(expected.Equals(actual));
        }

        [Fact(Skip = "Daily completed")]
        public void Day24_LobbyLayout_Part1_ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day24Data.Txt");
            Assert.Equal(471, lines.Length);

            var sut = new LobbyLayout();
            sut.ProcessDirections(lines);
            var actual = sut.CountBlackTiles();
            Assert.Equal(411, actual);
            Assert.Equal(441, sut.Tiles.Count);
        }

        [Theory(Skip = "Daily completed")]
        [InlineData(1, 15)]
        [InlineData(2, 12)]
        [InlineData(3, 25)]
        [InlineData(4, 14)]
        [InlineData(5, 23)]
        [InlineData(6, 28)]
        [InlineData(7, 41)]
        [InlineData(8, 37)]
        [InlineData(9, 49)]
        [InlineData(10, 37)]
        [InlineData(20, 132)]
        [InlineData(30, 259)]
        [InlineData(40, 406)]
        [InlineData(50, 566)]
        [InlineData(60, 788)]
        [InlineData(70, 1106)]
        [InlineData(80, 1373)]
        [InlineData(90, 1844)]
        [InlineData(100, 2208)]
        public void Day24_GenerationsExample_ok(int days, int expected)
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day24Example1Data.Txt");
            Assert.Equal(20, lines.Length);

            var sut = new LobbyLayout();
            sut.ProcessDirections(lines);
            var actual = sut.CountBlackTiles();
            Assert.Equal(10, actual);
            Assert.Equal(15, sut.Tiles.Count);
            for (int i = 0; i < days; i++)
            {
                sut.ProcessGeneration();
            }
            actual = sut.CountBlackTiles();
            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day24_LobbyLayout_Part2_ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day24Data.Txt");
            Assert.Equal(471, lines.Length);

            var sut = new LobbyLayout();
            sut.ProcessDirections(lines);
            var actual = sut.CountBlackTiles();
            Assert.Equal(411, actual);
            Assert.Equal(441, sut.Tiles.Count);
            for (int i = 0; i < 100; i++)
            {
                sut.ProcessGeneration();
            }
            actual = sut.CountBlackTiles();
            Assert.Equal(4092, actual);
        }
    }
}
