using AdventCode2024.Models;

namespace AdventCode2024
{
    public class Day01HistorianHysteriaUnitTests
    {
        [Fact]
        public void Day01_Step1_ListDistances_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day01.txt");
            int count = 1000;
            Assert.Equal(count, lines.Length);

            var listLeft = new List<int>();
            var listRight = new List<int>();

            foreach (var line in lines)
            {
                var vals = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int left = int.Parse(vals[0]);
                int right = int.Parse(vals[1]);
                listLeft.Add(left);
                listRight.Add(right);
            }

            listLeft.Sort();
            listRight.Sort();
            int sum = 0;

            for (int ii = 0; ii < listLeft.Count; ii++)
            {
                sum += Math.Abs(listLeft[ii] - listRight[ii]);
            }

            Assert.Equal(1223326, sum);
        }

        [Fact]
        public void Day01_Step1_ListSimilarity_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day01.txt");
            int count = 1000;
            Assert.Equal(count, lines.Length);

            var listLeft = new List<long>();
            var dictRight = new Dictionary<long, long>();

            foreach (var line in lines)
            {
                var vals = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                long left = long.Parse(vals[0]);
                long right = long.Parse(vals[1]);
                listLeft.Add(left);
                if (dictRight.ContainsKey(right))
                {
                    dictRight[right]++;
                }
                else
                {
                    dictRight[right] = 1;
                }
            }

            long sum = 0;
            foreach (var left in listLeft)
            {
                if (dictRight.ContainsKey(left))
                {
                    sum += left * dictRight[left];
                }
            }

            Assert.Equal(21070419, sum);
        }
    }
}
