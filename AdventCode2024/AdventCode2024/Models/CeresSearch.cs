namespace AdventCode2024.Models;

public class CeresSearch
{
    public Dictionary<Point, char> Puzzle { get; set; }
    public int MaxX { get; set; }
    public int MaxY { get; set; }

    public CeresSearch(string[] lines)
    {
        Puzzle = new Dictionary<Point, char>();
        MaxY = lines.Length;
        MaxX = lines[0].Length;
        for (int y = 0; y < MaxY; y++)
        {
            var chArr = lines[y].ToCharArray();
            for (int x = 0; x < MaxX; x++)
            {
                Puzzle.Add(new Point(x, y), chArr[x]);
            }
        }
    }

    public int FindAllXmas()
    {
        int count = 0;

        for (int y = 0; y < MaxY; y++)
        {
            for (int x = 0; x < MaxX; x++)
            {
                var ptNow = new Point(x, y);
                if (Puzzle[ptNow] == 'X')
                {
                    // look for XMAS
                    int found = FindXmasForPoint(ptNow);
                    count += found;
                }
            }
        }

        return count;
    }

    public int FindXmasForPoint(Point ptX)
    {
        int count = 0;

        // forwards XMAS
        count += IsXmas(new Point(ptX.X + 1, ptX.Y), new Point(ptX.X + 2, ptX.Y), new Point(ptX.X + 3, ptX.Y));
        // down right
        count += IsXmas(new Point(ptX.X + 1, ptX.Y + 1), new Point(ptX.X + 2, ptX.Y + 2), new Point(ptX.X + 3, ptX.Y + 3));
        // up right
        count += IsXmas(new Point(ptX.X + 1, ptX.Y - 1), new Point(ptX.X + 2, ptX.Y - 2), new Point(ptX.X + 3, ptX.Y - 3));
        // down 
        count += IsXmas(new Point(ptX.X, ptX.Y + 1), new Point(ptX.X, ptX.Y + 2), new Point(ptX.X, ptX.Y + 3));
        // up
        count += IsXmas(new Point(ptX.X, ptX.Y - 1), new Point(ptX.X, ptX.Y - 2), new Point(ptX.X, ptX.Y - 3));
        // backwards
        count += IsXmas(new Point(ptX.X - 1, ptX.Y), new Point(ptX.X - 2, ptX.Y), new Point(ptX.X - 3, ptX.Y));
        // down left
        count += IsXmas(new Point(ptX.X - 1, ptX.Y + 1), new Point(ptX.X - 2, ptX.Y + 2), new Point(ptX.X - 3, ptX.Y + 3));
        // up right
        count += IsXmas(new Point(ptX.X - 1, ptX.Y - 1), new Point(ptX.X - 2, ptX.Y - 2), new Point(ptX.X + -3, ptX.Y - 3));

        return count;
    }

    public int IsXmas(Point ptM, Point ptA, Point ptS)
    {
        // we start with an X so no need to check
        if (Puzzle.ContainsKey(ptM) && Puzzle.ContainsKey(ptA) && Puzzle.ContainsKey(ptS))
        {
            if (Puzzle[ptM] == 'M' && Puzzle[ptA] == 'A' && Puzzle[ptS] == 'S')
            {
                return 1;
            }
        }
        return 0;
    }

    public int FindAllX_Mas()
    {
        int count = 0;

        for (int y = 0; y < MaxY; y++)
        {
            for (int x = 0; x < MaxX; x++)
            {
                var ptNow = new Point(x, y);
                if (Puzzle[ptNow] == 'A')
                {
                    // look for MAS
                    int found = FindX_MasForPoint(ptNow);
                    count += found;
                }
            }
        }

        return count;
    }

    public int FindX_MasForPoint(Point ptA)
    {
        int count = 0;

        count += IsXmas(new Point(ptA.X + 1, ptA.Y + 1), ptA, new Point(ptA.X - 1, ptA.Y - 1));
        count += IsXmas(new Point(ptA.X - 1, ptA.Y - 1), ptA, new Point(ptA.X + 1, ptA.Y + 1));
        count += IsXmas(new Point(ptA.X + 1, ptA.Y - 1), ptA, new Point(ptA.X - 1, ptA.Y + 1));
        count += IsXmas(new Point(ptA.X - 1, ptA.Y + 1), ptA, new Point(ptA.X + 1, ptA.Y - 1));

        if (count == 2)
            return 1;
        return 0;
    }
}

public record Point(int X, int Y);

