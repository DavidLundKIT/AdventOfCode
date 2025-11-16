using days.day10;
using Xunit;

namespace days.test
{
    public class Day11UnitTests
    {
        [Theory]
        [InlineData(3, 5, 8, 4)]
        [InlineData(122, 79, 57, -5)]
        [InlineData(217, 196, 39, 0)]
        [InlineData(101, 153, 71, 4)]
        public void Day11_CalculatePowerLevel_Ok(int x, int y, int gridSerialNumber, int expectedLevel)
        {
            FuelCellCalculator sut = new FuelCellCalculator();
            int actual = sut.Power(x, y, gridSerialNumber);
            Assert.Equal(actual, expectedLevel);
        }

        [Theory]
        [InlineData(33, 45, 18, 29)]
        [InlineData(21, 61, 42, 30)]
        [InlineData(20, 43, 1309, 31)]
        public void Day11_CalculateGrid3x3(int expectedX, int expectedY, int gridSerialNumber, int expectedLevel)
        {
            int[,] grid = new int[301, 301];
            FuelCellCalculator sut = new FuelCellCalculator();
            sut.ComputeGrid(grid, gridSerialNumber);
            int actualPower = sut.FindMaxFuelCells3x3(grid, out int tlX, out int tlY, out int size);
            Assert.Equal(expectedLevel, actualPower);
            Assert.Equal(expectedX, tlX);
            Assert.Equal(expectedY, tlY);
            Assert.Equal(3, size);
        }

        [Theory]
        [InlineData(90, 269, 16, 18, 113)]
        [InlineData(232, 251, 12, 42, 119)]
        [InlineData(233, 271, 13, 1309, 108)]
        public void Day11_CalculateMaxGrid(int expectedX, int expectedY, int expectedSize, int gridSerialNumber, int expectedLevel)
        {
            int[,] grid = new int[301, 301];
            FuelCellCalculator sut = new FuelCellCalculator();
            sut.ComputeGrid(grid, gridSerialNumber);
            int actualPower = sut.FindMaxFuelCells(grid, out int tlX, out int tlY, out int size);
            Assert.Equal(expectedLevel, actualPower);
            Assert.Equal(expectedX, tlX);
            Assert.Equal(expectedY, tlY);
            Assert.Equal(expectedSize, size);
        }
    }
}