using System.Text;

namespace AdventCode2023.Models
{
    public class PointOfIncidenceHandler
    {
        public List<List<string>> MirrorPatterns { get; set; }

        public PointOfIncidenceHandler(string[] lines)
        {
            MirrorPatterns = new List<List<string>>();

            List<string> mirrorPattern = new List<string>();
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    mirrorPattern.Add(line);
                }
                else
                {
                    MirrorPatterns.Add(mirrorPattern);
                    mirrorPattern = new List<string>();
                }
            }
            MirrorPatterns.Add(mirrorPattern);
        }

        public int FindSymmetrySum()
        {
            int sum = 0;
            foreach (var mirrorPatttern in MirrorPatterns)
            {
                sum += FindSymmetryValue(mirrorPatttern);
            }
            return sum;
        }

        public int FindSymmetryValue(List<string> mirrorPattern)
        {
            var hval = FindHorizontalSymmetryValue(mirrorPattern);
            var vval = FindVerticalSymmetryValue(mirrorPattern);
            if (hval.Item2 > vval.Item2)
                return hval.Item1 * 100;
            return vval.Item1;
        }

        public Tuple<int, int> FindVerticalSymmetryValue(List<string> mirrorPattern)
        {
            List<string> columnMirrorPattern = new List<string>();

            for (int i = 0; i < mirrorPattern[0].Length; i++)
            {
                var sb = new StringBuilder();
                for (int j = 0; j < mirrorPattern.Count; j++)
                    sb.Append(mirrorPattern[j][i]);

                string column = sb.ToString();
                columnMirrorPattern.Add(column);
            }

            return FindHorizontalSymmetryValue(columnMirrorPattern);
        }

        public Tuple<int, int> FindHorizontalSymmetryValue(List<string> mirrorPattern)
        {
            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
            dict.Clear();

            for (int i = 0; i < mirrorPattern.Count; i++)
            {
                if (dict.ContainsKey(mirrorPattern[i]))
                {
                    // add match
                    dict[mirrorPattern[i]].Add(i);
                }
                else
                {
                    List<int> list = new List<int>();
                    list.Add(i);
                    dict.Add(mirrorPattern[i], list);
                }
            }

            Stack<int> stack = new Stack<int>();
            var pairs = dict.Values.Where(l => l.Count >= 2).ToList();

            List<int> order = new List<int>();
            foreach (var pair in pairs)
                order.AddRange(pair);
            order.Sort();

            foreach (var lm in pairs)
            {
                for (int i = 0; i < lm.Count - 1; i += 2)
                {

                    if (lm[i] + 1 == lm[i + 1])
                    {
                        // point of symmetry
                        stack.Push(lm[i]);
                    }
                }
            }

            int match = -1;
            if (stack.Count == 0)
            {
                // no symmetry match
                return new Tuple<int, int>(0, 0);
            }
            // find the best choice - most rows
            int maxRows = 2;
            int bestMatch = -1;

            do
            {
                // its a symmetry match
                int rows = 2;
                match = stack.Pop();
                int idxMatch = order.IndexOf(match);
                int idxLow = idxMatch - 1;
                int idxHigh = idxMatch + 2;
                while (idxLow >= 0 && idxHigh < order.Count)
                {
                    if ((order[idxLow] + 1 == order[idxLow + 1])
                        && (order[idxHigh] - 1 == order[idxHigh - 1]))
                    {
                        rows += 2;
                    }
                    else
                    {
                        break;
                    }
                    idxLow--;
                    idxHigh++;
                }
                if (rows > maxRows)
                {
                    maxRows = rows;
                    bestMatch = match;
                }
            } while (stack.Count != 0);

            match = bestMatch >= 0 ? bestMatch : match;
            return new Tuple<int, int>(match + 1, maxRows);
        }
    }
}
