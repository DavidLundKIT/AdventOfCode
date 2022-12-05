using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2022
{
    public class Day05SupplyStacksTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var elfSections = Utils.ReadLinesFromFile("Day05.txt");
            int expected = 512;
            int actual = elfSections.Length;
            Assert.Equal(expected, actual);
        }

    }
}
