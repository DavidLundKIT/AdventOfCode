
namespace AdventCode2024.Models;

public class ResonantColinearityMapper
{
    public Dictionary<Point, char> Antennas { get; set; }
    public Dictionary<Point, int> Antinodes { get; set; }
    public int MaxX { get; set; }
    public int MaxY { get; set; }

    public ResonantColinearityMapper(string[] lines)
    {
        Antennas = new Dictionary<Point, char>();
        Antinodes = new Dictionary<Point, int>();
        MaxY = lines.Length;
        MaxX = lines[0].Length;

        for (int y = 0; y < MaxY; y++)
        {
            var chArr = lines[y].ToCharArray();
            for (int x = 0; x < MaxX; x++)
            {
                if (chArr[x] != '.')
                {
                    var ptNow = new Point(x, y);
                    Antennas.Add(ptNow, chArr[x]);
                }
            }
        }
    }

    public void MapAntiNodes()
    {
        Antinodes.Clear();
        var antennaTypes = Antennas.Values.Distinct().ToList();

        foreach (var antType in antennaTypes)
        {
            var antennas = Antennas.Where(a => a.Value == antType).ToList();
            for (int i = 0; i < antennas.Count - 1; i++)
            {
                for (int j = i + 1; j < antennas.Count; j++)
                {
                    PlaceAntiNodes(antennas[i], antennas[j]);
                }
            }
        }
    }

    public void PlaceAntiNodes(KeyValuePair<Point, char> ant1, KeyValuePair<Point, char> ant2)
    {
        Point pt1 = ant1.Key;
        Point pt2 = ant2.Key;

        int diffX = Math.Abs(pt1.X - pt2.X);
        int diffY = Math.Abs(pt1.Y - pt2.Y);
        int doubleDist = 2 * NycDistance(pt1, pt2);

        ValidateAntiNode(new Point(pt1.X + diffX, pt1.Y + diffY), pt2, doubleDist);
        ValidateAntiNode(new Point(pt1.X - diffX, pt1.Y + diffY), pt2, doubleDist);
        ValidateAntiNode(new Point(pt1.X + diffX, pt1.Y - diffY), pt2, doubleDist);
        ValidateAntiNode(new Point(pt1.X - diffX, pt1.Y - diffY), pt2, doubleDist);

        ValidateAntiNode(new Point(pt2.X + diffX, pt2.Y + diffY), pt1, doubleDist);
        ValidateAntiNode(new Point(pt2.X - diffX, pt2.Y + diffY), pt1, doubleDist);
        ValidateAntiNode(new Point(pt2.X + diffX, pt2.Y - diffY), pt1, doubleDist);
        ValidateAntiNode(new Point(pt2.X - diffX, pt2.Y - diffY), pt1, doubleDist);
    }

    public void ValidateAntiNode(Point ptNew, Point ptCompare, int doubleDist)
    {
        if (ptNew.X < 0 || MaxX <= ptNew.X)
        {
            return;
        }
        if (ptNew.Y < 0 || MaxY <= ptNew.Y)
        {
            return;
        }
        int dist = NycDistance(ptNew, ptCompare);
        if (dist != doubleDist)
        {
            return;
        }
        if (Antinodes.ContainsKey(ptNew))
        {
            Antinodes[ptNew]++;
        }
        else
        {
            Antinodes.Add(ptNew, 1);
        }
    }

    public int NycDistance(Point ptA, Point ptB)
    {
        return Math.Abs(ptA.X - ptB.X) + Math.Abs(ptA.Y - ptB.Y);
    }
}
