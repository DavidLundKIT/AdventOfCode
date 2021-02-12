using AdventOfCode2020;
using System.Linq;
using Xunit;

namespace DailyXUnitTests
{
    public class Day22CrabCombatCardsUnitTests
    {
        [Fact(Skip = "Daily completed")]
        public void Day22_ReadData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day22Data.txt");
            Assert.Equal(53, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void Day22_Example1_Ok()
        {
            string[] hand1 = new string[]
            {
                "9",
                "2",
                "6",
                "3",
                "1"
            };
            string[] hand2 = new string[]
            {
                "5",
                "8",
                "4",
                "7",
                "10"
            };
            var sut = new CrabCombatGame();
            sut.Deal(hand1, hand2);
            long actual = sut.PlayMatch();
            Assert.Equal(306, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day22_CrabCombat_Part1_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day22Data.txt");
            Assert.Equal(53, lines.Length);

            var hand1 = lines.Skip(1).Take(25).ToArray();
            var hand2 = lines.Skip(28).Take(25).ToArray();
            var sut = new CrabCombatGame();
            sut.Deal(hand1, hand2);
            long actual = sut.PlayMatch();
            Assert.Equal(34566, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day22_Example2_HandsMatch_Ok()
        {
            string[] hand1 = new string[]
            {
                "43",
                "19"
            };
            string[] hand2 = new string[]
            {
                "2",
                "29",
                "14"
            };
            var sut = new RecursiveCrabCombatGame();
            sut.Deal(hand1, hand2);
            int actual = sut.PlayMatch();
            // winner should be 1 in recursive.
            Assert.Equal(3, actual);
            long score = sut.ScoreForMatch(actual);
            Assert.Equal(105, score);
        }

        [Fact(Skip = "Daily completed")]
        public void Day22_Example3_RccgMatch_Ok()
        {
            string[] hand1 = new string[]
            {
                "9",
                "2",
                "6",
                "3",
                "1"
            };
            string[] hand2 = new string[]
            {
                "5",
                "8",
                "4",
                "7",
                "10"
            };
            var sut = new RecursiveCrabCombatGame();
            sut.Deal(hand1, hand2);
            int winner = sut.PlayMatch();

            // winner should be 2 in recursive.
            Assert.Equal(2, winner);

            long score = sut.ScoreForMatch(winner); 
            Assert.Equal(291, score);
        }

        [Fact(Skip = "Daily completed")]
        public void Day22_RecursiveCrabCombat_Part2_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day22Data.txt");
            Assert.Equal(53, lines.Length);

            var hand1 = lines.Skip(1).Take(25).ToArray();
            var hand2 = lines.Skip(28).Take(25).ToArray();
            var sut = new RecursiveCrabCombatGame();
            sut.Deal(hand1, hand2);
            int winner = sut.PlayMatch();
            long score = sut.ScoreForMatch(winner);
            Assert.Equal(31854, score);
        }
    }
}
