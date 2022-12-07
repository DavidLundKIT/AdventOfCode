using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2022
{
    public class Day07NoDriveSpaceTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var things = Utils.ReadLinesFromFile("Day07.txt");
            int expected = 1060;
            int actual = things.Length;
            Assert.Equal(expected, actual);
        }
    }
}
