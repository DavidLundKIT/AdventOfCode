using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay08UnitTests
{
    string pathdata = "Adventday08.txt";
    string pathtest = "Adventday08test.txt";

    public Day08Registers sut { get; set; }

    public AdventDay08UnitTests()
    {
        sut = new Day08Registers();
    }


    [Fact]
    public void DayO8_TestReads()
    {
        var rows = sut.ReadData(pathtest);
        Assert.NotNull(rows);
        Assert.Equal(4, rows.Length);

        int actual= 0;
        int highest = int.MinValue;
        foreach (var row in rows)
        {
            actual = sut.ParseCmd(row);
            if (highest < actual)
            {
                highest = actual;
            }
        }
        int max = sut.MaxRegisterValue();
        Assert.Equal(1, max);
        Assert.Equal(10, highest);
    }

    [Fact]
    public void DayO8_TestSolutionA()
    {
        var rows = sut.ReadData(pathdata);
        Assert.NotNull(rows);
        Assert.Equal(1000, rows.Length);

        int actual = 0;
        int highest = int.MinValue;
        foreach (var row in rows)
        {
            actual = sut.ParseCmd(row);
            if (highest < actual)
            {
                highest = actual;
            }
        }
        int max = sut.MaxRegisterValue();
        Assert.Equal(5966, max);
        Assert.Equal(6347, highest);
    }
}
