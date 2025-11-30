using AdventCode2025.Models;

namespace AdventCode2025
{
    public class Day01UnitTests
    {
        [Fact]
        public void Day01_Part1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day01.txt");
            Assert.NotNull(lines);
            Assert.NotEmpty(lines);
            Assert.Equal("Hello world!", lines[0]);
        }
    }
}
