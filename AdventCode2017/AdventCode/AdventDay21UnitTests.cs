using AdventCodeLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventCode
{
    [TestClass]
    public class AdventDay21UnitTests
    {
        private readonly string pathdata = "Adventday21.txt";

        Day21FractalArt sut;

        [TestInitialize]
        public void TestSetup()
        {
            sut = new Day21FractalArt();
        }

        [TestMethod]
        public void Day21_TestRun01()
        {
            var lines = new string[]
            {
                "../.# => ##./#../...",
                ".#./..#/### => #..#/..../..../#..#"
            };

            Assert.AreEqual(2, lines.Length);

            sut.ParseData(lines);
            Assert.AreEqual(2, sut.Rules.Count);

            var key = sut.MakeKey(3, sut.ArtWork);

            sut.DumpMatrix(sut.ArtWork);
            Assert.AreEqual(".#./..#/###", key);
            var rotate = sut.RotateMatrix(sut.ArtWork);
            var rotateKey = sut.MakeKey(3, rotate);
            sut.DumpMatrix(rotate);
            Assert.AreEqual(".##/#.#/..#", rotateKey);
            var flipHor = sut.FlipHori(sut.ArtWork);
            var flipHorKey = sut.MakeKey(3, flipHor);
            sut.DumpMatrix(flipHor);
            Assert.AreEqual(".#./#../###", flipHorKey);
            var flipVert = sut.FlipVert(sut.ArtWork);
            var flipVertKey = sut.MakeKey(3, flipVert);
            sut.DumpMatrix(flipVert);
            Assert.AreEqual("###/..#/.#.", flipVertKey);

            Assert.AreEqual(5, sut.CountPixels(sut.ArtWork));
            sut.DoIteration();
            sut.DumpMatrix(sut.ArtWork);
            sut.DoIteration();
            sut.DumpMatrix(sut.ArtWork);
            Assert.AreEqual(12, sut.CountPixels(sut.ArtWork));
        }

        [TestMethod]
        public void Day21_Solution_PartA()
        {
            var lines = DataTools.ReadAllLines(pathdata);
            Assert.AreEqual(108, lines.Length);

            sut.ParseData(lines);
            Assert.AreEqual(108, sut.Rules.Count);
            sut.DumpMatrix(sut.ArtWork);
            for (int i = 0; i < 5; i++)
            {
                sut.DoIteration();
                sut.DumpMatrix(sut.ArtWork);
            }
            Assert.AreEqual(197, sut.CountPixels(sut.ArtWork));
        }

        [TestMethod]
        public void Day21_Solution_PartB()
        {
            var lines = DataTools.ReadAllLines(pathdata);
            Assert.AreEqual(108, lines.Length);

            sut.ParseData(lines);
            Assert.AreEqual(108, sut.Rules.Count);
            sut.DumpMatrix(sut.ArtWork);
            for (int i = 0; i < 18; i++)
            {
                sut.DoIteration();
                sut.DumpMatrix(sut.ArtWork);
            }
            Assert.AreEqual(3081737, sut.CountPixels(sut.ArtWork));
        }
    }
}
