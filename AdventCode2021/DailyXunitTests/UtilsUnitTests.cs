using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class UtilsUnitTests
    {
        [Fact]
        public void Utils_ReadLines_OK()
        {
            var lines = Utils.ReadLinesFromFile("UtilsTest.txt");
            string expected = "Line 2";
            Assert.Equal(expected, lines[1]);
        }
    }
}
