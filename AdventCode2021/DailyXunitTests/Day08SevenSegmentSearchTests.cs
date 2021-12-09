using AdventCode2021;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyXunitTests
{
    public class Day08SevenSegmentSearchTests
    {
        [Fact]
        public void Test_ReadSegments_Ok()
        {
            var lines = Utils.ReadLinesFromFile("Day08Test.txt");
            Assert.Equal(10, lines.Length);
        }

        [Fact]
        public void Day08_Puzzle1_Ok()
        {
            var lines = Utils.ReadLinesFromFile("Day08.txt");
            Assert.Equal(200, lines.Length);
        }
    }
}
