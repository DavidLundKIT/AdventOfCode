
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
            var antennas = Antennas.Where(a=> a.Value == antType).ToList();
            for (int i = 0;i < antennas.Count-1;i++)
            {
                for (int j = i+1; j < antennas.Count; j++)
                {
                    PlaceAntiNodes(antennas[i], antennas[j]);
                }
            }
        }
    }

    public void PlaceAntiNodes(KeyValuePair<Point, char> ant1, KeyValuePair<Point, char> ant2)
    {
        int diffX = Math.Abs(ant1.Key.X - ant2.Key.X);
        int diffY = Math.Abs(ant1.Key.Y - ant2.Key.Y);
    }
}
