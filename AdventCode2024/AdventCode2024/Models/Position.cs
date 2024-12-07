namespace AdventCode2024.Models;

public enum Direction
{
    Up,
    Down,
    Left,
    Right,
    Done,
    Loop
}

public class Position
{
    public Position(Point pt, Direction direction)
    {
        X = pt.X; 
        Y = pt.Y;
        Direction = direction;
    }

    public Position(Position p)
    {
        X = p.X;
        Y = p.Y;
        Direction = p.Direction;
    }

    public Direction Direction { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public Point Now()
    {
        return new Point(X, Y);
    }

    public void TurnRight()
    {
        switch (Direction)
        {
            case Direction.Up:
                Direction = Direction.Right;
                break;
            case Direction.Down:
                Direction = Direction.Left;
                break;
            case Direction.Left:
                Direction = Direction.Up;
                break;
            case Direction.Right:
                Direction = Direction.Down;
                break;
            case Direction.Done:
                break;
            default:
                break;
        }
    }

    public void MoveForward()
    {
        switch (Direction)
        {
            case Direction.Up:
                Y--;
                break;
            case Direction.Down:
                Y++;
                break;
            case Direction.Left:
                X--;
                break;
            case Direction.Right:
                X++;
                break;
            case Direction.Done:
                break;
            default:
                break;
        }
    }

    public Point NextStep()
    {
        int x = X;
        int y = Y;
        switch (Direction)
        {
            case Direction.Up:
                y--;
                break;
            case Direction.Down:
                y++;
                break;
            case Direction.Left:
                x--;
                break;
            case Direction.Right:
                x++;
                break;
            case Direction.Done:
                break;
            default:
                break;
        }
        return new Point(x, y); 
    }
}
