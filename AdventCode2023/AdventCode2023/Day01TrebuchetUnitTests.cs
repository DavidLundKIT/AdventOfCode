namespace AdventCode2023
{
    public class Day01TrebuchetUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var coords = Utils.ReadLinesFromFile("Day01.txt");
            int expected = 1000;
            int actual = coords.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var coords = Utils.ReadLinesFromFile("Day01Test.txt");
            int expected = 4;
            int actual = coords.Length;
            Assert.Equal(expected, actual);

            var sum = 0;
            foreach (var line in coords)
            {
                sum += LineValue(line);
            }
            Assert.Equal(142, sum);
        }

        [Theory]
        [InlineData("1abc2", 12)]
        [InlineData("pqr3stu8vwx", 38)]
        [InlineData("a1b2c3d4e5f", 15)]
        [InlineData("treb7uchet", 77)]
        public void LineValues_OK(string line, int expected)
        {
            var actual = LineValue(line);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1abc2", 12)]
        [InlineData("pqr3stu8vwx", 38)]
        [InlineData("a1b2c3d4e5f", 15)]
        [InlineData("treb7uchet", 77)]
        public void LineValues_Text_OK(string line, int expected)
        {
            var actual = LineValueText(line);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("two1nine", 29)]
        [InlineData("eightwothree", 83)]
        [InlineData("abcone2threexyz", 13)]
        [InlineData("xtwone3four", 24)]
        [InlineData("4nineeightseven2", 42)]
        [InlineData("zoneight234", 14)]
        [InlineData("7pqrstsixteen", 76)]
        public void LineValues_Text_NewData_OK(string line, int expected)
        {
            var actual = LineValueText(line);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Day01_Part1_Trebuchet_OK()
        {
            var coords = Utils.ReadLinesFromFile("Day01.txt");
            int expected = 1000;
            int actual = coords.Length;
            Assert.Equal(expected, actual);
            var sum = 0;
            foreach (var line in coords)
            {
                sum += LineValue(line);
            }
            Assert.Equal(54916, sum);
        }

        [Fact]
        public void Day01_Part2_Trebuchet_OK()
        {
            var coords = Utils.ReadLinesFromFile("Day01.txt");
            int expected = 1000;
            int actual = coords.Length;
            Assert.Equal(expected, actual);
            var sum = 0;
            foreach (var line in coords)
            {
                sum += LineValueText(line);
            }
            Assert.Equal(54728, sum);
        }



        public int LineValue(string line)
        {
            char now = 'a';
            List<char> chars = new List<char>();
            bool first = true;
            foreach (char ch in line)
            {
                if (char.IsDigit(ch))
                {
                    now = ch;
                    if (first)
                    {
                        chars.Add(now);
                        first = false;
                    }
                }
            }
            // now should be the last
            chars.Add(now);
            var temp = string.Join("", chars);
            return int.Parse(temp);
        }

        /// <summary>
        /// Rewrote after seeing a python solution using find and reverse find.
        /// This saved 17 ms from all tests for the dayn 27 ms to 10 ms.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public int LineValueText(string line)
        {
            SortedList<int, int> digitValues = new SortedList<int, int>();
            for (int ii = 0; ii < line.Length; ii++)
            {
                if (char.IsDigit(line[ii]))
                {
                    digitValues.Add(ii, ((int)line[ii] - (int)'0'));
                }
            }

            // now search for word digits
            List<string> digitWords = new List<string>()
            {
                "zero",
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine"
            };

            for (int num = 0; num < digitWords.Count; ++num)
            {
                int idx = line.IndexOf(digitWords[num]);
                if (idx >= 0)
                {
                    if (!digitValues.ContainsKey(idx))
                        digitValues.Add(idx, num);
                }
                idx = line.LastIndexOf(digitWords[num]);
                if (idx >= 0)
                {
                    if (!digitValues.ContainsKey(idx))
                        digitValues.Add(idx, num);
                }
            }

            var first = digitValues.First();
            var last = digitValues.Last();
            return first.Value * 10 + last.Value;
        }

        /// <summary>
        /// This for the star
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public int LineValueText_org(string line)
        {
            SortedList<int, int> digitValues = new SortedList<int, int>();
            for (int ii = 0; ii < line.Length; ii++)
            {
                if (char.IsDigit(line[ii]))
                {
                    digitValues.Add(ii, ((int)line[ii] - (int)'0'));
                }
            }

            // now search for word digits
            List<string> digitWords = new List<string>()
            {
                "zero",
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine"
            };
            var temp = line;
            int idx = 0;
            do
            {
                for (int jj = 0; jj < digitWords.Count; ++jj)
                {
                    if (temp.StartsWith(digitWords[jj]))
                    {
                        digitValues.Add(idx, jj);
                        break;
                    }
                }
                ++idx;
                temp = line.Substring(idx);
            } while (temp.Length >= 3);

            var first = digitValues.First();
            var last = digitValues.Last();
            return first.Value * 10 + last.Value;
        }
    }
}