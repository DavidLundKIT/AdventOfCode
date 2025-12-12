using System.Text;

namespace AdventCode2025.Models;

public class RectangleCalculator
{
    public List<Tile> Tiles { get; set; }
    public Dictionary<Tile, string> FloorMap { get; set; }

    public int MinX { get; set; } = int.MaxValue;
    public int MaxX { get; set; } = int.MinValue;
    public int MinY { get; set; } = int.MaxValue;
    public int MaxY { get; set; } = int.MinValue;

    public RectangleCalculator(string[] lines)
    {
        Tiles = new List<Tile>();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            int x = int.Parse(parts[0]);
            MaxX = Math.Max(MaxX, x);
            MinX = Math.Min(MinX, x);
            int y = int.Parse(parts[1]);
            MaxY = Math.Max(MaxY, y);
            MinY = Math.Min(MinY, y);
            Tiles.Add(new Tile(x, y));
        }

        FloorMap = new Dictionary<Tile, string>();
        for (int idx = 0; idx < Tiles.Count; idx++)
        {
            var tile0 = Tiles[idx];
            int next = (idx + 1) % Tiles.Count;
            var tile1 = Tiles[next];
            FillGreenTileLines(tile0, tile1);
        }
    }

    public void FillGreenTileLines(Tile tile0, Tile tile1)
    {
        FloorMap[tile0] = "#";
        FloorMap[tile1] = "#";
        if (tile0.X == tile1.X)
        {
            int startY = Math.Min(tile0.Y, tile1.Y);
            int endY = Math.Max(tile0.Y, tile1.Y);
            for (int dy = startY + 1; dy < endY; dy++)
            {
                FloorMap.Add(new Tile(tile0.X, dy), "x");
            }
        }
        else if (tile0.Y == tile1.Y)
        {
            int startX = Math.Min(tile0.X, tile1.X);
            int endX = Math.Max(tile0.X, tile1.X);
            for (int dx = startX + 1; dx < endX; dx++)
            {
                FloorMap.Add(new Tile(dx, tile0.Y), "x");
            }
        }
        else
        {
            throw new ArgumentException("Tiles must be aligned either horizontally or vertically.");
        }
    }

    public long FindLargestRectangleArea()
    {
        long maxArea = 0;
        for (int i = 0; i < Tiles.Count; i++)
        {
            for (int j = i + 1; j < Tiles.Count; j++)
            {
                var tile1 = Tiles[i];
                var tile2 = Tiles[j];
                long width = Math.Abs(tile2.X - tile1.X) + 1;
                long height = Math.Abs(tile2.Y - tile1.Y) + 1;
                long area = width * height;
                if (area > maxArea)
                {
                    maxArea = area;
                }
            }
        }
        return maxArea;
    }

    public long FindLargestContainedRectangleArea()
    {
        long maxArea = 0;
        for (int i = 0; i < Tiles.Count; i++)
        {
            for (int j = i + 1; j < Tiles.Count; j++)
            {
                var tile1 = Tiles[i];
                var tile2 = Tiles[j];
                if (!IsRectangleContained(tile1, tile2))
                {
                    continue;
                }
                long width = Math.Abs(tile2.X - tile1.X) + 1;
                long height = Math.Abs(tile2.Y - tile1.Y) + 1;
                long area = width * height;
                if (area > maxArea)
                {
                    maxArea = area;
                }
            }
        }
        return maxArea;
    }

    public bool IsRectangleContained(Tile tile1, Tile tile2)
    {
        int minX = Math.Min(tile1.X, tile2.X);
        int maxX = Math.Max(tile1.X, tile2.X);
        int minY = Math.Min(tile1.Y, tile2.Y);
        int maxY = Math.Max(tile1.Y, tile2.Y);

        // nothing on the inside 
        var innerTiles = FloorMap.Keys.Where(t => t.X > minX && t.X < maxX && t.Y > minY && t.Y < maxY);
        if (innerTiles.Any())
        {
            return false;
        }
        return true;
    }

    public void PrintFloor(string filePath)
    {
        using var fs = File.CreateText(filePath);
        fs.WriteLine("--- Floor ---");
        int minX = FloorMap.Keys.Select(k => k.X).Min();
        int maxX = FloorMap.Keys.Select(k => k.X).Max();
        int minY = FloorMap.Keys.Select(k => k.Y).Min();
        int maxY = FloorMap.Keys.Select(k => k.Y).Max();

        StringBuilder sb = new StringBuilder();
        for (int y = minY; y <= maxY; y++)
        {
            for (int x = minX; x <= maxX; x++)
            {
                var tile = new Tile(x, y);
                if (FloorMap.ContainsKey(tile))
                {
                    sb.Append(FloorMap[tile]);
                }
                else
                {
                    sb.Append('.');
                }
            }
            fs.WriteLine(sb.ToString());
            sb.Clear();
        }
        fs.WriteLine("--- Done ---");
        fs.Flush();
        fs.Close();
    }
}

