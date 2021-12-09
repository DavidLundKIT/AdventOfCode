using System;
using System.Collections.Generic;

namespace AdventCode2021
{
    public class DivePathFinder
    {
        public long Horizontal { get; set; }
        public long Depth { get; set; }
        public long Aim { get; set; }
        public Dictionary<string, long> CmdDict { get; set; }

        public DivePathFinder()
        {
            Horizontal = 0;
            Depth = 0;
            Aim = 0;
            CmdDict = new Dictionary<string, long>();
        }

        public long FindPosition(string[] cmds)
        {
            foreach (var cmd in cmds)
            {
                var vals = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                long val = long.Parse(vals[1]);
                if (CmdDict.ContainsKey(vals[0]))
                {
                    CmdDict[vals[0]] += val;
                }
                else
                {
                    // first time for command
                    CmdDict.Add(vals[0], val);
                }
            }
            Horizontal = CmdDict["forward"];
            Depth = CmdDict["down"] - CmdDict["up"];
            return Horizontal * Depth;
        }

        public long FindAimedPosition(string[] cmds)
        {
            foreach (var cmd in cmds)
            {
                var vals = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                long val = long.Parse(vals[1]);
                if (vals[0] == "forward")
                {
                    Horizontal += val;
                    Depth += val * Aim;
                }
                else if (vals[0] == "down")
                {
                    // first time for command
                    Aim += val;
                }
                else
                {
                    Aim -= val;
                }
            }
            return Horizontal * Depth;
        }
    }
}
