using AdventOfCode2020;
using Xunit;

namespace DailyXUnitTests
{
    public class Day12RainRiskUnitTests
    {
        private string[] testData = new string[]
        {
            "F10",
            "N3",
            "F7",
            "R90",
            "F11"
        };

        [Fact(Skip = "Daily completed")]
        public void Day12ReadData_OK()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day12Data.txt");
            Assert.Equal(786, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void Day12_Example_Part1_OK()
        {
            var sut = new FerryNavigator();

            foreach (var leg in testData)
            {
                sut.Move(leg);
            }
            int actual = sut.AbsoluteDistanceTravelled();
            Assert.Equal(25, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day12_RainRisk_Part1_OK()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day12Data.txt");
            Assert.Equal(786, lines.Length);
            var sut = new FerryNavigator();

            foreach (var leg in lines)
            {
                sut.Move(leg);
            }
            int actual = sut.AbsoluteDistanceTravelled();
            Assert.Equal(1838, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day12_Example_Part2_OK()
        {
            var sut = new WayPointNavigator();

            foreach (var leg in testData)
            {
                sut.Move(leg);
            }
            long actual = sut.AbsoluteDistanceTravelled();
            Assert.Equal(286, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day12_RainRisk_Part2_OK()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day12Data.txt");
            Assert.Equal(786, lines.Length);
            var sut = new WayPointNavigator();

            foreach (var leg in lines)
            {
                sut.Move(leg);
            }
            long actual = sut.AbsoluteDistanceTravelled();
            Assert.Equal(89936, actual);
        }
    }
}
