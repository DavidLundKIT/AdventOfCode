using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2023
{
    public class Day12HotSpringsUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day12.txt");
            long expectedLineCount = 1000;
            long actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day12test.txt");
            long expectedLineCount = 6;
            long actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);
        }

    }
}
