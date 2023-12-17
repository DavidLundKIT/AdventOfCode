using AdventCode2023.Models;

namespace AdventCode2023
{
    public class Day14ParabolicReflectorDishUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14.txt");
            int expected = 100;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14test.txt");
            int expected = 10;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new DishTilterMeter(lines);

            long lactual = sut.TiltNorth();
            Assert.Equal(136, lactual);
        }

        [Fact]
        public void Day14_Part1_ParabolicReflectorDish_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14.txt");
            int expected = 100;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new DishTilterMeter(lines);

            long lactual = sut.TiltNorth();
            Assert.Equal(110677, lactual);
        }

    }
}
