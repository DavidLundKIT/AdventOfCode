using System.Collections.Generic;
using System.Linq;

namespace AdventCodeLib
{
    public class pgm
    {
        public pgm()
        {
            PgmList = new List<string>();
        }

        public string Name { get; set; }
        public int Weight { get; set; }
        public List<string> PgmList { get; set; }
    }

    public class Day07RecursiveCircus
    {
        public Day07RecursiveCircus()
        {
            Progs = new Dictionary<string, pgm>();
        }

        public Dictionary<string, pgm> Progs { get; set; }

        public List<pgm> ReadData(string path)
        {
            List<pgm> list = new List<pgm>();

            var rows = DataTools.ReadAllLines(path);

            foreach (var row in rows)
            {
                var p = ParseRow(row);
                list.Add(p);
            }
            return list;
        }

        private pgm ParseRow(string row)
        {
            pgm p = new pgm();
            var vals = row.Split(new char[] { ' ', ',' });
            p.Name = vals[0];
            p.Weight = int.Parse(vals[1].Replace("(", string.Empty).Replace(")", string.Empty));
            if (vals.Length > 2)
            {
                for (int i = 3; i < vals.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(vals[i]))
                        p.PgmList.Add(vals[i]);
                }
            }
            return p;
        }

        public pgm FindRoot(List<pgm> pgmList)
        {
            pgm root = null;
            foreach (var p in pgmList)
            {
                foreach (string item in p.PgmList)
                {
                    Progs.Add(item, pgmList.Single(c => c.Name.Equals(item)));
                }
            }

            foreach (var p in pgmList)
            {
                if (!Progs.ContainsKey(p.Name))
                {
                    root = p;
                }
            }
            return root;
        }

        public int WeightSum(pgm node)
        {
            int weight = node.Weight;
            if (node.PgmList.Count > 0)
            {
                int? sum = null;
                int diff = 0;
                int idiff = 0;
                int isum = 0;
                foreach (var key in node.PgmList)
                {
                    int w = WeightSum(Progs[key]);
                    if (sum.HasValue && sum.Value != w)
                    {
                        // unbalanced!
                        diff = w;
                        idiff++;
                    }
                    else
                    {
                        sum = w;
                        isum++;
                    }

                    if (idiff != 0 && isum != 0)
                    {
                        // unbalanced!
                        int Guess = sum.Value - diff;
                    }
                    weight += w;
                }
            }
            return weight;
        }
    }
}
