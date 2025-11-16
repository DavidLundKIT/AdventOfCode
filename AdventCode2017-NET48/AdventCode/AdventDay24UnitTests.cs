using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay24UnitTests
    {
        string pathdata = "Adventday24.txt";
        string pathtest = "Adventday24test.txt";

        Day24Bridge sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day24Bridge();
        }

        [TestMethod]
        public void Day24_TestRun01()
        {
            sut.ParseComponents(pathtest);
            Assert.AreEqual(8, sut.Components.Count);
            sut.CreateBridges();
            int actual = sut.StrongestBridge();
            Assert.AreEqual(31, actual);
            actual = sut.LongestStrongestBridge();
            Assert.AreEqual(19, actual);
        }

        [TestMethod]
        public void Day24_TestSolutionA()
        {
            sut.ParseComponents(pathdata);
            Assert.AreEqual(56, sut.Components.Count);
            sut.CreateBridges();
            int actual = sut.StrongestBridge();
            Assert.AreEqual(1511, actual);
            actual = sut.LongestStrongestBridge();
            Assert.AreEqual(1471, actual);
        }
    }
}
