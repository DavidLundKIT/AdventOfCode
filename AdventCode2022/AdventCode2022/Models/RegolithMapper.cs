using System.Diagnostics;

namespace AdventCode2022.Models
{
    public class RegolithMapper
    {
        public Dictionary<Tuple<int, int>, string> Map { get; set; }

        public int Xmin { get; set; }
        public int Xmax { get; set; }
        public int Ymin { get; set; }
        public int Ymax { get; set; }

        public RegolithMapper()
        {
            Map = new Dictionary<Tuple<int, int>, string>();
        }

        public void MakeMap(string[] lines)
        {
            Map.Clear();
            foreach (var line in lines)
            {
                AddPath(line);
            }
            Map.Add(new Tuple<int, int>(500, 0), "+");
        }

        public void AddPath(string line)
        {
            var points = line.Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => s.Split(",", StringSplitOptions.RemoveEmptyEntries))
                            .Select(sp => new Tuple<int, int>(int.Parse(sp[0]), int.Parse(sp[1]))).ToList();
            for (int i = 0; i < points.Count - 1; i++)
            {
                AddPath(points[i], points[i + 1]);
            }
        }

        public void AddPath(Tuple<int, int> start, Tuple<int, int> end)
        {
            if (start.Item1 == end.Item1)
            {
                // over y
                if (start.Item2 < end.Item2)
                {
                    AddPathY(start.Item1, start.Item2, end.Item2);
                }
                else
                {
                    AddPathY(start.Item1, end.Item2, start.Item2);
                }
            }
            else
            {
                // over x
                if (start.Item1 < end.Item1)
                {
                    AddPathX(start.Item1, end.Item1, start.Item2);
                }
                else
                {
                    AddPathX(end.Item1, start.Item1, start.Item2);
                }
            }
        }

        public void AddPathY(int x, int startY, int endY)
        {
            for (int i = startY; i <= endY; i++)
            {
                var pt = new Tuple<int, int>(x, i);
                if (!Map.ContainsKey(pt))
                    Map.Add(pt, "#");
                else
                    Map[pt] = "#";
            }
        }

        public void AddPathX(int startX, int endX, int y)
        {
            for (int i = startX; i <= endX; i++)
            {
                var pt = new Tuple<int, int>(i, y);
                if (!Map.ContainsKey(pt))
                    Map.Add(pt, "#");
                else
                    Map[pt] = "#";
            }
        }

        public void InitBorders()
        {
            Xmin = Map.Keys.Min(p => p.Item1);
            Xmax = Map.Keys.Max(p => p.Item1);
            Ymin = Map.Keys.Min(p => p.Item2);
            Ymax = Map.Keys.Max(p => p.Item2);
        }

        public void DumpMap()
        {
            InitBorders();

            Debug.WriteLine("========= MAP =====================");
            for (int y = Ymin; y <= Ymax; y++)
            {
                for (int x = Xmin; x <= Xmax; x++)
                {
                    var pt = new Tuple<int, int>(x, y);
                    if (!Map.ContainsKey(pt))
                        Debug.Write(".");
                    else
                        Debug.Write(Map[pt]);
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("========= DONE ====================");
        }

        public int DropSandTillOverflow()
        {
            int count = 0;

            while (DropSandUnit())
            {
                count++;
            }
            return count;
        }

        public bool DropSandUnit()
        {
            var pt = new Tuple<int, int>(500, 0);
            while (OnMap(pt))
            {
                var ptNext = Blocked(pt);
                if (ptNext == pt)
                {
                    // blocked
                    Map.Add(pt, "o");
                    break;
                }
                pt = ptNext;
            }
            return OnMap(pt);
        }

        public bool OnMap(Tuple<int, int> pt)
        {
            return (Xmin <= pt.Item1 && pt.Item1 <= Xmax
                && Ymin <= pt.Item2 && pt.Item2 <= Ymax);
        }

        public Tuple<int, int> Blocked(Tuple<int, int> pt)
        {
            var ptNext = new Tuple<int, int>(pt.Item1, pt.Item2 + 1);
            if (!Map.ContainsKey(ptNext))
                return ptNext;
            // try left
            ptNext = new Tuple<int, int>(pt.Item1 - 1, pt.Item2 + 1);
            if (!Map.ContainsKey(ptNext))
                return ptNext;
            // try right
            ptNext = new Tuple<int, int>(pt.Item1 + 1, pt.Item2 + 1);
            if (!Map.ContainsKey(ptNext))
                return ptNext;
            // nowhere to go,
            return pt;
        }

        public int DropSandTillBlockedSpout()
        {
            int count = 0;

            while (DropSandUnitUntilBlockedSpout())
            {
                count++;
            }
            return count;
        }

        public void AddInfiniteFloor()
        {
            InitBorders();
            Ymax += 2;
            for (int x = Xmin - Ymax; x <= Xmax + Ymax; x++)
            {
                Map.Add(new Tuple<int, int>(x, Ymax), "#");
            }
        }

        public bool DropSandUnitUntilBlockedSpout()
        {
            var pt = new Tuple<int, int>(500, 0);
            var ptNext = Blocked(pt);
            if (ptNext == pt)
            {
                // blocked
                Map[pt] = "*";
                return false;
            }

            while (OnMap(pt))
            {
                ptNext = Blocked(pt);
                if (ptNext == pt)
                {
                    // blocked
                    Map.Add(pt, "o");
                    break;
                }
                pt = ptNext;
            }
            return OnMap(pt);
        }
    }
}
