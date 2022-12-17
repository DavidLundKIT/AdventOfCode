using AdventCode2022.Models;

namespace AdventCode2022
{
    public class Day13DistressSignalTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day13.txt");
            int actual = lines.Length;
            Assert.Equal(449, actual);
        }

        [Fact]
        public void ReadInTestDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day13test.txt");
            int actual = lines.Length;
            Assert.Equal(23, actual);
        }

        [Theory]
        [InlineData("[1,1,3,1,1]", "[1,1,5,1,1]", true)]
        [InlineData("[[1],[2,3,4]]", "[[1],4]", true)]
        [InlineData("[9]", "[[8,7,6]]", false)]
        [InlineData("[[4,4],4,4]", "[[4,4],4,4,4]", true)]
        [InlineData("[7,7,7,7]", "[7,7,7]", false)]
        [InlineData("[]", "[3]", true)]
        [InlineData("[[[]]]", "[[]]", false)]
        [InlineData("[1,[2,[3,[4,[5,6,7]]]],8,9]", "[1,[2,[3,[4,[5,6,0]]]],8,9]", false)]
        public void DistressSignal_TestCases(string left, string right, bool expected)
        {
            var sut = new DistressSignalComparer();

            int result = sut.Compare(left, right);
            bool actual = (result <= 0);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DistressSignal_TestCases_4s()
        {
            string left = "[[4,4],4,4]";
            string right = "[[4,4],4,4,4]";
            int expected = -1;
            var sut = new DistressSignalComparer();

            int actual = sut.Compare(left, right);
            Assert.True(actual == expected);
        }

        [Fact()]
        public void DistressSignal_OrderPairSum_TestCases()
        {
            var lines = Utils.ReadLinesFromFile("Day13test.txt");
            int actual = lines.Length;
            Assert.Equal(23, actual);

            int pair = 0;
            int index = 0;
            int total = 0;
            do
            {
                if (string.IsNullOrWhiteSpace(lines[index]))
                {
                    index++;
                }
                else
                {
                    string left = lines[index++];
                    string right = lines[index++];
                    pair++;
                    var cmp = new DistressSignalComparer();
                    int result = cmp.Compare(left, right);
                    if (result < 0)
                    {
                        total += pair;
                    }
                }
            } while (index < lines.Length);
            Assert.Equal(13, total);
        }

        [Fact]
        public void DistressSignal_OrderPairSum_Part1()
        {
            var lines = Utils.ReadLinesFromFile("Day13.txt");
            int actual = lines.Length;
            Assert.Equal(449, actual);

            int pair = 0;
            int index = 0;
            int total = 0;
            do
            {
                if (string.IsNullOrWhiteSpace(lines[index]))
                {
                    index++;
                }
                else
                {
                    string left = lines[index++];
                    string right = lines[index++];
                    pair++;
                    var cmp = new DistressSignalComparer();
                    int result = cmp.Compare(left, right);
                    if (result < 0)
                    {
                        total += pair;
                    }
                }
            } while (index < lines.Length);
            // 5920 is wrong too low.
            Assert.Equal(6415, total);
        }

        [Fact()]
        public void DistressSignal_DecoderKey_TestCases()
        {
            var lines = Utils.ReadLinesFromFile("Day13test.txt").ToList();
            int actual = lines.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            lines.Add("[[2]]");
            lines.Add("[[6]]");
            actual = lines.Count;
            Assert.Equal(18, actual);

            var sut = new DistressSignalComparer();
            lines.Sort(sut.Compare);

            int two = lines.IndexOf("[[2]]") + 1;
            int six = lines.IndexOf("[[6]]") + 1;

            Assert.Equal(140, two * six);
        }

        [Fact()]
        public void DistressSignal_DecoderKey_Part2()
        {
            var lines = Utils.ReadLinesFromFile("Day13.txt").ToList();
            int actual = lines.RemoveAll(s => string.IsNullOrWhiteSpace(s));
            lines.Add("[[2]]");
            lines.Add("[[6]]");

            var sut = new DistressSignalComparer();
            lines.Sort(sut.Compare);

            int two = lines.IndexOf("[[2]]") + 1;
            int six = lines.IndexOf("[[6]]") + 1;

            Assert.Equal(20056, two * six);
        }
    }
}
