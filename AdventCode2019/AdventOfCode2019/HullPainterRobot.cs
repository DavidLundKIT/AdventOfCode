using System;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class HullPainterRobot
    {
        public MagicSmokeComputer Brain { get; set; }
        public int XNow { get; set; }
        public int YNow { get; set; }
        public int Direction { get; set; }

        public Dictionary<Point, long> HullDict { get; set; }

        public HullPainterRobot(List<long> pgm)
        {
            Brain = new MagicSmokeComputer(pgm);
            XNow = 0;
            YNow = 0;
            Direction = 0;
            PointEqualityComparer peqc = new PointEqualityComparer();
            HullDict = new Dictionary<Point, long>(peqc);
        }

        public int GoPaint()
        {
            MagicSmokeComputer.ProgramMode state = MagicSmokeComputer.ProgramMode.Start;
            state = Brain.Run(state);
            while (state == MagicSmokeComputer.ProgramMode.NeedInput)
            {
                Point pNow = new Point(XNow, YNow);
                if (!HullDict.ContainsKey(pNow))
                {
                    // add hull section as black
                    HullDict.Add(pNow, 0);
                }
                Brain.InputPort = HullDict[pNow];
                state = Brain.Run(state);
                if (Brain.OutputQueueSize() > 0)
                {
                    // get the color
                    HullDict[pNow] = Brain.OutputPort();
                    long turn = Brain.OutputPort();
                    Turn(turn);
                    Move();
                }
            }
            return HullDict.Count;
        }

        public void Turn(long turn)
        {
            if (turn == 0)
            {
                // left 
                Direction -= 1;
                if (Direction < 0)
                {
                    Direction = 3;
                }
            }
            else
            {
                // right
                Direction += 1;
                if (Direction > 3)
                {
                    Direction = 0;
                }
            }
        }
        public void Move()
        {
            switch (Direction)
            {
                case 0:
                    YNow += 1;
                    break;
                case 1:
                    XNow += 1;
                    break;
                case 2:
                    YNow -= 1;
                    break;
                case 3:
                    XNow -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Direction");
            }
        }

    }
}
