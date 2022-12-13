using AdventCode2022.Models;

namespace AdventCode2022
{
    public class Day12HillClimbingAlgoTests
    {
        [Fact(Skip = "Got algo working")]
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

        [Fact]
        public void FindSteps_Part1_ok()
        {
            var lines = Utils.ReadLinesFromFile("Day12.txt");
            int actual = lines.Length;
            Assert.Equal(41, actual);

            var algo = new HillClimbingAlogrithm(lines, "S", "E");
            actual = algo.FindFewestSteps();
            Assert.Equal(520, actual);
        }

        [Fact]
        public void FindStepsOfAll_a_Test_ok()
        {
            var lines = Utils.ReadLinesFromFile("Day12test.txt");
            int actual = lines.Length;
            Assert.Equal(5, actual);

            int fewest = int.MaxValue;
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    char curr = lines[y][x];
                    if (curr == 'a')
                    {
                        Tile start = new Tile()
                        {
                            X = x,
                            Y = y
                        };
                        var algo = new HillClimbingAlogrithm(lines, start, "E");
                        actual = algo.FindFewestSteps();
                        if (actual < fewest)
                        {
                            fewest = actual;
                        }
                    }
                }
            }
            Assert.Equal(29, fewest);
        }

        [Fact]
        public void FindStepsOfAll_a_Part2_ok()
        {
            var lines = Utils.ReadLinesFromFile("Day12.txt");
            int actual = lines.Length;
            Assert.Equal(41, actual);

            int fewest = int.MaxValue;
            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    char curr = lines[y][x];
                    if (curr == 'a')
                    {
                        Tile start = new Tile()
                        {
                            X = x,
                            Y = y
                        };
                        var algo = new HillClimbingAlogrithm(lines, start, "E");
                        actual = algo.FindFewestSteps();
                        if (actual < fewest)
                        {
                            fewest = actual;
                        }
                    }
                }
            }
            Assert.Equal(508, fewest);
        }
    }
}
