﻿using AdventCode2023.Models;

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

        [Fact(Skip = "Doesn't end")]
        public void Day08_Part2_HauntedWastelands_Not_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day08.txt");
            int expectedLineCount = 732;
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var sut = new HauntedWastelandMapper(lines);
            Assert.Equal(expectedLineCount - 2, sut.Mapper.Count);

            actual = sut.SimultaneousStepsToEnd();
            Assert.Equal(0, actual);
        }

        [Theory]
        [InlineData("Day08test3.txt", 10, 6)]
        public void ReadInDataFile_Test3EndsWithZ_OK(string testFile, int expectedLineCount, long expectedSteps)
        {
            var lines = Utils.ReadLinesFromFile(testFile);
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var sut = new HauntedWastelandMapper(lines);
            Assert.Equal(expectedLineCount - 2, sut.Mapper.Count);


            long lactual = sut.StepsToAllEndWithZ();
            Assert.Equal(expectedSteps, lactual);
        }

        [Fact]
        public void Day08_Part2_HauntedWastelands_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day08.txt");
            int expectedLineCount = 732;
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var sut = new HauntedWastelandMapper(lines);
            Assert.Equal(expectedLineCount - 2, sut.Mapper.Count);

            long lactual = sut.StepsToAllEndWithZ();
            Assert.Equal(11678319315857, lactual);
        }
    }
}
