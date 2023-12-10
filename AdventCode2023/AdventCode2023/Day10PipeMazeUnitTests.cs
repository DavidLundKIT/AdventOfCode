using AdventCode2023.Models;

namespace AdventCode2023
{
    public class Day10PipeMazeUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day10.txt");
            int expectedLineCount = 140;
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);
        }

        [Theory]
        [InlineData("Day10test1.txt", 5, 1, 1, 4)]
        [InlineData("Day10test2.txt", 5, 0, 2, 8)]
        public void TestMazes_OK(string path, int expectedlines, int expectedX, int expectedY, int steps)
        {
            var lines = Utils.ReadLinesFromFile(path);
            int actual = lines.Length;
            Assert.Equal(expectedlines, actual);

            var sut = new PipeMazeWalker(lines);
            Assert.Equal(expectedX, sut.Start.Item1);
            Assert.Equal(expectedY, sut.Start.Item2);

            actual = sut.WalkPipeMaze();
            Assert.Equal(actual, steps);
        }

        [Fact]
        public void Day10_Part1_PipeMaze_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day10.txt");
            int expectedLineCount = 140;
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var sut = new PipeMazeWalker(lines);

            actual = sut.WalkPipeMaze();
            Assert.Equal(6842, actual);
        }

    }
}
