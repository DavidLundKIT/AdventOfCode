using System.Collections.Generic;
using System.Linq;

namespace AdventCode2021
{
    public class LanternFishModeller
    {
        public List<int> Fish { get; set; }
        public long[] FishPerDay { get; set; }

        public LanternFishModeller(int[] fishdata)
        {
            Fish = new List<int>(fishdata);
            FishPerDay = new long[9];
            for (int i = 0; i <= 8; i++)
            {
                //if (Fish.Any(f => f == i))
                int num = Fish.Where(f => f == i).Count();
                FishPerDay[i] = num;
                //else
            }
        }

        public void DoDay()
        {
            int countFish = Fish.Count;

            for (int ii = countFish - 1; ii >= 0; ii--)
            {
                int fish = Fish[ii];
                if (fish == 0)
                {
                    fish = 6;
                    Fish.Add(8);
                }
                else
                {
                    fish--;
                }
                Fish[ii] = fish;
            }
        }

        public void DoDay2()
        {
            long saveFish = FishPerDay[0];

            for (int ii = 1; ii < 9; ii++)
            {
                FishPerDay[ii - 1] = FishPerDay[ii];
            }
            FishPerDay[6] += saveFish;
            FishPerDay[8] = saveFish;
        }

        public long FishCount()
        {
            return FishPerDay.Sum();
        }
    }
}
