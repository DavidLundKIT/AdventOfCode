namespace AdventCode2022
{
    public class Day01CalorieCountingTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var calorieList = Utils.ReadLinesFromFile("Day01.txt");
            int expected = 2243;
            int actual = calorieList.Length;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CountingCalories_FindMax_Part1()
        {
            var calorieList = Utils.ReadLinesFromFile("Day01.txt");

            var elfCalDict = GetElfCalories(calorieList);
            var maxCalories = elfCalDict.Values.Max();
            Assert.Equal(69626, maxCalories);
        }

        [Fact]
        public void CountingCalories_FindTop3_Part2()
        {
            var calorieList = Utils.ReadLinesFromFile("Day01.txt");

            var elfCalDict = GetElfCalories(calorieList);
            var maxCalories = elfCalDict.Values.Max();
            Assert.Equal(69626, maxCalories);

            var max3list = elfCalDict.Values.OrderByDescending(v => v).Take(3);
            var max3Sum = max3list.Sum();
            Assert.Equal(206780, max3Sum);
        }

        public Dictionary<int, int> GetElfCalories(string[] calorieList)
        {
            Dictionary<int, int> elfCalories = new Dictionary<int, int>();

            int elf = 1;
            elfCalories.Add(elf, 0);
            foreach (var item in calorieList)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    elf++;
                    elfCalories.Add(elf, 0);
                }
                else
                {
                    int calories = int.Parse(item);
                    elfCalories[elf] += calories;
                }
            }

            return elfCalories;
        }
    }
}