namespace AdventCode2025.Models;

public class RectangleCalculator
{
    public List<Tile> Tiles { get; set; }

    public RectangleCalculator(string[] lines)
    {
        Tiles = new List<Tile>();

        foreach (var line in lines)
        {
            var parts = line.Split(',');
            Tiles.Add(new Tile(int.Parse(parts[0]), int.Parse(parts[1])));
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
}

