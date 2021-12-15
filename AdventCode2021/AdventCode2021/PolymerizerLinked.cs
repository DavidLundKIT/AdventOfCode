using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventCode2021
{
    /// <summary>
    /// BUST runs out of memory for Puzzle 2
    /// </summary>
    public class PolymerizerLinked
    {
        public string Template
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                Element cur = Start;
                do
                {
                    sb.Append(cur.Value);
                    cur = cur.Next;
                } while (cur != null);
                return sb.ToString();
            }
        }

        public Dictionary<string, char> Converter { get; set; }

        public Element Start { get; set; }

        public PolymerizerLinked(string[] lines)
        {
            Converter = new Dictionary<string, char>();
            var chs = lines[0].ToCharArray();

            Start = new Element(chs[0]);

            var prev = Start;
            for (int i = 1; i < chs.Length; i++)
            {
                var cur = new Element(chs[i]);
                prev.Next = cur;
                prev = cur;
            }

            for (int i = 2; i < lines.Length; i++)
            {
                var parts = lines[i].Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                Converter.Add(parts[0], parts[1][0]);
            }
        }
        public void PairInsertion()
        {
            Element cur = Start;
            do
            {
                if (cur.Next == null)
                    break;
                var key = $"{cur.Value}{cur.Next.Value}";
                var elem = new Element(Converter[key]);
                elem.Next = cur.Next;
                cur.Next = elem;
                cur = elem.Next;
            } while (cur != null);
        }

        public long QuantityOfElements()
        {
            Dictionary<char, long> elems = new Dictionary<char, long>();

            var cur = Start;

            do
            {

                if (elems.ContainsKey(cur.Value))
                    elems[cur.Value]++;
                else
                    elems.Add(cur.Value, 1);
                cur = cur.Next;
            } while (cur != null);

            long max = elems.Values.Max();
            long min = elems.Values.Min();
            return max - min;
        }

        public class Element
        {
            public Element Next { get; set; }
            public char Value { get; set; }

            public Element(char ch)
            {
                Value = ch;
            }
        }
    }
}
