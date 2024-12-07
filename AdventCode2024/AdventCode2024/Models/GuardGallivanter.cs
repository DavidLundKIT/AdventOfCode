namespace AdventCode2024.Models;

public class Spot
{
    public char Type { get; set; }
    public Dictionary<Direction, int> Steps { get; set; }

    public Spot(char type)
    {
        Type = type;
        Steps = new Dictionary<Direction, int>();
    }

    public bool Step(Direction direction)
    {
        bool found = Steps.ContainsKey(direction);
        if (!found)
        {
        Steps.Add(direction, 1);
        }
        return found;
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
                Puzzle.Add(ptNow, new Spot(chArr[x]));
                if (chArr[x] == '^')
                {
                    Start = ptNow;
                }
            }
        }
        Guard = new Position(Start, Direction.Up);
    }

    public Direction WalkTheRoom()
    {
        Puzzle[Guard.Now()].Type = 'X';
        Puzzle[Guard.Now()].Step(Direction.Up);

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
                    bool loop = Puzzle[Guard.Now()].Step(Guard.Direction);
                    if (loop)
                    {
                        Guard.Direction = Direction.Loop;
                        break;
                    }
                }
            }
            else
            {
                Guard.Direction = Direction.Done;
            }
        }
        return Guard.Direction;
    }

    public int HowManyXs()
    {
        int result = Puzzle.Values.Count(spot => spot.Type == 'X');
        return result;
    }
}
