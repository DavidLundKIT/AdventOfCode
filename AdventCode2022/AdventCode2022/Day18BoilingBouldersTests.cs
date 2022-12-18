using AdventCode2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2022
{
    public class Day18BoilingBouldersTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18.txt");
            int actual = lines.Length;
            Assert.Equal(2831, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18test.txt");
            int actual = lines.Length;
            Assert.Equal(13, actual);
        }

        [Fact]
        public void SurfaceArea_Test_OK()
        {
            var sut = new SurfaceAreaCalculator();
            sut.AddCube("1,1,1");
            sut.AddCube("1,1,1");
            sut.AddCube("2,1,1");
            Assert.Equal(2, sut.Cubes.Count);

            int actual = sut.SurfaceArea();
            Assert.Equal(10, actual);
        }

        [Fact]
        public void SurfaceArea_TestFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18test.txt");
            int actual = lines.Length;
            Assert.Equal(13, actual);

            var sut = new SurfaceAreaCalculator();

            sut.AddCubes(lines);
            Assert.Equal(13, sut.Cubes.Count);

            actual = sut.SurfaceArea();
            Assert.Equal(64, actual);
        }

        [Fact]
        public void SurfaceArea_Part1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18.txt");
            int actual = lines.Length;
            Assert.Equal(2831, actual);

            var sut = new SurfaceAreaCalculator();

            sut.AddCubes(lines);
            Assert.Equal(2831, sut.Cubes.Count);

            actual = sut.SurfaceArea();
            Assert.Equal(4548, actual);
        }

        [Fact]
        public void SurfaceAreaExternal_TestFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18test.txt");
            int actual = lines.Length;
            Assert.Equal(13, actual);

            var sut = new SurfaceAreaCalculator();

            sut.AddCubes(lines);
            Assert.Equal(13, sut.Cubes.Count);

            actual = sut.SurfaceAreaExternalOnly();
            Assert.Equal(58, actual);
        }

        [Fact]
        public void SurfaceAreaExternal_Part2_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day18.txt");
            int actual = lines.Length;
            Assert.Equal(2831, actual);

            var sut = new SurfaceAreaCalculator();

            sut.AddCubes(lines);
            Assert.Equal(2831, sut.Cubes.Count);

            actual = sut.SurfaceAreaExternalOnly();
            // 4218 is wrong
            Assert.Equal(0, actual);
        }
    }
}
