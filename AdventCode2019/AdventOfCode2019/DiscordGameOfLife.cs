using System.Diagnostics;

namespace AdventOfCode2019
{
    public class DiscordGameOfLife
    {
        private const int kSize = 5;
        public bool[,] BugsMap { get; set; }
        public bool[,] LifeMap { get; set; }

        /// <summary>
        /// 33 554 432‬
        /// </summary>
        public int[] States { get; set; }

        public DiscordGameOfLife(string[] bugsMap)
        {
            States = new int[(1 << kSize * kSize)];
            for (int i = 0; i < States.Length; i++)
            {
                States[i] = -1;
            }

            BugsMap = new bool[kSize, kSize];
            LifeMap = new bool[kSize, kSize];
            for (int i = 0; i < kSize; i++)
            {
                char[] bugRow = bugsMap[i].ToCharArray();
                for (int j = 0; j < kSize; j++)
                {
                    BugsMap[i, j] = (bugRow[j] == '#');
                }
            }
        }

        public int BioDiversityRating()
        {
            int rating = 0;
            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    if (BugsMap[i, j])
                    {
                        rating += 1 << (i * 5 + j);
                    }
                }
            }
            return rating;
        }

        public bool LiveOneMin(int minute)
        {
            Breed();
            CopyLifeToBugs();
            int rating = BioDiversityRating();
            if (States[rating] != -1)
            {
                // already set!
                return true;
            }
            States[rating] = minute;
            return false;
        }

        public void Breed()
        {
            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    int adjBugs = AdjacentBug(i, j, i - 1, j);
                    adjBugs += AdjacentBug(i, j, i + 1, j);
                    adjBugs += AdjacentBug(i, j, i, j - 1);
                    adjBugs += AdjacentBug(i, j, i, j + 1);
                    if (BugsMap[i, j])
                    {
                        // bug, dies unless only 1 adj bug
                        LifeMap[i, j] = (adjBugs == 1);
                    }
                    else
                    {
                        // no bug still no bug unless...
                        LifeMap[i, j] = (adjBugs == 1 || adjBugs == 2);
                    }
                }
            }
        }


        public void CopyLifeToBugs()
        {
            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    BugsMap[i, j] = LifeMap[i, j];
                }
            }
        }

        public int AdjacentBug(int i, int j, int dI, int dJ)
        {
            if (dI < 0 || dI >= kSize || dJ < 0 || dJ >= kSize)
            {
                // off map no adj bug
                return 0;
            }
            return BugsMap[dI, dJ] ? 1 : 0;
        }

        public void DumpBugs(int min)
        {
            Debug.WriteLine("----------------");
            Debug.WriteLine($"BugMap minute: {min}");
            for (int i = 0; i < kSize; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    if (BugsMap[i, j])
                        Debug.Write("#");
                    else
                        Debug.Write(".");
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine($"BioDiv rating: {BioDiversityRating()}");
        }
    }
}
