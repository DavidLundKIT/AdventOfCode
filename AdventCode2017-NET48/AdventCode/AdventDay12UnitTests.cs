using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventCodeLib;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay12UnitTests
    {
        string pathdata = "Adventday12.txt";
        string pathtest = "Adventday12test.txt";

        Day12DigitalPlumber sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day12DigitalPlumber();
        }

        [TestMethod]
        public void Day12_TestRun01()
        {
            sut.ParseFile(pathtest);
            Assert.IsNotNull(sut.AllProcs);
            Assert.AreEqual(7, sut.AllProcs.Count);
            sut.FindGroup("0");
            Assert.AreEqual(6, sut.Group.Count);
        }

        [TestMethod]
        public void Day12_TestRun02_SolutionA()
        {
            sut.ParseFile(pathdata);
            Assert.IsNotNull(sut.AllProcs);
            Assert.AreEqual(2000, sut.AllProcs.Count);
            sut.FindGroup("0");
            Assert.AreEqual(306, sut.Group.Count);
        }

        [TestMethod]
        public void Day12_TestRun03()
        {
            sut.ParseFile(pathtest);
            Assert.IsNotNull(sut.AllProcs);
            Assert.AreEqual(7, sut.AllProcs.Count);
            int actual = sut.FindAllGroups();
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void Day12_TestRun04_SolutionB()
        {
            sut.ParseFile(pathdata);
            Assert.IsNotNull(sut.AllProcs);
            Assert.AreEqual(2000, sut.AllProcs.Count);
            int actual = sut.FindAllGroups();
            Assert.AreEqual(200, actual);
        }
    }
}
