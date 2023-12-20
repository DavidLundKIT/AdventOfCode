using System.Text.RegularExpressions;

namespace AdventCode2023.Models
{
    public class AplentySorter
    {
        public List<MachinePart> Parts { get; set; }
        public List<MachinePart> AcceptedParts { get; set; }
        public List<MachinePart> RejectedParts { get; set; }
        public Dictionary<string, SortWorkflow> Workflows { get; set; }

        public AplentySorter(string[] lines)
        {
            Parts = new List<MachinePart>();
            AcceptedParts = new List<MachinePart>();
            RejectedParts = new List<MachinePart>();
            Workflows = new Dictionary<string, SortWorkflow>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                else if (line[0] == '{')
                {
                    Parts.Add(new MachinePart(line));
                }
                else
                {
                    var wf = new SortWorkflow(line);
                    Workflows.Add(wf.Key, wf);
                }
            }
        }

        public void SortParts()
        {
            AcceptedParts.Clear();
            RejectedParts.Clear();
            foreach (var part in Parts)
            {
                SortPart(part);
            }
        }

        public void SortPart(MachinePart part)
        {
            string nextKey = "in";

            while (nextKey != "A" && nextKey != "R")
            {
                var wf = Workflows[nextKey];
                nextKey = wf.ProcessPart(part);
            }

            if (nextKey == "A")
            {
                AcceptedParts.Add(part);
            }
            else
            {
                RejectedParts.Add(part);
            }
        }

        public int AcceptedRatingSum()
        {
            int total = AcceptedParts.Sum(p => p.Rating());
            return total;
        }
    }

    /// <summary>
    /// px{a<2006:qkq,m>2090:A,rfg}
    /// </summary>
    public class SortWorkflow
    {
        public List<SortRule> Rules { get; set; }
        public string Key { get; set; }
        public string Workflow { get; set; }

        public SortWorkflow(string line)
        {
            Workflow = line;
            Rules = new List<SortRule>();
            var temp = line.Split(new char[] { ',', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);

            Key = temp[0];
            for (int i = 1; i < temp.Length; i++)
            {
                Rules.Add(new SortRule(temp[i]));
            }
        }

        public string ProcessPart(MachinePart part)
        {
            foreach (var rule in Rules)
            {
                if (rule.ApplyRuleToPart(part))
                {
                    return rule.NextKey;
                }
            }
            throw new ArgumentOutOfRangeException("Rules", "Never found a nextKey");
        }
    }

    public class SortRule
    {
        public string Rule { get; set; }
        public string NextKey { get; set; }
        public char PartProperty { get; set; }
        public char Operand { get; set; }
        public int Threshold { get; set; }
        public bool DirectMove { get; set; }

        public SortRule(string rule)
        {
            Rule = rule;
            var temp = rule.Split(':', StringSplitOptions.RemoveEmptyEntries);
            if (temp.Length == 1)
            {
                DirectMove = true;
                NextKey = temp[0];
            }
            else
            {
                DirectMove = false;
                PartProperty = temp[0][0];
                Operand = temp[0][1];
                Threshold = int.Parse(Regex.Match(temp[0], @"\d+").Value);
                NextKey = temp[1];
            }
        }

        public bool ApplyRuleToPart(MachinePart part)
        {
            if (DirectMove)
            {
                return true;
            }
            // not direct
            int partVal = int.MinValue;
            switch (PartProperty)
            {
                case 'x':
                    partVal = part.x;
                    break;
                case 'm':
                    partVal = part.m;
                    break;
                case 'a':
                    partVal = part.a;
                    break;
                case 's':
                    partVal = part.s;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(PartProperty));
            }

            switch (Operand)
            {
                case '<':
                    return (partVal < Threshold);
                case '>':
                    return (partVal > Threshold);
                default:
                    throw new ArgumentOutOfRangeException(nameof(PartProperty));
            }
        }
    }

    /// <summary>
    /// {x=787,m=2655,a=1222,s=2876}
    /// </summary>
    public class MachinePart
    {
        public int x { get; set; }
        public int m { get; set; }
        public int a { get; set; }
        public int s { get; set; }

        public MachinePart(string line)
        {
            var temp = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            x = int.Parse(Regex.Match(temp[0], @"\d+").Value);
            m = int.Parse(Regex.Match(temp[1], @"\d+").Value);
            a = int.Parse(Regex.Match(temp[2], @"\d+").Value);
            s = int.Parse(Regex.Match(temp[3], @"\d+").Value);
        }

        public int Rating()
        {
            return x + m + a + s;
        }
    }
}