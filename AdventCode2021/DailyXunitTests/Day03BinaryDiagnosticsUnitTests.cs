using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class Day03BinaryDiagnosticsUnitTests
    {
        private string[] tdata;

        public Day03BinaryDiagnosticsUnitTests()
        {
            tdata = new string[]{
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };
        }

        [Fact]
        public void Test_GetGamma_Ok()
        {
            var sut = new BinaryDiagnostics();

            sut.ProcessData(tdata);
            Assert.Equal("10110", sut.Gamma);
            Assert.Equal("01001", sut.Epsilon);
            long actual = sut.CalcValue();
            Assert.Equal(198, actual);
        }


        [Fact]
        public void Day03_Puzzle1_Ok()
        {
            var data = Utils.ReadLinesFromFile("Day03.txt");
            Assert.Equal(1000, data.Length);
            Assert.Equal("011011010010", data[data.Length - 1]);

            var sut = new BinaryDiagnostics();

            sut.ProcessData(data);
            long actual = sut.CalcValue();
            Assert.Equal(1458194, actual);
        }

        [Fact]
        public void Test_LifeSupport_Ok()
        {
            var sut = new BinaryDiagnostics();

            sut.ProcessLifeSupport(tdata);
            Assert.Equal("10111", sut.Oxygen);
            Assert.Equal("01010", sut.CO2);
            long actual = sut.CalcLifeSupportValue();
            Assert.Equal(230, actual);
        }

        [Fact]
        public void Day03_Puzzle2_Ok()
        {
            var data = Utils.ReadLinesFromFile("Day03.txt");
            Assert.Equal(1000, data.Length);
            Assert.Equal("011011010010", data[data.Length - 1]);

            var sut = new BinaryDiagnostics();

            sut.ProcessLifeSupport(data);
            long actual = sut.CalcLifeSupportValue();
            Assert.Equal(2829354, actual);
        }
    }
}
