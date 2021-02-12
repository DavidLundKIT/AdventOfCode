using System;

namespace AdventOfCode2020
{
    public class WayPointNavigator
    {
        public long East { get; set; }
        public long North { get; set; }

        public Direction PointX { get; set; }
        public Direction PointY { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
        public WayPointNavigator()
        {
            East = 0;
            North = 0;

            X = 10;
            PointX = Direction.East;
            Y = 1;
            PointY = Direction.North;

        }

        public void Move(string leg)
        {
            char cmd = leg[0];
            long distance = long.Parse(leg.Substring(1));

            switch (cmd)
            {
                case 'N':
                    if (PointX == Direction.North)
                        X += distance;
                    if (PointX == Direction.South)
                        X -= distance;
                    if (PointY == Direction.North)
                        Y += distance;
                    if (PointY == Direction.South)
                        Y -= distance;
                    break;
                case 'S':
                    if (PointX == Direction.North)
                        X -= distance;
                    if (PointX == Direction.South)
                        X += distance;
                    if (PointY == Direction.North)
                        Y -= distance;
                    if (PointY == Direction.South)
                        Y += distance;
                    break;
                case 'E':
                    if (PointX == Direction.East)
                        X += distance;
                    if (PointX == Direction.West)
                        X -= distance;
                    if (PointY == Direction.East)
                        Y += distance;
                    if (PointY == Direction.West)
                        Y -= distance;
                    break;
                case 'W':
                    if (PointX == Direction.East)
                        X -= distance;
                    if (PointX == Direction.West)
                        X += distance;
                    if (PointY == Direction.East)
                        Y -= distance;
                    if (PointY == Direction.West)
                        Y += distance;
                    break;
                case 'F':
                    {
                        switch (PointX)
                        {
                            case Direction.East:
                                East += distance * X;
                                break;
                            case Direction.South:
                                North -= distance * X;
                                break;
                            case Direction.West:
                                East -= distance * X;
                                break;
                            case Direction.North:
                                North += distance * X;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("Pointing strange");
                        }
                        switch (PointY)
                        {
                            case Direction.East:
                                East += distance * Y;
                                break;
                            case Direction.South:
                                North -= distance * Y;
                                break;
                            case Direction.West:
                                East -= distance * Y;
                                break;
                            case Direction.North:
                                North += distance * Y;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("Pointing strange");
                        }
                    }
                    break;
                case 'R':
                    {
                        PointX = (Direction)(((int)PointX + (distance / 90)) % 4);
                        PointY = (Direction)(((int)PointY + (distance / 90)) % 4);
                    }
                    break;
                case 'L':
                    {
                        PointX = (Direction)(((int)PointX + (4 - (distance / 90))) % 4);
                        PointY = (Direction)(((int)PointY + (4 - (distance / 90))) % 4);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Cmd strange");
            }
        }

        public long AbsoluteDistanceTravelled()
        {
            return Math.Abs(East) + Math.Abs(North);
        }
    }
}
