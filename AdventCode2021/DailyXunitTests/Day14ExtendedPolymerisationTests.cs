using AdventCode2021;
using System.Linq;
using Xunit;

namespace DailyXunitTests
{
    public class Day14ExtendedPolymerisationTests
    {
        [Fact]
        public void Day14_TestReadPolymers_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14Test.txt");

            Assert.Equal(18, lines.Length);
            var sut = new Polymerizer(lines);
            Assert.Equal("NNCB", sut.Template);
            sut.PairInsertion();
            Assert.Equal("NCNBCHB", sut.Template);
            sut.PairInsertion();
            Assert.Equal("NBCCNBBBCBHCB", sut.Template);
            sut.PairInsertion();
            Assert.Equal("NBBBCNCCNBBNBNBBCHBHHBCHB", sut.Template);
            sut.PairInsertion();
            Assert.Equal("NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB", sut.Template);

            for (int i = 0; i < 6; i++)
            {
                sut.PairInsertion();
            }

            long actual = sut.QuantityOfElements();
            Assert.Equal(1588, actual);
        }

        [Fact]
        public void Day14_TestReadPolymers_Roboot_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14Test.txt");

            Assert.Equal(18, lines.Length);
            var sut = new PolymerizerLinked(lines);
            Assert.Equal("NNCB", sut.Template);
            sut.PairInsertion();
            Assert.Equal("NCNBCHB", sut.Template);
            sut.PairInsertion();
            Assert.Equal("NBCCNBBBCBHCB", sut.Template);
            sut.PairInsertion();
            Assert.Equal("NBBBCNCCNBBNBNBBCHBHHBCHB", sut.Template);
            sut.PairInsertion();
            Assert.Equal("NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB", sut.Template);

            for (int i = 0; i < 6; i++)
            {
                sut.PairInsertion();
            }

            long actual = sut.QuantityOfElements();
            Assert.Equal(1588, actual);
        }

        [Fact]
        public void Day14_Puzzle1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14.txt");

            Assert.Equal(102, lines.Length);
            var sut = new Polymerizer(lines);
            Assert.Equal("KOKHCCHNKKFHBKVVHNPN", sut.Template);

            for (int i = 0; i < 10; i++)
            {
                sut.PairInsertion();
            }

            long actual = sut.QuantityOfElements();
            Assert.Equal(3406, actual);
        }

        [Fact]
        public void Day14_Puzzle1_PolyLinked_10_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14.txt");

            Assert.Equal(102, lines.Length);
            var sut = new PolymerizerLinked(lines);
            Assert.Equal("KOKHCCHNKKFHBKVVHNPN", sut.Template);

            for (int i = 0; i < 10; i++)
            {
                sut.PairInsertion();
            }

            long actual = sut.QuantityOfElements();
            Assert.Equal(3406, actual);
        }

        [Fact(Skip = "Bust for Puzzle2")]
        public void Day14_Test_long_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14Test.txt");

            Assert.Equal(18, lines.Length);
            var sut = new PolymerizerLinked(lines);
            Assert.Equal("NNCB", sut.Template);

            for (int i = 0; i < 40; i++)
            {
                sut.PairInsertion();
            }

            long actual = sut.QuantityOfElements();
            Assert.Equal(2188189693529, actual);
        }

        [Fact(Skip = "Dies out of memory")]
        public void Day14_Test_OnePair40_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14Test.txt");

            Assert.Equal(18, lines.Length);
            var sut = new Polymerizer(lines);
            Assert.Equal("NNCB", sut.Template);
            // reset Template one pair
            //sut.Template = "NN";

            for (int i = 0; i < 40; i++)
            {
                sut.PairInsertion();
            }

            long actual = sut.QuantityOfElements();
            Assert.Equal(0, actual);
        }

        [Fact]
        public void Day14_TestReadPolymers_Roboot2_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14Test.txt");

            Assert.Equal(18, lines.Length);
            var sut = new PolymerizerKey(lines);
            Assert.Equal("NNCB", sut.Template);
            sut.PairInsertion(4);
            string expected = "NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB";
            long actual = sut.QuantityOfElements();
            actual = sut.Elems.Values.Sum();
            Assert.Equal(expected.Length, actual);
        }

        [Fact]
        public void Day14_TestReadPolymers_PolyKey_10_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14Test.txt");

            Assert.Equal(18, lines.Length);
            var sut = new PolymerizerKey(lines);
            Assert.Equal("NNCB", sut.Template);
            sut.PairInsertion(10);
            long actual = sut.QuantityOfElements();
            Assert.Equal(1588, actual);
        }

        [Fact]
        public void Day14_Puzzle1_PolyKey_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14.txt");

            Assert.Equal(102, lines.Length);
            var sut = new PolymerizerKey(lines);
            Assert.Equal("KOKHCCHNKKFHBKVVHNPN", sut.Template);
            sut.PairInsertion(10);
            long actual = sut.QuantityOfElements();
            Assert.Equal(3406, actual);
        }

        [Fact]
        public void Day14_TestReadPolymers_PolyCounter_10_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14Test.txt");

            Assert.Equal(18, lines.Length);
            var sut = new PolymerizerCounter(lines);
            Assert.Equal("NNCB", sut.Template);
            for (int i = 0; i < 10; i++)
            {
                sut.PairInsertion();
            }
            long actual = sut.QuantityOfElements();
            Assert.Equal(1588, actual);
        }

        [Fact]
        public void Day14_Puzzle1_PolyCounter_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14.txt");

            Assert.Equal(102, lines.Length);
            var sut = new PolymerizerCounter(lines);
            Assert.Equal("KOKHCCHNKKFHBKVVHNPN", sut.Template);
            for (int i = 0; i < 10; i++)
            {
                sut.PairInsertion();

            }
            long actual = sut.QuantityOfElements();
            Assert.Equal(3406, actual);
        }

        [Fact]
        public void Day14_TestReadPolymers_PolyCounter_40_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14Test.txt");

            Assert.Equal(18, lines.Length);
            var sut = new PolymerizerCounter(lines);
            Assert.Equal("NNCB", sut.Template);
            for (int i = 0; i < 40; i++)
            {
                sut.PairInsertion();
            }
            long actual = sut.QuantityOfElements();
            Assert.Equal(2188189693529, actual);
        }

        [Fact]
        public void Day14_Puzzle2_PolyCounter_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14.txt");

            Assert.Equal(102, lines.Length);
            var sut = new PolymerizerCounter(lines);
            Assert.Equal("KOKHCCHNKKFHBKVVHNPN", sut.Template);
            for (int i = 0; i < 40; i++)
            {
                sut.PairInsertion();
            }
            long actual = sut.QuantityOfElements();
            Assert.Equal(3941782230241, actual);
        }
    }
}
