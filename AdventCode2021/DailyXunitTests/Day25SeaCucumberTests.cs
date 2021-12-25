using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class Day25SeaCucumberTests
    {
        [Fact]
        public void Day25_testMoveSeaCucumbers_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day25test1.txt");
            Assert.Equal(9, lines.Length);
            var sut = new SeaCucumberMotion(lines);
            sut.DumpSeaFloor();
            int moves = 0;
            int steps = 0;
            do
            {
                moves = sut.MoveCuckes();
                sut.DumpSeaFloor();
                steps++;
            } while (moves > 0);
            Assert.Equal(58, steps);
        }

        [Fact]
        public void Day25_Puzzle1_ok()
        {
            var lines = Utils.ReadLinesFromFile("Day25.txt");
            Assert.Equal(137, lines.Length);
            var sut = new SeaCucumberMotion(lines);
            sut.DumpSeaFloor();
            int moves = 0;
            int steps = 0;
            do
            {
                moves = sut.MoveCuckes();
                //sut.DumpSeaFloor();
                steps++;
            } while (moves > 0);
            Assert.Equal(384, steps);
        }
    }
}
