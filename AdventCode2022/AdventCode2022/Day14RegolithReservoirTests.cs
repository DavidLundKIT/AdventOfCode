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

	}
}
