using AdventCode2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2023
{
    public class Day08HauntedWastelandUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day08.txt");
            int expectedLineCount = 732;
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var sut = new HauntedWastelandMapper(lines);
            Assert.Equal(expectedLineCount - 2, sut.Mapper.Count);
        }

        [Theory]
        [InlineData("Day08test1.txt", 9, 2)]
        [InlineData("Day08test2.txt", 5, 6)]
        public void ReadInDataFile_Tests_OK(string testFile, int expectedLineCount, int expectedSteps)
        {
            var lines = Utils.ReadLinesFromFile(testFile);
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var sut = new HauntedWastelandMapper(lines);
            Assert.Equal(expectedLineCount - 2, sut.Mapper.Count);

            actual = sut.StepsToEnd("AAA", "ZZZ");
            Assert.Equal(expectedSteps, actual);
        }

        [Theory]
        [InlineData("Day08test3.txt", 10, 6)]
        public void ReadInDataFile_Test3_OK(string testFile, int expectedLineCount, int expectedSteps)
        {
            var lines = Utils.ReadLinesFromFile(testFile);
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var sut = new HauntedWastelandMapper(lines);
            Assert.Equal(expectedLineCount - 2, sut.Mapper.Count);

            actual = sut.SimultaneousStepsToEnd();
            Assert.Equal(expectedSteps, actual);
        }

        [Fact]
        public void Day08_Part1_HauntedWastelands_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day08.txt");
            int expectedLineCount = 732;
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var sut = new HauntedWastelandMapper(lines);
            Assert.Equal(expectedLineCount - 2, sut.Mapper.Count);

            actual = sut.StepsToEnd("AAA", "ZZZ");
            Assert.Equal(21251, actual);
        }
    }
}
