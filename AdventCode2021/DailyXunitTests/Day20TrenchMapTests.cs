using AdventCode2021;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyXunitTests
{
    public class Day20TrenchMapTests
    {
        [Fact]
        public void ImageEnhancer_ReadData_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day20test.txt");
            Assert.Equal(7, lines.Length);

            var sut = new ImageEnhancer(lines);
            Assert.Equal(512, sut.ImageAlgorithm.Length);
            Assert.Equal(10, sut.Image.Count);
            sut.DumpImage();
            sut.EnchanceImage(0);
            sut.DumpImage();
            sut.EnchanceImage(1);
            sut.DumpImage();
            Assert.Equal(35, sut.Image.Count);
        }

        [Theory]
        [InlineData(1, 2, 1, 2, true)]
        public void ImageEnhancer_TestPoints_OK(int x1, int y1, int x2, int y2, bool expected)
        {
            var p1 = new Point(x1, y1);
            var p2 = new Point(x2, y2);

            Assert.Equal(expected, p1.Equals(p2));
            Assert.Equal(expected, p2.Equals(p1));
            Assert.Equal(p1, p2);

            // TODO David I think point is good for using in Dictionaries now
            var dict = new Dictionary<Point, int>();
            dict.Add(p1, 5);
            Assert.True(dict.ContainsKey(p2));
        }

        [Fact]
        public void Day20_Puzzle1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day20.txt");
            Assert.Equal(102, lines.Length);
            var sut = new ImageEnhancer(lines);
            Assert.Equal(512, sut.ImageAlgorithm.Length);
            Assert.Equal(4974, sut.Image.Count);
            sut.DumpImage();
            sut.EnchanceImage(0);
            sut.DumpImage();
            sut.EnchanceImage(1);
            sut.DumpImage();
            Assert.Equal(1, sut.OriginalPixelCount());
        }



    }
}
