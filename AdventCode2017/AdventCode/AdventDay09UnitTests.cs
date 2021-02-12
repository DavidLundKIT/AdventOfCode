using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay09UnitTests
    {
        string pathdata = "Adventday09.txt";
        private Day09GroupGarbage sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day09GroupGarbage();
        }

        [TestMethod]
        public void Day09_TestRun01()
        {
            string s = "{}";
            int score = 0;
            int junkChars = 0;
            int groups = sut.GroupCount(s, out score, out junkChars);
            Assert.AreEqual(1, groups);
            Assert.AreEqual(1, score);

            s = "{{{}}}";
            groups = sut.GroupCount(s, out score, out junkChars);
            Assert.AreEqual(3, groups);
            Assert.AreEqual(6, score);

            s = "{{},{}}";
            groups = sut.GroupCount(s, out score, out junkChars);
            Assert.AreEqual(3, groups);
            Assert.AreEqual(5, score);

            s = "{{},{}}";
            groups = sut.GroupCount(s, out score, out junkChars);
            Assert.AreEqual(3, groups);
            Assert.AreEqual(5, score);

            s = "{{{},{},{{}}}}";
            groups = sut.GroupCount(s, out score, out junkChars);
            Assert.AreEqual(6, groups);
            Assert.AreEqual(16, score);

            s = "{<{},{},{{}}>}";
            groups = sut.GroupCount(s, out score, out junkChars);
            Assert.AreEqual(1, groups);
            Assert.AreEqual(1, score);

            s = "{<a>,<a>,<a>,<a>}";
            groups = sut.GroupCount(s, out score, out junkChars);
            Assert.AreEqual(1, groups);
            Assert.AreEqual(1, score);

            s = "{{<a>},{<a>},{<a>},{<a>}}";
            groups = sut.GroupCount(s, out score, out junkChars);
            Assert.AreEqual(5, groups);
            Assert.AreEqual(9, score);

            s = "{{<!>},{<!>},{<!>},{<a>}}";
            groups = sut.GroupCount(s, out score, out junkChars);
            Assert.AreEqual(2, groups);
            Assert.AreEqual(3, score);

            s = "{{{},{},{{}}}}";
            groups = sut.GroupCount(s, out score, out junkChars);
            Assert.AreEqual(16, score);

            s = "{{<ab>},{<ab>},{<ab>},{<ab>}}";
            groups = sut.GroupCount(s, out score, out junkChars);
            Assert.AreEqual(9, score);

            s = "{{<!!>},{<!!>},{<!!>},{<!!>}}";
            groups = sut.GroupCount(s, out score, out junkChars);
            Assert.AreEqual(9, score);
        }

        [TestMethod]
        public void Day09_TestJunkCount()
        {
            string s = "<>";
            int score;
            int junk;
            int groups = sut.GroupCount(s, out score, out junk);
            Assert.AreEqual(0, junk);

            s = "<random characters>";
            groups = sut.GroupCount(s, out score, out junk);
            Assert.AreEqual(17, junk);

            s = "<{oi!a,<{i<a>";
            groups = sut.GroupCount(s, out score, out junk);
            Assert.AreEqual(9, junk);
        }

        [TestMethod]
        public void Day09_TestRun_SolutionA()
        {
            string data = sut.ReadData(pathdata);
            Assert.IsFalse(string.IsNullOrWhiteSpace(data));
            Assert.AreEqual(22329, data.Length);
            int score = 0;
            int junkChars = 0;
            int groups = sut.GroupCount(data, out score, out junkChars);
            Assert.AreEqual(1889, groups);
            Assert.AreEqual(16869, score);
        }
    }
}
