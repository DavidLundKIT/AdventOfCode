using AdventCode2022.Models;

namespace AdventCode2022
{
    public class Day22MonkeyMapTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day22.txt");
            long actual = lines.Length;
            Assert.Equal(202, actual);

            var mmp = new MonkeyMapPassword(lines.ToList());

            actual = mmp.Map.Count();
            Assert.Equal(15000, actual);
            //mmp.DumpMap();
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day22test.txt");
            long actual = lines.Length;
            Assert.Equal(14, actual);

            var mmp = new MonkeyMapPassword(lines.ToList());

            actual = mmp.Map.Count();
            Assert.Equal(96, actual);
        }

        [Fact]
        public void MakePassword_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day22test.txt");
            long actual = lines.Length;
            Assert.Equal(14, actual);

            var mmp = new MonkeyMapPassword(lines.ToList());

            actual = mmp.Map.Count();
            Assert.Equal(96, actual);
            mmp.DumpMap();
            mmp.ProcessCommands();
            actual = mmp.MakePassword();
            Assert.Equal(6032, actual);
        }

        [Fact]
        public void MakePassword_Part1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day22.txt");
            long actual = lines.Length;
            Assert.Equal(202, actual);

            var mmp = new MonkeyMapPassword(lines.ToList());

            actual = mmp.Map.Count();
            Assert.Equal(15000, actual);
            //mmp.DumpMap();
            mmp.ProcessCommands();
            actual = mmp.MakePassword();
            // 146200 wrong
            // 147200
            Assert.Equal(155060, actual);
        }
    }
}
