using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class Day10SyntaxScoringTests
    {
        [Fact]
        public void Test_readlines_SyntaxScore_ok()
        {
            var lines = Utils.ReadLinesFromFile("Day10Test.txt");
            Assert.Equal(10, lines.Length);

            var sut = new SyntaxChecker(lines);
            long actual = sut.CheckSyntaxScore();

            Assert.Equal(26397, actual);
        }

        [Fact]
        public void Test_readlines_CompletionScore_ok()
        {
            var lines = Utils.ReadLinesFromFile("Day10Test.txt");
            Assert.Equal(10, lines.Length);

            var sut = new SyntaxChecker(lines);
            long actual = sut.CheckSyntaxScore();
            actual = sut.GetCompScore();
            Assert.Equal(288957, actual);
        }

        [Fact]
        public void Day10_Puzzle1_Ok()
        {
            var lines = Utils.ReadLinesFromFile("Day10.txt");
            Assert.Equal(106, lines.Length);

            var sut = new SyntaxChecker(lines);
            long actual = sut.CheckSyntaxScore();

            Assert.Equal(323691, actual);
        }

        [Fact]
        public void Day10_Puzzle2_Ok()
        {
            var lines = Utils.ReadLinesFromFile("Day10.txt");
            Assert.Equal(106, lines.Length);

            var sut = new SyntaxChecker(lines);
            long actual = sut.CheckSyntaxScore();
            actual = sut.GetCompScore();
            Assert.Equal(2858785164, actual);
        }
    }
}
