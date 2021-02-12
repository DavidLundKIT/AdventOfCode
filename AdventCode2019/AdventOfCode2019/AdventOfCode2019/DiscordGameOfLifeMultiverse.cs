using System.Diagnostics;

namespace AdventOfCode2019
{
    public class DiscordGameOfLifeMultiverse
    {
        private const int kSize = 5;

        public int Middle { get; set; }
        public int Depth { get; set; }
        public bool[,,] BugsMap { get; set; }
        public bool[,,] LifeMap { get; set; }

        /// <summary>
        /// Do not need states for part 2. BugsMap goes 3d with
        /// being mapped index to level
        /// 0,  1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        /// -5 -4 -3 -2 -1  0  1  2  3  4   5 
        /// </summary>
        /// <param name="bugsMap"></param>
        public DiscordGameOfLifeMultiverse(string[] bugsMap, int depth)
        {
            Depth = depth;
            Middle = (Depth / 2);
            BugsMap = new bool[kSize, kSize, Depth];
            LifeMap = new bool[kSize, kSize, Depth];
            for (int i = 0; i < kSize; i++)
            {
                char[] bugRow = bugsMap[i].ToCharArray();
                for (int j = 0; j < kSize; j++)
                {
                    BugsMap[i, j, Middle] = (bugRow[j] == '#');
                }
            }
        }

        public void LiveOneMin()
        {
            Breed();
            CopyLifeToBugs();
        }

        public void Breed()
        {
            for (int k = 0; k < Depth; k++)
            {
                for (int i = 0; i < kSize; i++)
                {
                    for (int j = 0; j < kSize; j++)
                    {
                        if (i == 2 && j == 2)
                        {
                            // skip teh "portal" to multiverse
                            continue;
                        }
                        int adjBugs = AdjacentBug(i, j, k, i - 1, j);
                        adjBugs += AdjacentBug(i, j, k, i + 1, j);
                        adjBugs += AdjacentBug(i, j, k, i, j - 1);
                        adjBugs += AdjacentBug(i, j, k, i, j + 1);
                        if (BugsMap[i, j, k])
                        {
                            // bug, dies unless only 1 adj bug
                            LifeMap[i, j, k] = (adjBugs == 1);
                        }
                        else
                        {
                            // no bug still no bug unless...
                            LifeMap[i, j, k] = (adjBugs == 1 || adjBugs == 2);
                        }
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
                    for (int k = 0; k < Depth; k++)
                    {
                        BugsMap[i, j, k] = LifeMap[i, j, k];
                    }
                }
            }
        }

        public int AdjacentBug(int i, int j, int k, int dI, int dJ)
        {
            if (dI < 0 || dI >= kSize || dJ < 0 || dJ >= kSize)
            {
                if (k == 0)
                {
                    // dropping off map
                    return 0;
                }
                if (dI < 0)
                {
                    // down 1 level above square 8
                    return BugsMap[1, 2, k - 1] ? 1 : 0;
                }
                if (dI >= kSize)
                {
                    // down 1 level above square 18
                    return BugsMap[3, 2, k - 1] ? 1 : 0;
                }
                if (dJ < 0)
                {
                    // down 1 level above square 12
                    return BugsMap[2, 1, k - 1] ? 1 : 0;
                }
                if (dJ >= kSize)
                {
                    // down 1 level above square 14
                    return BugsMap[2, 3, k - 1] ? 1 : 0;
                }
            }
            else if (dI == 2 && dJ == 2)
            {
                int adjBugs = 0;
                // up a level, to an inner square
                if (k >= Depth - 1)
                {
                    // dropping off map
                    return 0;
                }

                if (i == 1)
                {
                    for (int jj = 0; jj < kSize; jj++)
                    {
                        adjBugs += (BugsMap[0, jj, k + 1] ? 1 : 0);
                    }
                    return adjBugs;
                }
                if (i == 3)
                {
                    for (int jj = 0; jj < kSize; jj++)
                    {
                        adjBugs += (BugsMap[4, jj, k + 1] ? 1 : 0);
                    }
                    return adjBugs;
                }


                if (j == 1)
                {
                    for (int ii = 0; ii < kSize; ii++)
                    {
                        adjBugs += (BugsMap[ii, 0, k + 1] ? 1 : 0);
                    }
                    return adjBugs;
                }
                if (j == 3)
                {
                    for (int ii = 0; ii < kSize; ii++)
                    {
                        adjBugs += (BugsMap[ii, 4, k + 1] ? 1 : 0);
                    }
                    return adjBugs;
                }
            }
            return BugsMap[dI, dJ, k] ? 1 : 0;
        }

        public void DumpBugs(int min)
        {
            Debug.WriteLine("----------------");
            Debug.WriteLine($"BugMap minute: {min}");
            for (int k = 0; k < Depth; k++)
            {
                Debug.WriteLine($"Depth {k - Middle}:");
                for (int i = 0; i < kSize; i++)
                {
                    for (int j = 0; j < kSize; j++)
                    {
                        if (BugsMap[i, j, k])
                            Debug.Write("#");
                        else
                            Debug.Write(".");
                    }
                    Debug.WriteLine("");
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine($"Bug count: {BugCount()}");
        }

        public int BugCount()
        {
            int bugs = 0;
            for (int k = 0; k < Depth; k++)
            {
                for (int i = 0; i < kSize; i++)
                {
                    for (int j = 0; j < kSize; j++)
                    {
                        if (BugsMap[i, j, k])
                        {
                            bugs++;
                        }
                    }
                }
            }
            return bugs;
        }
    }
}
