namespace AdventCode2022.Models
{
    public class SurfaceAreaCalculator
    {
        public Dictionary<Tuple<int, int, int>, int> Cubes { get; set; }

        public int Xmin { get; set; }
        public int Xmax { get; set; }
        public int Ymin { get; set; }
        public int Ymax { get; set; }
        public int Zmin { get; set; }
        public int Zmax { get; set; }

        public SurfaceAreaCalculator()
        {
            Cubes = new Dictionary<Tuple<int, int, int>, int>();
        }

        public void AddCubes(string[] lines)
        {
            Cubes.Clear();
            foreach (var line in lines)
            {
                AddCube(line);
            }
        }

        public void AddCube(string line)
        {
            var parts = line.Split(',');
            Tuple<int, int, int> pt = new Tuple<int, int, int>(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
            if (Cubes.ContainsKey(pt))
            {
                Cubes[pt] += 1;
            }
            else
            {
                Cubes.Add(pt, 1);
            }
        }

        public int SurfaceArea()
        {
            int areaTotal = 0;
            foreach (var cube in Cubes.Keys)
            {
                int cubeArea = SurfaceAreaCube(cube);
                areaTotal += cubeArea;
            }
            return areaTotal;
        }

        public int SurfaceAreaCube(Tuple<int, int, int> cube)
        {
            int freeSide = 0;
            if (!Cubes.ContainsKey(new Tuple<int, int, int>(cube.Item1 - 1, cube.Item2, cube.Item3)))
                freeSide++;
            if (!Cubes.ContainsKey(new Tuple<int, int, int>(cube.Item1 + 1, cube.Item2, cube.Item3)))
                freeSide++;
            if (!Cubes.ContainsKey(new Tuple<int, int, int>(cube.Item1, cube.Item2 - 1, cube.Item3)))
                freeSide++;
            if (!Cubes.ContainsKey(new Tuple<int, int, int>(cube.Item1, cube.Item2 + 1, cube.Item3)))
                freeSide++;
            if (!Cubes.ContainsKey(new Tuple<int, int, int>(cube.Item1, cube.Item2, cube.Item3 - 1)))
                freeSide++;
            if (!Cubes.ContainsKey(new Tuple<int, int, int>(cube.Item1, cube.Item2, cube.Item3 + 1)))
                freeSide++;
            return freeSide;
        }

        public int SurfaceAreaExternalOnly()
        {
            int areaTotal = 0;
            FloodFillOutside();
            foreach (var cube in Cubes.Keys)
            {
                if (Cubes[cube] != -1)
                {
                    int cubeArea = SurfaceAreaCubeExternalOnly(cube);
                    areaTotal += cubeArea;
                }
            }
            return areaTotal;
        }

        public int SurfaceAreaCubeExternalOnly(Tuple<int, int, int> cube)
        {
            int freeSide = 0;
            if (IsFreeSide(new Tuple<int, int, int>(cube.Item1 - 1, cube.Item2, cube.Item3)))
                freeSide++;
            if (IsFreeSide(new Tuple<int, int, int>(cube.Item1 + 1, cube.Item2, cube.Item3)))
                freeSide++;
            if (IsFreeSide(new Tuple<int, int, int>(cube.Item1, cube.Item2 - 1, cube.Item3)))
                freeSide++;
            if (IsFreeSide(new Tuple<int, int, int>(cube.Item1, cube.Item2 + 1, cube.Item3)))
                freeSide++;
            if (IsFreeSide(new Tuple<int, int, int>(cube.Item1, cube.Item2, cube.Item3 - 1)))
                freeSide++;
            if (IsFreeSide(new Tuple<int, int, int>(cube.Item1, cube.Item2, cube.Item3 + 1)))
                freeSide++;
            return freeSide;
        }

        public bool IsFreeSide(Tuple<int, int, int> cube)
        {
            return (Cubes.ContainsKey(cube) && Cubes[cube] == -1);
        }

        public void FloodFillOutside()
        {
            Xmin = Cubes.Keys.Min(t => t.Item1) - 1;
            Xmax = Cubes.Keys.Max(t => t.Item1) + 1;
            Ymin = Cubes.Keys.Min(t => t.Item2) - 1;
            Ymax = Cubes.Keys.Max(t => t.Item2) + 1;
            Zmin = Cubes.Keys.Min(t => t.Item3) - 1;
            Zmax = Cubes.Keys.Max(t => t.Item3) + 1;

            FloodFill(new Tuple<int, int, int>(Xmin, Ymin, Zmin), -1);
        }

        public  void FloodFill(Tuple<int, int, int> cube, int fillValue)
        {
            Stack<Tuple<int, int, int>> externalCubes = new Stack<Tuple<int, int, int>>();
            externalCubes.Push(cube);

            while (externalCubes.Count > 0)
            {
                var a = externalCubes.Pop();
                if (a.Item1 >= Xmin && a.Item1 <= Xmax
                    && a.Item2 >= Ymin && a.Item2 <= Ymax
                    && a.Item3 >= Zmin && a.Item3 <= Zmax)
                {
                    // with in bounds
                    if (!Cubes.ContainsKey(a))
                    {
                        // not in must be external
                        Cubes.Add(a, fillValue);
                        externalCubes.Push(new Tuple<int, int, int>(a.Item1 - 1, a.Item2, a.Item3));
                        externalCubes.Push(new Tuple<int, int, int>(a.Item1 + 1, a.Item2, a.Item3));
                        externalCubes.Push(new Tuple<int, int, int>(a.Item1, a.Item2 - 1, a.Item3));
                        externalCubes.Push(new Tuple<int, int, int>(a.Item1, a.Item2 + 1, a.Item3));
                        externalCubes.Push(new Tuple<int, int, int>(a.Item1, a.Item2, a.Item3 - 1));
                        externalCubes.Push(new Tuple<int, int, int>(a.Item1, a.Item2, a.Item3 + 1));
                    }
                }
            }
        }
    }
}
