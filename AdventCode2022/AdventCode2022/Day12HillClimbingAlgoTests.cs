using AdventCode2022.Models;

namespace AdventCode2022
{
    public class Day12HillClimbingAlgoTests
    {
        [Fact(Skip ="Got algo working")]
        public void Astar_code_ok()
        {
            List<string> map = new List<string>
            {
                "A          ",
                "--| |------",
                "           ",
                "   |-----| ",
                "   |     | ",
                "---|     |B"
            };

            var algo = new HillClimbingAlogrithm(map.ToArray(), "A", "B");
            int actual = algo.FindFewestSteps();
            Assert.Equal(15, actual);
        }

        [Fact]
        public void FindSteps_Test_ok()
        {
            var lines = Utils.ReadLinesFromFile("Day12test.txt");
            int actual = lines.Length;
            Assert.Equal(5, actual);

            var algo = new HillClimbingAlogrithm(lines, "S", "E");
            actual = algo.FindFewestSteps();
            Assert.Equal(31, actual);
        }
    }
}
