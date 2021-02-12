using AdventOfCode2019;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day01RocketEquationUnitTests
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void Day01Part1_TestCases(long mass, long expectedFuel)
        {
            long actualFuel = FuelCounterUpper.FuelCalculator(mass);

            Assert.Equal(expectedFuel, actualFuel);
        }

        [Fact]
        public void Day01Part1_TestSolution()
        {
            string[] masses = DayDataUtilities.ReadLinesFromFile("day01.txt");
            long totalFuel = 0;
            long mass;
            long fuel;
            foreach (var smass in masses)
            {
                mass = long.Parse(smass);
                fuel = FuelCounterUpper.FuelCalculator(mass);
                totalFuel += fuel;
            }
            Assert.Equal(3452245, totalFuel);
        }

        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void Day01Part2_TestCases(long mass, long expectedFuel)
        {
            long actualFuel = FuelCounterUpper.FuelFuelCalculator(mass);

            Assert.Equal(expectedFuel, actualFuel);
        }

        [Fact]
        public void Day01Part2_TestSolution()
        {
            string[] masses = DayDataUtilities.ReadLinesFromFile("day01.txt");
            long totalFuel = 0;
            long mass;
            long fuel;
            foreach (var smass in masses)
            {
                mass = long.Parse(smass);
                fuel = FuelCounterUpper.FuelFuelCalculator(mass);
                totalFuel += fuel;
            }
            Assert.Equal(5175499, totalFuel);
        }

    }
}
