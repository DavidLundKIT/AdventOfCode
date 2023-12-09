using AdventCode2023.Models;

namespace AdventCode2023
{
    public class Day07CamelCardsUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day07.txt");
            int expected = 1000;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day07test.txt");
            int expected = 5;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new CamelCardHandEvaluator(lines, false);

            sut.Hands.Sort();
            Assert.Equal("32T3K", sut.Hands[0].Hand);
            Assert.Equal("KTJJT", sut.Hands[1].Hand);
            Assert.Equal("KK677", sut.Hands[2].Hand);
            Assert.Equal("T55J5", sut.Hands[3].Hand);
            Assert.Equal("QQQJA", sut.Hands[4].Hand);

            long totalWinnings = sut.TotalWinnings();
            Assert.Equal(6440, totalWinnings);
        }

        [Theory]
        [InlineData("32T3K 1", CamelCardHandType.OnePair)]
        [InlineData("KK677 1", CamelCardHandType.TwoPair)]
        [InlineData("QQQJA 1", CamelCardHandType.ThreeOfAKind)]
        [InlineData("QQQQJ 1", CamelCardHandType.FourOfAKind)]
        [InlineData("QQQQQ 1", CamelCardHandType.FiveOfAKind)]
        [InlineData("J55J5 1", CamelCardHandType.FullHouse)]
        [InlineData("32T38K 1", CamelCardHandType.HighCard)]
        public void EvaluateHands_OK(string hand, CamelCardHandType expectedHandType)
        {
            var sut = new CamelCardHand(hand, false);

            Assert.Equal(expectedHandType, sut.HandType);
        }

        [Fact]
        public void UsingJokers_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day07test.txt");
            int expected = 5;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new CamelCardHandEvaluator(lines, true);

            sut.Hands.Sort();
            Assert.Equal("32T3K", sut.Hands[0].Hand);
            Assert.Equal("KK677", sut.Hands[1].Hand);
            Assert.Equal("T55J5", sut.Hands[2].Hand);
            Assert.Equal("QQQJA", sut.Hands[3].Hand);
            Assert.Equal("KTJJT", sut.Hands[4].Hand);

            long totalWinnings = sut.TotalWinnings();
            Assert.Equal(5905, totalWinnings);
        }

        [Fact]
        public void Day07_Part1_CamelCards_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day07.txt");
            int expected = 1000;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new CamelCardHandEvaluator(lines, false);

            long totalWinnings = sut.TotalWinnings();
            Assert.Equal(252052080, totalWinnings);
        }

        [Fact]
        public void Day07_Part2_CamelCards_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day07.txt");
            int expected = 1000;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new CamelCardHandEvaluator(lines, true);

            long totalWinnings = sut.TotalWinnings();
            Assert.Equal(252898370, totalWinnings);
        }
    }
}
