namespace AdventCode2023
{
    public class Day01UnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var calorieList = Utils.ReadLinesFromFile("Day01.txt");
            int expected = 1;
            int actual = calorieList.Length;
            Assert.Equal(expected, actual);
        }
    }
}