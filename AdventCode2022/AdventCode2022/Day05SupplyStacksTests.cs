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

        [Theory]
        [InlineData("move 1 from 2 to 1", 1, 2, 1)]
        [InlineData("move 3 from 1 to 3", 3, 1, 3)]
        [InlineData("move 2 from 2 to 1", 2, 2, 1)]
        [InlineData("move 1 from 1 to 2", 1, 1, 2)]
        public void ParseCommands_OK(string cmd, int amount, int from, int to) 
        {
            var parts = cmd.Split(new char[] { ' ' });
            Assert.Equal(amount, int.Parse(parts[1]));
            Assert.Equal(from, int.Parse(parts[3]));
            Assert.Equal(to, int.Parse(parts[5]));
        }
    }
}
