using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay16UnitTests
    {
        string pathdata = "Adventday16.txt";

        Day16Dancing sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day16Dancing();
        }

        [TestMethod]
        public void Day16_TestRun01()
        {
            string state0 = "abcde";
            var chars = sut.Spin(state0.ToCharArray(), 5, 3);
            string state1 = string.Join(string.Empty, chars);
            Assert.AreEqual("cdeab", state1);
        }

        [TestMethod]
        public void Day16_TestRun02()
        {
            string state0 = "abcde";

            var chars = sut.Spin(state0.ToCharArray(), 5, "s3");
            string state1 = string.Join(string.Empty, chars);
            Assert.AreEqual("cdeab", state1);
        }

        [TestMethod]
        public void Day16_TestRun03()
        {
            string state0 = "abcde";
            var chars = sut.Exchange(state0.ToCharArray(), 3, 4);
            string state1 = string.Join(string.Empty, chars);
            Assert.AreEqual("abced", state1);
        }

        [TestMethod]
        public void Day16_TestRun04()
        {
            string state0 = "abcde";
            var chars = sut.Exchange(state0.ToCharArray(), "x3/4");
            string state1 = string.Join(string.Empty, chars);
            Assert.AreEqual("abced", state1);
        }

        [TestMethod]
        public void Day16_TestRun05()
        {
            string state0 = "abcde";
            var chars = sut.Partner(state0.ToCharArray(), 5, "pb/d");
            string state1 = string.Join(string.Empty, chars);
            Assert.AreEqual("adcbe", state1);
        }

        [TestMethod]
        public void Day16_TestRun06()
        {
            string state0 = "abcde";
            List<string> cmds = new List<string>();
            cmds.Add("s1");
            cmds.Add("x3/4");
            cmds.Add("pe/b");

            var chars = state0.ToCharArray();

            foreach (var cmd in cmds)
            {
                chars = sut.ProcessCmd(chars, 5, cmd);
            }
            string state1 = string.Join(string.Empty, chars);

            Assert.AreEqual("baedc", state1);
        }

        [TestMethod]
        public void Day16_SolutionA()
        {
            string state0 = "abcdefghijklmnop";
            var rows = DataTools.ReadAllLines(pathdata);
            var cmds0 = rows[0].Split(new char[] { ',' });

            List<Command> cmds = new List<Command>();
            foreach (var cmd0 in cmds0)
            {
                cmds.Add(Command.CreateCmd(cmd0));
            }
            var chars = state0.ToCharArray();

            foreach (var cmd in cmds)
            {
                chars = sut.ProcessCmd(chars, 16, cmd);
            }
            string state1 = string.Join(string.Empty, chars);
            Assert.AreEqual("jkmflcgpdbonihea", state1);
        }

        [TestMethod]
        public void Day16_SolutionB()
        {
            string state0 = "abcdefghijklmnop";
            var rows = DataTools.ReadAllLines(pathdata);
            var cmds0 = rows[0].Split(new char[] { ',' });

            List<Command> cmds = new List<Command>();
            foreach (var cmd0 in cmds0)
            {
                cmds.Add(Command.CreateCmd(cmd0));
            }
            var chars = state0.ToCharArray();

            for (int i = 0; i < 10000; i++)
            {
                foreach (var cmd in cmds)
                {
                    chars = sut.ProcessCmd(chars, 16, cmd);
                }
            }
            string state1 = string.Join(string.Empty, chars);
            Assert.AreEqual("ajcdefghpkblmion", state1);
        }

        [TestMethod]
        public void Day16_CheckTransform()
        {
            string state0 = "abcdefghijklmnop";
            var rows = DataTools.ReadAllLines(pathdata);
            var cmds0 = rows[0].Split(new char[] { ',' });

            List<Command> cmds = new List<Command>();
            foreach (var cmd0 in cmds0)
            {
                cmds.Add(Command.CreateCmd(cmd0));
            }
            var chars0 = state0.ToCharArray();
            var chars1 = state0.ToCharArray();
            foreach (var cmd in cmds)
            {
                chars1 = sut.ProcessCmd(chars1, 16, cmd);
            }
            string state1 = string.Join(string.Empty, chars1);
            Assert.AreEqual("jkmflcgpdbonihea", state1);

            char[] charsn = new char[16];
            chars0.CopyTo(charsn, 0);

            charsn = sut.TransformX(chars0, chars1, charsn, 16);
            state1 = string.Join(string.Empty, charsn);
            Assert.AreEqual("jkmflcgpdbonihea", state1);

        }

        [TestMethod]
        public void Day16_SolutionD()
        {
            string state0 = "abcdefghijklmnop";

            Dictionary<string, string> transforms = new Dictionary<string, string>();

            var rows = DataTools.ReadAllLines(pathdata);
            var cmds0 = rows[0].Split(new char[] { ',' });

            List<Command> cmds = new List<Command>();
            foreach (var cmd0 in cmds0)
            {
                cmds.Add(Command.CreateCmd(cmd0));
            }

            var chars = state0.ToCharArray();
            string key;
            string stateEnd;
            for (int i = 0; i < 10000; i++)
            {
                key = string.Join(string.Empty, chars);
                if (transforms.ContainsKey(key))
                {
                    chars = transforms[key].ToCharArray();
                }
                else
                {
                    foreach (var cmd in cmds)
                    {
                        chars = sut.ProcessCmd(chars, 16, cmd);
                    }
                    stateEnd = string.Join(string.Empty, chars);
                    transforms.Add(key, stateEnd);
                }
            }
            string state1 = string.Join(string.Empty, chars);
            Assert.AreEqual("ajcdefghpkblmion", state1);
        }

        [TestMethod]
        public void Day16_SolutionD_Full()
        {
            string state0 = "abcdefghijklmnop";

            Dictionary<string, string> transforms = new Dictionary<string, string>();

            var rows = DataTools.ReadAllLines(pathdata);
            var cmds0 = rows[0].Split(new char[] { ',' });

            List<Command> cmds = new List<Command>();
            foreach (var cmd0 in cmds0)
            {
                cmds.Add(Command.CreateCmd(cmd0));
            }

            var chars = state0.ToCharArray();
            string key;
            string stateEnd;
            for (int i = 0; i < 1000000000; i++)
            {
                key = string.Join(string.Empty, chars);
                if (transforms.ContainsKey(key))
                {
                    chars = transforms[key].ToCharArray();
                }
                else
                {
                    foreach (var cmd in cmds)
                    {
                        chars = sut.ProcessCmd(chars, 16, cmd);
                    }
                    stateEnd = string.Join(string.Empty, chars);
                    transforms.Add(key, stateEnd);
                }
            }
            string state1 = string.Join(string.Empty, chars);
            Assert.AreEqual("ajcdefghpkblmion", state1);
        }
    }
}
