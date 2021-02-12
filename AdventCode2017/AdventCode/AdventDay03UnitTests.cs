﻿using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay03UnitTests
    {
        Day03Memory sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day03Memory();
        }

        [TestMethod]
        public void Day03_TestRunAdvent01()
        {
            int expected = 1;
            int cell = 1;
            int actual = sut.SquareHoldingInputCell(cell);
            Assert.AreEqual(expected, actual);

            expected = 5;
            cell = 12;
            actual = sut.SquareHoldingInputCell(cell);
            Assert.AreEqual(expected, actual);

            expected = 5;
            cell = 23;
            actual = sut.SquareHoldingInputCell(cell);
            Assert.AreEqual(expected, actual);

            expected = 33;
            cell = 1024;
            actual = sut.SquareHoldingInputCell(cell);
            Assert.AreEqual(expected, actual);

            expected = 539;
            cell = 289326;
            actual = sut.SquareHoldingInputCell(cell);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day03_TestRunAdvent02()
        {
            int expected = 0;
            int cell = 1;
            int actual = sut.StepsIntoCenter(cell);
            Assert.AreEqual(expected, actual);

            expected = 2;
            cell = 12;
            actual = sut.StepsIntoCenter(cell);
            Assert.AreEqual(expected, actual);

            expected = 2;
            cell = 23;
            actual = sut.StepsIntoCenter(cell);
            Assert.AreEqual(expected, actual);

            expected = 16;
            cell = 1024;
            actual = sut.StepsIntoCenter(cell);
            Assert.AreEqual(expected, actual);

            expected = 269;
            cell = 289326;
            actual = sut.StepsIntoCenter(cell);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day03_TestRunAdvent03()
        {
            int expected = 0;
            int cell = 1;
            int actual = sut.ManhattenDistance(cell);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day03_TestRunAdvent04()
        {
            int expected = 3;
            int cell = 12;
            int actual = sut.ManhattenDistance(cell);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day03_TestRunAdvent05()
        {
            int expected = 2;
            int cell = 23;
            int actual = sut.ManhattenDistance(cell);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day03_TestRunAdvent05b()
        {
            int expected = 3;
            int cell = 28;
            int actual = sut.ManhattenDistance(cell);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day03_TestRunAdvent05c()
        {
            int expected = 5;
            int cell = 26;
            int actual = sut.ManhattenDistance(cell);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day03_TestRunAdvent06()
        {
            int expected = 31;
            int cell = 1024;
            int actual = sut.ManhattenDistance(cell);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day03_TestRunAdvent06b()
        {
            int expected = 31;
            int cell = 962;
            int actual = sut.ManhattenDistance(cell);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day03_TestRunAdvent07_SolutionA()
        {
            int expected = 419;
            int cell = 289326;
            int actual = sut.ManhattenDistance(cell);
            Assert.AreEqual(expected, actual);
        }

        // 147  142  133  122   59
        // 304    5    4    2   57
        // 330   10    1    1   54
        // 351   11   23   25   26
        // 362  747  806--->   ...
        // my value 289326
        [TestMethod]
        public void Day03_TestRunAdvent08()
        {
            int size = 7;
            int index = 1;
            sut.CreateMatrix(size);
            var p = sut.GetPointAt(index);
            Assert.AreEqual(3, p.X);
            Assert.AreEqual(3, p.Y);

            index = 49;
            p = sut.GetPointAt(index);
            Assert.AreEqual(6, p.X);
            Assert.AreEqual(6, p.Y);

            index = 10;
            p = sut.GetPointAt(index);
            Assert.AreEqual(5, p.X);
            Assert.AreEqual(4, p.Y);

            index = 13;
            p = sut.GetPointAt(index);
            Assert.AreEqual(5, p.X);
            Assert.AreEqual(1, p.Y);

            index = 14;
            p = sut.GetPointAt(index);
            Assert.AreEqual(4, p.X);
            Assert.AreEqual(1, p.Y);

            index = 17;
            p = sut.GetPointAt(index);
            Assert.AreEqual(1, p.X);
            Assert.AreEqual(1, p.Y);

            index = 18;
            p = sut.GetPointAt(index);
            Assert.AreEqual(1, p.X);
            Assert.AreEqual(2, p.Y);

            index = 24;
            p = sut.GetPointAt(index);
            Assert.AreEqual(4, p.X);
            Assert.AreEqual(5, p.Y);

            index = 21;
            p = sut.GetPointAt(index);
            Assert.AreEqual(1, p.X);
            Assert.AreEqual(5, p.Y);
        }

        [TestMethod]
        public void Day03_TestRunAdvent09_SolutionB()
        {
            int expected = 1;
            int size = 21;
            sut.CreateMatrix(size);
            sut.FillTestValues();

            int index = 1;
            int actual = sut.GetMatrixValueAt(index);
            Assert.AreEqual(expected, actual);

            index = 23;
            actual = sut.GetMatrixValueAt(index);
            Assert.AreEqual(806, actual);

            // index 60, 295229
            int endValue = 289326;
            do
            {
                index++;
                actual = sut.GetMatrixValueAt(index);
            } while (actual < endValue);
            Assert.AreEqual(60, index);
            Assert.AreEqual(295229, actual);
        }
    }
}
