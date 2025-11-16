using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay06UnitTests
    {
        private Day06MemoryRealloc sut;
        private List<int> testDataA;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day06MemoryRealloc();
            testDataA = new List<int>();
            testDataA.AddRange(new int[] { 0, 2, 7, 0 });
        }

        [TestMethod]
        public void Day06_TestRun01()
        {
            Assert.IsNotNull(sut.InputA);
            Assert.AreEqual(16, sut.InputA.Count);
            Assert.IsNotNull(testDataA);
            Assert.AreEqual(4, testDataA.Count);
        }

        [TestMethod]
        public void Day06_TestRun02()
        {
            int expected = 5;
            int actual = sut.ReallocMemory(testDataA);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day06_TestRun03()
        {
            Assert.AreEqual("0 2 7 0", testDataA.AsString());
            Assert.AreEqual(sut.input06A, sut.InputA.AsString());
        }

        [TestMethod]
        public void Day06_TestRun04()
        {
            int actual = sut.FindMax(testDataA);

            Assert.AreEqual(2, actual);
            Assert.AreEqual(7, testDataA[actual]);
        }

        [TestMethod]
        public void Day06_TestRun05()
        {
            var actual = sut.NextAllocState(testDataA);

            Assert.AreEqual(2, actual[0]);
            Assert.AreEqual(4, actual[1]);
            Assert.AreEqual(1, actual[2]);
            Assert.AreEqual(2, actual[3]);
        }

        [TestMethod]
        public void Day06_TestRun06_SolutionA()
        {
            int expected = 11137;
            int actual = sut.ReallocMemory(sut.InputA);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day06_TestRun07()
        {
            int expected = 4;
            int actual = sut.ReallocMemoryNext(testDataA);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day06_TestRun08_SolutionB()
        {
            int expected = 1037;
            int actual = sut.ReallocMemoryNext(sut.InputA);
            Assert.AreEqual(expected, actual);
        }
    }
}
