using AdventOfCode2020;
using Xunit;

namespace DailyXUnitTests
{
    public class Day18OperationOrderUnitTests
    {
        [Fact(Skip = "Daily completed")]
        public void Day18_ReadData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day18Data.txt");
            Assert.Equal(380, lines.Length);
        }

        [Theory(Skip = "Daily completed")]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 71)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("2 * 3 + (4 * 5)", 26)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void Day18_Examples1_ok(string equation, long expected)
        {
            var sut = new OperationOrderParser();
            long actual = sut.Evaluate(equation);
            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day18_OperationOrder_Part1_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day18Data.txt");
            Assert.Equal(380, lines.Length);


            long sum = 0;
            foreach (var eq in lines)
            {
                var sut = new OperationOrderParser();
                sum += sut.Evaluate(eq);
            }
            Assert.Equal(8298263963837, sum);
        }

        [Theory(Skip = "Daily completed")]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 231)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("2 * 3 + (4 * 5)", 46)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
        public void Day18_Examples2_ok(string equation, long expected)
        {
            var sut = new OperationOrderParser();
            long actual = sut.Evaluate(equation, true);
            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day18_OperationOrder_Part2_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day18Data.txt");
            Assert.Equal(380, lines.Length);


            long sum = 0;
            foreach (var eq in lines)
            {
                var sut = new OperationOrderParser();
                sum += sut.Evaluate(eq, true);
            }
            Assert.Equal(145575710203332, sum);
        }
    }
}
