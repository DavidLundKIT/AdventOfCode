using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay10UnitTests
    {
        private int[] inputs = new int[] { 106, 118, 236, 1, 130, 0, 235, 254, 59, 205, 2, 87, 129, 25, 255, 118 };

        private int[] testInputs = new int[] { 3, 4, 1, 5 };

        private int[] addToEnd = new int[] { 17, 31, 73, 47, 23 };

        private string inputsData = "106,118,236,1,130,0,235,254,59,205,2,87,129,25,255,118";

        private string inputsTest = "3,4,1,5";

        private Day10HashKnot sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day10HashKnot();
        }

        [TestMethod]
        public void Day10_TestDataRunA()
        {
            sut.InitCircularList(5);

            foreach (int length in testInputs)
            {
                sut.KnotHash(length);

            }
            int actual = sut.CircularList[0] * sut.CircularList[1];
            Assert.AreEqual(12, actual);
        }

        [TestMethod]
        public void Day10_TestXor()
        {
            int expected = 64;
            int actual = 65 ^ 27 ^ 9 ^ 1 ^ 4 ^ 3 ^ 40 ^ 50 ^ 91 ^ 7 ^ 6 ^ 0 ^ 2 ^ 5 ^ 68 ^ 22;
            Assert.AreEqual(expected, actual);

            List<int> test = new List<int>();
            test.AddRange(new int[] { 65, 27, 9, 1, 4, 3, 40, 50, 91, 7, 6, 0, 2, 5, 68, 22 });
            sut.CircularList = test;
            actual = sut.Get16XorValue(0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Day10_TestSolutionA()
        {
            sut.InitCircularList(256);

            foreach (int length in inputs)
            {
                sut.KnotHash(length);
            }
            int actual = sut.CircularList[0] * sut.CircularList[1];
            Assert.AreEqual(6909, actual);
        }

        [TestMethod]
        public void Day10_TestSolutionB()
        {
            sut.InitCircularList(256);

            string it = "1,2,3";
            List<int> inputLens = new List<int>();
            var chars = inputsTest.ToCharArray();
            chars = it.ToCharArray();
            chars = inputsData.ToCharArray();
            foreach (char ch in chars)
            {
                inputLens.Add(ch);
            }
            inputLens.AddRange(addToEnd);

            for (int i = 0; i < 64; i++)
            {
                foreach (int length in inputLens)
                {
                    sut.KnotHash(length);
                }
            }

            List<int> denseHash = new List<int>();
            for (int i = 0; i < 256; i+=16)
            {
                denseHash.Add(sut.Get16XorValue(i));
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in denseHash)
            {
                string t = item.ToString("X");
                if (t.Length == 1)
                {
                    sb.Append("0");
                }
                sb.Append(t);
            }

            string actual = sb.ToString().ToLower();
            Assert.AreEqual("9d5f4561367d379cfbf04f8c471c0095", actual);
        }
    }
}
