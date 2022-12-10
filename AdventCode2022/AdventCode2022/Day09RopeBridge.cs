using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2022
{
    public class Day09RopeBridge
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var motions = Utils.ReadLinesFromFile("Day09test.txt");
            int actual = motions.Length;
            Assert.Equal(8, actual);
            motions = Utils.ReadLinesFromFile("Day09.txt");
            actual = motions.Length;
            Assert.Equal(2000, actual);
        }
    }
}
