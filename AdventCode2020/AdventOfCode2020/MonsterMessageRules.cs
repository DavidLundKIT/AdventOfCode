using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public class MonsterMessageRule
    {
        public string Value { get; set; }
        public List<int> SubRules { get; set; }
        public List<int> AltRules { get; set; }

        public MonsterMessageRule()
        {
            SubRules = new List<int>();
            AltRules = new List<int>();
        }
    }

    public class MonsterMessage
    {
        public SortedDictionary<int, MonsterMessageRule> Rules { get; set; }
        public bool isPart2 { get; set; }

        public MonsterMessage(string[] lines)
        {
            Rules = new SortedDictionary<int, MonsterMessageRule>();

            foreach (var line in lines)
            {
                MonsterMessageRule msr;
                int key;
                ParseRule(line, out msr, out key);
                Rules.Add(key, msr);
            }
            isPart2 = false;
        }

        private static void ParseRule(string line, out MonsterMessageRule msr, out int key)
        {
            var parts = line.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
            msr = new MonsterMessageRule();
            key = int.Parse(parts[0]);
            bool useAlt = false;
            for (int i = 1; i < parts.Length; i++)
            {
                if (parts[i] == "|")
                {
                    useAlt = true;
                    continue;
                }
                if (int.TryParse(parts[i], out int rule))
                {
                    if (useAlt)
                    {
                        msr.AltRules.Add(rule);
                    }
                    else
                    {
                        msr.SubRules.Add(rule);
                    }
                }
                else
                {
                    msr.Value = parts[i].Replace("\"", "");
                }
            }
        }

        public void ReplaceRule(string line)
        {
            MonsterMessageRule msr;
            int key;
            ParseRule(line, out msr, out key);
            Rules[key] = msr;
        }

        public string MakeRegexForRule(int key)
        {
            string rules;
            if (isPart2)
            {
                rules = MakeRegexPart2(key);
            }
            else
            {
                rules = MakeRegexPart(key);
            }
            string rg = $"^{rules}$";
            return rg;
        }

        public string MakeRegexPart(int key)
        {
            var mmr = Rules[key];
            if (!string.IsNullOrWhiteSpace(mmr.Value))
            {
                return mmr.Value;
            }
            StringBuilder rg = new StringBuilder();
            if (mmr.AltRules.Count > 0)
            {
                rg.Append("((");
            }
            foreach (var item in mmr.SubRules)
            {
                rg.Append(MakeRegexPart(item));
            }
            if (mmr.AltRules.Count > 0)
            {
                rg.Append(")|(");
                foreach (var item in mmr.AltRules)
                {
                    rg.Append(MakeRegexPart(item));
                }
                rg.Append("))");
            }
            return rg.ToString();
        }

        public string MakeRegexPart2(int key)
        {
            var mmr = Rules[key];
            if (!string.IsNullOrWhiteSpace(mmr.Value))
            {
                return mmr.Value;
            }
            StringBuilder rg = new StringBuilder();
            if (key == 8)
            {
                rg.Append("(");
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                //rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(")+");
                return rg.ToString();
            }
            else if (key == 11)
            {
                rg.Append("((");
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(")|(");
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(")|(");
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(")|(");
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(")|(");
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(")|(");
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[0]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append(MakeRegexPart2(mmr.SubRules[1]));
                rg.Append("))");
                return rg.ToString();
            }
            else
            {
                if (mmr.AltRules.Count > 0)
                {
                    rg.Append("((");
                }
                foreach (var item in mmr.SubRules)
                {
                    rg.Append(MakeRegexPart2(item));
                }
                if (mmr.AltRules.Count > 0)
                {
                    rg.Append(")|(");
                    foreach (var item in mmr.AltRules)
                    {
                        rg.Append(MakeRegexPart2(item));
                    }
                    rg.Append("))");
                }
                return rg.ToString();
            }
        }
    }
}
