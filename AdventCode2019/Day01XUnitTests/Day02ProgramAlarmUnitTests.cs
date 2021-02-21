using AdventOfCode2019;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day02ProgramAlarmUnitTests
    {
        [Fact]
        public void Day02Part1_TestSolution()
        {
            List<long> values = DayDataUtilities.ReadMagicSmokePgmFromFile("day02.txt");
            Assert.Equal(137, values.Count);

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.Noun = 12;
            sut.Verb = 2;
            sut.Run();

            Assert.Equal(3716250, sut.ProgramValues[0]);
        }

        [Fact]
        public void Day02Part1_ExampleTest01()
        {
            List<long> values = new List<long>(new long[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 });

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.Run();

            Assert.Equal(3500, sut.ProgramValues[0]);
        }

        [Fact]
        public void Day02Part1_ExampleTest02()
        {
            List<long> values = new List<long>(new long[] { 1, 0, 0, 0, 99 });

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.Run();

            Assert.Equal(2, sut.ProgramValues[0]);
        }

        [Fact]
        public void Day02Part1_ExampleTest03()
        {
            List<long> values = new List<long>(new long[] { 2, 3, 0, 3, 99 });

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.Run();

            Assert.Equal(2, sut.ProgramValues[0]);
            Assert.Equal(6, sut.ProgramValues[3]);
        }

        [Fact]
        public void Day02Part1_ExampleTest04()
        {
            List<long> values = new List<long>(new long[] { 2, 4, 4, 5, 99, 0 });

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.Run();

            Assert.Equal(2, sut.ProgramValues[0]);
            Assert.Equal(9801, sut.ProgramValues[5]);
        }

        [Fact]
        public void Day02Part1_ExampleTest05()
        {
            List<long> values = new List<long>(new long[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 });

            var sut = new MagicSmokeComputer();
            sut.ProgramValues = values;
            sut.Run();

            Assert.Equal(30, sut.ProgramValues[0]);
            Assert.Equal(2, sut.ProgramValues[4]);
        }

        [Fact]
        public void Day02Part2_TestSolution()
        {
            long expectedOutput = 19690720;

            for (long noun = 0; noun <= 99; noun++)
            {
                for (long verb = 0; verb <= 99; verb++)
                {
                    try
                    {
                        List<long> values = DayDataUtilities.ReadMagicSmokePgmFromFile("day02.txt");

                        var sut = new MagicSmokeComputer();
                        sut.ProgramValues = values;
                        sut.Noun = noun;
                        sut.Run();

                        if (expectedOutput == sut.ProgramValues[0])
                        {
                            Assert.Equal(6472, 100 * noun + verb);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            }
            Debug.WriteLine("Done");
        }
    }
}
