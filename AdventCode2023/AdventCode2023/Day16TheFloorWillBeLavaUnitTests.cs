using AdventCode2023.Models;

namespace AdventCode2023
{
    public class Day16TheFloorWillBeLavaUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day16.txt");
            int expected = 110;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day16test.txt");
            int expected = 10;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new MirrorTracer(lines);

            sut.StartTracing(0, 0, MirrorTracer.BeamDirection.Right);

            Assert.Equal(46, sut.EnergizedTiles.Count);
        }

        [Fact]
        public void Day16_Part1_TheFloorWillBeLava_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day16.txt");
            int expected = 110;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new MirrorTracer(lines);

            sut.StartTracing(0, 0, MirrorTracer.BeamDirection.Right);
            actual = sut.EnergizedTiles.Count;
            Assert.Equal(7415, actual);
        }

        [Fact]
        public void CheckFindBest_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day16test.txt");
            int expected = 10;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new MirrorTracer(lines);

            sut.StartTracing(3, 0, MirrorTracer.BeamDirection.Down);

            Assert.Equal(51, sut.EnergizedTiles.Count);

            actual = sut.FindBestEdgeToEnergize();
            Assert.Equal(51, actual);
        }

        [Fact]
        public void Day16_Part2_TheFloorWillBeLava_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day16.txt");
            int expected = 110;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new MirrorTracer(lines);

            actual = sut.FindBestEdgeToEnergize();
            Assert.Equal(7943, actual);
        }
    }
}
