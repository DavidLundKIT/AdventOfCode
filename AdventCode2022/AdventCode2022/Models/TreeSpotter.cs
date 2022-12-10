namespace AdventCode2022.Models
{
    public class TreeSpotter
    {
        public List<List<int>> Trees { get; set; }
        public Dictionary<string, int> VisibleTrees { get; set; }

        public TreeSpotter(List<List<int>> trees)
        {
            Trees = trees;
            VisibleTrees = new Dictionary<string, int>();
        }

        public int FindVisibleTrees()
        {
            int tallest = 0;
            VisibleTrees.Clear();

            for (int yIndex = 0; yIndex < Trees.Count; yIndex++)
            {
                tallest = VisibleFromLeft(yIndex);
                tallest = VisibleFromRight(yIndex);
            }
            for (int xIndex = 0; xIndex < Trees[0].Count; xIndex++)
            {
                tallest = VisibleFromTop(xIndex);
                tallest = VisibleFromBottom(xIndex);
            }

            return VisibleTrees.Count;
        }

        public int FindBestViewScore()
        {
            int bestView = 0;
            VisibleTrees.Clear();

            for (int yIndex = 0; yIndex < Trees.Count; yIndex++)
            {
                for (int xIndex = 0; xIndex < Trees[0].Count; xIndex++)
                {
                    bestView = BestViewScore(xIndex, yIndex);
                }
            }

            return VisibleTrees.Values.Max();
        }

        public int BestViewScore(int xIndex, int yIndex)
        {
            int thisTree = Trees[yIndex][xIndex];
            string treeKey = MakeTreeKey(xIndex, yIndex);
            VisibleTrees.Add(treeKey, 1);

            // Left
            int treesSeen = 0;
            for (int i = xIndex - 1; i >= 0; i--)
            {
                int treeNow = Trees[yIndex][i];
                treesSeen++;
                if (treeNow >= thisTree)
                {
                    break;
                }
            }
            VisibleTrees[treeKey] *= treesSeen;

            // Right
            treesSeen = 0;
            for (int i = xIndex + 1; i < Trees[yIndex].Count; i++)
            {
                int treeNow = Trees[yIndex][i];
                treesSeen++;
                if (treeNow >= thisTree)
                {
                    break;
                }
            }
            VisibleTrees[treeKey] *= treesSeen;

            // Top
            treesSeen = 0;
            for (int i = yIndex - 1; i >= 0; i--)
            {
                int treeNow = Trees[i][xIndex];
                treesSeen++;
                if (treeNow >= thisTree)
                {
                    break;
                }
            }
            VisibleTrees[treeKey] *= treesSeen;

            // Bottom
            treesSeen = 0;
            for (int i = yIndex + 1; i < Trees.Count; i++)
            {
                int treeNow = Trees[i][xIndex];
                treesSeen++;
                if (treeNow >= thisTree)
                {
                    break;
                }
            }
            VisibleTrees[treeKey] *= treesSeen;
            return VisibleTrees[treeKey];
        }

        int IsTallestTree(int xIndex, int yIndex, int tallestTree)
        {
            if (Trees[yIndex][xIndex] > tallestTree)
            {
                // visible
                string treeKey = MakeTreeKey(xIndex, yIndex);
                if (!VisibleTrees.ContainsKey(treeKey))
                {
                    VisibleTrees.Add(treeKey, 1);
                }
                else
                {
                    VisibleTrees[treeKey] += 1;
                }
                tallestTree = Trees[yIndex][xIndex];
            }

            return tallestTree;
        }

        public int VisibleFromBottom(int xIndex)
        {
            int tallestTree = -1;
            for (int yIndex = Trees.Count - 1; yIndex >= 0; yIndex--)
            {
                tallestTree = IsTallestTree(xIndex, yIndex, tallestTree);
            }
            return tallestTree;
        }

        public int VisibleFromTop(int xIndex)
        {
            int tallestTree = -1;
            for (int yIndex = 0; yIndex < Trees.Count; yIndex++)
            {
                tallestTree = IsTallestTree(xIndex, yIndex, tallestTree);
            }
            return tallestTree;
        }

        public int VisibleFromLeft(int yIndex)
        {
            int tallestTree = -1;
            for (int xIndex = 0; xIndex < Trees[yIndex].Count; xIndex++)
            {
                tallestTree = IsTallestTree(xIndex, yIndex, tallestTree);
            }
            return tallestTree;
        }

        public int VisibleFromRight(int yIndex)
        {
            int tallestTree = -1;
            for (int xIndex = Trees[yIndex].Count - 1; xIndex >= 0; xIndex--)
            {
                tallestTree = IsTallestTree(xIndex, yIndex, tallestTree);
            }
            return tallestTree;
        }

        public string MakeTreeKey(int xIndex, int yIndex)
        {
            return $"({xIndex}, {yIndex})";
        }
    }
}
