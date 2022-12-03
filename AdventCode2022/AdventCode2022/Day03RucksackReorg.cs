namespace AdventCode2022
{
    public class Day03RucksackReorg
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var things = Utils.ReadLinesFromFile("Day03.txt");
            int expected = 300;
            int actual = things.Length;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 'p', 16)]
        [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 'L', 38)]
        [InlineData("PmmdzqPrVvPwwTWBwg", 'P', 42)]
        [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 'v', 22)]
        [InlineData("ttgJtRGJQctTZtZT", 't', 20)]
        [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", 's', 19)]
        public void FindItemInRucksackAndPrio(string rucksack, char expectedItem, int expected)
        {
            char actualItem = FindItemInRucksack(rucksack);
            Assert.Equal(expectedItem, actualItem);
            int actual = CalcPriority(actualItem);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RucksackReorg_Part1_OK()
        {
            var rucksacks = Utils.ReadLinesFromFile("Day03.txt");
            int expected = 300;
            int actual = rucksacks.Length;
            Assert.Equal(expected, actual);

            int sumPrios = 0;
            foreach (var rucksack in rucksacks)
            {
                char item = FindItemInRucksack(rucksack);
                int prio = CalcPriority(item);
                sumPrios += prio;
            }
            Assert.Equal(7581, sumPrios);
        }

        [Theory]
        [InlineData(new string[] { "vJrwpWtwJgWrhcsFMMfFFhFp", "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", "PmmdzqPrVvPwwTWBwg" },'r', 18)]
        [InlineData(new string[] { "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", "ttgJtRGJQctTZtZT", "CrZsJsPPZsGzwwsLwLmpwMDw" }, 'Z', 52)]
        public void FindCommonItemInRucksackAndPrio(string[] rucksacks, char expectedItem, int expected)
        {
            char actualItem = FindCommonItemInRucsacks(rucksacks);
            Assert.Equal(expectedItem, actualItem);
            int actual = CalcPriority(actualItem);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RucksackReorg_Part2_OK()
        {
            var rucksacks = Utils.ReadLinesFromFile("Day03.txt");
            int expected = 300;
            int actual = rucksacks.Length;
            Assert.Equal(expected, actual);

            int sumPrios = 0;
            for (int ii = 0; ii < rucksacks.Length; ii+=3)
            {
                var sacks = rucksacks.Skip(ii).Take(3);
                char item = FindCommonItemInRucsacks(sacks.ToArray());
                int prio = CalcPriority(item);
                sumPrios += prio;
            }
            Assert.Equal(2525, sumPrios);
        }

        public char FindCommonItemInRucsacks(string[] rucksacks)
        {
            HashSet<char> h1 = new HashSet<char>(rucksacks[0]);
            HashSet<char> h2 = new HashSet<char>(rucksacks[1]);
            HashSet<char> h3 = new HashSet<char>(rucksacks[2]);
            h1.IntersectWith(h2);
            h1.IntersectWith(h3);
            return h1.Single();
        }

        public char FindItemInRucksack(string rucksack)
        {
            HashSet<char> side1 = new HashSet<char>(rucksack.Substring(0, rucksack.Length / 2));
            HashSet<char> side2 = new HashSet<char>(rucksack.Substring(rucksack.Length / 2));
            //Assert.Equal(rucksack.Length, side1.Count + side2.Count);
            //Assert.Equal(side1.Count, side2.Count);
            side1.IntersectWith(side2);
            return side1.Single();
        }

        // Used this first
        public char FindItemInRucksackFirst(string rucksack)
        {
            string side1 = rucksack.Substring(0, rucksack.Length / 2);
            string side2 = rucksack.Substring(rucksack.Length / 2);
            Assert.Equal(rucksack.Length, side1.Length + side2.Length);
            Assert.Equal(side1.Length, side2.Length);
            foreach (var item in side1)
            {
                if (side2.Contains(item, StringComparison.InvariantCulture))
                {
                    return item;
                }
            }
            return ' ';
        }

        public int CalcPriority(char item)
        {
            if (char.IsLower(item))
            {
                return item - 'a' + 1;
            }
            return item - 'A' + 27;
        }
    }
}
