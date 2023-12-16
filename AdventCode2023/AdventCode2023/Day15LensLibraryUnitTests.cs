using AdventCode2023.Models;

namespace AdventCode2023
{
    public class Day15LensLibraryUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day15.txt");
            int expected = 1;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
            expected = 22969; // 22970; 
            Assert.Equal(expected, lines[0].Length);
        }

        [Fact]
        public void Hash_Test_OK()
        {
            string line = "HASH";
            var sut = new LensLibraryProcessor(line);

            int actual = sut.HashLine(line);
            Assert.Equal(52, actual);
        }

        [Fact]
        public void Hash_MultilpleLines_OK()
        {
            string line = "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7";
            var sut = new LensLibraryProcessor(line);

            int actual = sut.HashAllLines();
            Assert.Equal(1320, actual);
        }

        [Fact]
        public void Day15_Part1_LensLibrary_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day15.txt");
            int expected = 1;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
            expected = 22969; // 22970; 
            Assert.Equal(expected, lines[0].Length);

            var sut = new LensLibraryProcessor(lines[0]);

            actual = sut.HashAllLines();
            Assert.Equal(498538, actual);
        }

        [Fact]
        public void ProcessLens_Test_OK()
        {
            string line = "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7";
            var sut = new LensLibraryProcessor(line);

            sut.ProcessLensCmdsToBoxes();
            long totalFocusPower = sut.CalcFocusingPower();
            Assert.Equal(145, totalFocusPower);
        }

        [Fact]
        public void Day15_Part2_LensLibrary_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day15.txt");
            int expected = 1;
            int actual = lines.Length;
            Assert.Equal(expected, actual);
            expected = 22969; // 22970; 
            Assert.Equal(expected, lines[0].Length);

            var sut = new LensLibraryProcessor(lines[0]);

            sut.ProcessLensCmdsToBoxes();
            long totalFocusPower = sut.CalcFocusingPower();
            Assert.Equal(286278, totalFocusPower);
        }
    }
}
