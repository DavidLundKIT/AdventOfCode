using AdventCode2022.Models;

namespace AdventCode2022
{
    public class Day10CathodeRayTubsTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day10test.txt");
            int actual = lines.Length;
            Assert.Equal(146, actual);
            lines = Utils.ReadLinesFromFile("Day10.txt");
            actual = lines.Length;
            Assert.Equal(140, actual);
        }

        [Fact]
        public void SimpleProgram_Test_OK()
        {
            string[] pgm = { "noop", "addx 3", "addx -5" };

            var cpu = new CathodeCpu(pgm);
            long actual = cpu.DoCycle();
            Assert.Equal(1, actual);
            actual = cpu.DoCycle();
            Assert.Equal(1, actual);
            actual = cpu.DoCycle();
            Assert.Equal(4, actual);
            actual = cpu.DoCycle();
            Assert.Equal(4, actual);
            actual = cpu.DoCycle();
            Assert.Equal(-1, actual);
        }

        [Fact]
        public void SignalStrProgram_Test_OK()
        {
            var pgm = Utils.ReadLinesFromFile("Day10test.txt");
            long[] steps = new long[] { 20, 40, 40, 40, 40, 40 }; 
            var cpu = new CathodeCpu(pgm);
            long totalSignal = 0;
            long stepsDone = 0;
            foreach (var step in steps)
            {
                long register = cpu.DoCycles(step);
                stepsDone += step;
                totalSignal += stepsDone*cpu.CycleSignal;
            }
            Assert.Equal(13140, totalSignal);
        }

        [Fact]
        public void SignalStrProgram_Part1_OK()
        {
            var pgm = Utils.ReadLinesFromFile("Day10.txt");
            long[] steps = new long[] { 20, 40, 40, 40, 40, 40 };
            var cpu = new CathodeCpu(pgm);
            long totalSignal = 0;
            long stepsDone = 0;
            foreach (var step in steps)
            {
                long register = cpu.DoCycles(step);
                stepsDone += step;
                totalSignal += stepsDone * cpu.CycleSignal;
            }
            Assert.Equal(0, totalSignal);
        }
    }
}
