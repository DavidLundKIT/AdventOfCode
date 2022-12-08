using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2022
{
    public class Day08TreetopTreeHouseTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var things = Utils.ReadIntSquareFromFile("Day08.txt");
            int expected = 99;
            int actual = things.Count;
            Assert.Equal(expected, actual);
        }

    }
}
