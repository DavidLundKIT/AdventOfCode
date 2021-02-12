using AdventOfCode2020;
using Xunit;

namespace DailyXUnitTests
{
    public class Day07BaggageUnitTests
    {
        private string[] TestBaggageRules = new string[]
        {
            "light red bags contain 1 bright white bag, 2 muted yellow bags.",
            "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
            "bright white bags contain 1 shiny gold bag.",
            "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
            "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
            "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
            "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
            "faded blue bags contain no other bags.",
            "dotted black bags contain no other bags."
        };

        [Fact(Skip = "Daily completed")]
        public void Day07ReadBaggageRulesData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day07Data.txt");
            Assert.Equal(594, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void Day07ParseBaggageRules_Ok()
        {
            var sut = new LuggageProcessor(TestBaggageRules);

            Assert.Equal(9, sut.BaggageRules.Count);

            var actual = sut.ComboToContainBag("shiny gold");
            Assert.Equal(4, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day07BaggageCombos_Part1_Ok()
        {
            var rules = DailyDataUtilities.ReadLinesFromFile("Day07Data.txt");
            Assert.Equal(594, rules.Length);
            var sut = new LuggageProcessor(rules);
            Assert.Equal(594, sut.BaggageRules.Count);

            var actual = sut.ComboToContainBag("shiny gold");
            Assert.Equal(151, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day07BaggageCount_Ok()
        {
            var sut = new LuggageProcessor(TestBaggageRules);
            Assert.Equal(9, sut.BaggageRules.Count);

            var actual = sut.TotalBagCount("shiny gold");
            Assert.Equal(32, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day07BaggageCount_Part2_Ok()
        {
            var rules = DailyDataUtilities.ReadLinesFromFile("Day07Data.txt");
            Assert.Equal(594, rules.Length);
            var sut = new LuggageProcessor(rules);
            Assert.Equal(594, sut.BaggageRules.Count);

            var actual = sut.TotalBagCount("shiny gold");
            Assert.Equal(41559, actual);
        }
    }
}
