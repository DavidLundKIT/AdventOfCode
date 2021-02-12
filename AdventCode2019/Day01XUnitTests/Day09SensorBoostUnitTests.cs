using AdventOfCode2019;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day09SensorBoostUnitTests
    {
        [Fact]
        public void Day09Part1_Example01()
        {
            List<long> pgm = new List<long>(new long[] { 109, 1, 204, -1, 1001, 100, 1, 100, 1008, 100, 16, 101, 1006, 101, 0, 99 });
            var sut = new MagicSmokeComputer(pgm);
            sut.Run(MagicSmokeComputer.ProgramMode.Start);
            foreach (var step in pgm)
            {
                Assert.Equal(step, sut.OutputPort());
            }
        }

        [Fact]
        public void Day09Part1_Example02()
        {
            List<long> pgm = new List<long>(new long[] { 1102, 34915192, 34915192, 7, 4, 7, 99, 0 });
            var sut = new MagicSmokeComputer(pgm);
            sut.Run(MagicSmokeComputer.ProgramMode.Start);
            string actual = sut.OutputPort().ToString();
            Assert.Equal(16, actual.Length);
        }

        [Fact]
        public void Day09Part1_Example03()
        {
            List<long> pgm = new List<long>(new long[] { 104, 1125899906842624, 99 });
            var sut = new MagicSmokeComputer(pgm);
            sut.Run(MagicSmokeComputer.ProgramMode.Start);
            Assert.Equal(1125899906842624, sut.OutputPort());
        }

        [Fact]
        public void Day09Part1_TestSolution()
        {
            List<long> pgm = DayDataUtilities.ReadMagicSmokePgmFromFile("day09.txt");
            Assert.NotNull(pgm);
            var sut = new MagicSmokeComputer(pgm);
            sut.InputPort = 1;
            sut.Run(MagicSmokeComputer.ProgramMode.Start);
            Assert.Equal(1, sut.OutputQueueSize());
            Assert.Equal(3518157894, sut.OutputPort());
        }

        [Fact]
        public void Day09Part2_TestSolution()
        {
            List<long> pgm = DayDataUtilities.ReadMagicSmokePgmFromFile("day09.txt");
            Assert.NotNull(pgm);
            var sut = new MagicSmokeComputer(pgm);
            sut.InputPort = 2;
            sut.Run(MagicSmokeComputer.ProgramMode.Start);
            Assert.Equal(1, sut.OutputQueueSize());
            Assert.Equal(80379, sut.OutputPort());
        }
    }
}
