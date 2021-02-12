using days.day09;
using Xunit;

namespace days.test
{
    public class Day09UnitTests
    {
        // 411 players; last marble is worth 71170 points
        [Theory(Skip = "Answer day 9 last 2. Obs! the last takes forever 115 minutes.")]
        [InlineData(9, 25, 32)]
        [InlineData(10, 1618, 8317)]
        [InlineData(13, 7999, 146373)]
        [InlineData(17, 1104, 2764)]
        [InlineData(21, 6111, 54718)]
        [InlineData(30, 5807, 37305)]
        [InlineData(411, 71170, 425688)]
        [InlineData(411, 7117000, 3526561003)]
        public void Day09_PlayGame(long players, int lastMarble, long highScore)
        {
            var game = new MarblesGame(players, lastMarble);
            long player = 1;
            long marble = 1;

            do
            {
                game.AddMarble(player++, marble++);
                if (player > players)
                {
                    player=1;
                }
            } while(marble <= lastMarble);
            Assert.Equal(highScore, game.HighScore());
        }
    }
}
