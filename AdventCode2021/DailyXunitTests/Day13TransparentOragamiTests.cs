using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class Day13TransparentOragamiTests
    {
        [Fact]
        public void Day13_Test1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day13Test.txt");
            Assert.Equal(21, lines.Length);

            var sut = new PaperFolder(lines);
            Assert.Equal(18, sut.Points.Count);
            Assert.Equal(2, sut.Folds.Count);

            int actual = sut.DoFold(sut.Folds[0]);
            Assert.Equal(17, actual);
        }

        [Fact]
        public void Day13_Puzzle1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day13.txt");
            Assert.Equal(815, lines.Length);

            var sut = new PaperFolder(lines);
            Assert.Equal(802, sut.Points.Count);
            Assert.Equal(12, sut.Folds.Count);

            int actual = sut.DoFold(sut.Folds[0]);
            Assert.Equal(669, actual);
        }

        [Fact]
        public void Day13_Puzzle2_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day13.txt");
            Assert.Equal(815, lines.Length);

            var sut = new PaperFolder(lines);
            Assert.Equal(802, sut.Points.Count);
            Assert.Equal(12, sut.Folds.Count);

            sut.DoAllFolds();
            sut.DumpPoints();

        }
    }
}
