using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay20UnitTests
{
    string pathdata = "Adventday20.txt";
    public Day20ParticleSwarm sut { get; set; }

    public AdventDay20UnitTests()
    {
        sut = new Day20ParticleSwarm();
    }

    [Fact]
    public void Day20_TestSolutionA()
    {
        sut.ParseData(pathdata);
        Assert.Equal(1000, sut.Particles.Count);

        Particle actual = sut.FindSlowest();
        Assert.NotNull(actual);
        Assert.Equal(457, actual.Index);
    }

    [Fact]
    public void Day20_SolutionB()
    {
        sut.ParseData(pathdata);
        Assert.Equal(1000, sut.Particles.Count);
        for (int i = 0; i < 50000; i++)
        {
            sut.ResolveCollisions();
            sut.MoveParticles();
        }
        Assert.Equal(448, sut.Particles.Count);
    }
}
