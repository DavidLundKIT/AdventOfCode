using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace days.day07
{
    public class Rule
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class InstructionComparer
    {
        public List<Rule> Rules { get; set; }
        public List<string> Steps { get; set; }
        public InstructionComparer(List<Rule> rules)
        {
            Rules = rules;
        }

        public InstructionComparer(string rulesPath)
        {
            var rows = DataHelpers.ReadLinesFromFile(rulesPath);
            Steps = new List<string>();
            Rules = new List<Rule>();
            foreach (var row in rows)
            {
                var items = row.Split(new char[]{' '});
                Rule rule = new Rule()
                {
                    Key = items[1],
                    Value = items[7]
                };
                Rules.Add(rule);

                if (!Steps.Contains(rule.Key))
                {
                    Steps.Add(rule.Key);
                }
                if (!Steps.Contains(rule.Value))
                {
                    Steps.Add(rule.Value);
                }
            }
        }

        public int CompareRules(string a, string b)
        {
            if (a == b)
            {
                return 0;
            }
            Rule rule = Rules.SingleOrDefault(r=> r.Key == a && r.Value == b);
            if (rule != null)
            {
                // rule says a before b
                return -1;
            }
            Rule reverseRule = Rules.SingleOrDefault(r=> r.Key == b && r.Value == a);
            if (reverseRule != null)
            {
                // a rule says b before a
                return 1;
            }
            // no rules, use aphabetical order.
            return string.Compare(a, b);
        }
    }
}