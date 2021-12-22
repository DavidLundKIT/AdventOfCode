using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AdventCode2021
{
    public class Point : IEquatable<Point>, IEqualityComparer<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(string line)
        {
            var vals = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            X = int.Parse(vals[0]);
            Y = int.Parse(vals[1]);
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point()
        {
        }

        public override string ToString()
        {
            return $"{X},{Y}";
        }

        public override bool Equals(object obj)
        {
            Point p = obj as Point;
            if (p == null)
                return false;
            return Equals(p);
        }

        public bool Equals([AllowNull] Point other)
        {
            if (other == null)
                return false;
            return (other.X == X && other.Y == Y);
        }

        public bool Equals([AllowNull] Point x, [AllowNull] Point y)
        {
            if (x == null)
                return false;
            return x.Equals(y);
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public int GetHashCode([DisallowNull] Point obj)
        {
            return X ^ Y;
        }
    }
}
