using AdventCode2021;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyXunitTests
{
    public class Day13TransparentOragamiTests
    {
        [Fact]
        public void Day13_Test1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day13Test.txt");
            Assert.Equal(21, lines.Length);
        }

        [Fact]
        public void Day13_Puzzle1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day13.txt");
            Assert.Equal(815, lines.Length);
        }
    }
}
