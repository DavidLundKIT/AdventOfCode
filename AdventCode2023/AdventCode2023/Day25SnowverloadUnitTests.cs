namespace AdventCode2023
{
    public class Day25SnowverloadUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day25.txt");
            int expected = 1247;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadInDataFile_Test1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day25test.txt");
            int expected = 13;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
        }
    }
}
