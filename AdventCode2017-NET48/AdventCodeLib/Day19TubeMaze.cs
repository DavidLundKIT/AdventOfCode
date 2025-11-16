using System;
using System.Text;

namespace AdventCodeLib
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        Done
    }

    public class Position
    {
        public Position()
        {

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

        public Tuple<int,int> Now()
        {
            return new Tuple<int, int>(X, Y);
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.Up:
                    Direction = Direction.Left;
                    break;
                case Direction.Down:
                    Direction = Direction.Right;
                    break;
                case Direction.Left:
                    Direction = Direction.Down;
                    break;
                case Direction.Right:
                    Direction = Direction.Up;
                    break;
                case Direction.Done:
                    break;
                default:
                    break;
            }
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

        public void Reverse()
        {
            switch (Direction)
            {
                case Direction.Up:
                    Direction = Direction.Down;
                    break;
                case Direction.Down:
                    Direction = Direction.Up;
                    break;
                case Direction.Left:
                    Direction = Direction.Right;
                    break;
                case Direction.Right:
                    Direction = Direction.Left;
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
    }

    public class Day19TubeMaze
    {
        public Day19TubeMaze()
        {
            Letters = new StringBuilder();
        }

        public int Steps { get; set; }
        public StringBuilder Letters { get; set; }
        public int DimX { get; set; }
        public int DimY { get; set; }

        public Position Current { get; set; }
        public char[,] Maze { get; set; }

        public void ParseMaze(string[] rows)
        {
            DimY = rows.Length;
            DimX = rows[0].Length;
            Maze = new char[DimX, DimY];
            for (int y = 0; y < DimY; y++)
            {
                var chars = rows[y].ToCharArray();
                for (int x = 0; x < DimX; x++)
                {
                    Maze[x, y] = chars[x];
                }
            }
        }

        public string FindInMaze()
        {
            Position next = null;

            FindStart();
            Steps = 1;
            do
            {
                CheckLetter(Current);

                next = FindNextMove(Current);

                if (next == null)
                {
                    next = MoveLeft(Current);
                    if (next == null)
                    {
                        next = MoveRight(Current);
                    }
                }

                if (next != null)
                {
                    Current = next;
                    Steps++;
                }
                else
                {
                    Current.Direction = Direction.Done;
                }
            } while (Current.Direction != Direction.Done);

            return Letters.ToString();
        }

        private void CheckLetter(Position now)
        {
            if (char.IsLetter(Maze[now.X, now.Y]))
            {
                Letters.Append(Maze[now.X, now.Y]);
            }
        }

        public Position MoveLeft(Position now)
        {
            Position next = new Position(now);
            switch (now.Direction)
            {
                case Direction.Up:
                    next.Direction = Direction.Left;
                    return FindNextMove(next);
                case Direction.Down:
                    next.Direction = Direction.Right;
                    return FindNextMove(next);
                case Direction.Left:
                    next.Direction = Direction.Down;
                    return FindNextMove(next);
                case Direction.Right:
                    next.Direction = Direction.Up;
                    return FindNextMove(next);
                case Direction.Done:
                    break;
                default:
                    break;
            }
            return null;
        }

        public Position MoveRight(Position now)
        {
            Position next = new Position(now);
            switch (now.Direction)
            {
                case Direction.Up:
                    next.Direction = Direction.Right;
                    return FindNextMove(next);
                case Direction.Down:
                    next.Direction = Direction.Left;
                    return FindNextMove(next);
                case Direction.Left:
                    next.Direction = Direction.Up;
                    return FindNextMove(next);
                case Direction.Right:
                    next.Direction = Direction.Down;
                    return FindNextMove(next);
                case Direction.Done:
                    break;
                default:
                    break;
            }
            return null;
        }

        public Position FindNextMove(Position now)
        {
            Position next = new Position()
            {
                X = now.X,
                Y = now.Y,
                Direction = now.Direction
            };

            switch (now.Direction)
            {
                case Direction.Up:
                    next.Y -= 1;
                    break;
                case Direction.Down:
                    next.Y += 1;
                    break;
                case Direction.Left:
                    next.X -= 1;
                    break;
                case Direction.Right:
                    next.X += 1;
                    break;
                case Direction.Done:
                    break;
                default:
                    break;
            }

            if ((next.Y >= 0) && (next.Y < DimY)
                && (next.X >= 0) && (next.X < DimX)
                && (Maze[next.X, next.Y] != ' '))
            {
                // a valid move
                return next;
            }

            return null;
        }

        public Position FindStart()
        {
            for (int i = 0; i < DimX; i++)
            {
                if (Maze[i, 0] == '|')
                {
                    Position pos = new Position()
                    {
                        X = i,
                        Y = 0,
                        Direction = Direction.Down
                    };
                    Current = pos;
                    return pos;
                }
            }
            return null;
        }
    }
}
