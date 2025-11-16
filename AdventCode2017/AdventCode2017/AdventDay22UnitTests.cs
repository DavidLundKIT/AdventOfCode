using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay22UnitTests
{
    string pathdata = "Adventday22.txt";
    string pathtest = "Adventday22test.txt";

    public Day22SporificaVirus sut { get; set; }

    public AdventDay22UnitTests()
    {
        sut = new Day22SporificaVirus();
    }

    [Fact]
    public void Day22_TestRun01()
    {
        VirusState infected;
        sut.ParseData(pathtest);
        Assert.NotNull(sut.Blocks);
        Assert.Equal(9, sut.Blocks.Count);
        infected = sut.DoBurst();
        Assert.Equal(VirusState.Clean, infected);
        for (int i = 1; i < 7; i++)
        {
            infected = sut.DoBurst();
        }
        Assert.Equal(5, sut.InfectionBursts);
    }

    [Fact]
    public void Day22_TestRun02()
    {
        sut.ParseData(pathtest);
        VirusState infected;
        for (int i = 0; i < 70; i++)
        {
            infected = sut.DoBurst();
        }
        Assert.Equal(41, sut.InfectionBursts);
    }

    [Fact]
    public void Day22_TestRun03()
    {
        sut.ParseData(pathtest);
        VirusState infected;
        for (int i = 0; i < 10000; i++)
        {
            infected = sut.DoBurst();
        }
        Assert.Equal(5587, sut.InfectionBursts);
    }

    [Fact]
    public void Day22_TestSolutionA()
    {
        sut.ParseData(pathdata);
        Assert.NotNull(sut.Blocks);
        Assert.Equal(625, sut.Blocks.Count);
        VirusState infected;
        for (int i = 0; i < 10000; i++)
        {
            infected = sut.DoBurst();
        }
        Assert.Equal(5404, sut.InfectionBursts);
    }

    [Fact]
    public void Day22_TestRun04()
    {
        sut.ParseData(pathtest);
        VirusState infected;
        for (int i = 0; i < 100; i++)
        {
            infected = sut.DoBurst2();
        }
        Assert.Equal(26, sut.InfectionBursts);
    }

    [Fact]
    public void Day22_TestRun05()
    {
        sut.ParseData(pathtest);
        VirusState infected;
        for (int i = 0; i < 10000000; i++)
        {
            infected = sut.DoBurst2();
        }
        Assert.Equal(2511944, sut.InfectionBursts);
    }

    [Fact]
    public void Day22_TestSolutionB()
    {
        sut.ParseData(pathdata);
        VirusState infected;
        for (int i = 0; i < 10000000; i++)
        {
            infected = sut.DoBurst2();
        }
        Assert.Equal(2511672, sut.InfectionBursts);
    }
}
