using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2019
{
    public class Point: IEquatable<Point>
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
            Steps0 = 0;
            Steps1 = 0;
        }
        public int X { get; set; }
        public double dX { get { return Convert.ToDouble(X); } }
        public int Y { get; set; }
        public double dY { get { return Convert.ToDouble(Y); } }

        public int Steps0 { get; set; }
        public int Steps1 { get; set; }
        public int TotalSteps
        {
            get 
            { 
                return Steps0 + Steps1;
            }
        }

        public bool Equals([AllowNull] Point other)
        {
            if (other != null)
            {
                return (X == other.X && Y == other.Y);
            }
            return false;
        }

        public override bool Equals(object other)
        {
            Point otherPoint = other as Point;
            if (other != null)
            {
                return this.Equals(otherPoint);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Point ({X}, {Y}) s0: {Steps0}, s1: {Steps1}, ts: {TotalSteps}";
        }
    }

    public class PointEqualityComparer : IEqualityComparer<Point>
    {
        public bool Equals([AllowNull] Point x, [AllowNull] Point y)
        {
            if (x == null && y == null)
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            return (x.X == y.X && x.Y == y.Y);
        }

        public int GetHashCode([DisallowNull] Point obj)
        {
            int hCode = obj.X ^ obj.Y;
            return hCode.GetHashCode();
        }
    }

    public class PolarPoint
    {
        public Point cartPt { get; set; }
        public double dist { get; set; }
        public double angle { get; set; }

        public PolarPoint(Point pt, Point originPt)
        {
            cartPt = pt;

            dist = Math.Sqrt(Math.Pow((pt.dX - originPt.dX), 2) + Math.Pow((pt.dY - originPt.dY),2));
            angle = Math.Atan2((pt.dY - originPt.dY), (pt.dX - originPt.dX));
        }
        public override string ToString()
        {
            return $"PolarPoint a:{angle}, d: {dist} cartPt: {cartPt}";
        }
    }
}
