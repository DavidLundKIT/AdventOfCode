using AdventCode2024.Models;

namespace AdventCode2024;

public class Day15WarehouseWoesUnitTests
{
    [Fact]
    public void TestData2_GetWareHouse_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day15test2.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(10, lines.Count());

        var wm = new WarehouseRobotTracker(lines);
        Assert.NotNull(wm);
        wm.ShowWarehouse();
        wm.DoCommands();
        wm.ShowWarehouse();
        long actual = wm.GpsSum();
        Assert.Equal(2028, actual);
    }

    [Fact]
    public void TestData1_GetWareHouse_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day15test1.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(21, lines.Count());

        var wm = new WarehouseRobotTracker(lines);
        Assert.NotNull(wm);
        wm.ShowWarehouse();
        wm.DoCommands();
        wm.ShowWarehouse();
        long actual = wm.GpsSum();
        Assert.Equal(10092, actual);
    }

    [Fact]
    public void Day15_Part1_WareHouseWoes_OK()
    {
        var lines = Utils.ReadLinesFromFile("Day15.txt");
        Assert.NotEmpty(lines);
        Assert.Equal(71, lines.Count());

        var wm = new WarehouseRobotTracker(lines);
        Assert.NotNull(wm);
        wm.ShowWarehouse();
        wm.DoCommands();
        long actual = wm.GpsSum();
        wm.ShowWarehouse();
        Assert.Equal(1516281, actual);
    }
}
