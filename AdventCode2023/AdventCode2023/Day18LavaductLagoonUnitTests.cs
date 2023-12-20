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
            actual = sut.CalculateLagoon();
            Assert.Equal(62, actual);
        }
    }
}
