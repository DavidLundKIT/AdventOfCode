using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventCodeLib;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay15UnitTests
    {
        Generator genA;
        Generator genB;
        long factorA = 16807;
        long factorB = 48271;

        [TestInitialize]
        public void TestSetup()
        {
            genA = new Generator(65, factorA);
            genB = new Generator(8921, factorB);
        }

        [TestMethod]
        public void Day15_TestRun01()
        {
            // --Gen.A--   --Gen.B--
            //   1092455    430625591
            Assert.AreEqual(1092455, genA.Generate());
            Assert.AreEqual(430625591, genB.Generate());
            Assert.IsFalse(Generator.Match(genA, genB));
            // 1181022009  1233683848
            Assert.AreEqual(1181022009, genA.Generate());
            Assert.AreEqual(1233683848, genB.Generate());
            Assert.IsFalse(Generator.Match(genA, genB));
            // 245556042   1431495498
            Assert.AreEqual(245556042, genA.Generate());
            Assert.AreEqual(1431495498, genB.Generate());
            Assert.IsTrue(Generator.Match(genA, genB));
            // 1744312007   137874439
            Assert.AreEqual(1744312007, genA.Generate());
            Assert.AreEqual(137874439, genB.Generate());
            Assert.IsFalse(Generator.Match(genA, genB));
            // 1352636452   285222916
            Assert.AreEqual(1352636452, genA.Generate());
            Assert.AreEqual(285222916, genB.Generate());
            Assert.IsFalse(Generator.Match(genA, genB));
        }

        [TestMethod]
        public void Day15_TestRun02()
        {
            long expected = 588;
            long actual = 0;
            int length = 40000000;

            for (int i = 0; i < length; i++)
            {
                genA.Generate();
                genB.Generate();
                if (Generator.Match(genA, genB))
                {
                    actual++;
                }
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day15_TestRun03()
        {
            genA.Check = 4;
            genB.Check = 8;
            // --Gen.A----Gen.B--
            // 1352636452  1233683848
            Assert.AreEqual(1352636452, genA.Generate2());
            Assert.AreEqual(1233683848, genB.Generate2());
            Assert.IsFalse(Generator.Match(genA, genB));
            // 1992081072   862516352
            Assert.AreEqual(1992081072, genA.Generate2());
            Assert.AreEqual(862516352, genB.Generate2());
            Assert.IsFalse(Generator.Match(genA, genB));
            //  530830436  1159784568
            Assert.AreEqual(530830436, genA.Generate2());
            Assert.AreEqual(1159784568, genB.Generate2());
            Assert.IsFalse(Generator.Match(genA, genB));
            // 1980017072  1616057672
            Assert.AreEqual(1980017072, genA.Generate2());
            Assert.AreEqual(1616057672, genB.Generate2());
            Assert.IsFalse(Generator.Match(genA, genB));
            //  740335192   412269392
            Assert.AreEqual(740335192, genA.Generate2());
            Assert.AreEqual(412269392, genB.Generate2());
            Assert.IsFalse(Generator.Match(genA, genB));
        }

        [TestMethod]
        public void Day15_TestRun04()
        {
            genA.Check = 4;
            genB.Check = 8;

            for (int i = 0; i < 1056; i++)
            {
                genA.Generate2();
                genB.Generate2();
            }
            Assert.IsTrue(Generator.Match(genA, genB));
        }

        [TestMethod]
        public void Day15_TestRun05()
        {
            long expected = 309;
            long actual = 0;
            int length = 5000000;
            genA.Check = 4;
            genB.Check = 8;

            for (int i = 0; i < length; i++)
            {
                genA.Generate2();
                genB.Generate2();
                if (Generator.Match(genA, genB))
                {
                    actual++;
                }
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day15_TestSolutionA()
        {
            genA = new Generator(703, factorA);
            genB = new Generator(516, factorB);
            long expected = 594;
            long actual = 0;
            int length = 40000000;

            for (int i = 0; i < length; i++)
            {
                genA.Generate();
                genB.Generate();
                if (Generator.Match(genA, genB))
                {
                    actual++;
                }
            }
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day15_TestSolutionB()
        {
            genA = new Generator(703, factorA);
            genB = new Generator(516, factorB);
            long expected = 328;
            long actual = 0;
            int length = 5000000;
            genA.Check = 4;
            genB.Check = 8;

            for (int i = 0; i < length; i++)
            {
                genA.Generate2();
                genB.Generate2();
                if (Generator.Match(genA, genB))
                {
                    actual++;
                }
            }
            Assert.AreEqual(expected, actual);
        }
    }
}
