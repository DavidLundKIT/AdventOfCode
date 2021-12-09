using AdventCode2021;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyXunitTests
{
    public class Day08SevenSegmentSearchTests
    {
        [Fact]
        public void Test_ReadSegments_Ok()
        {
            var lines = Utils.ReadLinesFromFile("Day08Test.txt");
            Assert.Equal(10, lines.Length);

            var sut = new SevenSegmentDecoder(lines);
            int actual = sut.CountUniqueDigits();
            Assert.Equal(26, actual);
        }

        [Fact]
        public void Test_DecodeLine_Ok()
        {
            var line = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf";
            var disp = new Display(line);

            int actual = disp.Decode();
            Assert.Equal("ab", disp.Digits[1]);
            Assert.Equal("eafb", disp.Digits[4]);
            Assert.Equal("dab", disp.Digits[7]);
            Assert.Equal("acedgfb", disp.Digits[8]);
            Assert.Equal(5353, actual);
        }

        [Fact]
        public void Day08_Puzzle1_Ok()
        {
            var lines = Utils.ReadLinesFromFile("Day08.txt");
            Assert.Equal(200, lines.Length);

            var sut = new SevenSegmentDecoder(lines);
            int actual = sut.CountUniqueDigits();
            Assert.Equal(409, actual);
        }
    }
}
