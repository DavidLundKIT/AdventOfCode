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
            Assert.Equal(5, sut.MapVentsHV());
        }

        [Fact]
        public void Day05_Puzzle1_Ok()
        {
            var lines = Utils.ReadLinesFromFile("Day05.txt");
            Assert.Equal(500, lines.Length);
            var sut = new HydroThermalVentMapper(lines);
            Assert.Equal(500, sut.Vents.Count);
            Assert.Equal(7468, sut.MapVentsHV());
        }

    }
}
