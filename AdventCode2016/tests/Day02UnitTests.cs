using System;
using Xunit;

namespace tests
{
    public class Day02UnitTests
    {
        private const string _indatafile = "day02.txt";

        [Fact]
        public void Day02ReadInput()
        {
            var instructions = DataUtils.ReadAllLines(_indatafile);

            Assert.Equal(5, instructions.Length);

            string result = string.Empty;
            var sut = new KeyPad(5);
            foreach (var cmd in instructions)
            {
                int keyNow = sut.ProcessCommand(cmd);
                result = $"{result}{keyNow}";
            }
            Assert.Equal("14894", result);
        }
       
        [Theory]
        [InlineData(5, "ULL", 1)]
        [InlineData(1, "RRDDD", 9)]
        [InlineData(9, "LURDL", 8)]
        [InlineData(8, "UUUUD", 5)]
        public void Day02KeyPadPart1(int startValue, string commands, int stopValue)
        {
            var sut = new KeyPad(startValue);
            int keyNow = sut.ProcessCommand(commands);
            Assert.Equal(stopValue, keyNow);
        }

        [Theory]
        [InlineData(5, "ULL", 5)]
        [InlineData(5, "RRDDD", 13)]
        [InlineData(13, "LURDL", 11)]
        [InlineData(11, "UUUUD", 3)]
        public void Day02KeyPadPart2(int startValue, string commands, int stopValue)
        {
            var sut = new DiamondKeyPad(startValue);
            int keyNow = sut.ProcessCommand(commands);
            Assert.Equal(stopValue, keyNow);
        }

        [Fact]
        public void Day02DiamondKeyPadPart2()
        {
            var instructions = DataUtils.ReadAllLines(_indatafile);

            Assert.Equal(5, instructions.Length);

            string result = string.Empty;
            var sut = new DiamondKeyPad(5);
            foreach (var cmd in instructions)
            {
                int keyNow = sut.ProcessCommand(cmd);
                result = $"{result}-{keyNow}";
            }
            Assert.Equal("-2-6-11-9-6", result);
        }
    }
}
