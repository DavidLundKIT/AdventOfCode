namespace AdventCode2024.Models;

public record Trail(Point head, Point end);

public class TrailMapper
{
    public Dictionary<Point, int> Map { get; set; }
    public int MaxX { get; set; }
    public int MaxY { get; set; }
    public Dictionary<Trail, int> Trails { get; set; }
    public Point? HeadNow { get; set; }

    public TrailMapper(string[] lines)
    {
        MaxY = lines.Length;
        MaxX = lines[0].Length;
        Map = new Dictionary<Point, int>();
        Trails = new Dictionary<Trail, int>();

        for (int y = 0; y < MaxY; y++)
        {
            var row = lines[y].ToCharArray().Select(c => int.Parse(Convert.ToString(c))).ToList();
            for (int x = 0; x < MaxX; x++)
            {
                var pt = new Point(x, y);
                Map.Add(pt, row[x]);
            }
        }
        HeadNow = null;
    }

    public int FindAllTrails()
    {
        var trailHeads = Map.Where(kv => kv.Value == 0).Select(kv => kv.Key).ToList();
        int sum = 0;
        foreach (var head in trailHeads)
        {
            sum += FindTrails(head);
        }

        return sum;
    }

    public int FindTrails(Point now)
    {
        HeadNow = now;

        int sum = FindTrail(now, new Point(now.X + 1, now.Y));
        sum += FindTrail(now, new Point(now.X - 1, now.Y));
        sum += FindTrail(now, new Point(now.X, now.Y + 1));
        sum += FindTrail(now, new Point(now.X, now.Y - 1));
        return sum;
    }

    public int FindTrail(Point prev, Point now)
    {
        int valPrev = Map[prev];
        if (!Map.ContainsKey(now))
        {
            // not on the map
            return 0;
        }
        int valNow = Map[now];
        if (valPrev + 1 != valNow)
        {
            // not next step
            return 0;
        }
        if (valNow == 9)
        {
            // Trail!
            var trail = new Trail(HeadNow ?? throw new ArgumentNullException("head"), now);
            if (Trails.ContainsKey(trail))
            {
                Trails[trail]++;
            }
            else
            {
                Trails.Add(trail, 1);
            }
            return 1;
        }
        // not end of trail look for the next parts
        int sum = FindTrail(now, new Point(now.X + 1, now.Y));
        sum += FindTrail(now, new Point(now.X - 1, now.Y));
        sum += FindTrail(now, new Point(now.X, now.Y + 1));
        sum += FindTrail(now, new Point(now.X, now.Y - 1));
        return sum;
    }
}
