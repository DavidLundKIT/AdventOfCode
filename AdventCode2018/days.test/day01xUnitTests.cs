using System;
using Xunit;
using day01;

namespace day01.tests
{
    public class Day01xUnitTests
    {
        [Fact(Skip = "")]
        public void Day01_Freq_is_3()
        {
            int expected = 3;
            int[] data = new int[] { +1, -2, +3, +1 };

            Day01 sut = new Day01();
            int actual = sut.GetFrequency(data );

            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "")]
        public void Day01_Freq_is_again_3()
        {
            int expected = 3;
            int[] data = new int[] { +1, +1, +1 };

            Day01 sut = new Day01();
            int actual = sut.GetFrequency(data );

            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "")]
        public void Day01_Freq_is_0()
        {
            int expected = 0;
            int[] data = new int[] { +1, +1, -2 };

            Day01 sut = new Day01();
            int actual = sut.GetFrequency(data );

            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "")]
        public void Day01_Freq_is_Neg6()
        {
            int expected = -6;
            int[] data = new int[] { -1, -2, -3 };

            Day01 sut = new Day01();
            int actual = sut.GetFrequency(data );

            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "")]
        public void Day01_Reading_data_Ok()
        {
            string datapath = "day01a.txt";
            int expected1st = 16;
            int expectedLast = -124478;

            Day01 sut = new Day01();
            int[] data = sut.ParseData(datapath);

            Assert.Equal(expected1st, data[0]);
            Assert.Equal(expectedLast, data[data.Length-1]);
        }

        [Fact(Skip = "")]
        public void Day01_Freq_part_1_answer()
        {
            int expected = 439;
            string datapath = "day01a.txt";

            Day01 sut = new Day01();
            int[] data = sut.ParseData(datapath);
            int actual = sut.GetFrequency(data);

            Assert.Equal(expected, actual);
        }
    }
}
