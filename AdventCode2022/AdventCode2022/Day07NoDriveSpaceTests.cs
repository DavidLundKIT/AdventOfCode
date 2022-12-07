using AdventCode2022.Models;

namespace AdventCode2022
{
    public class Day07NoDriveSpaceTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var things = Utils.ReadLinesFromFile("Day07.txt");
            int expected = 1060;
            int actual = things.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BuildFileSystem_Test_OK()
        {
            var ioList = Utils.ReadLinesFromFile("Day07test.txt");

            CommandParser os = new CommandParser("/");

            foreach (var cmd in ioList)
            {
                os.ParseIO(cmd);
            }

            Assert.Equal(48381165, os.Root.Size);

            long totalUnder100k = os.FindTotalForUnder100k();
            Assert.Equal(95437, totalUnder100k);
        }

        [Fact]
        public void NoDriveSpace_Part1_OK()
        {
            var ioList = Utils.ReadLinesFromFile("Day07.txt");

            CommandParser os = new CommandParser("/");

            foreach (var cmd in ioList)
            {
                os.ParseIO(cmd);
            }

            long expected = 40913445;
            Assert.Equal(expected, os.Root.Size);

            long totalUnder100k = os.FindTotalForUnder100k();
            expected = 1443806;
            Assert.Equal(expected, totalUnder100k);
        }

        [Fact]
        public void FindSmallestDir_Test_OK()
        {
            var ioList = Utils.ReadLinesFromFile("Day07test.txt");

            CommandParser os = new CommandParser("/");

            foreach (var cmd in ioList)
            {
                os.ParseIO(cmd);
            }

            Assert.Equal(48381165, os.Root.Size);

            long actual = os.FindSmallestDirectoryToDelete();
            Assert.Equal(24933642, actual);
        }

        [Fact]
        public void FindSmallestDirToDelete_Part2_OK()
        {
            var ioList = Utils.ReadLinesFromFile("Day07.txt");

            CommandParser os = new CommandParser("/");

            foreach (var cmd in ioList)
            {
                os.ParseIO(cmd);
            }

            long expected = 40913445;
            Assert.Equal(expected, os.Root.Size);
            expected = 942298;
            long actual = os.FindSmallestDirectoryToDelete();
            Assert.Equal(expected, actual);
        }
    }
}
