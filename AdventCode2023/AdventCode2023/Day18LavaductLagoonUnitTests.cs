using AdventCode2023.Models;

namespace AdventCode2023
{
    public class Day18LavaductLagoonUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18.txt");
            int expected = 766;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18test.txt");
            int expected = 14;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new LavaLagoonDigger(lines);
            sut.MakePerimeter();
            sut.DumpLagoon();
            sut.FloodFillLagoon(new Point(1, 1));
            sut.DumpLagoon();
            actual = sut.Points.Count;
            Assert.Equal(62, actual);
        }

        [Fact]
        public void Day18_Part1_LavaductLagoon_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18.txt");
            int expected = 766;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new LavaLagoonDigger(lines);
            sut.MakePerimeter();
            sut.DumpLagoon();
            sut.FloodFillLagoon(new Point(1, 1));
            sut.DumpLagoon();
            actual = sut.Points.Count;
            Assert.Equal(46334, actual);
        }

        [Fact]
        public void ReadInData_As_Color_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18test.txt");
            int expected = 14;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new LavaLagoonDigger(lines, true);
            sut.MakePerimeter();
            //sut.DumpLagoon();
            //sut.FloodFillLagoon(new Point(1, 1));
            //sut.DumpLagoon();
            actual = sut.Points.Count;
            Assert.Equal(62, actual);
        }

        [Fact]
        public void Day18_Part2_LavaductLagoon_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18.txt");
            int expected = 766;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new LavaLagoonDigger(lines, true);
            sut.MakePerimeter();
            actual = sut.Points.Count;
            Assert.Equal(46334, actual);
        }

    }
}
