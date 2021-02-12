using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode
{
    [TestClass]
    [Ignore]
    public class AdventDay19UnitTests
    {
        string pathdata = "Adventday19.txt";
        string pathtest = "Adventday19test.txt";

        Day19TubeMaze sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day19TubeMaze();
        }

        [TestMethod]
        public void Day19_TestRun01()
        {
            var rows = DataTools.ReadAllLines(pathtest);

            sut.ParseMaze(rows);

            Assert.IsNotNull(sut.Maze);
            string expected = "ABCDEF";

            var actualPos = sut.FindStart();
            Assert.AreEqual(0, sut.Current.Y);
            Assert.AreEqual(5, sut.Current.X);
            Assert.AreEqual(Direction.Down, sut.Current.Direction);
            Assert.AreEqual(0, actualPos.Y);
            Assert.AreEqual(5, actualPos.X);
            Assert.AreEqual(Direction.Down, actualPos.Direction);
            string actual = sut.FindInMaze();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(38, sut.Steps);
        }

        [TestMethod]
        public void Day19_SoulutionA()
        {
            var rows = DataTools.ReadAllLines(pathdata);

            sut.ParseMaze(rows);

            Assert.IsNotNull(sut.Maze);
            string expected = "DWNBGECOMY";

            sut.FindStart();
            Assert.AreEqual(0, sut.Current.Y);
            Assert.AreEqual(55, sut.Current.X);
            Assert.AreEqual(Direction.Down, sut.Current.Direction);

            string actual = sut.FindInMaze();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(17228, sut.Steps);
        }
    }
}
