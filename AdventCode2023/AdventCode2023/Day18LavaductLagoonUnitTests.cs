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
            sut.FloodFillLagoon(new Point(1, 1));
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
            sut.MakePerimeter(false);
            actual = sut.Points.Count;
            Assert.Equal(14, actual);
        }

        [Fact]
        public void CalculateLagoon_Part1_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18test.txt");
            int expected = 14;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new LavaLagoonDigger(lines);
            sut.MakePerimeter(false);
            long larea = sut.CalculateLagoonArea();
            Assert.Equal(62, larea);
        }

        [Fact]
        public void Day18_Part1_CalculateLavaductLagoon_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18.txt");
            int expected = 766;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new LavaLagoonDigger(lines);
            sut.MakePerimeter(false);
            long larea = sut.CalculateLagoonArea();
            Assert.Equal(46334, larea);
        }

        [Fact]
        public void CalculateLagoon_Part2_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18test.txt");
            int expected = 14;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new LavaLagoonDigger(lines, true);
            sut.MakePerimeter();
            //sut.DumpLagoon();
            long larea = sut.CalculateLagoonArea();
            Assert.Equal(952408144115, larea);
        }


        [Fact(Skip = "Not working yet")]
        public void Day18_Part2_LavaductLagoon_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18.txt");
            int expected = 766;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new LavaLagoonDigger(lines, true);
            sut.MakePerimeter();
            actual = sut.Points.Count;
            // 207069894 too low
            Assert.Equal(46334, actual);
        }

    }
}
