using AdventOfCode2020;
using Xunit;

namespace DailyXUnitTests
{
    public class Day23CrabCupsUnitTests
    {
        private string prodData = "716892543";

        [Theory(Skip = "Daily completed")]
        [InlineData(3, 8, 9, 1, 2, 2)]
        [InlineData(5, 4, 6, 7, 3, 3)]
        [InlineData(4, 6, 7, 3, 2, 8)]
        [InlineData(6, 7, 3, 8, 5, 9)]
        [InlineData(7, 3, 8, 9, 6, 1)]
        public void Day23_Example1_OK(int currentCup, int cup0, int cup1, int cup2, int destCup, int newCurrectCup)
        {
            string data = "389125467";

            var sut = new CrabCupsGame(data);
            sut.CurrentCup = currentCup;
            var cups3 = sut.Extract3Cups();
            Assert.NotNull(cups3);
            Assert.Equal(cup0, cups3[0]);
            Assert.Equal(cup1, cups3[1]);
            Assert.Equal(cup2, cups3[2]);
            var actual = sut.FindDestination(9);
            Assert.Equal(destCup, actual);
            sut.InsertCups(cups3, actual);
            sut.UpdateCurrentCup();
            Assert.Equal(newCurrectCup, sut.CurrentCup);
        }

        [Fact(Skip = "Daily completed")]
        public void Day23_Example_10_Moves_Ok()
        {
            string data = "389125467";

            var sut = new CrabCupsGame(data);
            for (int i = 0; i < 10; i++)
            {
                sut.DoMove(9);
            }
            string actual = sut.CupsAfterOne();
            Assert.Equal("92658374", actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day23_Example_100_Moves_Ok()
        {
            string data = "389125467";

            var sut = new CrabCupsGame(data);
            for (int i = 0; i < 100; i++)
            {
                sut.DoMove(9);
            }
            string actual = sut.CupsAfterOne();
            Assert.Equal("67384529", actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day23_CrabCups_Part1_Ok()
        {
            var sut = new CrabCupsGame(prodData);
            for (int i = 0; i < 100; i++)
            {
                sut.DoMove(9);
            }
            string actual = sut.CupsAfterOne();
            Assert.Equal("49725386", actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day23_CrabCups_Part2_Ok()
        {
            // Takes a long time to run. around 2 hours.
            var sut = new CrabCupsGame(prodData, true);
            for (int i = 0; i < 10000000; i++)
            {
                sut.DoMove(1000000);
            }

            var iOne = sut.Cups.IndexOf(1);
            var i1 = (iOne + 1) % 1000000;
            var i2 = (iOne + 2) % 1000000;
            Assert.Equal(1, sut.Cups[iOne]);
            long v1 = sut.Cups[i1];
            long v2 = sut.Cups[i2];
            long actual = v1 * v2;
            Assert.Equal(538935646702, actual);
        }
    }
}
