using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class TicketScanner
    {
        public Dictionary<string, Tuple<int, int, int, int>> ClassRules { get; set; }
        public Dictionary<string, List<int>> RuleToColumnMatches { get; set; }

        public List<string> ValidTickets { get; set; }
        public List<List<int>> ValidTicketColumns { get; set; }

        public TicketScanner()
        {
            ClassRules = new Dictionary<string, Tuple<int, int, int, int>>();
            RuleToColumnMatches = new Dictionary<string, List<int>>();
            ValidTickets = new List<string>();
            ValidTicketColumns = new List<List<int>>();
        }

        public void ParseClassRules(string[] lines)
        {
            ClassRules.Clear();

            foreach (var item in lines)
            {
                ParseClassRule(item);
            }
        }

        public void ParseClassRule(string line)
        {
            var parts = line.Split(new char[] { ':' });

            var values = parts[1].Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);

            var rule = Tuple.Create(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[3]), int.Parse(values[4]));

            ClassRules.Add(parts[0], rule);
        }

        public List<int> ValidateTickets(List<string> tickets)
        {
            List<int> invalidFields = new List<int>();
            foreach (var ticket in tickets)
            {
                var badFields = ValidateTicket(ticket);
                if (badFields.Count > 0)
                {
                    invalidFields.AddRange(badFields);
                }
                else
                {
                    ValidTickets.Add(ticket);
                }
            }
            return invalidFields;
        }

        public List<int> ValidateTicket(string ticket)
        {
            List<int> invalidFields = new List<int>();
            var fields = ticket.Split(new char[] { ',' }).Select(p => int.Parse(p)).ToList();

            foreach (var field in fields)
            {
                bool valid = false;
                foreach (var rule in ClassRules.Values)
                {
                    if ((rule.Item1 <= field && field <= rule.Item2) || (rule.Item3 <= field && field <= rule.Item4))
                    {
                        // found in this rule, no need to continue
                        valid = true;
                        break;
                    }
                }
                if (!valid)
                {
                    invalidFields.Add(field);
                }
            }
            return invalidFields;
        }

        public void ExpandTickets()
        {
            foreach (var ticket in ValidTickets)
            {
                var fields = ticket.Split(new char[] { ',' }).Select(p => int.Parse(p)).ToList();
                ValidTicketColumns.Add(fields);
            }
        }

        public void MatchRulesToColumns()
        {
            RuleToColumnMatches.Clear();

            foreach (var rule in ClassRules)
            {
                List<int> columnMatches = new List<int>();
                int maxCols = ValidTicketColumns[0].Count;
                for (int iCol = 0; iCol < maxCols; iCol++)
                {
                    bool valid = true;
                    foreach (var vtc in ValidTicketColumns)
                    {
                        //vtc[iCol]
                        if (!(rule.Value.Item1 <= vtc[iCol] && vtc[iCol] <= rule.Value.Item2) && !(rule.Value.Item3 <= vtc[iCol] && vtc[iCol] <= rule.Value.Item4))
                        {
                            // column not valid in this rule
                            valid = false;
                            break;
                        }
                    }
                    if (valid)
                    {
                        columnMatches.Add(iCol);
                    }
                }
                RuleToColumnMatches.Add(rule.Key, columnMatches);
            }
        }

        public void MakeUniqueRuleToColumnMatch()
        {
            while (RuleToColumnMatches.Values.Any(v => v.Count > 1))
            {
                var rules = RuleToColumnMatches.Values.Where(v => v.Count == 1).Select(v => v.ToArray()[0]).ToList();
                foreach (var rc in RuleToColumnMatches.Values)
                {
                    if (rc.Count > 1)
                    {
                        rules.Select(s => rc.Remove(s)).ToArray();
                    }
                }
            }
        }

        public List<int> ListDepartureColumns()
        {
            var list = RuleToColumnMatches.Where(kv => kv.Key.Contains("departure")).Select(kv => kv.Value[0]).ToList();
            return list;
        }
    }
}
