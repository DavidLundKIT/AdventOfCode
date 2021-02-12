using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Xunit;
using System.Diagnostics;
using days.day10;

namespace days.test
{
    public class Day10UnitTests
    {
        [Fact]
        public void Day10_ParseStartPoints()
        {
            string datapath = @"C:\Work\fun\AdventCode2018\data\day10.txt";
            Messages sut = new Messages();

            var starData = sut.ParseStarData(datapath);

            Assert.NotNull(starData);
            Assert.Equal(356, starData.Count);
            // position=< -9860,  -9862> velocity=< 1,  1>
            Assert.Equal(-9860, starData[355].X);
            Assert.Equal(-9862, starData[355].Y);
            Assert.Equal(1, starData[355].dX);
            Assert.Equal(1, starData[355].dY);
        }
    }
}
