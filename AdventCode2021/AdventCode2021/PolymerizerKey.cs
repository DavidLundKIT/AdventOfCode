using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCode2021
{
    /// <summary>
    /// BUST also good on memory but 40!+ calculations
    /// </summary>
    public class PolymerizerKey
    {
        public string Template { get; set; }
        public Dictionary<string, string> Converter { get; set; }
        public Dictionary<char, long> Elems { get; set; }

        public PolymerizerKey(string[] lines)
        {
            Converter = new Dictionary<string, string>();
            Elems = new Dictionary<char, long>();

            Template = lines[0];

            for (int i = 2; i < lines.Length; i++)
            {
                var parts = lines[i].Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                Converter.Add(parts[0], parts[1]);
            }
        }

        public void PairInsertion(int iterations)
        {
            for (int i = 0; i < Template.Length - 1; i++)
            {
                var key = Template.Substring(i, 2);
                AllIterationsForPair(key, iterations);
            }
            // add in last char
            char ch = Template[Template.Length - 1];
            if (Elems.ContainsKey(ch))
                Elems[ch]++;
            else
                Elems.Add(ch, 1);
        }

        public void AllIterationsForPair(string pair, int iterations)
        {
            Stack<string> stack = new Stack<string>();
            var key = pair;
            for (int iter = 0; iter < iterations; iter++)
            {
                var val = Converter[key];
                var ch = key[1];
                key = $"{key[0]}{val}";
                stack.Push($"{val}{ch}");
            }
            QuantifyElements(key);
            stack.Pop();
            while (stack.Count > 0)
            {
                AllIterationsForPair(stack.Peek(), iterations - stack.Count);
                stack.Pop();
            }
        }

        public void QuantifyElements(string pair)
        {
            var chs = pair.ToCharArray();
            foreach (var ch in chs)
            {
                if (Elems.ContainsKey(ch))
                    Elems[ch]++;
                else
                    Elems.Add(ch, 1);
            }
        }

        public long QuantityOfElements()
        {
            long max = Elems.Values.Max();
            long min = Elems.Values.Min();
            return max - min;
        }
    }
}
