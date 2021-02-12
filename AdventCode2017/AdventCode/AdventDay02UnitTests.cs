using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay02UnitTests
    {
        Day02SpreadSheetChecksum sut;
        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day02SpreadSheetChecksum();
        }

        [TestMethod]
        public void Day02_TestRunAdvent01()
        {
            string row = "5 1 9 5";
            int expected = 8;
            int actual = sut.RowCheckSum(row);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void Day02_TestRunAdvent02()
        {
            string row = "7 5 3";
            int expected = 4;
            int actual = sut.RowCheckSum(row);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day02_TestRunAdvent03()
        {
            string row = "2 4 6 8";
            int expected = 6;
            int actual = sut.RowCheckSum(row);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day02_TestRunAdvent04()
        {
            List<string> rows = new List<string>();
            rows.Add("2 4 6 8");
            int expected = 6;
            int actual = sut.CheckSum(rows);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day02_TestRunAdvent05()
        {
            List<string> rows = new List<string>();
            rows.Add("5 1 9 5");
            rows.Add("7 5 3");
            rows.Add("2 4 6 8");
            int expected = 18;
            int actual = sut.CheckSum(rows);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day02_TestRunAdvent06()
        {
            string path = @"advent02a.txt";
            int expected = 18;
            int actual = sut.CheckSumFile(path);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day02_TestRunAdvent07_SolutionA()
        {
            string path = @"advent02.txt";
            int expected = 45351;
            int actual = sut.CheckSumFile(path);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day02_TestRunAdvent08()
        {
            string path = @"advent02b.txt";
            int expected = 9;
            int actual = sut.CheckSumFileDiv(path);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day02_TestRunAdvent09_SolutionB()
        {
            string path = @"advent02.txt";
            int expected = 275;
            int actual = sut.CheckSumFileDiv(path);
            Assert.AreEqual(expected, actual);
        }
    }
}
