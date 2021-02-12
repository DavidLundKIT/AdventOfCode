using System;
using System.Collections.Generic;

namespace tests
{
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class DistanceCalculator
    {
        public DistanceCalculator()
        {
            Facing = 0;
            X = 0;
            Y = 0;
            Path = new List<Point>();
            Path.Add(new Point(X, Y));
            CrossingDistance = -1;
        }

        public int Facing { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public List<Point> Path;

        public int Distance()
        {
            return Math.Abs(X) + Math.Abs(Y);
        }

        public int CrossingDistance { get; set;}

        public void Turn(string direction)
        {
            string cmd = direction.ToUpper();

            if (cmd == "R")
            {
                TurnRight();
            }
            if (cmd == "L")
            {
                TurnLeft();
            }
        }

        public void TurnRight()
        {
            Facing = WrapFacing(++Facing);
        }

        public void TurnLeft()
        {
            Facing = WrapFacing(--Facing);
        }

        public int WrapFacing(int facing)
        {
            if (facing < 0)
            {
                return 3;
            }
            if (facing > 3)
            {
                return 0;
            }
            return facing;
        }

        public void Walk(int steps)
        {
            switch (Facing)
            {
            case 0:
                Y += steps;
                break;
            case 1:
                X += steps;
                break;
            case 2:
                Y -= steps;
                break;
            case 3:
                X -= steps;
                break;
            }
            // add to Path
            Path.Add(new Point(X, Y));
        }

        public bool CrossPath()
        {
            if (Path.Count < 5)
            {
                CrossingDistance = -1;
                return false;
            }

            Point pNow = Path[Path.Count -1];
            Point pPrev = Path[Path.Count -2];
            // either X is the same or Y is the same
            bool isVertical = (pNow.X == pPrev.X);
            Point pMax = GetMax(pNow, pPrev);
            Point pMin = GetMin(pNow, pPrev);

            for (int idx = Path.Count - 4; idx >= 1; idx-=2)
            {
                Point pSegMin = GetMin(Path[idx], Path[idx-1]);
                Point pSegMax = GetMax(Path[idx], Path[idx-1]);

                if (isVertical && pSegMin.Y >= pMin.Y && pSegMin.Y <= pMax.Y && pSegMin.X <= pMin.X && pMin.X <= pSegMax.X)
                {
                    // crossing
                    CrossingDistance = Math.Abs(pMin.X) + Math.Abs(pSegMin.Y);
                    return true;
                }
                if (!isVertical && pSegMin.X >= pMin.X && pSegMin.X <= pMax.X && pSegMin.Y <= pMin.Y && pMin.Y <= pSegMax.Y)
                {
                    // crossing
                    CrossingDistance = Math.Abs(pSegMin.X) + Math.Abs(pMin.Y);
                    return true;
                }
            }
            CrossingDistance = -1;
            return false;
        }

        public Point GetMin(Point pNow, Point pPrev)
        {
            bool isVertical = (pNow.X == pPrev.X);
            Point pMax = null;
            Point pMin = null;
            if (isVertical)
            {
                if (pNow.Y > pPrev.Y)
                {
                    pMax = pNow;
                    pMin = pPrev;
                }
                else 
                {
                    pMax = pPrev;
                    pMin = pNow;
                }
            }
            else
            {
                if (pNow.X > pPrev.X)
                {
                    pMax = pNow;
                    pMin = pPrev;
                }
                else 
                {
                    pMax = pPrev;
                    pMin = pNow;
                }
            }
            return pMin;
        }
        public Point GetMax(Point pNow, Point pPrev)
        {
            bool isVertical = (pNow.X == pPrev.X);
            Point pMax = null;
            Point pMin = null;
            if (isVertical)
            {
                if (pNow.Y > pPrev.Y)
                {
                    pMax = pNow;
                    pMin = pPrev;
                }
                else 
                {
                    pMax = pPrev;
                    pMin = pNow;
                }
            }
            else
            {
                if (pNow.X > pPrev.X)
                {
                    pMax = pNow;
                    pMin = pPrev;
                }
                else 
                {
                    pMax = pPrev;
                    pMin = pNow;
                }
            }
            return pMax;
        }
    }
}