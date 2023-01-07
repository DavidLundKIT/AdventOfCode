using AdventCode2022.Models;

namespace AdventCode2022
{
    public class Day23UnstableDiffusionTests
    {

        public string[] SmallTestData { get; set; }

        public Day23UnstableDiffusionTests()
        {
            SmallTestData = new string[] {
                "##",
                "#.",
                "..",
                "##"
            };
        }

        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day23.txt");
            int actual = lines.Length;
            Assert.Equal(72, actual);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day23test.txt");
            int actual = lines.Length;
            Assert.Equal(7, actual);
        }

        [Fact]
        public void ShowCube_SmallTest_OK()
        {
            var sut = new ElfDiffuser(SmallTestData);

            long actual = sut.EmptyTilesNow();
            sut.DumpElvesNow($"EmptyTiles: {actual}");
            Assert.Equal(3, actual);
            sut.DoARound();
            actual = sut.EmptyTilesNow();
            sut.DumpElvesNow($"EmptyTiles: {actual}");
            sut.DoARound();
            actual = sut.EmptyTilesNow();
            sut.DumpElvesNow($"EmptyTiles: {actual}");
            sut.DoARound();
            actual = sut.EmptyTilesNow();
            sut.DumpElvesNow($"EmptyTiles: {actual}");
            sut.DoARound();
            actual = sut.EmptyTilesNow();
            sut.DumpElvesNow($"No one should have moved: {actual}");
        }

        [Fact]
        public void ShowCube_EmptyTiles10_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day23test.txt");
            long actual = lines.Length;
            Assert.Equal(7, actual);
            var sut = new ElfDiffuser(lines);

            actual = sut.EmptyTilesNow();
            sut.DumpElvesNow($"Start EmptyTiles: {actual}");
            for (int i = 0; i < 10; i++)
            {
                sut.DoARound();
                actual = sut.EmptyTilesNow();
                sut.DumpElvesNow($"EmptyTiles: {actual}");
            }
            Assert.Equal(110, actual);
        }

        [Fact]
        public void ShowCube_EmptyTiles10_Part1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day23.txt");
            long actual = lines.Length;
            Assert.Equal(72, actual);
            var sut = new ElfDiffuser(lines);

            actual = sut.EmptyTilesNow();
            sut.DumpElvesNow($"Start EmptyTiles: {actual}");
            for (int i = 0; i < 10; i++)
            {
                sut.DoARound();
            }
            actual = sut.EmptyTilesNow();
            sut.DumpElvesNow($"EmptyTiles: {actual}");
            Assert.Equal(4146, actual);
        }


        [Fact]
        public void NoElfMoves_Round_20_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day23test.txt");
            long actual = lines.Length;
            Assert.Equal(7, actual);
            var sut = new ElfDiffuser(lines);

            long rounds = 0;
            do
            {
                sut.DoARound();
                rounds++;
            } while (sut.ElfMoves.Count > 0);

            Assert.Equal(20, rounds);
        }

        [Fact]
        public void NoElfMoves_Round_Part2_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day23.txt");
            long actual = lines.Length;
            Assert.Equal(72, actual);
            var sut = new ElfDiffuser(lines);

            long rounds = 0;
            do
            {
                sut.DoARound();
                rounds++;
            } while (sut.ElfMoves.Count > 0);

            Assert.Equal(957, rounds);
        }
    }
}
