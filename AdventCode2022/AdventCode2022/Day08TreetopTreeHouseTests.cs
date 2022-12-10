using AdventCode2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2022
{
    public class Day08TreetopTreeHouseTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var trees = Utils.ReadIntSquareFromFile("Day08.txt");
            int expected = 99;
            int actual = trees.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadTestDataFile_OK()
        {
            var trees = Utils.ReadIntSquareFromFile("Day08test.txt");
            int expected = 5;
            int actual = trees.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindVisibleTrees_Test_OK()
        {
            var trees = Utils.ReadIntSquareFromFile("Day08test.txt");
            int expected = 21;
            var sut = new TreeSpotter(trees);
            int actual = sut.FindVisibleTrees();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void FindVisibleTrees_Part1_OK()
        {
            var trees = Utils.ReadIntSquareFromFile("Day08.txt");
            int expected = 1543;
            var sut = new TreeSpotter(trees);
            int actual = sut.FindVisibleTrees();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BestViewTreeScore_Test_OK()
        {
            var trees = Utils.ReadIntSquareFromFile("Day08test.txt");
            var sut = new TreeSpotter(trees);

            int actual = sut.BestViewScore(2, 1);
            Assert.Equal(4, actual);

            actual = sut.BestViewScore(2, 3);
            Assert.Equal(8, actual);
        }

        [Fact]
        public void FindBestViewTreeScore_Test_OK()
        {
            var trees = Utils.ReadIntSquareFromFile("Day08test.txt");
            var sut = new TreeSpotter(trees);

            int actual = sut.FindBestViewScore();
            Assert.Equal(8, actual);
        }

        [Fact]
        public void FindBestViewTreeScore_Part2_OK()
        {
            var trees = Utils.ReadIntSquareFromFile("Day08.txt");
            var sut = new TreeSpotter(trees);

            int actual = sut.FindBestViewScore();
            Assert.Equal(595080, actual);
        }
    }
}
