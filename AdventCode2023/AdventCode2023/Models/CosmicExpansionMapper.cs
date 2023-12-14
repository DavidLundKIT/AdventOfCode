namespace AdventCode2023.Models
{
    public class CosmicExpansionMapper
    {
        public List<Tuple<long, long>> Stars { get; set; }
        public List<Tuple<long, long>> ExpandedStars { get; set; }

        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public CosmicExpansionMapper(string[] lines)
        {
            Stars = new List<Tuple<long, long>>();
            ExpandedStars = new List<Tuple<long, long>>();

            MaxX = lines[0].Length;
            MaxY = lines.Length;

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    if (lines[y][x] == '#')
                    {
                        // star
                        Stars.Add(new Tuple<long, long>(x, y));
                    }
                }
            }
        }

        public void ExpandTheCosmos(long factor)
        {
            HashSet<long> starXs = new HashSet<long>(Stars.Select(s => s.Item1).Distinct().ToList());
            HashSet<long> starYs = new HashSet<long>(Stars.Select(s => s.Item2).Distinct().ToList());
            HashSet<long> emptyXs = new HashSet<long>(Enumerable.Range(0, MaxX).Select(l => (long)l));
            HashSet<long> emptyYs = new HashSet<long>(Enumerable.Range(0, MaxY).Select(l => (long)l));

            emptyXs.ExceptWith(starXs);
            emptyYs.ExceptWith(starYs);

            factor = (factor - 1) < 1 ? 1 : factor - 1;
            foreach (var star in Stars)
            {
                long x = star.Item1;
                long y = star.Item2;
                foreach (var x2 in emptyXs)
                {
                    if (star.Item1 > x2)
                        x += factor;
                }
                foreach (var y2 in emptyYs)
                {
                    if (star.Item2 > y2)
                        y += factor;
                }
                ExpandedStars.Add(new Tuple<long, long>(x, y));
            }
        }

        public long CalcGalaxyLengths()
        {
            Dictionary<Tuple<long, long>, long> dists = new Dictionary<Tuple<long, long>, long>();

            for (int idx = 0; idx < ExpandedStars.Count - 1; idx++)
            {
                for (int idx2 = idx + 1; idx2 < ExpandedStars.Count; idx2++)
                {
                    long dist = Math.Abs(ExpandedStars[idx].Item1 - ExpandedStars[idx2].Item1) + Math.Abs(ExpandedStars[idx].Item2 - ExpandedStars[idx2].Item2);
                    var distXY = new Tuple<long, long>(idx, idx2);
                    if (!dists.ContainsKey(distXY))
                    {
                        dists.Add(distXY, dist);
                    }
                }
            }

            long totalLengths = dists.Values.Sum();
            return totalLengths;
        }
    }
}
