using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019
{
    public class OxyRepairDroid
    {
        public MagicSmokeComputer Brain { get; set; }
        public int XNow { get; set; }
        public int YNow { get; set; }

        public Dictionary<Point, long> HullDict { get; set; }

        public OxyRepairDroid(List<long> pgm)
        {
            Brain = new MagicSmokeComputer(pgm);
            XNow = 0;
            YNow = 0;
            PointEqualityComparer peqc = new PointEqualityComparer();
            HullDict = new Dictionary<Point, long>(peqc);
        }

        public Point FindOxygenSystem()
        {
            MagicSmokeComputer.ProgramMode state = MagicSmokeComputer.ProgramMode.Start;
            Point pos = null;
            // start point (0, 0) and moveable (1). Others wall (0), Oxy system (2)
            Point p = new Point(0, 0);
            HullDict.Add(p, 1);

            // north (1), south (2), west (3), and east (4)
            int direction = 1;

            while (state != MagicSmokeComputer.ProgramMode.Stop)
            {
                Brain.InputPort = direction;
                state = Brain.Run(state);
                if (Brain.OutputQueueSize() > 0)
                {
                    long moved = Brain.OutputPort();
                    p = GetPointFromDirection(direction);
                    switch (moved)
                    {
                        case 0:
                            // wall 
                            HullDict.TryAdd(p, 0);
                            // do not update X, Y
                            // change direction
                            direction = NextDirection(direction);
                            break;
                        case 1:
                            // clear space 
                            HullDict.TryAdd(p, 1);
                            // update X, Y
                            XNow = p.X;
                            YNow = p.Y;
                            // keep going
                            //direction = NextDirection(direction);
                            break;
                        case 2:
                            // the oxygen system! 
                            HullDict.TryAdd(p, 2);
                            pos = p;
                            // update X, Y
                            XNow = p.X;
                            YNow = p.Y;
                            // stop
                            //direction = NextDirection(direction);
                            state = MagicSmokeComputer.ProgramMode.Stop;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException($"moved is {moved}");
                    }
                }
            }
            return pos;
        }

        public int NextDirection(int direction)
        {
            // north (1), south (2), west (3), and east (4)
            direction += 1;
            if (direction > 4)
                direction = 1;
            return direction;
        }

        public Point GetPointFromDirection(int direction)
        {
            int x = XNow;
            int y = YNow;

            // north (1), south (2), west (3), and east (4)
            switch (direction)
            {
                case 1:
                    y += 1;
                    break;
                case 2:
                    y -= 1;
                    break;
                case 3:
                    x -= 1;
                    break;
                case 4:
                    x += 1;
                    break;
                default:
                    break;
            }
            Point p = new Point(x, y);
            return p;
        }
    }
}
