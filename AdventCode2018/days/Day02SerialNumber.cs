using System;
using System.Collections.Generic;
using System.IO;

namespace day02
{
    public class Day02SerialNumber
    {
        public Day02SerialNumber()
        {
        }

        public string[] ParseData(string datapath)
        {
            var rows = File.ReadAllLines(datapath);
            return rows;
        }

        public int CheckSum(string [] sns)
        {
            int count2chs = 0;
            int count3chs = 0;
            int checksum = 0;

            foreach (var sn in sns)
            {
                var lc = GetLetterCount(sn);
                var lcr = GetLetterCountResult(lc);
                if (lcr.DoubleLetterCount > 0)
                {
                    count2chs++;
                }
                if (lcr.TripleLetterCount > 0)
                {
                    count3chs++;
                }
            }

            checksum = count2chs*count3chs;

            return checksum;
        }

        public Dictionary<char, int> GetLetterCount(string sn)
        {
            Dictionary<char, int> lc = new Dictionary<char, int>();

            var letters = sn.ToCharArray();
            foreach (var ch in letters)
            {
                if (lc.ContainsKey(ch))
                {
                    lc[ch] += 1;
                }
                else
                {
                    lc.Add(ch, 1);
                }
            }

            return lc;
        }

        public LetterCountResult GetLetterCountResult(Dictionary<char, int> lc)
        {
            LetterCountResult lcr = new LetterCountResult();
            lcr.DoubleLetterCount = lc.ContainsValue(2) ? 1: 0;
            lcr.TripleLetterCount = lc.ContainsValue(3) ? 1: 0;

            return lcr;
        }

        public string FindClosestMatch(string[] sns)
        {
            string result = string.Empty;

            // sorted list was a big mistake
            for (int ii = 0; ii < sns.Length; ii++)
            {
                for (int jj = 0; jj < sns.Length; jj++)
                {
                    string temp = CompareDiffOneChar(sns[ii], sns[jj]);
                    if (!string.IsNullOrEmpty(temp))
                    {
                        result = temp;
                        return temp;
                    }
                }
            }
            return result;
        }

        public string CompareDiffOneChar(string sn1, string sn2)
        {
            var chs1 = sn1.ToCharArray();
            var chs2 = sn2.ToCharArray();
            int diffs = 0;
            int diffIndex = -1;

            char ch1 = ' ';
            char ch2 = ' ';
            for (int i = 0; i < chs1.Length; i++)
            {
                if (chs1[i] != chs2[i])
                {
                    diffs++;
                    diffIndex= i;
                    ch1 = chs1[i];
                    ch2 = chs2[i];
                }
            } 

            if (diffs != 1)
            {
                return string.Empty;
            }
            string match = sn1.Remove(diffIndex, 1);
            return match;
        }
    }
}
