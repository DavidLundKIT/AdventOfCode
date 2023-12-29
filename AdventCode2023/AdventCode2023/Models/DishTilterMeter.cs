using System.Diagnostics;

namespace AdventCode2023.Models
{
    public class DishTilterMeter
    {
        public char[,] DishOneCycle { get; set; }
        public char[,] Dish { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        // The dictionary:
        // the key is the load calculation.
        // the tuple is <count, last cycle, first cycle, second cycle>
        public Dictionary<long, Tuple<int, int, int, int>> LoadDict { get; set; }


        public DishTilterMeter(string[] lines)
        {
            LoadDict = new Dictionary<long, Tuple<int, int, int, int>>();
            MaxX = lines[0].Length;
            MaxY = lines.Length;
            Dish = new char[MaxX, MaxY];
            DishOneCycle = new char[MaxX, MaxY];
            for (int y = 0; y < MaxY; y++)
            {
                var tch = lines[y].ToCharArray();
                for (int x = 0; x < MaxX; x++)
                {
                    Dish[x, y] = tch[x];
                }
            }
        }

        public void TiltNorth()
        {
            for (var k = 0; k < MaxY; k++)
            {
                for (var x = 0; x < MaxX; x++)
                {
                    char ch = Dish[x, k];
                    if (ch == 'O' || ch == '#')
                    {
                        continue;
                    }
                    else
                    {
                        // can something fill this spot?
                        for (var y = k + 1; y < MaxY; y++)
                        {
                            char tch = Dish[x, y];
                            if (tch == 'O')
                            {
                                Dish[x, k] = 'O';
                                Dish[x, y] = '.';
                                break;
                            }
                            if (tch == '#')
                            {
                                // unmoveable rock
                                break;
                            }
                        }
                    }
                }
            }

        }

        public void TiltSouth()
        {
            for (var k = MaxY - 1; k >= 0; k--)
            {
                for (var x = 0; x < MaxX; x++)
                {
                    char ch = Dish[x, k];
                    if (ch == 'O' || ch == '#')
                    {
                        continue;
                    }
                    else
                    {
                        // can something fill this spot?
                        for (var y = k - 1; y >= 0; y--)
                        {
                            char tch = Dish[x, y];
                            if (tch == 'O')
                            {
                                Dish[x, k] = 'O';
                                Dish[x, y] = '.';
                                break;
                            }
                            if (tch == '#')
                            {
                                // unmoveable rock
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void TiltWest()
        {
            for (var k = 0; k < MaxX; k++)
            {
                for (var y = 0; y < MaxY; y++)
                {
                    char ch = Dish[k, y];
                    if (ch == 'O' || ch == '#')
                    {
                        continue;
                    }
                    else
                    {
                        // can something fill this spot?
                        for (var x = k + 1; x < MaxX; x++)
                        {
                            char tch = Dish[x, y];
                            if (tch == 'O')
                            {
                                Dish[k, y] = 'O';
                                Dish[x, y] = '.';
                                break;
                            }
                            if (tch == '#')
                            {
                                // unmoveable rock
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void TiltEast()
        {
            for (var k = MaxX - 1; k >= 0; k--)
            {
                for (var y = 0; y < MaxY; y++)
                {
                    char ch = Dish[k, y];
                    if (ch == 'O' || ch == '#')
                    {
                        continue;
                    }
                    else
                    {
                        // can something fill this spot?
                        for (var x = k - 1; x >= 0; x--)
                        {
                            char tch = Dish[x, y];
                            if (tch == 'O')
                            {
                                Dish[k, y] = 'O';
                                Dish[x, y] = '.';
                                break;
                            }
                            if (tch == '#')
                            {
                                // unmoveable rock
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void DoCycle()
        {
            TiltNorth();
            TiltWest();
            TiltSouth();
            TiltEast();
        }

        public void RunCyclesForPattern()
        {
            LoadDict.Clear();
            int cycles = 1;
            DoCycle();
            long lactual = CalculateLoad();
            LoadDict.Add(lactual, new Tuple<int, int, int, int>(1, cycles, 1, 0));
            do
            {
                DoCycle();
                cycles++;
                lactual = CalculateLoad();
                if (LoadDict.ContainsKey(lactual))
                {
                    var tp = LoadDict[lactual];
                    if (tp.Item1 > 110)
                    {
                        Debug.WriteLine($"Load: {lactual}, count: {tp.Item1}, cycle: {cycles}");
                        break;
                    }
                    LoadDict[lactual] = new Tuple<int, int, int, int>(tp.Item1 + 1, cycles, tp.Item3, tp.Item4 == 0 ? cycles : tp.Item4);
                }
                else
                {
                    LoadDict.Add(lactual, new Tuple<int, int, int, int>(1, cycles, cycles, 0));
                }
            } while (cycles < 1000000000);
        }

        public long FindCorrectLoad()
        {
            var listSingleKeys = LoadDict.Where(kvp => kvp.Value.Item1 == 1).Select(kvp => kvp.Key).ToList();
            foreach (var key in listSingleKeys)
            {
                LoadDict.Remove(key);
            }

            int size = LoadDict.Count + LoadDict.Where(kvp => kvp.Value.Item1 > 100).Count();

            foreach (var kvp in LoadDict)
            {
                int temp = (1000000000 - kvp.Value.Item3) % size;
                if (temp == 0)
                {
                    return kvp.Key;
                }
            }
            return -1;
        }

        public void SaveDishOneCycle()
        {
            for (int y = 0; y < MaxY; ++y)
            {
                for (var x = 0; x < MaxX; x++)
                {
                    DishOneCycle[x, y] = Dish[x, y];
                }
            }
        }

        public bool DishesAreEqual()
        {
            for (int y = 0; y < MaxY; ++y)
            {
                for (var x = 0; x < MaxX; x++)
                {
                    if (DishOneCycle[x, y] != Dish[x, y])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public long CalculateLoad()
        {
            long totalLoad = 0;
            for (var y = 0; y < MaxY; y++)
            {
                int iCount = 0;
                for (int x = 0; x < MaxX; x++)
                {
                    if (Dish[x, y] == 'O')
                        iCount++;
                }
                totalLoad += (iCount * (MaxY - y));
            }
            return totalLoad;
        }

        public void DumpDish()
        {
            Debug.WriteLine("==========================");
            for (var y = 0; y < MaxY; y++)
            {
                for (int x = 0; x < MaxX; x++)
                {
                    Debug.Write(Dish[x, y]);
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("==========================");
        }
    }
}
