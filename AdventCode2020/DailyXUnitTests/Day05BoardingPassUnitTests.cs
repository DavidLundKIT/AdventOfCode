using AdventOfCode2020;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DailyXUnitTests
{
    public class Day05BoardingPassUnitTests
    {
        [Fact(Skip = "Daily completed")]
        public void Day05ReadBoardingPassData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day05Data.txt");
            Assert.Equal(814, lines.Length);
        }

        [Theory(Skip = "Daily completed")]
        [InlineData("FBFBBFFRLR", 44, 5, 357)]
        [InlineData("BFFFBBFRRR", 70, 7, 567)]
        [InlineData("FFFBBBFRRR", 14, 7, 119)]
        [InlineData("BBFFBBFRLL", 102, 4, 820)]
        public void Day05CalculateSeatId(string boardingPass, int expectedRow, int expectedSeat, int expectedSeatId)
        {
            var sut = new BoardingPassChecker();

            var seatId = sut.CalculateSeatID(boardingPass, out int row, out int seat);
            Assert.Equal(expectedRow, row);
            Assert.Equal(expectedSeat, seat);
            Assert.Equal(expectedSeatId, seatId);
        }

        [Fact(Skip = "Daily completed")]
        public void Day05HighestSeatId_Part1_Ok()
        {
            var boardingPasses = new List<string>();
            boardingPasses.AddRange(DailyDataUtilities.ReadLinesFromFile("Day05Data.txt"));
            Assert.Equal(814, boardingPasses.Count);
            var checker = new BoardingPassChecker();

            int maxSeatId = boardingPasses.Select(bp => checker.CalculateSeatID(bp, out int row, out int seat)).Max();
            Assert.Equal(892, maxSeatId);
        }

        [Fact(Skip = "Daily completed")]
        public void Day05HighestSeatId_Part2_Ok()
        {
            var boardingPasses = new List<string>();
            boardingPasses.AddRange(DailyDataUtilities.ReadLinesFromFile("Day05Data.txt"));
            Assert.Equal(814, boardingPasses.Count);
            var checker = new BoardingPassChecker();

            var Seats = boardingPasses.Select(bp => checker.CalculateSeatID(bp, out int row, out int seat)).ToList();
            List<int> emptySeats = new List<int>();
            Seats.Sort();
            for (int i = 0; i < Seats.Count - 1; i++)
            {
                if (Seats[i] + 2 == Seats[i + 1])
                {
                    emptySeats.Add(Seats[i] + 1);
                }
            }
            Assert.Equal(1, emptySeats.Count);
            Assert.Equal(625, emptySeats[0]);
        }
    }
}
