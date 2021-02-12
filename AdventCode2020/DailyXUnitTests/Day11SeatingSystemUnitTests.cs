using AdventOfCode2020;
using Xunit;

namespace DailyXUnitTests
{
    public class Day11SeatingSystemUnitTests
    {
        private string[] testSeating = new string[]{
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL"
            };

        [Fact(Skip = "Daily completed")]
        public void Day11ReadLines_OK()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day11Data.txt");
            Assert.Equal(94, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void Day11_SeatingSystem_Example1_OK()
        {
            var sut = new SeatingSystem(testSeating);

            Assert.Equal(10, sut.Rows);
            Assert.Equal(10, sut.RowSize);
            Assert.Equal(0, sut.Now);

            Assert.False(sut.Compare());
            Assert.Equal(0, sut.CountOccupiedSeats(sut.Now));

            int seats = 0;
            bool areEqual = false;
            do
            {
                sut.CalcNextRound();
                areEqual = sut.Compare();
                sut.DumpGenerations();
                sut.Toggle();
                seats = sut.CountOccupiedSeats(sut.Now);
            } while (!areEqual);

            Assert.Equal(37, seats);
        }

        [Fact(Skip = "Daily completed")]
        public void Day11SeatingSystem_Part1_OK()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day11Data.txt");
            Assert.Equal(94, lines.Length);
            var sut = new SeatingSystem(lines);

            Assert.False(sut.Compare());
            Assert.Equal(0, sut.CountOccupiedSeats(sut.Now));

            int seats = 0;
            bool areEqual = false;
            do
            {
                sut.CalcNextRound();
                areEqual = sut.Compare();
                //sut.DumpGenerations();
                sut.Toggle();
                seats = sut.CountOccupiedSeats(sut.Now);
            } while (!areEqual);

            Assert.Equal(2222, seats);
        }

        [Fact(Skip = "Daily completed")]
        public void Day11_SeatingSystem_Example1_Part2_OK()
        {
            var sut = new SeatingSystem(testSeating);

            Assert.Equal(10, sut.Rows);
            Assert.Equal(10, sut.RowSize);
            Assert.Equal(0, sut.Now);

            Assert.False(sut.Compare());
            Assert.Equal(0, sut.CountOccupiedSeats(sut.Now));

            int seats = 0;
            bool areEqual = false;
            do
            {
                sut.CalcNextRound(true);
                areEqual = sut.Compare();
                sut.DumpGenerations();
                sut.Toggle();
                seats = sut.CountOccupiedSeats(sut.Now);
            } while (!areEqual);

            Assert.Equal(26, seats);
        }

        [Fact(Skip = "Daily completed")]
        public void Day11SeatingSystem_Part2_OK()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day11Data.txt");
            Assert.Equal(94, lines.Length);
            var sut = new SeatingSystem(lines);

            Assert.False(sut.Compare());
            Assert.Equal(0, sut.CountOccupiedSeats(sut.Now));

            int seats = 0;
            bool areEqual = false;
            do
            {
                sut.CalcNextRound(true);
                areEqual = sut.Compare();
                //sut.DumpGenerations();
                sut.Toggle();
                seats = sut.CountOccupiedSeats(sut.Now);
            } while (!areEqual);

            Assert.Equal(2032, seats);
        }
    }
}
