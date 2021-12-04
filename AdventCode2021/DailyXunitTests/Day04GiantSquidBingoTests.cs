using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class Day04GiantSquidBingoTests
    {
        [Fact]
        public void Read_Bingo_Numbers_Boards_ok()
        {
            var lines = Utils.ReadLinesFromFile("Day04Test.txt");
            var sut = new GiantSquidBingo();
            sut.InitGame(lines);

            Assert.Equal(3, sut.Boards.Count);

            var bingoBoard = sut.Play();
            Assert.NotNull(bingoBoard);
            Assert.Equal(4512, bingoBoard.Score());
        }

        [Fact]
        public void Day04_Puzzle1_Ok()
        {
            var lines = Utils.ReadLinesFromFile("Day04.txt");
            var sut = new GiantSquidBingo();
            sut.InitGame(lines);

            Assert.Equal(100, sut.Boards.Count);
            var bingoBoard = sut.Play();
            Assert.NotNull(bingoBoard);
            Assert.Equal(72770, bingoBoard.Score());
        }

        [Fact]
        public void Test_Boards_ToLose_ok()
        {
            var lines = Utils.ReadLinesFromFile("Day04Test.txt");
            var sut = new GiantSquidBingo();
            sut.InitGame(lines);

            Assert.Equal(3, sut.Boards.Count);

            var bingoBoard = sut.PlayToLose();
            Assert.NotNull(bingoBoard);
            Assert.Equal(1924, bingoBoard.Score());
        }

        [Fact]
        public void Day04_Puzzle2_Ok()
        {
            var lines = Utils.ReadLinesFromFile("Day04.txt");
            var sut = new GiantSquidBingo();
            sut.InitGame(lines);

            Assert.Equal(100, sut.Boards.Count);
            var bingoBoard = sut.PlayToLose();
            Assert.NotNull(bingoBoard);
            Assert.Equal(13912, bingoBoard.Score());
        }
    }
}
