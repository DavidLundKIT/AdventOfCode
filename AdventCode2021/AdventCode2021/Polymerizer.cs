using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventCode2021
{
    /// <summary>
    /// BUST runs out of memory for Puzzle2
    /// </summary>
    public class Polymerizer
    {
        public string Template { get; set; }

        public Dictionary<string, string> Converter { get; set; }

        public Polymerizer(string[] lines)
        {
            Converter = new Dictionary<string, string>();
            Template = lines[0];

            for (int i = 2; i < lines.Length; i++)
            {
                var parts = lines[i].Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                Converter.Add(parts[0], parts[1]);
            }
        }

        public void PairInsertion()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Template.Length - 1; i++)
            {
                var key = Template.Substring(i, 2);
                var val = Converter[key];
                var chs = key.ToCharArray();
                sb.Append(chs[0]);
                sb.Append(val);
            }
            // add last ch
            sb.Append(Template.Substring(Template.Length - 1, 1));
            Template = sb.ToString();
        }

        public long QuantityOfElements()
        {
            Dictionary<char, long> elems = new Dictionary<char, long>();
            var chs = Template.ToCharArray();
            foreach (var ch in chs)
            {
                if (elems.ContainsKey(ch))
                    elems[ch]++;
                else
                    elems.Add(ch, 1);
            }

            long max = elems.Values.Max();
            long min = elems.Values.Min();
            return max - min;
        }
    }
}
