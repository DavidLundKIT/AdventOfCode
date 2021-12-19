using AdventCode2021;
using Xunit;

namespace DailyXunitTests
{
    public class Day18SnailishTests
    {
        [Theory]
        [InlineData("[1,2]")]
        [InlineData("[[1,2],3]")]
        [InlineData("[9,[8,7]]")]
        [InlineData("[[1,9],[8,5]]")]
        [InlineData("[[[[1,2],[3,4]],[[5,6],[7,8]]],9]")]
        [InlineData("[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]")]
        [InlineData("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]")]
        public void SnailNumber_Parse_OK(string expected)
        {
            SnailNumber sn = SnailNumber.Builder(expected);

            string actual = sn.ToString();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("[1,2]", "[[3,4],5]", "[[1,2],[[3,4],5]]")]
        public void SnailNumber_Add_OK(string lna, string lnb, string expected)
        {
            var sna = SnailNumber.Builder(lna);
            var snb = SnailNumber.Builder(lnb);
            var actual = sna.Add(snb);
            Assert.Equal(expected, actual.ToString());
        }

        [Fact]
        public void SnailNumber_NothingToExplode_OK()
        {
            string lna = "[[1,2],[[3,4],5]]";
            string expected = "[[1,2],[[3,4],5]]";

            var sna = SnailNumber.Builder(lna);

            SnailNumber explode = sna.FindExplode(0);
            Assert.Null(explode);

            var sn = sna.Explode();
            Assert.Null(sn);
            Assert.Equal(expected, sna.ToString());
        }

