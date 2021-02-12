﻿using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay25UnitTests
    {
        [TestMethod]
        public void Day25_TestRun01()
        {
            Day25Turing sut = new Day25Turing();

            int value;
            for (int i = 0; i < 6; i++)
            {
                value = sut.TuringStep();
            }

            Assert.AreEqual(3, sut.CheckSum());
        }

        [TestMethod]
        public void Day25_TestSolutionA()
        {
            Day25TuringA sut = new Day25TuringA();

            int value;
            for (int i = 0; i < 12861455; i++)
            {
                value = sut.TuringStep();
            }

            Assert.AreEqual(3578, sut.CheckSum());
        }
    }
}
