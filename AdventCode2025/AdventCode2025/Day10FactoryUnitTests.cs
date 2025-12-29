using AdventCode2025.Models;

namespace AdventCode2025;

public class Day10FactoryUnitTests
{
    [Fact]
    public void Day10_testdata_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day10test.txt");
        Assert.Equal(3, lines.Length);

        int total = 0;
        foreach (var line in lines)
        {
            var mc = new MachineConfigurator(line);
            int steps = mc.MinPressesForStartUp();
            total += steps;
        }

        Assert.Equal(7, total);
    }

    [Theory]
    [InlineData("[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}", 6, 2)]
    [InlineData("[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}", 5, 3)]
    [InlineData("[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}", 4, 2)]
    public void Day10_testdata_line_OK(string line, int buttons, int expectedSteps)
    {
        var sut = new MachineConfigurator(line);
        Assert.Equal(buttons, sut.Buttons.Count);

        int actualSteps = sut.MinPressesForStartUp();
        Assert.Equal(expectedSteps, actualSteps);
    }

    [Fact]
    public void Day10_Part1_Solution_OK() 
    {
        var lines = Utils.ReadLinesFromFile("Day10.txt");
        Assert.Equal(158, lines.Length);

        int total = 0;
        foreach (var line in lines)
        {
            var mc = new MachineConfigurator(line);
            int steps = mc.MinPressesForStartUp();
            total += steps;
        }

        Assert.Equal(411, total);
    }

    [Theory]
    [InlineData("[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}", 6, 10)]
    [InlineData("[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}", 5, 12)]
    [InlineData("[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}", 4, 11)]
    //[InlineData("[##....#.##] (0,1,2,4,5,6,7,9) (0,1,2,3,4,6,7,9) (0,1,6) (0,5,8) (1,3,4,5,9) (0,1,3,8,9) (0,2,4,5) (0,1,2,5,8,9) (1,2,4,5,6,8,9) (0,2,3,5,7,8,9) (0,2,3,4,7,8,9) (1,2,3,5,6,7,8) {97,74,93,57,65,79,46,51,84,79}", 12, 100)]
    public void Day10_testdata_line_jolt_OK(string line, int buttons, int expectedSteps)
    {
        var sut = new MachineConfigurator(line);
        Assert.Equal(buttons, sut.Buttons.Count);

        int actualSteps = sut.MinPressesForJoltage();
        Assert.Equal(expectedSteps, actualSteps);
    }

    [Fact]
    public void Day10_testdata_joltage_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day10test.txt");
        Assert.Equal(3, lines.Length);

        int total = 0;
        foreach (var line in lines)
        {
            var mc = new MachineConfigurator(line);
            int steps = mc.MinPressesForJoltage();
            total += steps;
        }

        Assert.Equal(33, total);
    }

    [Fact(Skip ="Not ending after 21 hours")]
    public void Day10_Part2_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day10.txt");
        Assert.Equal(158, lines.Length);

        int total = 0;
        foreach (var line in lines)
        {
            var mc = new MachineConfigurator(line);
            int steps = mc.MinPressesForJoltage();
            total += steps;
        }

        Assert.Equal(0, total);
    }
}
