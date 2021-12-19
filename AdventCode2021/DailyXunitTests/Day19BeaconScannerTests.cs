using AdventCode2021;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyXunitTests
{
    public class Day19BeaconScannerTests
    {
        [Fact]
        public void Day19_Puzzle1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day19.txt");
            Assert.Equal(777, lines.Length);
        }
    }
}
