using AdventOfCode2020;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DailyXUnitTests
{
    public class Day10AdapterArrayUnitTests
    {
        [Fact(Skip = "Daily completed")]
        public void Day10ReadData_OK()
        {
            var adapters = DailyDataUtilities.ReadLongsFromFile("Day10Data.txt");
            Assert.Equal(103, adapters.Count);
        }

        [Fact(Skip = "Daily completed")]
        public void Day10AdapterCheck_Example1_Part1_OK()
        {
            List<long> adapters = new List<long>() { 16,
                10,
                15,
                5,
                1,
                11,
                7,
                19,
                6,
                12,
                4
            };

            adapters.Sort();
            adapters.Insert(0, 0);
            adapters.Add(adapters[adapters.Count - 1] + 3);
            List<long> diffs = new List<long>();
            for (int i = 0; i < adapters.Count - 1; i++)
            {
                diffs.Add(adapters[i + 1] - adapters[i]);
            }
            var ones = diffs.Where(d => d == 1).Count();
            var threes = diffs.Where(d => d == 3).Count();

            Assert.Equal(35, ones * threes);

            Dictionary<long, int> combos = new Dictionary<long, int>();
            // the first has to exist
            combos.Add(0, 1);
            for (int idx = 1; idx < adapters.Count; idx++)
            {
                combos.Add(adapters[idx], 0);
                if (combos.ContainsKey(adapters[idx] - 1))
                {
                    combos[adapters[idx]] += combos[adapters[idx] - 1];
                }
                if (combos.ContainsKey(adapters[idx] - 2))
                {
                    combos[adapters[idx]] += combos[adapters[idx] - 2];
                }
                if (combos.ContainsKey(adapters[idx] - 3))
                {
                    combos[adapters[idx]] += combos[adapters[idx] - 3];
                }
            }
            Assert.Equal(8, combos[adapters.Max()]);
        }

        [Fact(Skip = "Daily completed")]
        public void Day10AdapterCheck_Example2_OK()
        {
            List<long> adapters = new List<long>() { 28,
                33,
                18,
                42,
                31,
                14,
                46,
                20,
                48,
                47,
                24,
                23,
                49,
                45,
                19,
                38,
                39,
                11,
                1,
                32,
                25,
                35,
                8,
                17,
                7,
                9,
                4,
                2,
                34,
                10,
                3
            };
            adapters.Sort();
            adapters.Insert(0, 0);
            adapters.Add(adapters[adapters.Count - 1] + 3);
            List<long> diffs = new List<long>();
            for (int i = 0; i < adapters.Count - 1; i++)
            {
                diffs.Add(adapters[i + 1] - adapters[i]);
            }
            var ones = diffs.Where(d => d == 1).Count();
            var threes = diffs.Where(d => d == 3).Count();

            Assert.Equal(220, ones * threes);

            Dictionary<long, int> combos = new Dictionary<long, int>();
            // the first has to exist
            combos.Add(0, 1);
            for (int idx = 1; idx < adapters.Count; idx++)
            {
                combos.Add(adapters[idx], 0);
                if (combos.ContainsKey(adapters[idx] - 1))
                {
                    combos[adapters[idx]] += combos[adapters[idx] - 1];
                }
                if (combos.ContainsKey(adapters[idx] - 2))
                {
                    combos[adapters[idx]] += combos[adapters[idx] - 2];
                }
                if (combos.ContainsKey(adapters[idx] - 3))
                {
                    combos[adapters[idx]] += combos[adapters[idx] - 3];
                }
            }

            Assert.Equal(19208, combos[adapters.Max()]);
        }

        [Fact(Skip = "Daily completed")]
        public void Day10AdapterCheck_Part1_and_Part2_OK()
        {
            var adapters = DailyDataUtilities.ReadLongsFromFile("Day10Data.txt");
            Assert.Equal(103, adapters.Count);

            adapters.Sort();
            adapters.Insert(0, 0);
            adapters.Add(adapters[adapters.Count - 1] + 3);
            List<long> diffs = new List<long>();
            for (int i = 0; i < adapters.Count - 1; i++)
            {
                diffs.Add(adapters[i + 1] - adapters[i]);
            }
            var ones = diffs.Where(d => d == 1).Count();
            var threes = diffs.Where(d => d == 3).Count();

            Assert.Equal(2343, ones * threes);

            Dictionary<long, long> combos = new Dictionary<long, long>();
            // the first has to exist
            combos.Add(0, 1);
            for (int idx = 1; idx < adapters.Count; idx++)
            {
                combos.Add(adapters[idx], 0);
                if (combos.ContainsKey(adapters[idx] - 1))
                {
                    combos[adapters[idx]] += combos[adapters[idx] - 1];
                }
                if (combos.ContainsKey(adapters[idx] - 2))
                {
                    combos[adapters[idx]] += combos[adapters[idx] - 2];
                }
                if (combos.ContainsKey(adapters[idx] - 3))
                {
                    combos[adapters[idx]] += combos[adapters[idx] - 3];
                }
            }

            Assert.Equal(31581162962944, combos[adapters.Max()]);
        }
    }
}
