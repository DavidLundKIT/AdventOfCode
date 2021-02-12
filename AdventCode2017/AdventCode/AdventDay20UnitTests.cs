using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode
{

    [TestClass]
    [Ignore]
    public class AdventDay20UnitTests
    {
        string pathdata = "Adventday20.txt";
        Day20ParticleSwarm sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day20ParticleSwarm();
        }

        [TestMethod]
        public void Day20_TestSolutionA()
        {
            sut.ParseData(pathdata);
            Assert.AreEqual(1000, sut.Particles.Count);

            Particle actual = sut.FindSlowest();
            Assert.IsNotNull(actual);
            Assert.AreEqual(457, actual.Index);
        }

        [TestMethod]
        public void Day20_SolutionB()
        {
            sut.ParseData(pathdata);
            Assert.AreEqual(1000, sut.Particles.Count);
            for (int i = 0; i < 50000; i++)
            {
                sut.ResolveCollisions();
                sut.MoveParticles();
            }
            Assert.AreEqual(448, sut.Particles.Count);
        }
    }
}
