using System;

namespace AdventOfCode2020
{
    public enum Direction : int
    {
        East = 0,
        South = 1,
        West = 2,
        North = 3
    }

    public class FerryNavigator
    {
        public int East { get; set; }
        public int North { get; set; }
        public Direction Pointing { get; set; }

        public FerryNavigator()
        {
            East = 0;
            North = 0;
            Pointing = Direction.East;
        }

        public void Move(string leg)
        {
            char cmd = leg[0];
            int distance = int.Parse(leg.Substring(1));

            switch (cmd)
            {
                case 'N':
                    North += distance;
                    break;
                case 'S':
                    North -= distance;
                    break;
                case 'E':
                    East += distance;
                    break;
                case 'W':
                    East -= distance;
                    break;
                case 'F':
                    {
                        switch (Pointing)
                        {
                            case Direction.East:
                                East += distance;
                                break;
                            case Direction.South:
                                North -= distance;
                                break;
                            case Direction.West:
                                East -= distance;
                                break;
                            case Direction.North:
                                North += distance;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("Pointing strange");
                        }
                    }
                    break;
                case 'R':
                    {
                        Pointing = (Direction)(((int)Pointing + (distance / 90)) % 4);
                    }
                    break;
                case 'L':
                    {
                        Pointing = (Direction)(((int)Pointing + (4 - (distance / 90))) % 4);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Cmd strange");
            }
        }

        public int AbsoluteDistanceTravelled()
        {
            return Math.Abs(East) + Math.Abs(North);
        }
    }
}
