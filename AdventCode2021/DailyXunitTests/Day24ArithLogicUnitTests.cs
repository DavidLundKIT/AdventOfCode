using AdventCode2021;
using System.Collections.Generic;
using Xunit;

namespace DailyXunitTests
{
    public class Day24ArithLogicUnitTests
    {
        [Fact]
        public void Day24_Puzzle1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day24.txt");
            Assert.Equal(252, lines.Length);
        }
    }
}
