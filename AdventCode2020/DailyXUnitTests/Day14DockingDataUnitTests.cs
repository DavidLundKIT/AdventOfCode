using AdventOfCode2020;
using Xunit;

namespace DailyXUnitTests
{
    public class Day14DockingDataUnitTests
    {
        [Fact(Skip = "Daily completed")]
        public void Day14ReadData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day14Data.txt");
            Assert.Equal(580, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void Day14_Example1_Ok()
        {
            string[] lines = new string[]
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "mem[8] = 11",
                "mem[7] = 101",
                "mem[8] = 0"
            };
            var sut = new DockingDataUnit();
            long lval = 0;
            foreach (var line in lines)
            {
                lval = sut.ProcessData(line);
            }
            lval = sut.Sum();
            Assert.Equal(165, lval);
        }

        [Fact(Skip = "Daily completed")]
        public void Day14DockingData_Part1_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day14Data.txt");
            Assert.Equal(580, lines.Length);

            var sut = new DockingDataUnit();
            long lval = 0;
            foreach (var line in lines)
            {
                lval = sut.ProcessData(line);
            }
            lval = sut.Sum();
            Assert.Equal(13865835758282, lval);
        }

        [Fact(Skip = "Daily completed")]
        public void Day14_Example2_Ok()
        {
            string[] lines = new string[]
            {
                "mask = 000000000000000000000000000000X1001X",
                "mem[42] = 100",
                "mask = 00000000000000000000000000000000X0XX",
                "mem[26] = 1"
            };
            var sut = new DockingDataUnit();
            long lval = 0;
            foreach (var line in lines)
            {
                lval = sut.ProcessData2(line);
            }
            lval = sut.Sum();
            Assert.Equal(208, lval);
        }

        [Fact(Skip = "Daily completed")]
        public void Day14DockingData_Part2_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day14Data.txt");
            Assert.Equal(580, lines.Length);

            var sut = new DockingDataUnit();
            long lval = 0;
            foreach (var line in lines)
            {
                lval = sut.ProcessData2(line);
            }
            lval = sut.Sum();
            Assert.Equal(4195339838136, lval);
        }
    }
}
