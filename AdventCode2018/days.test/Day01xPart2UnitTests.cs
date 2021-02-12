using Xunit;

namespace day01.tests
{
    public class Day01xPart2UnitTests
    {
        [Fact(Skip = "Done")]
        public void Day01_FirstRepeatFreq_is_0()
        {
            int expected = 0;

            Day01 sut = new Day01();
            int[] data = new int[] { +1, -1 };
            int actual = sut.FindFirstRepeatFrequency(data);

            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "Done")]
        public void Day01_FirstRepeatFreq_is_10()
        {
            int expected = 10;

            Day01 sut = new Day01();
            int[] data = new int[] { +3, +3, +4, -2, -4 };
            int actual = sut.FindFirstRepeatFrequency(data);

            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "Done")]
        public void Day01_FirstRepeatFreq_is_5()
        {
            int expected = 5;

            Day01 sut = new Day01();
            int[] data = new int[] { -6, +3, +8, +5, -6 };
            int actual = sut.FindFirstRepeatFrequency(data);

            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "Done")]
        public void Day01_FirstRepeatFreq_is_14()
        {
            int expected = 14;

            Day01 sut = new Day01();
            int[] data = new int[] { +7, +7, -2, -7, -4 };
            int actual = sut.FindFirstRepeatFrequency(data);

            Assert.Equal(expected, actual);
        }

        [Fact(Skip = "Done")]
        public void Day01_FirstRepeatFreq_part_2_answer()
        {
            int expected = 124645;
            string datapath = "day01a.txt";

            Day01 sut = new Day01();
            int[] data = sut.ParseData(datapath);
            int actual = sut.FindFirstRepeatFrequency(data);

            Assert.Equal(expected, actual);
        }

    }
}