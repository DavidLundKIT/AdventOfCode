using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class Day02DiveUnitTests
    {
        private string[] tcmds;

        public Day02DiveUnitTests()
        {
            tcmds = new string[]
            {
                "forward 5",
                "down 5",
                "forward 8",
                "up 3",
                "down 8",
                "forward 2"
            };
        }

        [Fact]
        public void Day02_TestPath_OK()
        {
            var sut = new DivePathFinder();
            string expected = "forward 2";
            Assert.Equal(expected, tcmds[tcmds.Length - 1]);

            //            int increases = sut.SimpleIncreases(depths);
            long actual = sut.FindPosition(tcmds);
            Assert.Equal(15, sut.Horizontal);
            Assert.Equal(10, sut.Depth);
            Assert.Equal(150, actual);
        }

        [Fact]
        public void Day02_TestAimedPath_OK()
        {
            var sut = new DivePathFinder();
            string expected = "forward 2";
            Assert.Equal(expected, tcmds[tcmds.Length - 1]);

            //            int increases = sut.SimpleIncreases(depths);
            long actual = sut.FindAimedPosition(tcmds);
            Assert.Equal(15, sut.Horizontal);
            Assert.Equal(60, sut.Depth);
            Assert.Equal(900, actual);
        }


        [Fact]
        public void Day02_Puzzle1_OK()
        {
            var sut = new DivePathFinder();
            var cmds = Utils.ReadLinesFromFile("Day02.txt");
            string expected = "forward 2";
            Assert.Equal(expected, cmds[cmds.Length - 1]);

            long actual = sut.FindPosition(cmds);
            //Assert.Equal(15, sut.Horizontal);
            //Assert.Equal(10, sut.Depth);
            Assert.Equal(1480518, actual);
        }

        [Fact]
        public void Day02_Puzzle2_OK()
        {
            var sut = new DivePathFinder();
            var cmds = Utils.ReadLinesFromFile("Day02.txt");
            string expected = "forward 2";
            Assert.Equal(expected, cmds[cmds.Length - 1]);

            long actual = sut.FindAimedPosition(cmds);
            Assert.Equal(1282809906, actual);
        }
    }
}
