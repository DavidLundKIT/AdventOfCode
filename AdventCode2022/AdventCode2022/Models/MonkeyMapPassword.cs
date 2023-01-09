using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2022.Models
{
    public class MonkeyMapPassword
    {
        public Dictionary<Tuple<long, long>, char> Map { get; set; }
        public string Instructions { get; set; }

        public MonkeyMapPassword(List<string> lines)
        {
            Instructions = lines[lines.Count - 1];
            lines.RemoveAt(lines.Count - 1);

            Map = new Dictionary<Tuple<long, long>, char>();
            for (int y = 0; y < lines.Count; y++)
            {
                var line = lines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x] != ' ')
                    {
                        Map.Add(new Tuple<long, long>(x, y), line[x]);
                    }
                }
            }
        }

    }
}
