namespace AdventOfCode2020
{
    public class ForestMap
    {
        public string[] Forest { get; set; }

        public ForestMap(string [] forest)
        {
            Forest = forest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>
        /// 0 = nothing
        /// 1 = tree
        /// -1 = no longer in the forest
        /// </returns>
        public int ForestStatus(int x, int y)
        {
            if (y >= Forest.Length)
                return -1;
            var trees = Forest[y].ToCharArray();
            int modX = x % trees.Length;
            if (trees[modX] == '.')
                return 0;
            return 1;
        }

        public int TreesOnSlope(int x, int y, int right, int down)
        {
            int result = 0;
            int numTrees = 0;
            foreach (var treeLine in Forest)
            {
                result = ForestStatus(x, y);
                if (result == 1)
                {
                    numTrees++;
                }
                if (result == -1)
                {
                    break;
                }
                x += right;
                y += down;
            }
            return numTrees;
        }
    }
}
