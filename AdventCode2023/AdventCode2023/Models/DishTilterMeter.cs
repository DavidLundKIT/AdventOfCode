using System.Diagnostics;

namespace AdventCode2023.Models
{
    public class DishTilterMeter
    {
        public char[,] Dish { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public DishTilterMeter(string[] lines)
        {
            MaxX = lines[0].Length;
            MaxY = lines.Length;
            Dish = new char[MaxX, MaxY];
            for (int y = 0; y < MaxY; y++)
            {
                var tch = lines[y].ToCharArray();
                for (int x = 0; x < MaxX; x++)
                {
                    Dish[x, y] = tch[x];
                }
            }
        }

        public long TiltNorth()
        {
            DumpDish();
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

            DumpDish();
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
