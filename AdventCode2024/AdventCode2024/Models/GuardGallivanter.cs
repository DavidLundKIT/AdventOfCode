namespace AdventCode2024.Models;

public class Spot
{
    public int Count { get; set; }
    public char Type { get; set; }

    public Spot(char type, int count)
    {
        Type = type;
        Count = count;
    }
}
public class GuardGallivanter
{
    public Dictionary<Point, Spot> Puzzle { get; set; }
    public int MaxX { get; set; }
    public int MaxY { get; set; }
    public Point Start { get; set; }
    public Position Guard { get; set; }

    public GuardGallivanter(string[] lines)
    {
        Start = new Point(-1, -1);
        Puzzle = new Dictionary<Point, Spot>();
        MaxY = lines.Length;
        MaxX = lines[0].Length;
        for (int y = 0; y < MaxY; y++)
        {
            var chArr = lines[y].ToCharArray();
            for (int x = 0; x < MaxX; x++)
            {
                var ptNow = new Point(x, y);
                Puzzle.Add(ptNow, new Spot(chArr[x], 0));
                if (chArr[x] == '^')
                {
                    Start = ptNow;
                }
            }
        }
        Guard = new Position(Start, Direction.Up);
    }

    public void WalkTheRoom()
    {
        Puzzle[Guard.Now()].Type = 'X';
        Puzzle[Guard.Now()].Count++;

        while (Guard.Direction != Direction.Done)
        {
            var nextStep = Guard.NextStep();
            if (Puzzle.ContainsKey(nextStep))
            {
                if (Puzzle[nextStep].Type == '#')
                {
                    Guard.TurnRight();
                }
                else
                {
                    Guard.MoveForward();
                    Puzzle[Guard.Now()].Type = 'X';
                    Puzzle[Guard.Now()].Count++;
                }
            }
            else
            {
                Guard.Direction = Direction.Done;
            }
        }

        Position now = new Position(Guard);
    }

    public int HowManyXs()
    {
        int result = Puzzle.Values.Count(spot => spot.Type == 'X');
        return result;
    }
}
