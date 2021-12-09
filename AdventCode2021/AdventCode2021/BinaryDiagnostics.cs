using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventCode2021
{
    public class BinaryDiagnostics
    {
        public string Gamma { get; set; }
        public string Epsilon { get; set; }
        public string Oxygen { get; set; }
        public string CO2 { get; set; }
        public List<Dictionary<char, int>> Counters;

        public void InitCounters(int size)
        {
            Counters = new List<Dictionary<char, int>>();
            for (int i = 0; i < size; i++)
            {
                Counters.Add(new Dictionary<char, int>());
            }
        }

        public void CountCharFrequency(string[] data)
        {
            foreach (var num in data)
            {
                var chs = num.ToCharArray();
                for (int ii = 0; ii < chs.Length; ii++)
                {
                    if (Counters[ii].ContainsKey(chs[ii]))
                    {
                        Counters[ii][chs[ii]] += 1;
                    }
                    else
                    {
                        Counters[ii].Add(chs[ii], 1);
                    }
                }
            }
        }

        public long CalcValue()
        {
            return Convert.ToInt32(Gamma, 2) * Convert.ToInt32(Epsilon, 2);
        }

        public string GetStrings()
        {
            StringBuilder sbGamma = new StringBuilder();
            StringBuilder sbEpsilon = new StringBuilder();

            foreach (var dict in Counters)
            {
                int max = dict.Values.Max();
                var i = dict.Single(p => p.Value == max);
                sbGamma.Append(i.Key);
                sbEpsilon.Append(i.Key == '0' ? '1' : '0');
            }
            Gamma = sbGamma.ToString();
            Epsilon = sbEpsilon.ToString();
            return Gamma;
        }

        public bool ProcessData(string[] data)
        {
            InitCounters(data[0].Length);
            CountCharFrequency(data);
            Gamma = GetStrings();
            return true;
        }

        public void ProcessLifeSupport(string[] data)
        {
            var o2List = FindOxygenRating(data.ToList(), 0);
            Oxygen = o2List.Single();
            var co2List = FindCO2Rating(data.ToList(), 0);
            CO2 = co2List.Single();
        }

        public List<string> FindOxygenRating(List<string> data, int index)
        {
            if (index < data[0].Length)
            {
                int total = data.Count;
                var ones = data.Where(s => s[index] == '1').ToList();
                if (ones.Count >= total - ones.Count)
                {
                    if (ones.Count == 1)
                        return ones;
                    return FindOxygenRating(ones, index + 1);
                }
                else
                {
                    var zeroes = data.Where(s => s[index] != '1').ToList();
                    if (zeroes.Count == 1)
                        return zeroes;
                    return FindOxygenRating(zeroes, index + 1);
                }
            }
            return data;
        }

        public List<string> FindCO2Rating(List<string> data, int index)
        {
            if (index < data[0].Length)
            {
                int total = data.Count;
                var ones = data.Where(s => s[index] == '1').ToList();
                if (ones.Count < total - ones.Count)
                {
                    if (ones.Count == 1)
                        return ones;
                    return FindCO2Rating(ones, index + 1);
                }
                else
                {
                    var zeroes = data.Where(s => s[index] != '1').ToList();
                    if (zeroes.Count == 1)
                        return zeroes;
                    return FindCO2Rating(zeroes, index + 1);
                }

            }
            return data;
        }

        public long CalcLifeSupportValue()
        {
            return Convert.ToInt32(Oxygen, 2) * Convert.ToInt32(CO2, 2);
        }
    }
}
