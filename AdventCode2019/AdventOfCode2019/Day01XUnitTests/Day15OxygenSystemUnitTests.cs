using AdventOfCode2019;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day15OxygenSystemUnitTests
    {
        [Fact(Skip = "Infinite loop at the moment")]
        public void Day15Part1_TestSolution()
        {
            List<long> pgm = DayDataUtilities.ReadMagicSmokePgmFromFile("day15.txt");
            Assert.NotNull(pgm);
            OxyRepairDroid sut = new OxyRepairDroid(pgm);
            Point pos = sut.FindOxygenSystem();

            Assert.Equal(0, pos.X);
            Assert.Equal(0, pos.Y);

        }
    }
}
