using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Xunit;
using System.Diagnostics;
using days.day07;

namespace days.test
{
    public class Day07UnitTests
    {
        [Fact(Skip = "Not using")]
        public void Day07_ParseDataToDictionarys_ok()
        {
            string datapath = "day07.txt";
            var rows = File.ReadAllLines(datapath);
            Assert.Equal(101, rows.Length);
            List<string> values = new List<string>();
            Dictionary<string, List<string>> steps = new Dictionary<string, List<string>>();
            foreach (var row in rows)
            {
                var items = row.Split(new char[]{' '});
                var key = items[1];
                if (steps.ContainsKey(key))
                {
                    steps[key].Add(items[7]);
                }
                else
                {
                    List<string> list = new List<string>();
                    list.Add(items[7]);
                    steps.Add(key, list);
                }
                if (!values.Contains(items[7]))
                {
                    values.Add(items[7]);
                }
            }
            foreach (var key in steps.Keys)
            {
                Debug.WriteLine($"Key: {key}");
            }
            foreach (var val in values)
            {
                Debug.WriteLine($"Value: {val}");
            }
            Assert.Equal(25, steps.Count);
            Assert.Equal(22, values.Count); 
        }

        [Fact]
        public void Day07_ParseDataToRulesListTest_ok()
        {
            string datapath = "day07t.txt";

            InstructionComparer sut = new InstructionComparer(datapath);
            foreach (var step in sut.Steps)
            {
                Debug.WriteLine($"Step: {step}");
            }
            Assert.Equal(6, sut.Steps.Count);
            Assert.Equal(7, sut.Rules.Count); 
            sut.Steps.Sort(sut.CompareRules);
            foreach (var step in sut.Steps)
            {
                Debug.WriteLine($"Sorted step: {step}");
            }
            string expected = "CABDFE";
            string[] actualArr = sut.Steps.ToArray();
            string actual = string.Join("", actualArr);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Day07_ParseDataToRulesList_ok()
        {
            string datapath = "day07.txt";

            InstructionComparer sut = new InstructionComparer(datapath);
            foreach (var step in sut.Steps)
            {
                Debug.WriteLine($"Step: {step}");
            }
            Assert.Equal(26, sut.Steps.Count);
            Assert.Equal(101, sut.Rules.Count); 
            sut.Steps.Sort(sut.CompareRules);
            foreach (var step in sut.Steps)
            {
                Debug.WriteLine($"Sorted step: {step}");
            }
            string expected = "ACDFKBENQTHJMOWIZULPRSXVGY";
            string[] actualArr = sut.Steps.ToArray();
            string actual = string.Join("", actualArr);
            Assert.Equal(expected, actual);
        }
    }
}
