using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay07UnitTests
    {
        string pathdata = "Advent07.txt";
        string pathtest = "Advent07test.txt";

        Day07RecursiveCircus sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day07RecursiveCircus();
        }
        
        [TestMethod]
        public void Day07_TestRun01()
        {
            List<pgm> result = sut.ReadData(pathtest);
            Assert.IsNotNull(result);
            Assert.AreEqual(13, result.Count);

            var root = sut.FindRoot(result);
            Assert.IsNotNull(root);
            Assert.AreEqual("tknk", root.Name);

            int actual = sut.WeightSum(root);
            Assert.AreEqual(778, actual);
        }

        [TestMethod]
        public void Day07_TestRun02_SolutionA()
        {
            List<pgm> result = sut.ReadData(pathdata);
            Assert.IsNotNull(result);
            Assert.AreEqual(1452, result.Count);

            var root = sut.FindRoot(result);
            Assert.IsNotNull(root);
            Assert.AreEqual("veboyvy", root.Name);

            int actual = sut.WeightSum(root);
            Assert.AreEqual(377179, actual);
        }
    }
}
