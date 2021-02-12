using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2019
{
    public class PathCmdsToPoints
    {
        public List<Point> ParsePath(List<string> cmds)
        {
            int X = 0;
            int Y = 0;
            List<Point> path = new List<Point>();
            path.Add(new Point(0, 0));
            foreach (var cmd in cmds)
            {
                string tcmd = cmd.TrimStart();
                string ch = tcmd.Substring(0, 1);
                int dist = int.Parse(tcmd.Substring(1));
                switch (ch)
                {
                    case "R":
                        X += dist;
                        break;
                    case "L":
                        X -= dist;
                        break;
                    case "U":
                        Y += dist;
                        break;
                    case "D":
                        Y -= dist;
                        break;
                    default:
                        break;
                }
                path.Add(new Point(X, Y));
            }
            return path;
        }

        public int FindAllInterSections(List<Point> path0, List<Point> path1)
        {
            int distMin = int.MaxValue;
            int distNow;
            for (int idx0 = 0; idx0 < path0.Count - 1; idx0++)
            {
                Point p0Min = GetMin(path0[idx0], path0[idx0 + 1]);
                Point p0Max = GetMax(path0[idx0], path0[idx0 + 1]);
                bool isVertical = (p0Max.X == p0Min.X);

                for (int idx1 = 0; idx1 < path1.Count - 1; idx1++)
                {
                    Point p1Min = GetMin(path1[idx1], path1[idx1 + 1]);
                    Point p1Max = GetMax(path1[idx1], path1[idx1 + 1]);
                    if (idx0 == 0 && idx1 == 0)
                    {
                        continue;
                    }
                    if (isVertical && p1Min.Y >= p0Min.Y && p1Min.Y <= p0Max.Y && p1Min.X <= p0Min.X && p0Min.X <= p1Max.X)
                    {
                        // crossing
                        distNow = Math.Abs(p0Min.X) + Math.Abs(p1Min.Y);
                        distMin = (distNow < distMin) ? distNow : distMin;
                    }
                    if (!isVertical && p1Min.X >= p0Min.X && p1Min.X <= p0Max.X && p1Min.Y <= p0Min.Y && p0Min.Y <= p1Max.Y)
                    {
                        // crossing
                        distNow = Math.Abs(p1Min.X) + Math.Abs(p0Min.Y);
                        distMin = (distNow < distMin) ? distNow : distMin;
                    }
                }
            }

            return distMin;
        }

        public int FindLeastStepsIntersection(List<Point> path0, List<Point> path1)
        {
            Dictionary<string, Point> intersections = new Dictionary<string, Point>();
            string key;
            int steps0 = 0;
            for (int idx0 = 0; idx0 < path0.Count - 1; idx0++)
            {
                Point p0Min = GetMin(path0[idx0], path0[idx0 + 1]);
                Point p0Max = GetMax(path0[idx0], path0[idx0 + 1]);
                bool isVertical = (p0Max.X == p0Min.X);

                int steps1 = 0;
                for (int idx1 = 0; idx1 < path1.Count - 1; idx1++)
                {
                    Point p1Min = GetMin(path1[idx1], path1[idx1 + 1]);
                    Point p1Max = GetMax(path1[idx1], path1[idx1 + 1]);

                    if (idx0 == 0 && idx1 == 0)
                    {
                        // both start from origin, skip
                        steps1 += Distance(p1Min, p1Max);
                        continue;
                    }

                    if (isVertical && p1Min.Y >= p0Min.Y && p1Min.Y <= p0Max.Y && p1Min.X <= p0Min.X && p0Min.X <= p1Max.X)
                    {
                        // crossing
                        Point pV = new Point(p0Min.X, p1Min.Y);
                        pV.Steps0 = steps0 + Math.Abs(path0[idx0].Y - pV.Y);
                        pV.Steps1 = steps1 + Math.Abs(path1[idx1].X - pV.X);
                        key = $"({pV.X}, {pV.Y})";
                        if (intersections.ContainsKey(key))
                        {
                            // compare steps values
                            if(intersections[key].Steps0 > pV.Steps0)
                            {
                                intersections[key].Steps0 = pV.Steps0;
                            }
                            if (intersections[key].Steps1 > pV.Steps1)
                            {
                                intersections[key].Steps1 = pV.Steps1;
                            }
                        }
                        else
                        {
                            intersections.Add(key, pV);
                        }
                    }
                    if (!isVertical && p1Min.X >= p0Min.X && p1Min.X <= p0Max.X && p1Min.Y <= p0Min.Y && p0Min.Y <= p1Max.Y)
                    {
                        // crossing
                        Point pV = new Point(p1Min.X, p0Min.Y);
                        pV.Steps0 = steps0 + Math.Abs(path0[idx0].X - pV.X);
                        pV.Steps1 = steps1 + Math.Abs(path1[idx1].Y - pV.Y);
                        key = $"({pV.X}, {pV.Y})";
                        if (intersections.ContainsKey(key))
                        {
                            // compare steps values
                            if (intersections[key].Steps0 > pV.Steps0)
                            {
                                intersections[key].Steps0 = pV.Steps0;
                            }
                            if (intersections[key].Steps1 > pV.Steps1)
                            {
                                intersections[key].Steps1 = pV.Steps1;
                            }
                        }
                        else
                        {
                            intersections.Add(key, pV);
                        }
                    }
                    steps1 += Distance(p1Min, p1Max);
                }
                steps0 += Distance(p0Min, p0Max);
            }
            int stepsMin = int.MaxValue;
            foreach (var pt in intersections.Values)
            {
                stepsMin = (stepsMin < pt.TotalSteps) ? stepsMin : pt.TotalSteps;
            }
            return stepsMin;
        }

        public int Distance(Point a, Point b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
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
