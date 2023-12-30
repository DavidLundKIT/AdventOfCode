using AdventCode2023.Models;

namespace AdventCode2023
{
    public class Day19AplentyUnitTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day19.txt");
            int expected = 769;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new AplentySorter(lines);
            Assert.Equal(568, sut.Workflows.Count);
            Assert.Equal(200, sut.Parts.Count);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day19test.txt");
            int expected = 17;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new AplentySorter(lines);
            Assert.Equal(11, sut.Workflows.Count);
            Assert.Equal(5, sut.Parts.Count);

            sut.SortParts();
            Assert.Equal(3, sut.AcceptedParts.Count);

            actual = sut.AcceptedRatingSum();
            Assert.Equal(19114, actual);
        }

        [Fact]
        public void Day19_Part1_AplentyRating_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day19.txt");
            int expected = 769;
            int actual = lines.Length;
            Assert.Equal(expected, actual);

            var sut = new AplentySorter(lines);
            Assert.Equal(568, sut.Workflows.Count);
            Assert.Equal(200, sut.Parts.Count);

            sut.SortParts();
            actual = sut.AcceptedRatingSum();
            Assert.Equal(397061, actual);
        }
    }
}
