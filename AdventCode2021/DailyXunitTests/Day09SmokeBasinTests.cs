using AdventCode2021;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

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
        }

        [Fact]
        public void Day09_Puzzle1_Ok()
        {
            var lines = Utils.ReadLinesFromFile("Day09.txt");
            Assert.Equal(100, lines.Length);
        }
    }
}
