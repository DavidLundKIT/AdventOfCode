using AdventCode2023.Models;

namespace AdventCode2023
{
    public class Day13PointOfIncidenceUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day13.txt");
            int expectedLineCount = 1339;
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var sut = new PointOfIncidenceHandler(lines);

            actual = sut.MirrorPatterns.Count;
            Assert.Equal(100, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day13test.txt");
            int expectedLineCount = 15;
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var sut = new PointOfIncidenceHandler(lines);

            actual = sut.MirrorPatterns.Count;
            Assert.Equal(2, actual);

            var colMirror = sut.FlipMirror(sut.MirrorPatterns[0]);
            var colMirror2 = sut.FlipMirror(sut.MirrorPatterns[1]);

            actual = sut.FindSymmetrySum();

            Assert.Equal(405, actual);
        }

        [Fact]
        public void Day13_Part1_PointOfIncidence_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day13.txt");
            int expectedLineCount = 1339;
            int actual = lines.Length;
            Assert.Equal(expectedLineCount, actual);

            var sut = new PointOfIncidenceHandler(lines);

            actual = sut.MirrorPatterns.Count;
            Assert.Equal(100, actual);

            actual = sut.FindSymmetrySum();

            // 35688 too high
            // 33269 too low
            // 33270 too low
            // 31510 way too low
            Assert.Equal(34918, actual);
        }
    }
}
