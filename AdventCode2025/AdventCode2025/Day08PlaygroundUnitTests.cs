using AdventCode2025.Models;

namespace AdventCode2025;

public class Day08PlaygroundUnitTests
{
    [Fact]
    public void Day08_TestData_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day08test.txt");
        Assert.Equal(20, lines.Length);

        var jbcm = new JunctionBoxCircuitMaker(lines);
        Assert.Equal(20, jbcm.JunctionBoxes.Count);
        jbcm.CalculateCircuitPairs();
        Assert.NotEmpty(jbcm.CircuitPairs.Keys);
        Assert.Equal(190, jbcm.CircuitPairs.Count);
        long actual = jbcm.CombineShortestCircuits(10);
        Assert.Equal(40, actual);
    }

    [Fact]
    public void Day08_Part1_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day08.txt");
        Assert.Equal(1000, lines.Length);

        var jbcm = new JunctionBoxCircuitMaker(lines);
        Assert.Equal(1000, jbcm.JunctionBoxes.Count);
        jbcm.CalculateCircuitPairs();
        Assert.NotEmpty(jbcm.CircuitPairs.Keys);
        Assert.Equal(499500, jbcm.CircuitPairs.Count);
        long actual = jbcm.CombineShortestCircuits(1000);
        Assert.Equal(164475, actual);
    }

    [Fact]
    public void Day08_TestData_AllCircuits_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day08test.txt");
        Assert.Equal(20, lines.Length);

        var jbcm = new JunctionBoxCircuitMaker(lines);
        Assert.Equal(20, jbcm.JunctionBoxes.Count);
        jbcm.CalculateCircuitPairs();
        Assert.NotEmpty(jbcm.CircuitPairs.Keys);
        Assert.Equal(190, jbcm.CircuitPairs.Count);
        long actual = jbcm.CombineShortestUntilOneCircuit();
        Assert.Equal(25272, actual);
    }

    [Fact]
    public void Day08_Part2_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day08.txt");
        Assert.Equal(1000, lines.Length);

        var jbcm = new JunctionBoxCircuitMaker(lines);
        Assert.Equal(1000, jbcm.JunctionBoxes.Count);
        jbcm.CalculateCircuitPairs();
        Assert.NotEmpty(jbcm.CircuitPairs.Keys);
        Assert.Equal(499500, jbcm.CircuitPairs.Count);
        long actual = jbcm.CombineShortestUntilOneCircuit();
        Assert.Equal(169521198, actual);
    }
}
