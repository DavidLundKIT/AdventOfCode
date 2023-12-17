using AdventCode2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2023
{
    public class Day17ClumsyCrucibleUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day17.txt");
            int expected = 141;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day17test.txt");
            int expected = 13;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new ClumsyCrucibleMapper(lines);

            actual = sut.FindFewestSteps();
            Assert.Equal(102, actual);
        }

    }
}
