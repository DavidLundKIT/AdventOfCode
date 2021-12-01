using System.Collections.Generic;

namespace AdventCode2021
{
    public class SonarSweeper
    {
        public int SimpleIncreases(List<int> depths)
        {
            int increases = 0;
            for (int ii = 1; ii < depths.Count; ii++)
            {
                if (depths[ii - 1] < depths[ii])
                {
                    increases++;
                }
            }
            return increases;
        }

        public List<int> ToSumList(List<int> depths)
        {
            List<int> sums = new List<int>();

            int sum = 0;
            for (int ii = 0; ii < depths.Count - 2; ii++)
            {
                sum = depths[ii] + depths[ii + 1] + depths[ii + 2];
                sums.Add(sum);
            }
            return sums;
        }
    }
}
