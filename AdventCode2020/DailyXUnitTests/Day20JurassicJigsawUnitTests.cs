using AdventOfCode2020;
using System.Collections.Generic;
using Xunit;

namespace DailyXUnitTests
{
    public class Day20JurassicJigsawUnitTests
    {
        [Fact(Skip = "Daily completed")]
        public void Day20_ReadData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day20Data.txt");
            Assert.Equal(1727, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void Day20_Example1_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day20Example1Data.txt");
            Assert.Equal(107, lines.Length);

            var sut = new JurassicJigsaw();
            sut.ReadTiles(new List<string>(lines));
            Assert.Equal(9, sut.Tiles.Count);

            sut.ProcessEdges();
            Assert.Equal(34, sut.Edges.Count);

            sut.ProcessMatches();
            Assert.Equal(34, sut.Edges.Count);

            long total = sut.FindCornerTotal();
            Assert.Equal(20899048083289, total);
        }

        [Fact(Skip = "Daily completed")]
        public void Day20_JurassicJigsaw_Part1_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day20Data.txt");
            Assert.Equal(1727, lines.Length);

            var sut = new JurassicJigsaw();
            sut.ReadTiles(new List<string>(lines));
            Assert.Equal(144, sut.Tiles.Count);

            sut.ProcessEdges();
            Assert.Equal(453, sut.Edges.Count);

            sut.ProcessMatches();
            Assert.Equal(453, sut.Edges.Count);

            sut.DumpDoubleFalseEdges();
            long total = sut.FindCornerTotal();
            Assert.Equal(15003787688423, total);
        }

        [Fact(Skip = "working")]
        public void Day20_TestRotations()
        {
            string[] edge = new string[] { 
                "abcdefghij", "0123456789", "klmnopqrst", "9876543210", "abcdefghij", "0123456789", "klmnopqrst", "9876543210", "abcdefghij", "0123456789" 
            };

            var sutR = new Tile(1, edge);
            sutR.RotateRight();
            Assert.Contains("0a9k0a9k0a", sutR.Edge1);
            var sutL = new Tile(1, edge);
            sutL.RotateLeft();
            Assert.Contains("j9t0j9t0j9", sutL.Edge1);
            var sut13 = new Tile(1, edge);
            sut13.Flip1To3();
            Assert.Contains("0123456789", sut13.Edge1);
            var sut24 = new Tile(1, edge);
            sut24.Flip2To4();
            Assert.Contains("jihgfedcba", sut24.Edge1);
        }

        [Fact(Skip = "Semi working")]
        public void Day20_Example1_Part2_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day20Example1Data.txt");
            Assert.Equal(107, lines.Length);

            var sut = new JurassicJigsaw();
            sut.ReadTiles(new List<string>(lines));
            Assert.Equal(9, sut.Tiles.Count);

            do
            {
                sut.DoChanges();
                sut.ProcessEdges();
                if (sut.FindActions())
                    continue;
                sut.ProcessReverseMatches();
                sut.FindActions();
            } while (sut.Changes.Count > 0);
            sut.DumpEdges();
            long total = sut.FindCornerTotal();
            Assert.Equal(20899048083289, total);

            sut.MatchTiles();
            Assert.NotNull(sut.StartCorner);

            sut.DumpTileIds();
            Assert.NotNull(sut);
        }

        [Fact(Skip = "Not working")]
        public void Day20_JurassicJigsaw_Part2_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day20Data.txt");
            Assert.Equal(1727, lines.Length);

            var sut = new JurassicJigsaw();
            sut.ReadTiles(new List<string>(lines));
            Assert.Equal(144, sut.Tiles.Count);

            do
            {
                sut.DoChanges();
                sut.ProcessEdges();
                if (sut.FindActions())
                    continue;
                sut.ProcessReverseMatches();
                sut.FindActions();
            } while (sut.Changes.Count > 0);
            sut.DumpEdges();

            long total = sut.FindCornerTotal();
            Assert.Equal(15003787688423, total);
        }

        [Fact]
        public void Day20_JurassicJigsawPerska_Example_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day20Example1Data.txt");
            Assert.Equal(107, lines.Length);

            var sut = new JurassicJigsawPerska();
            sut.Day20(new List<string>(lines));
            Assert.NotNull(sut);
            Assert.Equal(20899048083289, sut.Corners);
            Assert.Equal(273, sut.Roughness);
        }

        [Fact]
        public void Day20_JurassicJigsawPerska_Part2_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day20Data.txt");
            Assert.Equal(1727, lines.Length);

            var sut = new JurassicJigsawPerska();
            sut.Day20(new List<string>(lines));
            Assert.NotNull(sut);
            Assert.Equal(15003787688423, sut.Corners);
            Assert.Equal(1705, sut.Roughness);
        }
    }
}
