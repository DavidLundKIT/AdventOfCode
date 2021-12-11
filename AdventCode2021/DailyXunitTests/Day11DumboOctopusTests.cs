using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class Day11DumboOctopusTests
    {
        [Fact]
        public void Test_Read_Octupi_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day11Test.txt");
            Assert.Equal(10, lines.Length);
            var sut = new OctopusEnergyMeter(lines);
            Assert.Equal(5, sut.OctopusGrid[0, 0].Energy);
            Assert.Equal(6, sut.OctopusGrid[9, 9].Energy);
            for (int i = 0; i < 10; i++)
            {
                sut.DoStep(i);
            }
            Assert.Equal(204, sut.TotalFlashes);
            for (int i = 0; i < 90; i++)
            {
                sut.DoStep(i);
            }
            Assert.Equal(1656, sut.TotalFlashes);
        }

        [Fact]
        public void Day11_Puzzle1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day11.txt");
            Assert.Equal(10, lines.Length);
            var sut = new OctopusEnergyMeter(lines);
            Assert.Equal(4, sut.OctopusGrid[0, 0].Energy);
            Assert.Equal(4, sut.OctopusGrid[9, 9].Energy);

            for (int i = 0; i < 100; i++)
            {
                sut.DoStep(i);
            }
            Assert.Equal(1741, sut.TotalFlashes);
        }

        [Fact]
        public void Test_OctopusSynchronization_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day11Test.txt");
            Assert.Equal(10, lines.Length);
            var sut = new OctopusEnergyMeter(lines);

            int step = 0;
            do
            {
                sut.DoStep(step++);
            } while (sut.Synchronized == int.MaxValue);
            Assert.Equal(195, sut.Synchronized + 1);
        }

        [Fact]
        public void Day11_Puzzle2_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day11.txt");
            Assert.Equal(10, lines.Length);
            var sut = new OctopusEnergyMeter(lines);
            Assert.Equal(4, sut.OctopusGrid[0, 0].Energy);
            Assert.Equal(4, sut.OctopusGrid[9, 9].Energy);

            int step = 0;
            do
            {
                sut.DoStep(step++);
            } while (sut.Synchronized == int.MaxValue);
            Assert.Equal(440, sut.Synchronized + 1);
        }
    }
}
