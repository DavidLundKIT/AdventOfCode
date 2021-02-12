using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventCodeLib;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay22UnitTests
    {
        string pathdata = "Adventday22.txt";
        string pathtest = "Adventday22test.txt";

        Day22SporificaVirus sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day22SporificaVirus();
        }

        [TestMethod]
        public void Day22_TestRun01()
        {
            VirusState infected;
            sut.ParseData(pathtest);
            Assert.IsNotNull(sut.Blocks);
            Assert.AreEqual(9, sut.Blocks.Count);
            infected = sut.DoBurst();
            Assert.AreEqual(VirusState.Clean, infected);
            for (int i = 1; i < 7; i++)
            {
                infected = sut.DoBurst();
            }
            Assert.AreEqual(5, sut.InfectionBursts);
        }

        [TestMethod]
        public void Day22_TestRun02()
        {
            sut.ParseData(pathtest);
            VirusState infected;
            for (int i = 0; i < 70; i++)
            {
                infected = sut.DoBurst();
            }
            Assert.AreEqual(41, sut.InfectionBursts);
        }

        [TestMethod]
        public void Day22_TestRun03()
        {
            sut.ParseData(pathtest);
            VirusState infected;
            for (int i = 0; i < 10000; i++)
            {
                infected = sut.DoBurst();
            }
            Assert.AreEqual(5587, sut.InfectionBursts);
        }

        [TestMethod]
        public void Day22_TestSolutionA()
        {
            sut.ParseData(pathdata);
            Assert.IsNotNull(sut.Blocks);
            Assert.AreEqual(625, sut.Blocks.Count);
            VirusState infected;
            for (int i = 0; i < 10000; i++)
            {
                infected = sut.DoBurst();
            }
            Assert.AreEqual(5404, sut.InfectionBursts);
        }

        [TestMethod]
        public void Day22_TestRun04()
        {
            sut.ParseData(pathtest);
            VirusState infected;
            for (int i = 0; i < 100; i++)
            {
                infected = sut.DoBurst2();
            }
            Assert.AreEqual(26, sut.InfectionBursts);
        }

        [TestMethod]
        public void Day22_TestRun05()
        {
            sut.ParseData(pathtest);
            VirusState infected;
            for (int i = 0; i < 10000000; i++)
            {
                infected = sut.DoBurst2();
            }
            Assert.AreEqual(2511944, sut.InfectionBursts);
        }

        [TestMethod]
        public void Day22_TestSolutionB()
        {
            sut.ParseData(pathdata);
            VirusState infected;
            for (int i = 0; i < 10000000; i++)
            {
                infected = sut.DoBurst2();
            }
            Assert.AreEqual(2511672, sut.InfectionBursts);
        }
    }
}
