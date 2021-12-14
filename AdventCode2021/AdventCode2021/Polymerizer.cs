using System;
using System.Collections.Generic;
using System.Text;

namespace AdventCode2021
{
    public class Polymerizer
    {
        public string Template { get; set; }

        public Dictionary<string,string> Converter { get; set; }

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
    }
}
