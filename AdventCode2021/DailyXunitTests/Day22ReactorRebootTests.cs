using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class Day22ReactorRebootTests
    {
        [Theory]
        [InlineData("Day22test1.txt", 4, 39)]
        [InlineData("Day22test2.txt", 22, 590784)]
        //[InlineData("Day22.txt", 420, 0)]
        public void ReactorReboot_In50Cube_OK(string filename, int numLines, long expected)
        {
            var lines = Utils.ReadLinesFromFile(filename);
            Assert.Equal(numLines, lines.Length);

            var sut = new ConwayCubeReactor(lines);
            Assert.Equal(numLines, sut.Commands.Count);

            long actual = sut.DoReboot50();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Day22_Puzzle1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day22.txt");
            Assert.Equal(420, lines.Length);

            var sut = new ConwayCubeReactor(lines);
            Assert.Equal(420, sut.Commands.Count);

            long actual = sut.DoReboot50();
            Assert.Equal(648023, actual);
        }
    }
}
