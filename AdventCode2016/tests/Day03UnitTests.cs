using System;
using System.IO;
using Xunit;

namespace tests
{
    public class Day03UnitTests
    {
        private const string _indatafile = @"C:\Repos\AdventOfCode\Advent2016\data\day03.txt";

        [Fact]
        public void Day03TrianglesPart1()
        {
            var triangles = File.ReadAllLines(_indatafile);

            Assert.Equal(1915, triangles.Length);
            int validTriangles = 0;

            for (int i = 0; i < triangles.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(triangles[i]))
                {
                    int a = int.Parse(triangles[i].Substring(0, 5));
                    int b = int.Parse(triangles[i].Substring(5, 5));
                    int c = int.Parse(triangles[i].Substring(10, 5));
                    if (ValidTriangle(a, b, c))
                    {
                        validTriangles++;
                    }
                }
            }
            Assert.Equal(1032, validTriangles);
        }

        [Fact]
        public void Day03TrianglesVerticalPart2()
        {
            var triangles = File.ReadAllLines(_indatafile);

            Assert.Equal(1915, triangles.Length);
            int validTriangles = 0;

            for (int i = 0; i < triangles.Length; i+=3)
            {
                if (!string.IsNullOrWhiteSpace(triangles[i]))
                {
                    int a1 = int.Parse(triangles[i].Substring(0, 5));
                    int a2 = int.Parse(triangles[i].Substring(5, 5));
                    int a3 = int.Parse(triangles[i].Substring(10, 5));
                    int b1 = int.Parse(triangles[i+1].Substring(0, 5));
                    int b2 = int.Parse(triangles[i+1].Substring(5, 5));
                    int b3 = int.Parse(triangles[i+1].Substring(10, 5));
                    int c1 = int.Parse(triangles[i+2].Substring(0, 5));
                    int c2 = int.Parse(triangles[i+2].Substring(5, 5));
                    int c3 = int.Parse(triangles[i+2].Substring(10, 5));
                    if (ValidTriangle(a1, b1, c1))
                    {
                        validTriangles++;
                    }
                    if (ValidTriangle(a2, b2, c2))
                    {
                        validTriangles++;
                    }
                    if (ValidTriangle(a3, b3, c3))
                    {
                        validTriangles++;
                    }
                }
            }
            Assert.Equal(1838, validTriangles);
        }

        private bool ValidTriangle(int a, int b, int c)
        {
            return (a+ b > c) && (b + c > a) && (a + c > b);
        }
    }
}
