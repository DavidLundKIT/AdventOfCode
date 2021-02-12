using AdventOfCode2020;
using Xunit;

namespace DailyXUnitTests
{
    public class Day03ToboganForestUnitTests
    {
        [Fact(Skip = "Daily completed")]
        public void Day03ReadForestData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day03Data.txt");
            Assert.Equal(323, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void Day03ReadForestTestData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day03TestData.txt");
            Assert.Equal(11, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void TestTobaganRide_3R1D_OK()
        {
            var trees = DailyDataUtilities.ReadLinesFromFile("Day03TestData.txt");
            Assert.Equal(11, trees.Length);

            var forest = new ForestMap(trees);
            int numTrees = forest.TreesOnSlope(0, 0, 3, 1);
            Assert.Equal(7, numTrees);
        }

        [Fact(Skip = "Daily completed")]
        public void Day03ToboganForestRide_Part1_Ok()
        {
            var trees = DailyDataUtilities.ReadLinesFromFile("Day03Data.txt");
            Assert.Equal(323, trees.Length);

            var forest = new ForestMap(trees);
            int numTrees = forest.TreesOnSlope(0, 0, 3, 1);
            Assert.Equal(167, numTrees);
        }

        [Fact(Skip = "Daily completed")]
        public void TestTobaganRide_Part2_OK()
        {
            var trees = DailyDataUtilities.ReadLinesFromFile("Day03TestData.txt");
            Assert.Equal(11, trees.Length);

            var forest = new ForestMap(trees);
            
            int numTrees = forest.TreesOnSlope(0, 0, 1, 1);
            Assert.Equal(2, numTrees);
            int totalTrees = numTrees;

            numTrees = forest.TreesOnSlope(0, 0, 3, 1);
            Assert.Equal(7, numTrees);
            totalTrees *= numTrees;

            numTrees = forest.TreesOnSlope(0, 0, 5, 1);
            Assert.Equal(3, numTrees);
            totalTrees *= numTrees;

            numTrees = forest.TreesOnSlope(0, 0, 7, 1);
            Assert.Equal(4, numTrees);
            totalTrees *= numTrees;

            numTrees = forest.TreesOnSlope(0, 0, 1, 2);
            Assert.Equal(2, numTrees);
            totalTrees *= numTrees;

            Assert.Equal(336, totalTrees);
        }

        [Fact(Skip = "Daily completed")]
        public void Day03TobaganRide_Part2_OK()
        {
            var trees = DailyDataUtilities.ReadLinesFromFile("Day03Data.txt");
            Assert.Equal(323, trees.Length);

            var forest = new ForestMap(trees);

            int numTrees = forest.TreesOnSlope(0, 0, 1, 1);
            int totalTrees = numTrees;

            numTrees = forest.TreesOnSlope(0, 0, 3, 1);
            totalTrees *= numTrees;

            numTrees = forest.TreesOnSlope(0, 0, 5, 1);
            totalTrees *= numTrees;

            numTrees = forest.TreesOnSlope(0, 0, 7, 1);
            totalTrees *= numTrees;

            numTrees = forest.TreesOnSlope(0, 0, 1, 2);
            totalTrees *= numTrees;

            Assert.Equal(736527114, totalTrees);
        }
    }
}
