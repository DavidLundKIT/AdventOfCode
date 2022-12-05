namespace AdventCode2022
{
    public class Day04CampCleanupTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var elfSections = Utils.ReadLinesFromFile("Day04.txt");
            int expected = 1000;
            int actual = elfSections.Length;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2-4,6-8", false)]
        [InlineData("2-3,4-5", false)]
        [InlineData("5-7,7-9", false)]
        [InlineData("2-8,3-7", true)]
        [InlineData("6-6,4-6", true)]
        [InlineData("2-6,4-8", false)]
        public void OnContainsTheOther_OK(string elfSection, bool expected)
        {
            bool actual = OneContainsTheOther(elfSection);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ContainedElfSections_Part1_OK()
        {
            var elfSections = Utils.ReadLinesFromFile("Day04.txt");
            int expected = 1000;
            int actual = elfSections.Length;
            Assert.Equal(expected, actual);

            int count = 0;
            foreach (var elfSection in elfSections)
            {
                if (OneContainsTheOther(elfSection))
                {
                    count++;
                }
            }

            Assert.Equal(560, count);
        }

        [Theory]
        [InlineData("2-4,6-8", false)]
        [InlineData("2-3,4-5", false)]
        [InlineData("5-7,7-9", true)]
        [InlineData("2-8,3-7", true)]
        [InlineData("6-6,4-6", true)]
        [InlineData("2-6,4-8", true)]
        public void OverlappingSections_OK(string elfSection, bool expected)
        {
            bool actual = OverlappingSections(elfSection);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void OverlappingElfSections_Part2_OK()
        {
            var elfSections = Utils.ReadLinesFromFile("Day04.txt");
            int expected = 1000;
            int actual = elfSections.Length;
            Assert.Equal(expected, actual);

            int count = 0;
            foreach (var elfSection in elfSections)
            {
                if (OverlappingSections(elfSection))
                {
                    count++;
                }
            }

            Assert.Equal(839, count);
        }

        private bool OneContainsTheOther(string elfSection)
        {
            var ends = elfSection.Split(new char[] { '-', ',', ' ' }).Select(s => int.Parse(s)).ToList();
            HashSet<int> elf1 = new HashSet<int>(Enumerable.Range(ends[0], ends[1] - ends[0]+1));
            HashSet<int> elf2 = new HashSet<int>(Enumerable.Range(ends[2], ends[3] - ends[2] + 1));
            if (elf1.IsSubsetOf(elf2) || elf2.IsSubsetOf(elf1))
            {
                return true;
            }
            return false;
        }

        private bool OverlappingSections(string elfSection)
        {
            var ends = elfSection.Split(new char[] { '-', ',', ' ' }).Select(s => int.Parse(s)).ToList();
            HashSet<int> elf1 = new HashSet<int>(Enumerable.Range(ends[0], ends[1] - ends[0] + 1));
            HashSet<int> elf2 = new HashSet<int>(Enumerable.Range(ends[2], ends[3] - ends[2] + 1));
            return elf1.Overlaps(elf2);
        }
    }
}
