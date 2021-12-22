using System;
using System.Collections.Generic;
using System.Text;

namespace AdventCode2021
{
    public class ConwayCubeReactor
    {
        public List<RebootCommand> Commands { get; set; }
        public HashSet<Cube> Cubes { get; set; }
        public ConwayCubeReactor(string[] lines)
        {
            Commands = new List<RebootCommand>();
            foreach (var line in lines)
            {
                Commands.Add(new RebootCommand(line));
            }
        }

        public long DoReboot50()
        {
            Cubes = new HashSet<Cube>();

            foreach (var cmd in Commands)
            {
                var hs = cmd.Make50Cubes();
                if (hs.Count > 0)
                {
                    if (cmd.On)
                    {
                        Cubes.UnionWith(hs);
                    }
                    else
                    {
                        Cubes.ExceptWith(hs);
                    }
                }
            }
            return Cubes.Count;
        }
    }

    public class RebootCommand
    {
        public bool On { get; set; }
        public int X1 { get; set; }
        public int X2 { get; set; }

        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public int Z1 { get; set; }
        public int Z2 { get; set; }

        public RebootCommand(string line)
        {
            var parts = line.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
            On = (parts[0] == "on");
            var t = ParseDimension(parts[1]);
            X1 = t.Item1;
            X2 = t.Item2;
            t = ParseDimension(parts[2]);
            Y1 = t.Item1;
            Y2 = t.Item2;
            t = ParseDimension(parts[3]);
            Z1 = t.Item1;
            Z2 = t.Item2;
        }

        public HashSet<Cube> Make50Cubes()
        {
            HashSet<Cube> cubes = new HashSet<Cube>();
            var tx = TrimTo50(X1, X2);
            var ty = TrimTo50(Y1, Y2);
            var tz = TrimTo50(Z1, Z2);

            if (tx != null && ty != null && tz != null)
            {
                for (int z = tz.Item1; z <= tz.Item2; z++)
                {
                    for (int y = ty.Item1; y <= ty.Item2; y++)
                    {
                        for (int x = tx.Item1; x <= tx.Item2; x++)
                        {
                            cubes.Add(new Cube(x, y, z));
                        }
                    }
                }
            }
            return cubes;
        }

        public Tuple<int, int> TrimTo50(int a, int b)
        {
            if (a > 50 || b < -50)
                return null;

            int min = a;
            int max = b;
            if (a < -50)
            {
                min = -50;
            }
            if (b > 50)
                max = 50;
            return new Tuple<int, int>(min, max);
        }

        public Tuple<int, int> ParseDimension(string dimension)
        {
            var parts = dimension.Split(new string[] { "=", ".." }, StringSplitOptions.RemoveEmptyEntries);

            int a = int.Parse(parts[1]);
            int b = int.Parse(parts[2]);
            if (a > b)
                throw new ArgumentOutOfRangeException("a", "a > b");
            return new Tuple<int, int>(a, b);
        }
    }
}
