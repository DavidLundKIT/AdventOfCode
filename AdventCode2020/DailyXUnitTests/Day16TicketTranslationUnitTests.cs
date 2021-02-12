using AdventOfCode2020;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DailyXUnitTests
{
    public class Day16TicketTranslationUnitTests
    {
        private string[] testLines = new string[] {
            "class: 1-3 or 5-7",
            "row: 6-11 or 33-44",
            "seat: 13-40 or 45-50",
            "",
            "your ticket:",
            "7,1,14",
            "",
            "nearby tickets:",
            "7,3,47",
            "40,4,50",
            "55,2,20",
            "38,6,12",
        };

        private string[] testLines2 = new string[] {
            "class: 0-1 or 4-19",
            "row: 0-5 or 8-19",
            "seat: 0-13 or 16-19",
            "",
            "your ticket:",
            "11,12,13",
            "",
            "nearby tickets:",
            "3,9,18",
            "15,1,5",
            "5,14,9"
         };

        [Fact(Skip = "Daily completed")]
        public void Day16ParseTestData_Example1_OK()
        {
            var lines = new List<string>(testLines);
            Assert.Equal(12, lines.Count);

            var rules = lines.Take(3).ToList();
            var myTicket = lines[5];
            var tickets = lines.Skip(8).Take(4).ToList();

            Assert.StartsWith("seat:", rules[2]);
            Assert.False(string.IsNullOrWhiteSpace(myTicket));

            var sut = new TicketScanner();
            sut.ParseClassRules(rules.ToArray());
            Assert.Equal(3, sut.ClassRules.Count);

            var result = sut.ValidateTickets(tickets);
            Assert.Equal(3, result.Count);
            Assert.Equal(71, result.Sum());

            Assert.Equal(1, sut.ValidTickets.Count);
        }

        [Fact(Skip = "Daily completed")]
        public void Day16ParseData_Part1_OK()
        {
            var lines = new List<string>(DailyDataUtilities.ReadLinesFromFile("Day16Data.txt"));
            Assert.Equal(266, lines.Count);

            var rules = lines.Take(20).ToList();
            var myTicket = lines[22];
            var tickets = lines.Skip(25).Take(241).ToList();

            Assert.StartsWith("zone:", rules[19]);
            Assert.False(string.IsNullOrWhiteSpace(myTicket));

            var sut = new TicketScanner();
            sut.ParseClassRules(rules.ToArray());
            Assert.Equal(20, sut.ClassRules.Count);

            var result = sut.ValidateTickets(tickets);
            Assert.Equal(20091, result.Sum());

            Assert.Equal(190, sut.ValidTickets.Count);
        }

        [Fact(Skip = "Daily completed")]
        public void Day16ParseTestData_Example2_OK()
        {
            var lines = new List<string>(testLines2);
            Assert.Equal(11, lines.Count);

            var rules = lines.Take(3).ToList();
            var myTicket = lines[5];
            var tickets = lines.Skip(8).Take(3).ToList();

            Assert.StartsWith("seat:", rules[2]);
            Assert.False(string.IsNullOrWhiteSpace(myTicket));

            var sut = new TicketScanner();
            sut.ParseClassRules(rules.ToArray());
            Assert.Equal(3, sut.ClassRules.Count);

            var result = sut.ValidateTickets(tickets);
            Assert.Equal(0, result.Count);
            Assert.Equal(0, result.Sum());
            Assert.Equal(3, sut.ValidTickets.Count);
            sut.ExpandTickets();
            Assert.Equal(3, sut.ValidTicketColumns.Count);

            sut.MatchRulesToColumns();
            Assert.Equal(3, sut.RuleToColumnMatches.Count);
        }

        [Fact(Skip = "Daily completed")]
        public void Day16ParseData_Part2_OK()
        {
            var lines = new List<string>(DailyDataUtilities.ReadLinesFromFile("Day16Data.txt"));
            Assert.Equal(266, lines.Count);

            var rules = lines.Take(20).ToList();
            var myTicket = lines[22];
            var tickets = lines.Skip(25).Take(241).ToList();

            Assert.StartsWith("zone:", rules[19]);
            Assert.False(string.IsNullOrWhiteSpace(myTicket));

            var sut = new TicketScanner();
            sut.ParseClassRules(rules.ToArray());
            Assert.Equal(20, sut.ClassRules.Count);

            var result = sut.ValidateTickets(tickets);
            Assert.Equal(20091, result.Sum());

            Assert.Equal(190, sut.ValidTickets.Count);
            sut.ExpandTickets();
            sut.MatchRulesToColumns();
            Assert.Equal(20, sut.RuleToColumnMatches.Count);

            sut.MakeUniqueRuleToColumnMatch();
            var indices = sut.ListDepartureColumns();
            var myfields = myTicket.Split(new char[] { ',' }).Select(p => long.Parse(p)).ToList();
            long actual = 1;
            foreach (var idx in indices)
            {
                actual *= myfields[idx];
            }
            Assert.Equal(2325343130651, actual);
        }
    }
}
