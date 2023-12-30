using AdventCode2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2023
{
    public class Day20PulsePropagationUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day20.txt");
            int expected = 58;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadInDataFile_Test1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day20test1.txt");
            int expected = 5;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadInDataFile_Test2_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day20test2.txt");
            int expected = 5;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
        }
    }
}
