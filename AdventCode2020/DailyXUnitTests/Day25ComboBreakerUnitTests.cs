using System;
using System.Collections.Generic;
using AdventOfCode2020;
using Xunit;

namespace DailyXUnitTests
{
    public class Day25ComboBreakerUnitTests
    {
        private long[] realData = new long[] { 16616892, 14505727 };

        [Fact]
        public void Day25_ComboBreaker_Example1_OK()
        {
            long cardKey = 5764801;
            long doorKey = 17807724;
            long expectedKey = 14897079;

            var sut = new ComboBreaker(cardKey, doorKey);
            long actualKey = sut.GetEncryptionKey();
            Assert.Equal(expectedKey, actualKey);
        }

        [Fact]
        public void Day25_ComboBreaker_Part1_OK()
        {
            long cardKey = 16616892;
            long doorKey = 14505727;
            long expectedKey = 4441893;

            var sut = new ComboBreaker(cardKey, doorKey);
            long actualKey = sut.GetEncryptionKey();
            Assert.Equal(expectedKey, actualKey);
        }
    }
}
