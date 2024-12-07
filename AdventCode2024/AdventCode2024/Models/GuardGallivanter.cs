namespace AdventCode2024.Models;

public record Spot(char type, int count);

public class GuardGallivanter
{
    public Dictionary<Point, Spot> Puzzle { get; set; }
    public int MaxX { get; set; }
    public int MaxY { get; set; }
    public Point GuardStart { get; set; }

    public GuardGallivanter(string[] lines)
    {
        Puzzle = new Dictionary<Point, Spot>();
        MaxY = lines.Length;
        MaxX = lines[0].Length;
        for (int y = 0; y < MaxY; y++)
        {
            var chArr = lines[y].ToCharArray();
            for (int x = 0; x < MaxX; x++)
            {
                Puzzle.Add(new Point(x, y), new Spot(chArr[x], 0));
                if (chArr[x] == '^')
                {
                    GuardStart = new Point(x, y);
                }
            }
        }
    }
}
