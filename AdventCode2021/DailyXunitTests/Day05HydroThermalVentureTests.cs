using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class Day05HydroThermalVentureTests
    {
        [Fact]
        public void Read_Horizontal_and_Vertical_Vents_ok()
        {
            var lines = Utils.ReadLinesFromFile("Day05Test.txt");
            Assert.Equal(10, lines.Length);
            var sut = new HydroThermalVentMapper(lines);
            Assert.Equal(10, sut.Vents.Count);
            Assert.Equal(5, sut.MapVents(false));
        }

        [Fact]
        public void Day05_Puzzle1_Ok()
        {
            var lines = Utils.ReadLinesFromFile("Day05.txt");
            Assert.Equal(500, lines.Length);
            var sut = new HydroThermalVentMapper(lines);
            Assert.Equal(500, sut.Vents.Count);
            Assert.Equal(7468, sut.MapVents(false));
        }

        [Fact]
        public void Read_All_Vents_ok()
        {
            var lines = Utils.ReadLinesFromFile("Day05Test.txt");
            Assert.Equal(10, lines.Length);
            var sut = new HydroThermalVentMapper(lines);
            Assert.Equal(10, sut.Vents.Count);
            Assert.Equal(12, sut.MapVents(true));
        }

        [Fact]
        public void Day05_Puzzle2_Ok()
        {
            var lines = Utils.ReadLinesFromFile("Day05.txt");
            Assert.Equal(500, lines.Length);
            var sut = new HydroThermalVentMapper(lines);
            Assert.Equal(500, sut.Vents.Count);
            Assert.Equal(22364, sut.MapVents(true));
        }
    }
}
