using AdventOfCode2019;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day03CrossedWiresUnitTests
    {
        [Theory]
        [InlineData("R75, D30, R83, U83, L12, D49, R71, U7, L72", "U62, R66, U55, R34, D71, R55, D58, R83", 159)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void Day03Part1_Examples(string data0, string data1, int expectedDist)
        {
            List<string> cmds0 = new List<string>(data0.Split(','));
            List<string> cmds1 = new List<string>(data1.Split(','));
            Assert.NotNull(cmds0);
            Assert.NotNull(cmds1);

            PathCmdsToPoints pathMaker = new PathCmdsToPoints();
            List<Point> path0 = pathMaker.ParsePath(cmds0);
            List<Point> path1 = pathMaker.ParsePath(cmds1);

            Assert.NotNull(path0);
            Assert.Equal(cmds0.Count + 1, path0.Count);
            Assert.NotNull(path1);
            Assert.Equal(cmds1.Count + 1, path1.Count);

            int actualDist = pathMaker.FindAllInterSections(path0, path1);
            Assert.Equal(expectedDist, actualDist);
        }

        [Fact]
        public void Day03Part1_TestSolution()
        {
            string[] vectors = DayDataUtilities.ReadLinesFromFile("day03.txt");

            Assert.Equal(2, vectors.Length);
            List<string> cmds0 = new List<string>(vectors[0].Split(','));
            List<string> cmds1 = new List<string>(vectors[1].Split(','));
            Assert.NotNull(cmds0);
            Assert.NotNull(cmds1);

            PathCmdsToPoints pathMaker = new PathCmdsToPoints();
            List<Point> path0 = pathMaker.ParsePath(cmds0);
            List<Point> path1 = pathMaker.ParsePath(cmds1);

            int actualDist = pathMaker.FindAllInterSections(path0, path1);
            Assert.Equal(1264, actualDist);
        }

        [Theory]
        [InlineData("R75, D30, R83, U83, L12, D49, R71, U7, L72", "U62, R66, U55, R34, D71, R55, D58, R83", 610)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 410)]
        public void Day03Part2_StepsExamples(string data0, string data1, int expectedSteps)
        {
            List<string> cmds0 = new List<string>(data0.Split(','));
            List<string> cmds1 = new List<string>(data1.Split(','));
            Assert.NotNull(cmds0);
            Assert.NotNull(cmds1);

            PathCmdsToPoints pathMaker = new PathCmdsToPoints();
            List<Point> path0 = pathMaker.ParsePath(cmds0);
            List<Point> path1 = pathMaker.ParsePath(cmds1);

            Assert.NotNull(path0);
            Assert.Equal(cmds0.Count + 1, path0.Count);
            Assert.NotNull(path1);
            Assert.Equal(cmds1.Count + 1, path1.Count);

            int actualSteps = pathMaker.FindLeastStepsIntersection(path0, path1);
            Assert.Equal(expectedSteps, actualSteps);
        }

        [Fact]
        public void Day03Part2_TestSolution()
        {
            string[] vectors = DayDataUtilities.ReadLinesFromFile("day03.txt");

            Assert.Equal(2, vectors.Length);
            List<string> cmds0 = new List<string>(vectors[0].Split(','));
            List<string> cmds1 = new List<string>(vectors[1].Split(','));
            Assert.NotNull(cmds0);
            Assert.NotNull(cmds1);

            PathCmdsToPoints pathMaker = new PathCmdsToPoints();
            List<Point> path0 = pathMaker.ParsePath(cmds0);
            List<Point> path1 = pathMaker.ParsePath(cmds1);

            int actualSteps = pathMaker.FindLeastStepsIntersection(path0, path1);
            Assert.Equal(37390, actualSteps);
        }

    }
}
