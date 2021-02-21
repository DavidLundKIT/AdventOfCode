using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day25CryostasisUnitTests
    {
        [Fact]
        public void Day25Part1_TestSolution()
        {
            List<long> pgm = DayDataUtilities.ReadMagicSmokePgmFromFile("day25.txt");
            Assert.NotNull(pgm);

        }
    }
}
