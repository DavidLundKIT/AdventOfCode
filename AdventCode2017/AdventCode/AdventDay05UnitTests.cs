using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay05UnitTests
    {
        Day05JumpMaze sut;
        string path = "AdventDay05a.txt";

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day05JumpMaze();
            // (0) 3  0  1  -3 for tests
            sut.Jumps.AddRange(new int[] { 0, 3, 0, 1, -3 });
        }

        [TestMethod]
        public void Day05_TestRunAdvent01()
        {
            List<int> jumps = sut.ReadJumpStack(path);
            int expected = 1044;
            Assert.IsNotNull(jumps);
            Assert.AreEqual(expected, jumps.Count);
        }

        [TestMethod]
        public void Day05_TestRunAdvent02()
        {
            Assert.IsNotNull(sut.Jumps);
            Assert.AreEqual(0, sut.Jumps[0]);
            Assert.AreEqual(3, sut.Jumps[1]);
            Assert.AreEqual(0, sut.Jumps[2]);
            Assert.AreEqual(1, sut.Jumps[3]);
            Assert.AreEqual(-3, sut.Jumps[4]);
        }

        [TestMethod]
        public void Day05_TestRunAdvent03()
        {
            // (0) 3  0  1  -3
            int actual = sut.StepsUntilExits();
            Assert.AreEqual(5, actual);
            //2  5  0  1  -2
        }

        [TestMethod]
        public void Day05_TestRunAdvent04_SolutionA()
        {
            List<int> jumps = sut.ReadJumpStack(path);
            int expected = 1044;
            Assert.IsNotNull(jumps);
            Assert.AreEqual(expected, jumps.Count);
            sut.Jumps = jumps;
            int actual = sut.StepsUntilExits();
            Assert.AreEqual(342669, actual);
        }

        [TestMethod]
        public void Day05_TestRun05()
        {
            // (0) 3  0  1  -3
            int actual = sut.StepsUntilExitsB();
            Assert.AreEqual(10, actual);
            // 2 3 2 3 -1
        }

        [TestMethod]
        public void Day05_TestRunAdvent06_SolutionB()
        {
            List<int> jumps = sut.ReadJumpStack(path);
            int expected = 1044;
            Assert.IsNotNull(jumps);
            Assert.AreEqual(expected, jumps.Count);
            sut.Jumps = jumps;
            int actual = sut.StepsUntilExitsB();
            Assert.AreEqual(25136209, actual);
        }
    }
}
