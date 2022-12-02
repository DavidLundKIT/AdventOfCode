using AdventCode2022.Models;

namespace AdventCode2022
{
    public class Day02RockPaperScissorsTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var matches = Utils.ReadLinesFromFile("Day02.txt");
            int expected = 2500;
            int actual = matches.Length;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("A Y", 8)]
        [InlineData("B X", 1)]
        [InlineData("C Z", 6)]
        public void TestMatchesScoring(string results, int expected)
        {
            var players = results.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int actual = RockPaperScissorsScorer.GameScorer(players[0][0], players[1][0]);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GameResults_Part1()
        {
            var matches = Utils.ReadLinesFromFile("Day02.txt");
            int score = 0;
            foreach (var match in matches)
            {
                var players = match.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                score += RockPaperScissorsScorer.GameScorer(players[0][0], players[1][0]);
            }
            int expected = 10816;
            Assert.Equal(expected, score);
        }

        [Theory]
        [InlineData("A Y", 4)]
        [InlineData("B X", 1)]
        [InlineData("C Z", 7)]
        public void TestMatchesAdjustedScoring(string results, int expected)
        {
            var players = results.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int actual = RockPaperScissorsScorer.GameAdjustedScorer(players[0][0], players[1][0]);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GameResultsAdjusted_Part2()
        {
            var matches = Utils.ReadLinesFromFile("Day02.txt");
            int score = 0;
            foreach (var match in matches)
            {
                var players = match.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                score += RockPaperScissorsScorer.GameAdjustedScorer(players[0][0], players[1][0]);
            }
            int expected = 11657;
            Assert.Equal(expected, score);
        }
    }
}
