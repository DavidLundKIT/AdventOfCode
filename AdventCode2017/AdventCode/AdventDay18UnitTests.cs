﻿using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay18UnitTests
    {
        private readonly string pathdata = "Adventday18.txt";
        private readonly string pathtest = "Adventday18test.txt";
        private readonly string pathtestB = "Adventday18testB.txt";

        Day18Duet sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day18Duet();
        }

        [TestMethod]
        public void Day18_TestRun01()
        {
            var rows = DataTools.ReadAllLines(pathtest);
            sut.ParseDuet(rows);
            Assert.AreEqual(10, sut.Instructions.Count);
            Assert.AreEqual(1, sut.Registers.Count);
            sut.PlayDuet();
            Assert.AreEqual(4, sut.Recovered);
        }

        [TestMethod]
        public void Day18_SolutionA()
        {
            var rows = DataTools.ReadAllLines(pathdata);
            sut.ParseDuet(rows);
            Assert.AreEqual(41, sut.Instructions.Count);
            Assert.AreEqual(5, sut.Registers.Count);
            sut.PlayDuet();
            Assert.AreEqual(1187, sut.Recovered);
        }

        [TestMethod]
        public void Day18_TestRun02()
        {
            var sut0 = new Day18DuetB();
            var sut1 = new Day18DuetB();
            sut1.SendQueue = sut0.RecieveQueue;
            sut0.SendQueue = sut1.RecieveQueue;
            var rows = DataTools.ReadAllLines(pathtestB);
            sut0.ParseDuet(rows);
            sut0.Registers["p"] = 0;
            sut1.ParseDuet(rows);
            sut1.Registers["p"] = 1;

            long step0 = 0;
            long step1 = 0;

            do
            {
                step0 = sut0.PlayDuetStep(step0);
                step1 = sut1.PlayDuetStep(step1);
                if (sut0.Blocked && sut1.Blocked)
                {
                    break;
                }
            } while ((step0 >= 0 && step0 < sut0.Instructions.Count)
                    || (step1 >= 0 && step1 < sut1.Instructions.Count));
            Assert.AreEqual(3, sut1.Sends);
        }

        [TestMethod]
        public void Day18_SolutionB()
        {
            var sut0 = new Day18DuetB();
            var sut1 = new Day18DuetB();
            sut1.SendQueue = sut0.RecieveQueue;
            sut0.SendQueue = sut1.RecieveQueue;
            var rows = DataTools.ReadAllLines(pathdata);
            sut0.ParseDuet(rows);
            sut0.Registers["p"] = 0;
            sut1.ParseDuet(rows);
            sut1.Registers["p"] = 1;

            long step0 = 0;
            long step1 = 0;

            do
            {
                step1 = sut1.PlayDuetStep(step1);
                step0 = sut0.PlayDuetStep(step0);
                if(sut0.Blocked && sut1.Blocked)
                {
                    break;
                }
            } while ((step0 >= 0 && step0 < sut0.Instructions.Count)
                    && (step1 >= 0 && step1 < sut1.Instructions.Count));
            Assert.AreEqual(5969, sut1.Sends);
        }
    }
}
