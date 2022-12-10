using AdventCode2022.Models;

namespace AdventCode2022
{
    public class Day09RopeBridgeTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var motions = Utils.ReadLinesFromFile("Day09test.txt");
            int actual = motions.Length;
            Assert.Equal(8, actual);
            motions = Utils.ReadLinesFromFile("Day09.txt");
            actual = motions.Length;
            Assert.Equal(2000, actual);
        }

        [Theory]
        [InlineData(0, 2, "U", 0, 1)]
        [InlineData(1, 2, "U", 1, 1)]
        [InlineData(2, 1, "R", 1, 1)]
        [InlineData(2, 0, "R", 1, 0)]
        [InlineData(2, -1, "R", 1, -1)]
        [InlineData(1, -2, "D", 1, -1)]
        [InlineData(0, -2, "D", 0, -1)]
        public void TrailCatchUpTests(int hx, int hy, string cmd, int expectedTailX, int expectedTailY)
        {
            var sut = new RopeMotion(0, 0, 2);
            sut.HeadX[0] = hx;
            sut.HeadY[0] = hy;

            sut.MoveTail(1);
            var expectedKey = sut.MakeKey(expectedTailX, expectedTailY);
            Assert.True(sut.TailPlaces.ContainsKey(expectedKey));
        }

        [Fact]
        public void FindTailPositions_Test_OK()
        {
            var motions = Utils.ReadLinesFromFile("Day09test.txt");
            int actual = motions.Length;
            Assert.Equal(8, actual);

            var sut = new RopeMotion(0, 0, 2);
            sut.ProcessCommands(motions);
            actual = sut.TailPlaces.Count;
            Assert.Equal(13, actual);
        }

        [Fact]
        public void FindTailPositions_Part1_OK()
        {
            var motions = Utils.ReadLinesFromFile("Day09.txt");
            int actual = motions.Length;
            Assert.Equal(2000, actual);

            var sut = new RopeMotion(0, 0, 2);
            sut.ProcessCommands(motions);
            actual = sut.TailPlaces.Count;
            Assert.Equal(6406, actual);
        }
    }
}
