using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2023
{
    public class Day04ScratchCardsUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var cards = Utils.ReadLinesFromFile("Day04.txt");
            int expected = 203;
            int actual = cards.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var cards = Utils.ReadLinesFromFile("Day04test.txt");
            int expected = 6;
            int actual = cards.Length;
            Assert.Equal(expected, actual);
        }

    }
}
