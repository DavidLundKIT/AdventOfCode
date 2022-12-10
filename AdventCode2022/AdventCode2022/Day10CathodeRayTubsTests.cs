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
            Assert.Equal(12880, totalSignal);
        }

        [Fact]
        public void CrtMessage_Test_OK()
        {
            var pgm = Utils.ReadLinesFromFile("Day10test.txt");
            var cpu = new CathodeCpu(pgm);
            for (int i = 0; i < 240; i++)
            {
                long reg = cpu.DoCycle();
            }
            cpu.DumpScreen();
            Assert.Equal('#', cpu.Screen[0,0]);
            Assert.Equal('#', cpu.Screen[0,1]);
            Assert.Equal('#', cpu.Screen[0,2]);
            Assert.Equal('#', cpu.Screen[0,3]);
            Assert.Equal('#', cpu.Screen[0,4]);
            Assert.Equal('#', cpu.Screen[0,5]);
        }

        [Fact]
        public void CrtMessage_Part2_OK()
        {
            var pgm = Utils.ReadLinesFromFile("Day10.txt");
            var cpu = new CathodeCpu(pgm);
            for (int i = 0; i < 240; i++)
            {
                long reg = cpu.DoCycle();
            }
            cpu.DumpScreen();
            // Answer was FCJAPJRE
            // Look in the Output Window to tsee the Debug Dump Screen
            Assert.Equal('#', cpu.Screen[0, 0]);
        }
    }
}
