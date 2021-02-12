using System;
using Xunit;
using day02;
using System.Collections.Generic;
using System.Diagnostics;

namespace day02.tests
{
    public class Day02Part1UnitTests
    {
        [Fact(Skip = "Done")]
        public void Day02_ParseInputFile_OK()
        {
            string datapath = @"C:\Work\fun\AdventCode2018\data\day02a.txt";
            var sut = new Day02SerialNumber();

            List<string> sns = new List<string>(sut.ParseData(datapath));
            Assert.NotNull(sns);
            Assert.Equal(250, sns.Count);
        }

        [Theory(Skip = "Done")]
        [InlineData("abcdef", 0, 0)]
        [InlineData("bababc", 1, 1)]
        [InlineData("abbcde", 1, 0)]
        [InlineData("abcccd", 0, 1)]
        [InlineData("aabcdd", 1, 0)]
        [InlineData("abcdee", 1, 0)]
        [InlineData("ababab", 0, 1)]
        public void Day02_TestLetterCounts_OK(string sn, int ch2s, int ch3s)
        {
            var sut = new Day02SerialNumber();
            var lc = sut.GetLetterCount(sn);
            var lcr = sut.GetLetterCountResult(lc);
            Assert.Equal(ch2s, lcr.DoubleLetterCount);
            Assert.Equal(ch3s, lcr.TripleLetterCount);
        }

        [Fact(Skip = "Done")]
        public void Day02_TestChecksum_12()
        {
            int expected = 12;
            string[] sns = new string[]{
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab",
            };
            var sut = new Day02SerialNumber();
            var actual = sut.CheckSum(sns);
            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "Done")]
        public void Day02_ChecksumPart1_Answer()
        {
            string datapath = @"C:\Work\fun\AdventCode2018\data\day02a.txt";
            var sut = new Day02SerialNumber();

            var sns = sut.ParseData(datapath);
            int expected = 5904;
            var actual = sut.CheckSum(sns);
            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "Done")]
        public void Day02_FindSerialNumberDiffOneChar_OK()
        {
            string expected = "fgij";
            string[] sns = new string[]{
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz"
            };
            var sut = new Day02SerialNumber();
            var actual = sut.FindClosestMatch(sns);
            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "Done")]
        public void Day02_FindSerialNumberPart2_Answer()
        {
            string expected = "jiwamotgsfrudclzbyzkhlrvp";
            string datapath = @"C:\Work\fun\AdventCode2018\data\day02a.txt";
            var sut = new Day02SerialNumber();

            var sns = sut.ParseData(datapath);
            Assert.NotNull(sns);
            Assert.Equal(250, sns.Length);
            var actual = sut.FindClosestMatch(sns);
            Debug.WriteLine($"actual: {actual}");
            Assert.Equal(expected, actual);
        }
    }
}
