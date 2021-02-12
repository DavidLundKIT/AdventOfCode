using AdventOfCode2019;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day05ChanceOfAsteroidsUnitTests
    {
        [Fact()]
        public void Day05_Part1_example01()
        {
            List<long> values = new List<long>(new long[] { 3, 0, 4, 0, 99 });

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.InputPort = 666;
            sut.Run();

            Assert.Equal(666, sut.OutputPort());
        }

        [Fact()]
        public void Day05_Part1_example02()
        {
            List<long> values = new List<long>(new long[] { 1002, 4, 3, 4, 33 });

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.Run();

            Assert.Equal(99, sut.ProgramValues[4]);
        }

        [Fact]
        public void Day05Part1_TestSolution()
        {
            List<long> values = DayDataUtilities.ReadMagicSmokePgmFromFile("day05.txt");
            Assert.Equal(223, values[values.Count - 3]);
            Assert.Equal(99, values[values.Count - 2]);
            Assert.Equal(226, values[values.Count - 1]);

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.InputPort = 1;

            sut.Run();
            long actualCode = 0;
            do
            {
                actualCode = sut.OutputPort();
            } while (actualCode == 0);
            Assert.Equal(14522484, actualCode);
        }



        [Fact()]
        public void Day05_Part1_example03()
        {
            List<long> values = new List<long>(new long[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 });

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.InputPort = 8;
            sut.Run();

            Assert.Equal(1, sut.OutputPort());
        }

        [Fact()]
        public void Day05_Part1_example04()
        {
            List<long> values = new List<long>(new long[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 });

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.InputPort = 8;
            sut.Run();

            Assert.Equal(0, sut.OutputPort());
        }

        [Fact()]
        public void Day05_Part1_example05()
        {
            List<long> values = new List<long>(new long[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 });

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.InputPort = 8;
            sut.Run();

            Assert.Equal(1, sut.OutputPort());
        }

        [Fact()]
        public void Day05_Part1_example06()
        {
            List<long> values = new List<long>(new long[] { 3, 3, 1107, -1, 8, 3, 4, 3, 99 });

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.InputPort = 8;
            sut.Run();

            Assert.Equal(0, sut.OutputPort());
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(94, 1)]
        public void Day05_Part1_example07(int input, int expectedOutput)
        {
            List<long> values = new List<long>(new long[] { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 });

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.InputPort = input;
            sut.Run();

            Assert.Equal(expectedOutput, sut.OutputPort());
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(94, 1)]
        public void Day05_Part1_example08(int input, int expectedOutput)
        {
            List<long> values = new List<long>(new long[] { 3, 3, 1105, -1, 9, 1101, 0, 0, 12, 4, 12, 99, 1 });

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.InputPort = input;
            sut.Run();

            Assert.Equal(expectedOutput, sut.OutputPort());
        }

        [Theory]
        [InlineData(0, 999)]
        [InlineData(8, 1000)]
        [InlineData(94, 1001)]
        public void Day05_Part1_example09(int input, int expectedOutput)
        {
            List<long> values = new List<long>(new long[] { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 });

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.InputPort = input;
            sut.Run();

            Assert.Equal(expectedOutput, sut.OutputPort());
        }

        [Fact]
        public void Day05Part2_TestSolution()
        {
            List<long> values = DayDataUtilities.ReadMagicSmokePgmFromFile("day05.txt");
            Assert.Equal(223, values[values.Count - 3]);
            Assert.Equal(99, values[values.Count - 2]);
            Assert.Equal(226, values[values.Count - 1]);

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.InputPort = 5;
            //sut.InputPort = 1;

            sut.Run();

            Assert.Equal(4655956, sut.OutputPort());
        }

    }
}
