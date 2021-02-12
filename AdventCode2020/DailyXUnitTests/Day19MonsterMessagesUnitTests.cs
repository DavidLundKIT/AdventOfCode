using AdventOfCode2020;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace DailyXUnitTests
{
    public class Day19MonsterMessagesUnitTests
    {
        [Fact(Skip = "Daily completed")]
        public void Day19_ReadData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day19Data.txt");
            Assert.Equal(634, lines.Length);

            var sut = new MonsterMessage(lines.Take(131).ToArray());
            Assert.Equal(131, sut.Rules.Count);
        }

        [Theory(Skip = "Daily completed")]
        [InlineData("aab", true)]
        [InlineData("aba", true)]
        [InlineData("abb", false)]
        public void Day19_Example1_OK(string msg, bool expected)
        {
            var rules = new string[] {
                "0: 1 2",
                "1: a",
                "2: 1 3 | 3 1",
                "3: b"
            };

            var sut = new MonsterMessage(rules);
            Assert.Equal(4, sut.Rules.Count);

            string exp = sut.MakeRegexForRule(0);
            Assert.NotNull(exp);


            var rg = Regex.Match(msg, exp);
            Assert.Equal(expected, rg.Success);
        }

        [Fact(Skip = "Daily completed")]
        public void Day19_Example2_OK()
        {
            var rules = new string[] {
                "0: 4 1 5",
                "1: 2 3 | 3 2",
                "2: 4 4 | 5 5",
                "3: 4 5 | 5 4",
                "4: a",
                "5: b"
            };

            var msgs = new string[] {
                "ababbb",
                "bababa",
                "abbbab",
                "aaabbb",
                "aaaabbb"
            };

            var sut = new MonsterMessage(rules);
            Assert.Equal(6, sut.Rules.Count);

            string exp = sut.MakeRegexForRule(0);
            Assert.NotNull(exp);

            int count = 0;
            foreach (var msg in msgs)
            {
                var rg = Regex.Match(msg, exp);
                if (rg.Success)
                    count++;
            }
            Assert.Equal(2, count);
        }

        [Fact(Skip = "Daily completed")]
        public void Day19_MonsterMessages_Part1_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day19Data.txt");
            Assert.Equal(634, lines.Length);

            var sut = new MonsterMessage(lines.Take(131).ToArray());

            Assert.Equal(131, sut.Rules.Count);

            var messages = lines.Skip(132).Take(510).ToArray();
            Assert.Equal(502, messages.Length);

            string exp = sut.MakeRegexForRule(0);

            int count = 0;
            foreach (var msg in messages)
            {
                var rg = Regex.Match(msg, exp);
                if (rg.Success)
                    count++;
            }
            Assert.Equal(299, count);
        }

        [Fact(Skip = "Daily completed")]
        public void Day19_Example_Part2_NoNewRule_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day19Part2DataExample.txt");
            Assert.Equal(47, lines.Length);

            var sut = new MonsterMessage(lines.Take(31).ToArray());

            Assert.Equal(31, sut.Rules.Count);

            var messages = lines.Skip(32).Take(14).ToArray();
            Assert.Equal(14, messages.Length);

            string exp = sut.MakeRegexForRule(0);

            int count = 0;
            foreach (var msg in messages)
            {
                var rg = Regex.Match(msg, exp);
                if (rg.Success)
                    count++;
            }
            Assert.Equal(3, count);
        }

        [Fact(Skip = "Daily completed")]
        public void Day19_Example_WithNewRules_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day19Part2DataExample.txt");
            Assert.Equal(47, lines.Length);

            var sut = new MonsterMessage(lines.Take(31).ToArray());

            Assert.Equal(31, sut.Rules.Count);
            sut.ReplaceRule("8: 42 | 42 8");
            sut.ReplaceRule("11: 42 31 | 42 11 31");

            var messages = lines.Skip(32).Take(15).ToArray();
            Assert.Equal(15, messages.Length);

            sut.isPart2 = true;
            string exp = sut.MakeRegexForRule(0);

            int count = 0;
            foreach (var msg in messages)
            {
                var rg = Regex.Match(msg, exp);
                if (rg.Success)
                    count++;
            }
            Assert.Equal(12, count);
        }

        [Theory(Skip = "Daily completed")]
        [InlineData("bbabbbbaabaabba", true)]
        [InlineData("babbbbaabbbbbabbbbbbaabaaabaaa", true)]
        [InlineData("aaabbbbbbaaaabaababaabababbabaaabbababababaaa", true)]
        [InlineData("bbbbbbbaaaabbbbaaabbabaaa", true)]
        [InlineData("bbbababbbbaaaaaaaabbababaaababaabab", true)]
        [InlineData("ababaaaaaabaaab", true)]
        [InlineData("ababaaaaabbbaba", true)]
        [InlineData("baabbaaaabbaaaababbaababb", true)]
        [InlineData("abbbbabbbbaaaababbbbbbaaaababb", true)]
        [InlineData("aaaaabbaabaaaaababaa", true)]
        [InlineData("aaaabbaabbaaaaaaabbbabbbaaabbaabaaa", true)]
        [InlineData("aabbbbbaabbbaaaaaabbbbbababaaaaabbaaabba", true)]
        public void Day19_Example_WithNewRulesSingle_Ok(string msg, bool expected)
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day19Part2DataExample.txt");
            Assert.Equal(47, lines.Length);

            var sut = new MonsterMessage(lines.Take(31).ToArray());

            Assert.Equal(31, sut.Rules.Count);
            sut.ReplaceRule("8: 42 | 42 8");
            sut.ReplaceRule("11: 42 31 | 42 11 31");

            sut.isPart2 = true;
            string exp = sut.MakeRegexForRule(0);

            var rg = Regex.Match(msg, exp);
            Assert.Equal(expected, rg.Success);
        }

        [Fact(Skip = "Daily completed")]
        public void Day19_MonsterMessages_NewParts_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day19Data.txt");
            Assert.Equal(634, lines.Length);

            var sut = new MonsterMessage(lines.Take(131).ToArray());

            Assert.Equal(131, sut.Rules.Count);
            sut.ReplaceRule("8: 42 | 42 8");
            sut.ReplaceRule("11: 42 31 | 42 11 31");

            sut.isPart2 = true;
            string exp42 = sut.MakeRegexForRule(42);
            Assert.NotEmpty(exp42);
            string exp31 = sut.MakeRegexForRule(31);
            Assert.NotEmpty(exp31);

            string exp8 = sut.MakeRegexForRule(8);
            Assert.NotEmpty(exp8);
            string exp11 = sut.MakeRegexForRule(11);
            Assert.NotEmpty(exp11);

        }


        [Fact(Skip = "Daily completed")]
        public void Day19_MonsterMessages_Part2_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day19Data.txt");
            Assert.Equal(634, lines.Length);

            var sut = new MonsterMessage(lines.Take(131).ToArray());

            Assert.Equal(131, sut.Rules.Count);
            sut.ReplaceRule("8: 42 | 42 8");
            sut.ReplaceRule("11: 42 31 | 42 11 31");

            var messages = lines.Skip(132).Take(510).ToArray();
            Assert.Equal(502, messages.Length);

            sut.isPart2 = true;
            string exp = sut.MakeRegexForRule(0);

            int count = 0;
            foreach (var msg in messages)
            {
                var rg = Regex.Match(msg, exp);
                if (rg.Success)
                    count++;
            }
            Assert.Equal(414, count);
        }
    }
}

