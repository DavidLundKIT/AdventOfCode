using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventCodeLib;
using System.Collections.Generic;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay11UnitTests
    {
        private Day11HexTiles sut;

        private string pathdata = "adventday11.txt";

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day11HexTiles();
        }

        [TestMethod]
        public void Day11_TestRun01()
        {
            string data = sut.ReadInputData(pathdata);
            Assert.IsFalse(string.IsNullOrEmpty(data));
            Assert.AreEqual(21607, data.Length);
            var cmds = sut.GetCommands(data);
            Assert.IsNotNull(cmds);
        }

        [TestMethod]
        public void Day11_TestRun02()
        {
            string data = "ne,ne,ne";
            var cmds = sut.GetCommands(data);
            Assert.AreEqual(3, cmds.Count);
            int steps = sut.FindSteps(cmds);
            Assert.AreEqual(3, steps);
        }

        [TestMethod]
        public void Day11_TestRun03()
        {
            string data = "ne,ne,sw,sw";
            var cmds = sut.GetCommands(data);
            Assert.AreEqual(4, cmds.Count);
            int steps = sut.FindSteps(cmds);
            Assert.AreEqual(0, steps);
        }

        [TestMethod]
        public void Day11_TestRun04()
        {
            string data = "ne,ne,s,s";
            var cmds = sut.GetCommands(data);
            Assert.AreEqual(4, cmds.Count);
            int steps = sut.FindSteps(cmds);
            Assert.AreEqual(2, steps);
        }

        [TestMethod]
        public void Day11_TestRun05()
        {
            string data = "se,sw,se,sw,sw";
            var cmds = sut.GetCommands(data);
            Assert.AreEqual(5, cmds.Count);
            int steps = sut.FindSteps(cmds);
            Assert.AreEqual(3, steps);
        }

        [TestMethod]
        public void Day11_TestRun_SolutionA()
        {
            string data = sut.ReadInputData(pathdata);
            Assert.IsFalse(string.IsNullOrEmpty(data));
            Assert.AreEqual(21607, data.Length);
            var cmds = sut.GetCommands(data);
            Assert.IsNotNull(cmds);
            int steps = sut.FindSteps(cmds);
            Assert.AreEqual(808, steps);
        }

        [TestMethod]
        public void Day11_TestRun_SolutionB()
        {
            string data = sut.ReadInputData(pathdata);
            Assert.IsFalse(string.IsNullOrEmpty(data));
            Assert.AreEqual(21607, data.Length);
            var cmds = sut.GetCommands(data);
            Assert.IsNotNull(cmds);
            int maxSteps = 0;

            List<string> stepsSoFar = new List<string>();
            foreach (var cmd in cmds)
            {
                stepsSoFar.Add(cmd);
                int steps = sut.FindSteps(stepsSoFar);
                maxSteps = Math.Max(steps, maxSteps);
            }
            Assert.AreEqual(1556, maxSteps);
        }
    }
}
