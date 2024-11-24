using AdventCode2024.Models;

namespace AdventCode2024
{
    public class Day01blahblahUnitTests
    {
        [Fact]
        public void Day01_Step1_Something_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day01.txt");
            int count = 1;
            Assert.Equal(count, lines.Length);
        }
    }
}
