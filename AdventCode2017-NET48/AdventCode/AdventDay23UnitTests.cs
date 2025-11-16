using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay23UnitTests
    {
        private readonly string pathdata = "Adventday23.txt";

        Day23Coprocessor sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day23Coprocessor();
        }

        [TestMethod]
        public void Day23_Solution_PartA()
        {
            sut.ParseProgram(pathdata);
            Assert.IsNotNull(sut.Instructions);
            Assert.AreEqual(32, sut.Instructions.Count);

            sut.PlayProgram();

            Assert.AreEqual(6724, sut.MulCount);
            Assert.AreEqual(1, sut.Registers["h"]);

            var sut2 = new CoprocessorB
            {
                B = 84,
                C = 84
            };
            sut2.PlayProgram();
            Assert.AreEqual(1, sut2.H);
            Assert.AreEqual(84, sut2.B);
            Assert.AreEqual(84, sut2.C);
        }

        [TestMethod]
        public void Day23_TestRun02()
        {
            var sut2 = new CoprocessorB
            {
                B = 108400,
                C = 125400
            };
            sut2.PlayProgram();
            Assert.AreEqual(903, sut2.H);
            Assert.AreEqual(125400, sut2.B);
            Assert.AreEqual(125400, sut2.C);
        }
    }
}
