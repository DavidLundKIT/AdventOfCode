using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class LuggageProcessor
    {
        public Dictionary<string, Dictionary<string, int>> BaggageRules { get; set; }
        public LuggageProcessor(string[] rules)
        {
            BaggageRules = new Dictionary<string, Dictionary<string, int>>();

            ProcessRules(rules);
        }

        public void ProcessRules(string[] rules)
        {
            foreach (var rule in rules)
            {
                int idx = rule.IndexOf(" bags contain ");
                var color = rule.Substring(0, idx).Trim();
                var bags = rule.Substring(idx + 14).Split(new char[] { ',' });
                var containedBags = new Dictionary<string, int>();
                foreach (var bag in bags)
                {
                    var parts = bag.Trim().Split(new char[] { ' ' });
                    if (parts[0].ToLower() != "no")
                    {
                        var numberBags = int.Parse(parts[0]);
                        var bagColor = string.Join(' ', parts.Skip(1).Take(parts.Length - 2));
                        containedBags.Add(bagColor, numberBags);
                    }
                }
                BaggageRules.Add(color, containedBags);
            }
        }

        public int ComboToContainBag(string targetBagColor)
        {
            List<string> containingBags = new List<string>();
            int combos = 0;
            foreach (var bag in BaggageRules)
            {
                combos += BagContainsThisBag(bag.Key, targetBagColor);
            }
            return combos;
        }

        public int BagContainsThisBag(string bagColor, string targetBagColor)
        {
            var containedBags = BaggageRules[bagColor];
            if (containedBags.ContainsKey(targetBagColor))
            {
                return 1;
            }
            foreach (var bag in containedBags)
            {
                if (BagContainsThisBag(bag.Key, targetBagColor) == 1)
                {
                    return 1;
                }
            }
            return 0;
        }

        public int TotalBagCount(string bagColor)
        {
            int bagCount = 0;
            var containedBags = BaggageRules[bagColor];
            foreach (var bag in containedBags)
            {
                bagCount += bag.Value;
                var childBags = TotalBagCount(bag.Key);
                bagCount += (bag.Value * childBags);
            }
            return bagCount;
        }
    }
}
