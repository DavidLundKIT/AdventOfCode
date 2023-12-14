using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2023
{
    public class Day11CosmicExpansionUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day11.txt");
            int expectedLineCount = 140;
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day11test1.txt");
            int expectedLineCount = 10;
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);
        }
    }
}
