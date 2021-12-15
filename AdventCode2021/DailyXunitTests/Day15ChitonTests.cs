using AdventCode2021;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyXunitTests
{
    public class Day15ChitonTests
    {
        [Fact]
        public void Day15_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day15test.txt");
            Assert.Equal(10, lines.Length);
        }
    }
}
