using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay08UnitTests
    {
        string pathdata = "Adventday08.txt";
        string pathtest = "Adventday08test.txt";

        Day08Registers sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day08Registers();
        }


        [TestMethod]
        public void DayO8_TestReads()
        {
            var rows = sut.ReadData(pathtest);
            Assert.IsNotNull(rows);
            Assert.AreEqual(4, rows.Length);

            int actual= 0;
            int highest = int.MinValue;
            foreach (var row in rows)
            {
                actual = sut.ParseCmd(row);
                if (highest < actual)
                {
                    highest = actual;
                }
            }
            int max = sut.MaxRegisterValue();
            Assert.AreEqual(1, max);
            Assert.AreEqual(10, highest);
        }

        [TestMethod]
        public void DayO8_TestSolutionA()
        {
            var rows = sut.ReadData(pathdata);
            Assert.IsNotNull(rows);
            Assert.AreEqual(1000, rows.Length);

            int actual = 0;
            int highest = int.MinValue;
            foreach (var row in rows)
            {
                actual = sut.ParseCmd(row);
                if (highest < actual)
                {
                    highest = actual;
                }
            }
            int max = sut.MaxRegisterValue();
            Assert.AreEqual(5966, max);
            Assert.AreEqual(6347, highest);
        }
    }
}
