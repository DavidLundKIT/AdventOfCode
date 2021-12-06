using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class Day06LanternFishTests
    {
        public int[] TestData { get; set; }
        public int[] Data { get; set; }

        public Day06LanternFishTests()
        {
            TestData = new int[] { 3, 4, 3, 1, 2 };
            Data = new int[] { 1, 3, 4, 1, 5, 2, 1, 1, 1, 1, 5, 1, 5, 1, 1, 1, 1, 3, 1, 1, 1, 1, 1, 1, 1, 2, 1, 5, 1, 1,
                1, 1, 1, 4, 4, 1, 1, 4, 1, 1, 2, 3, 1, 5, 1, 4, 1, 2, 4, 1, 1, 1, 1, 1, 1, 1, 1, 2, 5, 3, 3, 5, 1, 1, 1,
                1, 4, 1, 1, 3, 1, 1, 1, 2, 3, 4, 1, 1, 5, 1, 1, 1, 1, 1, 2, 1, 3, 1, 3, 1, 2, 5, 1, 1, 1, 1, 5, 1, 5, 5,
                1, 1, 1, 1, 3, 4, 4, 4, 1, 5, 1, 1, 4, 4, 1, 1, 1, 1, 3, 1, 1, 1, 1, 1, 1, 3, 2, 1, 4, 1, 1, 4, 1, 5, 5,
                1, 2, 2, 1, 5, 4, 2, 1, 1, 5, 1, 5, 1, 3, 1, 1, 1, 1, 1, 4, 1, 2, 1, 1, 5, 1, 1, 4, 1, 4, 5, 3, 5, 5, 1,
                2, 1, 1, 1, 1, 1, 3, 5, 1, 2, 1, 2, 1, 3, 1, 1, 1, 1, 1, 4, 5, 4, 1, 3, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5,
                1, 1, 1, 5, 1, 1, 4, 1, 5, 2, 4, 1, 1, 1, 2, 1, 1, 4, 4, 1, 2, 1, 1, 1, 1, 5, 3, 1, 1, 1, 1, 4, 1, 4, 1,
                1, 1, 1, 1, 1, 3, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1,
                1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 5, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        }

        [Fact]
        public void Test_CheckInput_OK()
        {
            int len = TestData.Length;
            Assert.Equal(5, len);

            var sut = new LanternFishModeller(TestData);
            for (int day = 0; day < 18; day++)
            {
                sut.DoDay();
            }
            len = sut.Fish.Count;
            Assert.Equal(26, len);
        }

        [Theory]
        [InlineData(18, 26)]
        [InlineData(80, 5934)]
        public void Test_DoDays_old_OK(int days, long expected)
        {
            int len = TestData.Length;
            Assert.Equal(5, len);

            var sut = new LanternFishModeller(TestData);
            for (int day = 0; day < days; day++)
            {
                sut.DoDay();
            }
            long actual = (long)sut.Fish.Count;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Day06_Puzzle1_OK()
        {
            int len = Data.Length;
            Assert.Equal(300, len);

            var sut = new LanternFishModeller(Data);
            for (int day = 0; day < 80; day++)
            {
                sut.DoDay();
            }
            len = sut.Fish.Count;
            Assert.Equal(386755, len);
        }

        [Theory]
        [InlineData(18, 26)]
        [InlineData(80, 5934)]
        [InlineData(256, 26984457539)]
        public void Test_DoDays_New_OK(int days, long expected)
        {
            int len = TestData.Length;
            Assert.Equal(5, len);

            var sut = new LanternFishModeller(TestData);
            for (int day = 0; day < days; day++)
            {
                sut.DoDay2();
            }
            long actual = sut.FishCount();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Day06_Puzzle2_OK()
        {
            int len = Data.Length;
            Assert.Equal(300, len);

            var sut = new LanternFishModeller(Data);
            for (int day = 0; day < 256; day++)
            {
                sut.DoDay2();
            }
            long actual = sut.FishCount();
            Assert.Equal(1732731810807, actual);
        }
    }
}
