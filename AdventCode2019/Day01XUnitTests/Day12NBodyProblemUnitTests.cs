using AdventOfCode2019;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day12NBodyProblemUnitTests
    {
        [Fact]
        public void Day12Part1_Example01()
        {
            //< x = -1, y = 0, z = 2 >
            //< x = 2, y = -10, z = -7 >
            //< x = 4, y = -8, z = 8 >
            //< x = 3, y = 5, z = -1 >
            int[,] bodies = new int[4, 3]
            {
                { -1, 0, 2 },
                { 2, -10, -7 },
                { 4, -8, 8 },
                { 3, 5, -1 }
            };
            var sut = new NBodyCalculator(bodies);
            Assert.NotNull(sut.Bodies);
            Assert.Equal(-1, sut.Bodies[0, 0]);
            Assert.Equal(-10, sut.Bodies[1, 1]);
            Assert.Equal(8, sut.Bodies[2, 2]);
            Assert.Equal(5, sut.Bodies[3, 1]);
            sut.DumpBodiesAndVelocities();

            // step 1
            sut.CalculateVelocity();
            sut.ApplyVelocity();
            sut.DumpBodiesAndVelocities();
            Assert.Equal(2, sut.Bodies[0, 0]);
            Assert.Equal(-7, sut.Bodies[1, 1]);
            Assert.Equal(5, sut.Bodies[2, 2]);
            Assert.Equal(2, sut.Bodies[3, 1]);

            for (int step = 2; step <= 10; step++)
            {
                Debug.WriteLine("Step: ", step);
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                sut.DumpBodiesAndVelocities();
            }
            Assert.Equal(2, sut.Bodies[0, 0]);
            Assert.Equal(-8, sut.Bodies[1, 1]);
            Assert.Equal(1, sut.Bodies[2, 2]);
            Assert.Equal(0, sut.Bodies[3, 1]);

            Assert.Equal(179, sut.CalculateTotalEnergy());
        }

        [Fact]
        public void Day12Part1_Example02()
        {
            //< x = -8, y = -10, z = 0 >
            //< x = 5, y = 5, z = 10 >
            //< x = 2, y = -7, z = 3 >
            //< x = 9, y = -8, z = -3 >
            int[,] bodies = new int[4, 3]
            {
                    { -8, -10, 0 },
                    { 5, 5, 10 },
                    { 2, -7, 3 },
                    { 9, -8, -3 }
            };

            var sut = new NBodyCalculator(bodies);
            Assert.NotNull(sut.Bodies);
            Assert.Equal(-8, sut.Bodies[0, 0]);
            Assert.Equal(5, sut.Bodies[1, 1]);
            Assert.Equal(3, sut.Bodies[2, 2]);
            Assert.Equal(-8, sut.Bodies[3, 1]);
            sut.DumpBodiesAndVelocities();

            for (int step = 1; step <= 100; step++)
            {
                Debug.WriteLine("Step: ", step);
                sut.CalculateVelocity();
                sut.ApplyVelocity();
            }
            sut.DumpBodiesAndVelocities();
            Assert.Equal(8, sut.Bodies[0, 0]);
            Assert.Equal(16, sut.Bodies[1, 1]);
            Assert.Equal(-1, sut.Bodies[2, 2]);
            Assert.Equal(-13, sut.Bodies[3, 1]);

            Assert.Equal(1940, sut.CalculateTotalEnergy());
        }

        [Fact]
        public void Day12Part1_TestSolution()
        {
            //            string[] bodies = DayDataUtilities.ReadLinesFromFile("day12.txt");
            //            Assert.NotNull(bodies);
            //< x = 15, y = -2, z = -6 >
            //< x = -5, y = -4, z = -11 >
            //< x = 0, y = -6, z = 0 >
            //< x = 5, y = 9, z = 6 >
            int[,] bodies = new int[4, 3]
            {
                { 15, -2, -6 },
                { -5, -4, -11 },
                { 0, -6, 0 },
                { 5, 9, 6 }
            };
            var sut = new NBodyCalculator(bodies);
            Assert.NotNull(sut.Bodies);
            Assert.Equal(15, sut.Bodies[0, 0]);
            Assert.Equal(-4, sut.Bodies[1, 1]);
            Assert.Equal(0, sut.Bodies[2, 2]);
            Assert.Equal(9, sut.Bodies[3, 1]);
            sut.DumpBodiesAndVelocities();

            for (int step = 1; step <= 1000; step++)
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
            }
            sut.DumpBodiesAndVelocities();

            Assert.Equal(6735, sut.CalculateTotalEnergy());
        }

        [Fact]
        public void Day12Part2_Example01()
        {
            //< x = -1, y = 0, z = 2 >
            //< x = 2, y = -10, z = -7 >
            //< x = 4, y = -8, z = 8 >
            //< x = 3, y = 5, z = -1 >
            int[,] bodies = new int[4, 3]
            {
                { -1, 0, 2 },
                { 2, -10, -7 },
                { 4, -8, 8 },
                { 3, 5, -1 }
            };
            var sut = new NBodyCalculator(bodies);
            Assert.NotNull(sut.Bodies);
            Assert.Equal(-1, sut.Bodies[0, 0]);
            Assert.Equal(-10, sut.Bodies[1, 1]);
            Assert.Equal(8, sut.Bodies[2, 2]);
            Assert.Equal(5, sut.Bodies[3, 1]);
            sut.DumpBodiesAndVelocities();
            string hash = sut.HashBodiesAndVelocities();

            Dictionary<string, long> hashDict = new Dictionary<string, long>();

            hashDict.Add(hash, 0);

            long step = 1;
            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                hash = sut.HashBodiesAndVelocities();
                if (hashDict.ContainsKey(hash))
                {
                    sut.DumpBodiesAndVelocities();
                    break;
                }
                hashDict.Add(hash, step);
                step++;
            } while (step > 1);
            Assert.Equal(2772, step);
        }

        [Fact]
        public void Day12Part2_Example01in3s()
        {
            //< x = -1, y = 0, z = 2 >
            //< x = 2, y = -10, z = -7 >
            //< x = 4, y = -8, z = 8 >
            //< x = 3, y = 5, z = -1 >
            int[,] orgBodies = new int[4, 3]
            {
                { -1, 0, 2 },
                { 2, -10, -7 },
                { 4, -8, 8 },
                { 3, 5, -1 }
            };
            int[,] bodies = new int[4, 3]
            {
                { -1, 0, 2 },
                { 2, -10, -7 },
                { 4, -8, 8 },
                { 3, 5, -1 }
            };
            var sut = new NBodyCalculator(bodies);
            Assert.NotNull(sut.Bodies);
            Assert.Equal(-1, sut.Bodies[0, 0]);
            Assert.Equal(-10, sut.Bodies[1, 1]);
            Assert.Equal(8, sut.Bodies[2, 2]);
            Assert.Equal(5, sut.Bodies[3, 1]);
            sut.DumpBodiesAndVelocities();

            Assert.True(sut.Equal(orgBodies, 0));
            Assert.True(sut.Equal(orgBodies, 1));
            Assert.True(sut.Equal(orgBodies, 2));

            long step = 1;
            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                step++;
            } while (!sut.Equal(orgBodies, 0));
            Assert.Equal(19, step);

            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                step++;
            } while (!sut.Equal(orgBodies, 0));
            Assert.Equal(37, step);

            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                step++;
            } while (!sut.Equal(orgBodies, 0));
            Assert.Equal(55, step);

            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                step++;
            } while (!sut.Equal(orgBodies, 0));
            Assert.Equal(73, step);

            sut = new NBodyCalculator(orgBodies);
            step = 1;
            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                step++;
            } while (!sut.Equal(orgBodies, 1));
            Assert.Equal(29, step);

            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                step++;
            } while (!sut.Equal(orgBodies, 1));
            Assert.Equal(29 + 28, step);

            sut = new NBodyCalculator(orgBodies);
            step = 1;
            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                step++;
            } while (!sut.Equal(orgBodies, 2));
            Assert.Equal(45, step);

            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                step++;
            } while (!sut.Equal(orgBodies, 2));
            Assert.Equal(45 + 44, step);
        }

        [Fact(Skip = "Doesn't end")]
        public void Day12Part2_TestSolution()
        {
            //            string[] bodies = DayDataUtilities.ReadLinesFromFile("day12.txt");
            //            Assert.NotNull(bodies);
            //< x = 15, y = -2, z = -6 >
            //< x = -5, y = -4, z = -11 >
            //< x = 0, y = -6, z = 0 >
            //< x = 5, y = 9, z = 6 >
            int[,] bodies = new int[4, 3]
            {
                { 15, -2, -6 },
                { -5, -4, -11 },
                { 0, -6, 0 },
                { 5, 9, 6 }
            };
            var sut = new NBodyCalculator(bodies);
            Assert.NotNull(sut.Bodies);
            Assert.Equal(15, sut.Bodies[0, 0]);
            Assert.Equal(-4, sut.Bodies[1, 1]);
            Assert.Equal(0, sut.Bodies[2, 2]);
            Assert.Equal(9, sut.Bodies[3, 1]);
            sut.DumpBodiesAndVelocities();

            string hash = sut.HashBodiesAndVelocities();

            Dictionary<string, long> hashDict = new Dictionary<string, long>();

            hashDict.Add(hash, 0);

            long step = 1;
            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                hash = sut.HashBodiesAndVelocities();
                if (hashDict.ContainsKey(hash))
                {
                    sut.DumpBodiesAndVelocities();
                    break;
                }
                hashDict.Add(hash, step);
                step++;
            } while (step > 1);
            Assert.Equal(1, step);
        }

        /// <summary>
        /// Find the period of the x, the y, and the z parts.
        /// Then using all the common prime factors figure out the first time when all cycles match.
        /// </summary>
        [Fact]
        public void Day12Part2_TestSolutionIn3Parts()
        {
            //< x = 15, y = -2, z = -6 >
            //< x = -5, y = -4, z = -11 >
            //< x = 0, y = -6, z = 0 >
            //< x = 5, y = 9, z = 6 >
            int[,] bodies = new int[4, 3]
            {
                { 15, -2, -6 },
                { -5, -4, -11 },
                { 0, -6, 0 },
                { 5, 9, 6 }
            };
            int[,] orgBodies = new int[4, 3]
            {
                { 15, -2, -6 },
                { -5, -4, -11 },
                { 0, -6, 0 },
                { 5, 9, 6 }
            };
            var sut = new NBodyCalculator(bodies);
            Assert.NotNull(sut.Bodies);
            Assert.Equal(15, sut.Bodies[0, 0]);
            Assert.Equal(-4, sut.Bodies[1, 1]);
            Assert.Equal(0, sut.Bodies[2, 2]);
            Assert.Equal(9, sut.Bodies[3, 1]);
            sut.DumpBodiesAndVelocities();

            Assert.True(sut.Equal(orgBodies, 0));
            Assert.True(sut.Equal(orgBodies, 1));
            Assert.True(sut.Equal(orgBodies, 2));

            long step = 1;
            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                step++;
            } while (!sut.Equal(orgBodies, 0));
            Assert.Equal(161429, step);

            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                step++;
            } while (!sut.Equal(orgBodies, 0));
            Assert.Equal(161429 + 161428, step);

            sut = new NBodyCalculator(orgBodies);
            step = 1;
            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                step++;
            } while (!sut.Equal(orgBodies, 1));
            Assert.Equal(167625, step);

            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                step++;
            } while (!sut.Equal(orgBodies, 1));
            Assert.Equal(167625 + 167624, step);

            sut = new NBodyCalculator(orgBodies);
            step = 1;
            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                step++;
            } while (!sut.Equal(orgBodies, 2));
            Assert.Equal(193053, step);

            do
            {
                sut.CalculateVelocity();
                sut.ApplyVelocity();
                step++;
            } while (!sut.Equal(orgBodies, 2));
            Assert.Equal(193053 + 193052, step);

            // x: 161428 = 2*2*40357
            // y: 167624 = 2*2*2*23*911
            // z: 193052 = 2*2*17*17*167
            long result = 2L * 2 * 2 * 17 * 17 * 23 * 167 * 911 * 40357;
            Assert.Equal(326489627728984, result);
        }
    }
}
