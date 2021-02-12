using days;
using System.Collections.Generic;

namespace day01
{
    public class Day01
    {
        public Day01()
        {
        }

        public int[] ParseData(string datapath)
        {
            var rows = DataHelpers.ReadLinesFromFile(datapath);
            List<int> data = new List<int>();
            foreach (var row in rows)
            {
                if (!string.IsNullOrWhiteSpace(row) && int.TryParse(row, out int num))
                {
                    data.Add(num);
                }
            }
            return data.ToArray();
        }

        public int GetFrequency(int[] freqChanges)
        {
            int freq = 0;

            foreach (var change in freqChanges)
            {
                freq += change;
            }

            return freq;
        }

        public int FindFirstRepeatFrequency(int[] freqChanges)
        {
            int freq = 0;
            bool found = false;
            Dictionary<int, bool> freqs = new Dictionary<int, bool>();

            freqs.Add(freq, false);

            while (!found)
            {
                foreach (var change in freqChanges)
                {
                    freq += change;
                    if (freqs.ContainsKey(freq))
                    {
                        found = true;
                        break;
                    }
                    else
                    {
                        freqs.Add(freq, false);
                    }
                }
            }
            return freq;
        }
    }
}
