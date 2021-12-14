using AdventCode2021;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyXunitTests
{
    public class Day14ExtendedPolymerisationTests
    {
        [Fact]
        public void Day14_TestReadPolymers_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14Test.txt");

            Assert.Equal(18, lines.Length);
            var sut = new Polymerizer(lines);
            Assert.Equal("NNCB", sut.Template);
        }

        [Fact]
        public void Day14_Puzzle1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14.txt");

            Assert.Equal(102, lines.Length);
            var sut = new Polymerizer(lines);
            Assert.Equal("KOKHCCHNKKFHBKVVHNPN", sut.Template);
        }
    }
}
