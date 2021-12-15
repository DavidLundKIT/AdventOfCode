using AdventCode2021;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyXunitTests
{
    public class Day12PassagePathingTests
    {
        [Fact]
        public void Day12_Test1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day12Test1.txt");
            Assert.Equal(7, lines.Length);
            var sut = new CavePathFinder(lines);
            sut.FindAllPaths();

            Assert.Equal(10, sut.Paths.Count);
        }

        [Fact]
        public void Day12_Test2_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day12Test2.txt");
            Assert.Equal(10, lines.Length);
            var sut = new CavePathFinder(lines);
        }

        [Fact]
        public void Day12_Test3_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day12test3.txt");
            Assert.Equal(18, lines.Length);
            var sut = new CavePathFinder(lines);
        }

        [Fact]
        public void Day12_Puzzle1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day12.txt");
            Assert.Equal(23, lines.Length);
            var sut = new CavePathFinder(lines);
        }
    }
}
