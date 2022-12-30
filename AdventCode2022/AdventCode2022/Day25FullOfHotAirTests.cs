using AdventCode2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2022
{
    public class Day25FullOfHotAirTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day25.txt");
            long actual = lines.Length;
            Assert.Equal(114, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day25test.txt");
            long actual = lines.Length;
            Assert.Equal(13, actual);

            actual = 0;
            foreach (var snafu in lines)
            {
                actual += SnafuToLong(snafu);
            }
            Assert.Equal(4890, actual);

            string base5 = LongToBase5(actual);
            string sactual = Base5ToSnafu(base5);
            Assert.Equal("2=-1=0", sactual);
        }

        [Theory]
        [InlineData("1=-0-2", 1747)]
        [InlineData("12111", 906)]
        [InlineData("2=0=", 198)]
        [InlineData("21", 11)]
        [InlineData("2=01", 201)]
        [InlineData("111", 31)]
        [InlineData("20012", 1257)]
        [InlineData("112", 32)]
        [InlineData("1=-1=", 353)]
        [InlineData("1-12", 107)]
        [InlineData("12", 7)]
        [InlineData("1=", 3)]
        [InlineData("122", 37)]
        public void SnafuToDecimalConversion_OK(string snafu, long expected)
        {
            long actual = SnafuToLong(snafu);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SnafuNumberForBob_Part1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day25.txt");
            long actual = lines.Length;
            Assert.Equal(114, actual);

            actual = 0;
            foreach (var snafu in lines)
            {
                actual += SnafuToLong(snafu);
            }

            // 31915503502222
            Assert.Equal(31915503502222, actual);
            string base5 = LongToBase5(actual);
            string sactual = Base5ToSnafu(base5);
            Assert.Equal("2=2-1-010==-0-1-=--2", sactual);
        }

        public long SnafuToLong(string snafu)
        {
            long value = 0;
            long power5 = 1;
            for (int i = snafu.Length - 1; i >= 0; i--)
            {
                switch (snafu[i])
                {
                    case '0':
                        value += (snafu[i] - '0') * power5;
                        break;
                    case '1':
                        value += (snafu[i] - '0') * power5;
                        break;
                    case '2':
                        value += (snafu[i] - '0') * power5;
                        break;
                    case '=':
                        value += (-2 * power5);
                        break;
                    case '-':
                        value += (-1 * power5);
                        break;
                    default:
                        break;
                }
                power5 *= 5;
            }
            return value;
        }

        public string Base5ToSnafu(string base5)
        {
            var snafu = base5.ToCharArray();

            bool addOne = false;
            for (int i = snafu.Length - 1; i >= 0; i--)
            {
                switch (snafu[i])
                {
                    case '0':
                        snafu[i] = addOne ? '1' : '0';
                        addOne = false;
                        break;
                    case '1':
                        snafu[i] = addOne ? '2' : '1';
                        addOne = false;
                        break;
                    case '2':
                        snafu[i] = addOne ? '=' : '2';
                        break;
                    case '3':
                        snafu[i] = addOne ? '-' : '=';
                        addOne = true;
                        break;
                    case '4':
                        snafu[i] = addOne ? '0' : '-';
                        addOne = true;
                        break;
                    default:
                        break;
                }
            }
            string result = string.Join(string.Empty, snafu);
            if (addOne)
            {
                result = result.Insert(0, "1");
            }
            return result;
        }

        public string LongToBase5(long orginal)
        {
            List<char> snafu = new List<char>();
            long power5 = 5;
            long value = orginal;
            while (value > 0)
            {
                long remainder = value % power5;
                value = value / power5;
                switch (remainder)
                {
                    case 0:
                        snafu.Insert(0, '0');
                        break;
                    case 1:
                        snafu.Insert(0, '1');
                        break;
                    case 2:
                        snafu.Insert(0, '2');
                        break;
                    case 3:
                        snafu.Insert(0, '3');
                        break;
                    case 4:
                        snafu.Insert(0, '4');
                        break;
                    default:
                        break;
                }
            }
            return string.Join(string.Empty, snafu);
        }
    }
}
