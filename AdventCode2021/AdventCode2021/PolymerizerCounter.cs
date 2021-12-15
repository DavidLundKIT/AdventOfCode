using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCode2021
{
    /// <summary>
    /// This is the winner!
    /// </summary>
    public class PolymerizerCounter
    {
        public string Template { get; set; }
        public Dictionary<string, string> Converter { get; set; }
        public Dictionary<char, long> Elems { get; set; }
        public Dictionary<string, long> Pairs { get; set; }
        public Dictionary<string, long> NewPairs { get; set; }

        public PolymerizerCounter(string[] lines)
        {
            Converter = new Dictionary<string, string>();
            Elems = new Dictionary<char, long>();
            Pairs = new Dictionary<string, long>();
            NewPairs = new Dictionary<string, long>();

            Template = lines[0];

            for (int i = 2; i < lines.Length; i++)
            {
                var parts = lines[i].Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                Converter.Add(parts[0], parts[1]);
            }

            Init();
        }

        public void Init()
        {
            for (int i = 0; i < Template.Length; i++)
            {
                // add in template characters
                char ch = Template[i];
                if (Elems.ContainsKey(ch))
                    Elems[ch]++;
                else
                    Elems.Add(ch, 1);
            }

            // add in pairs
            for (int i = 0; i < Template.Length - 1; i++)
            {
                var key = Template.Substring(i, 2);
                if (Pairs.ContainsKey(key))
                    Pairs[key]++;
                else
                    Pairs.Add(key, 1);
            }
        }

        public long QuantityOfElements()
        {
            long max = Elems.Values.Max();
            long min = Elems.Values.Min();
            return max - min;
        }

        public void PairInsertion()
        {
            NewPairs = new Dictionary<string, long>();

            foreach (var pair in Pairs)
            {
                char ch = Converter[pair.Key][0];
                if (Elems.ContainsKey(ch))
                    Elems[ch] += pair.Value;
                else
                    Elems.Add(ch, pair.Value);

                AddNewPair($"{pair.Key[0]}{ch}", pair.Value);
                AddNewPair($"{ch}{pair.Key[1]}", pair.Value);
            }

            Pairs = NewPairs;
        }

        public void AddNewPair(string key, long val)
        {
            if (NewPairs.ContainsKey(key))
                NewPairs[key] += val;
            else
                NewPairs.Add(key, val);
        }
    }
}
