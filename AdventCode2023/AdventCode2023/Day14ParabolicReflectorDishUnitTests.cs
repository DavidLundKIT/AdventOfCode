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
            sut.TiltNorth();
            long lactual = sut.CalculateLoad();
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

            sut.TiltNorth();
            long lactual = sut.CalculateLoad();
            Assert.Equal(110677, lactual);
        }

        [Fact]
        public void Check_Each_Cycle_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14test.txt");
            int expected = 10;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new DishTilterMeter(lines);
            sut.DoCycle();
            sut.DoCycle();
            sut.DoCycle();
            long lactual = sut.CalculateLoad();
            Assert.Equal(69, lactual);
        }

        [Fact]
        public void Check_For_Repeat_Cycle_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14test.txt");
            int expected = 10;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
            var sut = new DishTilterMeter(lines);
            sut.RunCyclesForPattern();
            long lactual = sut.FindCorrectLoad();
            Assert.Equal(64, lactual);
        }

        [Fact]
        public void Day14_Part2_ParabolicReflectorDish_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14.txt");
            int expected = 100;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new DishTilterMeter(lines);
            sut.RunCyclesForPattern();
            /*
             * It is here that I inspected the loadDict dictionary and saw the repeat pattern after 107 single steps
             * The pattern had 34 cycle length. I dumped the dictionary to Excel and then looked for the row that 
             * when (1000000000 - first cycle ) mod 34 = 0.
             */
            long lactual = sut.FindCorrectLoad();
            Assert.Equal(90551, lactual);
        }
    }
}
