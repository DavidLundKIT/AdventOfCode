using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    /// <summary>
    /// Solution was by hand pen, paper, and Excel to check sums
    /// </summary>
    public class Day23AmphipodTests
    {
        [Fact]
        public void Day23_Puzzle1_Ok()
        {
            var lines = Utils.ReadLinesFromFile("Day23.txt");
            Assert.Equal(5, lines.Length);
        }
    }
}
