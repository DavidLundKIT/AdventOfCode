using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay17UnitTests
    {
        Day17Spinlock sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day17Spinlock();
        }

        [TestMethod]
        public void Day17_TestRun01()
        {
            sut.Factor = 3;

            sut.Spin(1);
            Assert.AreEqual(0, sut.Buffer[0]);
            Assert.AreEqual(1, sut.Buffer[1]);

            sut.Spin(2);
            Assert.AreEqual(0, sut.Buffer[0]);
            Assert.AreEqual(2, sut.Buffer[1]);
            Assert.AreEqual(1, sut.Buffer[2]);

            sut.Spin(3);
            Assert.AreEqual(0, sut.Buffer[0]);
            Assert.AreEqual(2, sut.Buffer[1]);
            Assert.AreEqual(3, sut.Buffer[2]);
            Assert.AreEqual(1, sut.Buffer[3]);
        }

        [TestMethod]
        public void Day17_TestRun02()
        {
            sut.Factor = 3;

            for (int i = 1; i < 2018; i++)
            {
                sut.Spin(i);
            }
            Assert.AreEqual(638, sut.Buffer[sut.Position + 1]);
        }

        [TestMethod]
        public void Day17_SolutionA()
        {
            sut.Factor = 376;
            for (int i = 1; i < 2018; i++)
            {
                sut.Spin(i);
            }
            Assert.AreEqual(777, sut.Buffer[sut.Position + 1]);
        }

        [TestMethod]
        public void Day17_SolutionB()
        {
            sut.Factor = 376;
            for (int i = 1; i < 50000000; i++)
            {
                sut.Spin2(i);
            }
            Assert.AreEqual(39289581, sut.BufPos1);
        }
    }
}
