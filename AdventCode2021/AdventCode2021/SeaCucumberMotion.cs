using System.Diagnostics;

namespace AdventCode2021
{
    public class SeaCucumberMotion
    {
        public char[,] SeaFloor { get; set; }
        public int maxX { get; set; }
        public int maxY { get; set; }

        public SeaCucumberMotion(string[] lines)
        {
            maxX = lines[0].Length;
            maxY = lines.Length;
            SeaFloor = new char[maxX, maxY];
            for (int y = 0; y < maxY; y++)
            {
                var chs = lines[y].ToCharArray();
                for (int x = 0; x < maxX; x++)
                {
                    SeaFloor[x, y] = chs[x];
                }
            }
        }

        public void DumpSeaFloor()
        {
            Debug.WriteLine("------------------");
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    Debug.Write(SeaFloor[x, y]);
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("------------------");
        }

        public int MoveCuckes()
        {
            int moves = 0;
            moves = MoveEast();
            moves += MoveSouth();

            return moves;
        }

        public int MoveEast()
        {
            var nextSeaFloor = new char[maxX, maxY];
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    nextSeaFloor[x, y] = '.';
                }
            }
            int moves = 0;
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    if (SeaFloor[x, y] == '>')
                    {
                        if (SeaFloor[((x + 1) % maxX), y] == '.')
                        {
                            nextSeaFloor[x, y] = '.';
                            nextSeaFloor[((x + 1) % maxX), y] = '>';
                            x++;
                            moves++;
                        }
                        else
                            nextSeaFloor[x, y] = SeaFloor[x, y];
                    }
                    else
                        nextSeaFloor[x, y] = SeaFloor[x, y];
                }
            }
            SeaFloor = nextSeaFloor;
            return moves;
        }

        public int MoveSouth()
        {
            var nextSeaFloor = new char[maxX, maxY];
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    nextSeaFloor[x, y] = '.';
                }
            }
            int moves = 0;
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    if (SeaFloor[x, y] == 'v')
                    {
                        if (SeaFloor[x, ((y + 1) % maxY)] == '.')
                        {
                            nextSeaFloor[x, y] = '.';
                            nextSeaFloor[x, ((y + 1) % maxY)] = 'v';
                            y++;
                            moves++;
                        }
                        else
                            nextSeaFloor[x, y] = SeaFloor[x, y];
                    }
                    else
                        nextSeaFloor[x, y] = SeaFloor[x, y];
                }
            }
            SeaFloor = nextSeaFloor;
            return moves;
        }
    }
}
