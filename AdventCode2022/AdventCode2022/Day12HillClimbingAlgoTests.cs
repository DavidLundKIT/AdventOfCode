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
    }
}