        [Theory]
        [InlineData("[[[[[9,8],1],2],3],4]", "[9,8]", "[[[[0,9],2],3],4]")]
        [InlineData("[7,[6,[5,[4,[3,2]]]]]", "[3,2]", "[7,[6,[5,[7,0]]]]")]
        [InlineData("[[6,[5,[4,[3,2]]]],1]", "[3,2]", "[[6,[5,[7,0]]],3]")]
        [InlineData("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", "[7,3]", "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]")]
        [InlineData("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "[3,2]", "[[3,[2,[8,0]]],[9,[5,[7,0]]]]")]
        public void SnailNumber_ReduceExplode_OK(string lna, string exploding, string expected)
        {
            var sna = SnailNumber.Builder(lna);

            SnailNumber explode = sna.FindExplode(0);
            Assert.Equal(exploding, explode.ToString());

            var sn = sna.Explode();
            Assert.Equal(exploding, sn.ToString());
            Assert.Equal(expected, sna.ToString());
        }

        [Fact]
        public void SnailNumber_Split_OK()
        {
            string lna = "[[[[0,7],4],[15,[0,13]]],[1,1]]";
            string expected = "[[[[0,7],4],[[7,8],[0,13]]],[1,1]]";

            var sna = SnailNumber.Builder(lna);
            var sn = sna.Split();
            Assert.Equal(expected, sna.ToString());
        }

        [Fact]
        public void SnailNumber_NoSplit_OK()
        {
            string lna = "[[[[0,7],4],[5,[0,3]]],[1,1]]";
            string expected = "[[[[0,7],4],[5,[0,3]]],[1,1]]";

            var sna = SnailNumber.Builder(lna);
            var sn = sna.Split();
            Assert.Null(sn);
            Assert.Equal(expected, sna.ToString());
        }

        [Fact]
        public void SnailNumber_AddReduce_OK()
        {
            string lna = "[[[[4,3],4],4],[7,[[8,4],9]]]";
            string lnb = "[1,1]";
            string expected = "[[[[0,7],4],[[7,8],[6,0]]],[8,1]]";

            var sna = SnailNumber.Builder(lna);
            var snb = SnailNumber.Builder(lnb);

            var sn = sna.Add(snb);
            sn.Reduce();

            Assert.Equal(expected, sn.ToString());
        }

        [Theory]
        [InlineData("[9,1]", 29)]
        [InlineData("[1,9]", 21)]
        [InlineData("[[1,2],[[3,4],5]]", 143)]
        [InlineData("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", 1384)]
        [InlineData("[[[[1,1],[2,2]],[3,3]],[4,4]]", 445)]
        [InlineData("[[[[3,0],[5,3]],[4,4]],[5,5]]", 791)]
        [InlineData("[[[[5,0],[7,4]],[5,5]],[6,6]]", 1137)]
        [InlineData("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", 3488)]
        public void SnailNumber_Magnitude_OK(string lna, long expected)
        {
            var sna = SnailNumber.Builder(lna);
            long actual = sna.Magnitude();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Day18Test1.txt", "[[[[1,1],[2,2]],[3,3]],[4,4]]")]
        [InlineData("Day18Test2.txt", "[[[[3,0],[5,3]],[4,4]],[5,5]]")]
        [InlineData("Day18Test3.txt", "[[[[5,0],[7,4]],[5,5]],[6,6]]")]
        [InlineData("Day18Test4.txt", "[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]")]
        public void SnailNumber_AddList_ok(string testfile, string expected)
        {
            var lines = Utils.ReadLinesFromFile(testfile);
            SnailNumber snacc = SnailNumber.Builder(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                SnailNumber sn = SnailNumber.Builder(lines[i]);
                snacc = snacc.Add(sn);
                snacc.Reduce();
            }
            Assert.Equal(expected, snacc.ToString());
        }

        [Fact]
        public void SnailNumber_ListMagnitude_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18Test5.txt");
            SnailNumber snacc = SnailNumber.Builder(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                SnailNumber sn = SnailNumber.Builder(lines[i]);
                snacc = snacc.Add(sn);
                snacc.Reduce();
            }
            long actual = snacc.Magnitude();
            Assert.Equal(4140, actual);
        }

        [Fact]
        public void Day18_Puzzle1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18.txt");
            Assert.Equal(100, lines.Length);
            SnailNumber snacc = SnailNumber.Builder(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                SnailNumber sn = SnailNumber.Builder(lines[i]);
                snacc = snacc.Add(sn);
                snacc.Reduce();
            }
            long actual = snacc.Magnitude();
            Assert.Equal(4088, actual);
        }

        [Fact]
        public void SnailNumber_ListMaxMagnitude_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18Test5.txt");

            long maxMag = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    var sn1 = SnailNumber.Builder(lines[i]);
                    var sn2 = SnailNumber.Builder(lines[j]);
                    var sum1 = sn1.Add(sn2);
                    sum1.Reduce();
                    long mag = sum1.Magnitude();
                    if (maxMag < mag)
                        maxMag = mag;

                    var snr1 = SnailNumber.Builder(lines[j]);
                    var snr2 = SnailNumber.Builder(lines[i]);
                    var sumr1 = snr1.Add(snr2);
                    sumr1.Reduce();
                    mag = sumr1.Magnitude();
                    if (maxMag < mag)
                        maxMag = mag;
                }
            }
            Assert.Equal(3993, maxMag);
        }

        [Fact]
        public void Day18_Puzzle2_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18.txt");
            Assert.Equal(100, lines.Length);
            long maxMag = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines.Length; j++)
                {
                    var sn1 = SnailNumber.Builder(lines[i]);
                    var sn2 = SnailNumber.Builder(lines[j]);
                    var sum1 = sn1.Add(sn2);
                    sum1.Reduce();
                    long mag = sum1.Magnitude();
                    if (maxMag < mag)
                        maxMag = mag;

                    var snr1 = SnailNumber.Builder(lines[j]);
                    var snr2 = SnailNumber.Builder(lines[i]);
                    var sumr1 = snr1.Add(snr2);
                    sumr1.Reduce();
                    mag = sumr1.Magnitude();
                    if (maxMag < mag)
                        maxMag = mag;
                }
            }
            Assert.Equal(4536, maxMag);
        }
    }
}
