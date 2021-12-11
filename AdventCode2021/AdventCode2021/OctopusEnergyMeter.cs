namespace AdventCode2021
{
    public class OctopusEnergyMeter
    {
        public const int KGrid = 10;
        public int TotalFlashes { get; set; }
        public Octopus[,] OctopusGrid { get; set; }
        public int Synchronized { get; set; }

        public OctopusEnergyMeter(string[] lines)
        {
            OctopusGrid = new Octopus[KGrid, KGrid];

            for (int y = 0; y < KGrid; y++)
            {
                var chs = lines[y].ToCharArray();
                for (int x = 0; x < KGrid; x++)
                {
                    OctopusGrid[x, y] = new Octopus(x, y, (int)(chs[x] - '0'), OctopusGrid);
                }
            }
            TotalFlashes = 0;
            Synchronized = int.MaxValue;
        }

        public void IncreaseEnergy()
        {
            for (int i = 0; i < KGrid; i++)
            {
                for (int j = 0; j < KGrid; j++)
                {
                    OctopusGrid[i, j].Inc();
                }
            }
        }

        public int FindOctopusFlashes()
        {
            int flashes = 0;
            for (int i = 0; i < KGrid; i++)
            {
                for (int j = 0; j < KGrid; j++)
                {
                    flashes += OctopusGrid[i, j].HasFlashed();
                }
            }
            return flashes;
        }

        public void DoStep(int step)
        {
            IncreaseEnergy();
            int flashes = FindOctopusFlashes();
            if (flashes == 100)
                Synchronized = step;
            TotalFlashes += flashes;
        }
    }

    public class Octopus
    {
        public int Energy { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Flashed { get; set; }
        public Octopus[,] Octopi { get; set; }
        public Octopus(int x, int y, int energy, Octopus[,] octopi)
        {
            X = x;
            Y = y;
            Energy = energy;
            Flashed = false;
            Octopi = octopi;
        }

        public void Inc()
        {
            Energy++;
            if (Energy == 10 && !Flashed)
            {
                Flashed = true;
                for (int x = X - 1; x <= X + 1; x++)
                {
                    for (int y = Y - 1; y <= Y + 1; y++)
                    {
                        Energize(x, y);
                    }
                }
            }
        }

        public int HasFlashed()
        {
            if (!Flashed)
                return 0;
            Flashed = false;
            Energy = 0;
            return 1;
        }

        public void Energize(int x, int y)
        {
            if (0 <= x && x <= 9 && 0 <= y && y <= 9)
            {
                Octopi[x, y].Inc();
            }
        }
    }
}
