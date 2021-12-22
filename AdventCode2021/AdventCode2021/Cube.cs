using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AdventCode2021
{
    public class Cube : IEquatable<Cube>, IEqualityComparer<Cube>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Cube(string line)
        {
            var vals = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            X = int.Parse(vals[0]);
            Y = int.Parse(vals[1]);
            Z = int.Parse(vals[2]);
        }
        public Cube(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Cube()
        {
        }

        public override string ToString()
        {
            return $"{X},{Y},{Z}";
        }

        public override bool Equals(object obj)
        {
            Cube p = obj as Cube;
            if (p == null)
                return false;
            return Equals(p);
        }

        public bool Equals([AllowNull] Cube other)
        {
            if (other == null)
                return false;
            return (other.X == X && other.Y == Y && other.Z == Z);
        }

        public bool Equals([AllowNull] Cube x, [AllowNull] Cube y)
        {
            if (x == null)
                return false;
            return x.Equals(y);
        }

        public override int GetHashCode()
        {
            return X ^ Y ^ Z;
        }

        public int GetHashCode([DisallowNull] Cube obj)
        {
            return X ^ Y ^ Z;
        }
    }
}
