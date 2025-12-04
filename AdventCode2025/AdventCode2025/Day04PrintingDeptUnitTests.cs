using AdventCode2025.Models;

namespace AdventCode2025;

public class Day04PrintingDeptUnitTests
{
    [Fact]
    public void Day04_TestData_Find13_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day04test.txt");
        Assert.Equal(10, lines.Length);

        var sut = new PrinterDeptFloorMapper(lines);

        //sut.PrintWarehouse();
        var tiles = sut.CountAccessiblePaperRolls();
        Assert.Equal(13, tiles);
    }

    [Fact]
    public void Day04_Part1_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day04.txt");
        Assert.Equal(136, lines.Length);
        var sut = new PrinterDeptFloorMapper(lines);

        //sut.PrintWarehouse();
        var tiles = sut.CountAccessiblePaperRolls();
        Assert.Equal(1397, tiles);
    }

    [Fact]
    public void Day04_TestData_RemoveRolls_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day04test.txt");
        Assert.Equal(10, lines.Length);

        var sut = new PrinterDeptFloorMapper(lines);

        //sut.PrintWarehouse();
        var tiles = sut.RemoveWarehousePaperRolls();
        Assert.Equal(43, tiles);
    }

    [Fact]
    public void Day04_Part2_Solution_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day04.txt");
        Assert.Equal(136, lines.Length);
        var sut = new PrinterDeptFloorMapper(lines);

        //sut.PrintWarehouse();
        var tiles = sut.RemoveWarehousePaperRolls();
        Assert.Equal(8758, tiles);
    }
}
