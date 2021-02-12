using AdventOfCode2020;
using Xunit;

namespace DailyXUnitTests
{
    public class Day17ConwayCubesUnitTests
    {
        private string[] example1 = new string[] {
            ".#.",
            "..#",
            "###"
        };

        [Fact(Skip = "Daily completed")]
        public void Day17ReadParseData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day17Data.txt");
            Assert.Equal(8, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void Day17_Example1_Ok()
        {
            var sut = new ConwayCubes();
            Assert.NotNull(sut);
            sut.CreateStartCubes(example1);
            int actual = sut.Cubes[sut.Now].Count;
            Assert.Equal(5, actual);
            Assert.Equal(5, sut.NumberActiveCubes(sut.Now));
            sut.DumpGeneration();
            for (int i = 0; i < 6; i++)
            {
                sut.DoCycle();
                sut.Toggle();
                sut.DumpGeneration();
            }
            actual = sut.NumberActiveCubes(sut.Now);
            Assert.Equal(112, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day17Conwaycubes_Part1_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day17Data.txt");
            Assert.Equal(8, lines.Length);

            var sut = new ConwayCubes();
            Assert.NotNull(sut);
            sut.CreateStartCubes(lines);
            int actual = sut.Cubes[sut.Now].Count;
            Assert.Equal(25, actual);
            Assert.Equal(25, sut.NumberActiveCubes(sut.Now));

            for (int i = 0; i < 6; i++)
            {
                sut.DoCycle();
                sut.Toggle();
            }
            actual = sut.NumberActiveCubes(sut.Now);
            Assert.Equal(211, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day17_Example2_Ok()
        {
            var sut = new ConwayCubes4D();
            Assert.NotNull(sut);
            sut.CreateStartCubes(example1);
            int actual = sut.Cubes[sut.Now].Count;
            Assert.Equal(5, actual);
            Assert.Equal(5, sut.NumberActiveCubes(sut.Now));
            sut.DumpGeneration();
            for (int i = 0; i < 6; i++)
            {
                sut.DoCycle();
                sut.Toggle();
                sut.DumpGeneration();
            }
            actual = sut.NumberActiveCubes(sut.Now);
            Assert.Equal(848, actual);
        }

        [Fact(Skip = "Daily completed")]
        public void Day17Conwaycubes_Part2_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day17Data.txt");
            Assert.Equal(8, lines.Length);

            var sut = new ConwayCubes4D();
            Assert.NotNull(sut);
            sut.CreateStartCubes(lines);
            int actual = sut.Cubes[sut.Now].Count;
            Assert.Equal(25, actual);
            Assert.Equal(25, sut.NumberActiveCubes(sut.Now));

            for (int i = 0; i < 6; i++)
            {
                sut.DoCycle();
                sut.Toggle();
            }
            actual = sut.NumberActiveCubes(sut.Now);
            Assert.Equal(1952, actual);
        }
    }
}
