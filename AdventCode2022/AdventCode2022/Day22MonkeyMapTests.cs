using AdventCode2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2022
{
    public class Day22MonkeyMapTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day22.txt");
            long actual = lines.Length;
            Assert.Equal(202, actual);

            var mmp = new MonkeyMapPassword(lines.ToList());

            actual = mmp.Map.Count();
            Assert.Equal(0, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day22test.txt");
            long actual = lines.Length;
            Assert.Equal(14, actual);

            var mmp = new MonkeyMapPassword(lines.ToList());

            actual = mmp.Map.Count();
            Assert.Equal(0, actual);
        }


    }
}
