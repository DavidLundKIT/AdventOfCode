using System;
using System.Collections.Generic;

namespace AdventCodeLib
{
    public class Day13Firewall
    {
        public Day13Firewall()
        {
            Firewall = new Dictionary<int, int>();
        }

        public Dictionary<int, int> Firewall { get; set; }
        public void ParseFirewall(string path)
        {
            var rows = DataTools.ReadAllLines(path);
            foreach (var row in rows)
            {
                var vals = row.Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                Firewall.Add(int.Parse(vals[0]), int.Parse(vals[1]));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="step"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public int SeverityScore(long step, int layer)
        {
            int score = 0;
            if (Firewall.ContainsKey(layer))
            {
                int depth = Firewall[layer];
                if (IsScannerThere(step, depth))
                {
                    score = layer * depth;
                }
            }
            return score;
        }

        public bool IsScannerThere(long step, int depth)
        {
            if (step == 0)
            {
                return true;
            }

            int scanner = ScannerPosition(step, depth);
            return (scanner == 0);
        }

        public int ScannerPositionOld(long step, int depth)
        {
            int scanner = 0;
            bool inc = true;
            for (long i = 0; i < step; i++)
            {
                if (inc)
                {
                    scanner++;
                }
                else
                {
                    scanner--;
                }
                if (scanner == depth - 1)
                {
                    inc = false;
                }
                if (scanner == 0)
                {
                    inc = true;
                }
            }
            return scanner;
        }

        public int ScannerPosition(long step, int depth)
        {
            int scanner = 0;
            int cycle = (depth * 2) - 2;
            int leftover = (int)(step % cycle);
            if (leftover > depth - 1)
            {
                scanner = cycle - leftover;
            }
            else
            {
                scanner = leftover;
            }
            return scanner;
        }
    }
}
