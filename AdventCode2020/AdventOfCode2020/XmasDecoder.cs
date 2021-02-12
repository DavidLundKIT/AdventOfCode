using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class XmasDecoder
    {
        public List<long> Numbers { get; set; }
        public int PreambleSize { get; set; }
        public int Index { get; set; }
        public long Target { get; set; }
        public long First { get; set; }
        public long Second { get; set; }

        public XmasDecoder(List<long> numbers, int preambleSize)
        {
            Numbers = numbers;
            PreambleSize = preambleSize;
        }

        public bool XmasDecode(int index)
        {
            Index = index;
            Target = Numbers[Index];
            for (int idx1 = Index - PreambleSize; idx1 < Index - 1; idx1++)
            {
                First = Numbers[idx1];
                Second = Target - First;
                for (int idx2 = idx1 + 1; idx2 < Index; idx2++)
                {
                    if (Numbers[idx2] == Second)
                        return true;
                }
            }
            return false;
        }

        public long FindFirstFail()
        {
            for (int Index = PreambleSize; Index < Numbers.Count; Index++)
            {
                if (!XmasDecode(Index))
                    return Target;
            }
            throw new ArgumentOutOfRangeException("No answer found");
        }

        public long FindMultiNumbers(long targetNumber)
        {
            long sum = 0;
            for (int idx1 = 0; idx1 < Numbers.Count - 1; idx1++)
            {
                sum = Numbers[idx1];
                for (int idx2 = idx1 + 1; idx2 < Numbers.Count; idx2++)
                {
                    sum += Numbers[idx2];
                    if (sum == targetNumber)
                    {
                        List<long> list = new List<long>(Numbers.Skip(idx1).Take(idx2 - idx1 + 1));
                        return list.Min() + list.Max();
                    }
                }
            }
            return -666;
        }
    }
}
