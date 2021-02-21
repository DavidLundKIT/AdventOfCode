using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day16FlawedFrequencyTransmissionUnitTests
    {
        [Fact]
        public void Day16Part1_TestSolution()
        {
            string map = DayDataUtilities.ReadBigStringFromFile("day16.txt");
            Assert.NotNull(map);
            List<int> signal = map.ToCharArray().Select(c => int.Parse(c.ToString())).ToList();
            Assert.Equal(650, signal.Count);
        }
    }
}
