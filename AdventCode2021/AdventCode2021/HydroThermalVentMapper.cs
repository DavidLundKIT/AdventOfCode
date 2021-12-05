using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCode2021
{
    public class HydroThermalVentMapper
    {
        public List<Vent> Vents { get; set; }
        public Dictionary<string, int> MapHV { get; set; }

        public HydroThermalVentMapper(string[] lines)
        {
            Vents = new List<Vent>();
            foreach (var line in lines)
            {
                Vents.Add(new Vent(line));
            }
        }

        public int MapVents(bool all)
        {
            MapHV = new Dictionary<string, int>();
            foreach (var vent in Vents)
            {
                List<Point> points = all ? vent.GetPointsHVD() : vent.GetPointsHV();
                foreach (var point in points)
                {
                    string key = point.ToString();
                    if (MapHV.ContainsKey(key))
                    {
                        MapHV[key] += 1;
                    }
                    else
                    {
                        MapHV.Add(key, 1);
                    }
                }
            }

            return MapHV.Values.Where(v => v > 1).Count();
        }
    }

    public class Vent
    {
        public Point A { get; set; }
        public Point B { get; set; }

        public Vent(string line)
        {
            var vals = line.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            A = new Point(vals[0]);
            B = new Point(vals[1]);
        }

        public List<Point> GetPointsHV()
        {
            List<Point> list = new List<Point>();
            if (A.X == B.X)
            {
                int ymin = Math.Min(A.Y, B.Y);
                int ymax = Math.Max(A.Y, B.Y);
                for (int y = ymin; y <= ymax; y++)
                {
                    list.Add(new Point(A.X, y));
                }
            }
            if (A.Y == B.Y)
            {
                int xmin = Math.Min(A.X, B.X);
                int xmax = Math.Max(A.X, B.X);
                for (int x = xmin; x <= xmax; x++)
                {
                    list.Add(new Point(x, A.Y));
                }
            }
            return list;
        }

        public List<Point> GetPointsHVD()
        {
            List<Point> list = GetPointsHV();
            if (A.X != B.X && A.Y != B.Y)
            {
                // 45 degree lines
                int slope = (B.Y - A.Y) / (B.X - A.X);
                int rslope = (B.Y - A.Y) % (B.X - A.X);
                if (Math.Abs(slope) == 1 && rslope == 0)
                {
                    int c = A.Y - slope * A.X;
                    int xmin = Math.Min(A.X, B.X);
                    int xmax = Math.Max(A.X, B.X);
                    for (int x = xmin; x <= xmax; x++)
                    {
                        int y = slope * x + c;
                        list.Add(new Point(x, y));
                    }
                }

            }
            return list;
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(string line)
        {
            var vals = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            X = int.Parse(vals[0]);
            Y = int.Parse(vals[1]);
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }
    }
}
