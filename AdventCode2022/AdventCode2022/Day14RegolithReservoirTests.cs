using AdventCode2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2022
{
    public class Day14RegolithReservoirTests
    {
		[Fact]
		public void ReadInDataFile_OK()
		{
			var lines = Utils.ReadLinesFromFile("Day14.txt");
			int actual = lines.Length;
			Assert.Equal(138, actual);
		}

		[Fact]
		public void DrawMap_TestData()
		{
			var sut = new RegolithMapper();
			sut.AddPath("498,4 -> 498,6 -> 496,6");
			sut.AddPath("503,4 -> 502,4 -> 502,9 -> 494,9");
            sut.Map.Add(new Tuple<int, int>(500, 0), "+");
            sut.DumpMap();
			Assert.Equal(21, sut.Map.Count);
            sut.InitBorders();
            int actual = sut.DropSandTillOverflow();

            Assert.Equal(24, actual);
		}

        [Fact]
        public void DrawMap_File_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14.txt");
            int actual = lines.Length;
            Assert.Equal(138, actual);

            var sut = new RegolithMapper();
            sut.MakeMap(lines);
            sut.DumpMap();
            Assert.Equal(566, sut.Map.Count);
        }

        [Fact]
        public void DropSandCount_Part1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day14.txt");
            int actual = lines.Length;
            Assert.Equal(138, actual);

            var sut = new RegolithMapper();
            sut.MakeMap(lines);
            sut.DumpMap();
            Assert.Equal(566, sut.Map.Count);

            sut.InitBorders();
            actual = sut.DropSandTillOverflow();
            Assert.Equal(808, actual);
            sut.DumpMap();
        }
    }
}
