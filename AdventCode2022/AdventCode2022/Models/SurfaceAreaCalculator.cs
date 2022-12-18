namespace AdventCode2022.Models
{
    public class SurfaceAreaCalculator
    {
        public Dictionary<Tuple<int, int, int>, int> Cubes { get; set; }

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

        public int SurfaceAreaExternalOnly()
        {
            int areaTotal = 0;
            foreach (var cube in Cubes.Keys)
            {
                int cubeArea = SurfaceAreaCubeExternalOnly(cube);
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
            if (Cubes.ContainsKey(cube))
            {
                // cube exists not air pocket for side
                return false;
            }
            // check other sides for enclosed air pocket
            if (Cubes.ContainsKey(new Tuple<int, int, int>(cube.Item1 - 1, cube.Item2, cube.Item3))
                && Cubes.ContainsKey(new Tuple<int, int, int>(cube.Item1 + 1, cube.Item2, cube.Item3))
                && Cubes.ContainsKey(new Tuple<int, int, int>(cube.Item1, cube.Item2 - 1, cube.Item3))
                && Cubes.ContainsKey(new Tuple<int, int, int>(cube.Item1, cube.Item2 + 1, cube.Item3))
                && Cubes.ContainsKey(new Tuple<int, int, int>(cube.Item1, cube.Item2, cube.Item3 - 1))
                && Cubes.ContainsKey(new Tuple<int, int, int>(cube.Item1, cube.Item2, cube.Item3 + 1)))
            {
                // air pocket
                return false;
            }
            return true;
        }
    }
}
