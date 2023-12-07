using AdventCode2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2023
{
    public class DayO7CamelCardsUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day07.txt");
            int expected = 1000;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day07test.txt");
            int expected = 5;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
        }
    }
}
