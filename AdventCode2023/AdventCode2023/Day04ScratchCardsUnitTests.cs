using AdventCode2023.Models;

namespace AdventCode2023
{
    public class Day04ScratchCardsUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var cards = Utils.ReadLinesFromFile("Day04.txt");
            int expected = 203;
            int actual = cards.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var cards = Utils.ReadLinesFromFile("Day04test.txt");
            int expected = 6;
            int actual = cards.Length;
            Assert.Equal(expected, actual);

            var sut = new ScratchCardEvaluator(cards);

            actual = 0;
            foreach (var card in sut.Cards)
            {
                actual += card.PointValue();
            }
            Assert.Equal(13, actual);

            actual = sut.CalculateTotalCards();
            Assert.Equal(30, actual);
        }

        [Fact]
        public void Day04_Part1_ScratchCards_OK()
        {
            var cards = Utils.ReadLinesFromFile("Day04.txt");
            int expected = 203;
            int actual = cards.Length;
            Assert.Equal(expected, actual);

            var sut = new ScratchCardEvaluator(cards);

            actual = 0;
            foreach (var card in sut.Cards)
            {
                actual += card.PointValue();
            }
            Assert.Equal(25174, actual);
        }

        [Fact]
        public void Day04_Part2_ScratchCards_OK()
        {
            var cards = Utils.ReadLinesFromFile("Day04.txt");
            int expected = 203;
            int actual = cards.Length;
            Assert.Equal(expected, actual);

            var sut = new ScratchCardEvaluator(cards);

            actual = 0;
            foreach (var card in sut.Cards)
            {
                actual += card.PointValue();
            }
            Assert.Equal(25174, actual);

            actual = sut.CalculateTotalCards();
            Assert.Equal(6420979, actual);
        }
    }
}
