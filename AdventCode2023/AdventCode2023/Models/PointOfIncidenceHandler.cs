using System.Diagnostics;

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
            DumpMirror("original", mirrorPattern);
            var hval = FindHorizontalSymmetryValue(mirrorPattern);
            var vval = FindVerticalSymmetryValue(mirrorPattern);
            if (hval.Item2 >= vval.Item2)
            {
                return hval.Item1 * 100;
            }
            return vval.Item1;
        }

        public Tuple<int, int> FindVerticalSymmetryValue(List<string> mirrorPattern)
        {
            List<string> columnMirrorPattern =FlipMirror(mirrorPattern);
            return FindHorizontalSymmetryValue(columnMirrorPattern);
        }

        public List<string> FlipMirror(List<string> mirrorPattern)
        {
            DumpMirror("Original", mirrorPattern);

            List<List<char>> tempMirror = new List<List<char>>();
            foreach (var mirror in mirrorPattern)
            {
                tempMirror.Add(new List<char>(mirror.ToCharArray()));
            }
            var transposed = Transpose(tempMirror);

            List<string> columnMirrorPattern = new List<string>();

            foreach (List<char> charList in transposed)
            {
                columnMirrorPattern.Add(new string(charList.ToArray()));
            }
            DumpMirror("Transformed", columnMirrorPattern);
            return columnMirrorPattern;
        }

        public List<List<char>> Transpose(List<List<char>> lists)
        {
            var longest = lists.Any() ? lists.Max(l => l.Count) : 0;
            List<List<char>> outer = new List<List<char>>(longest);
            for (int i = 0; i < longest; i++)
                outer.Add(new List<char>(lists.Count));
            for (int j = 0; j < lists.Count; j++)
                for (int i = 0; i < longest; i++)
                    outer[i].Add(lists[j].Count > i ? lists[j][i] : default(char));
            return outer;
        }

        public Tuple<int, int> FindHorizontalSymmetryValue(List<string> mirrorPattern)
        {
            int match = -1;
            int maxRows = -1;

            for (int i = 0; i < mirrorPattern.Count - 1; i++)
            {
                // find 2 rows that match
                if (string.Equals(mirrorPattern[i], mirrorPattern[i + 1]))
                {
                    int rows = CheckMirrorSymmetry(mirrorPattern, i);
                    if (rows >= 0)
                    {
                        if (maxRows == -1)
                        {
                            // first match
                            match = i;
                            maxRows = rows;
                        }
                        else if (maxRows < rows)
                        {
                            match = i;
                            maxRows = rows;
                        }
                        // else leave alone
                    }
                }
            }

            return new Tuple<int, int>(match + 1, maxRows);
        }

        public int CheckMirrorSymmetry(List<string> mirrorPattern, int i)
        {
            int rowOffset = 0;

            while ((i + 1 + rowOffset < mirrorPattern.Count) && ((i - rowOffset) >= 0))
            {
                DumpTestBlock((i - rowOffset), (i + 1 + rowOffset), mirrorPattern);
                if (!string.Equals(mirrorPattern[i - rowOffset], mirrorPattern[i + 1 + rowOffset]))
                {
                    return -1;
                }
                rowOffset++;
            }
            // got here, no mismatches
            return rowOffset * 2;
        }

        public void DumpMirror(string type, List<string> mirror)
        {
            Debug.WriteLine($"======={type}=========");
            foreach (string mirrorPattern in mirror)
            {
                Debug.WriteLine(mirrorPattern);
            }
            Debug.WriteLine("==========================");
            Debug.WriteLine("");
        }

        public void DumpTestBlock(int low, int high, List<string> mirror)
        {
            Debug.WriteLine($"=== Low: {low}, High: {high} ===");
            for (int i = low; i <= high; ++i)
            {
                Debug.WriteLine(mirror[i]);
            }
            Debug.WriteLine("==========================");
            Debug.WriteLine("");
        }
    }
}
