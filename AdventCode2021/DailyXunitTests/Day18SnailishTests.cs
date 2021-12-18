using AdventCode2021;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyXunitTests
{
    public class Day18SnailishTests
    {
        [Fact]
        public void Day18_Puzzle1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18.txt");
            Assert.Equal(100, lines.Length);
        }
    }
}
