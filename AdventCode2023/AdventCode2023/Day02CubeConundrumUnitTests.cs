using AdventCode2023.Models;

namespace AdventCode2023
{
    public class Day02CubeConundrumUnitTests
    {
        private const int kMinBlueCubes = 14;
        private const int kMinGreenCubes = 13;
        private const int kMinRedCubes = 12;


        [Fact]
        public void ReadInDataFile_OK()
        {
            var games = Utils.ReadLinesFromFile("Day02.txt");
            int expected = 100;
            int actual = games.Length;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1, true, 48)]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 2, true, 12)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 3, false, 1560)]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 4, false, 630)]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 5, true, 36)]
        public void ParseGames_Test_OK(string line, int gameNr, bool possible, int power)
        {
            var game = new CubeConundrumGame(line);
            Assert.Equal(gameNr, game.GameNr);

            var actual = game.PossibleGame(kMinRedCubes, kMinBlueCubes, kMinGreenCubes);
            Assert.Equal(actual, possible);
            var actualPower = game.MinimumPowerCalculation();
            Assert.Equal(power, actualPower);
        }

        [Fact]
        public void Day02_Part1_CubeConundrum_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day02.txt");
            int expected = 100;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            int sum = 0;
            foreach (var line in lines)
            {
                var game = new CubeConundrumGame(line.Trim());
                if (game.PossibleGame(kMinRedCubes, kMinBlueCubes, kMinGreenCubes))
                {
                    sum += game.GameNr;
                }
            }
            Assert.Equal(1931, sum);
        }

        [Fact]
        public void Day02_Part2_CubeConundrum_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day02.txt");
            int expected = 100;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            int sum = 0;
            foreach (var line in lines)
            {
                var game = new CubeConundrumGame(line.Trim());

                int power = game.MinimumPowerCalculation();
                sum += power;
            }
            Assert.Equal(83105, sum);
        }
    }
}
