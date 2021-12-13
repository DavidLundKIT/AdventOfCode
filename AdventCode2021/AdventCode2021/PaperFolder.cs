using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventCode2021
{
    public class PaperFolder
    {
        public List<string> Lines { get; set; }
        public List<Point> Points { get; set; }
        public List<string> Folds { get; set; }

        public PaperFolder(string[] lines)
        {
            Lines = new List<string>(lines);
            Points = new List<Point>();
            Folds = lines.Where(s => s.Contains("fold")).ToList();
            Lines.RemoveAll(s => s.Contains("fold"));
            foreach (var line in Lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                    Points.Add(new Point(line));
            }
        }

        public int DoFold(string fold)
        {
            bool foldX = fold.Contains("x");
            var parts = fold.Split("=");
            int idx = int.Parse(parts[1]);

            List<Point> folded = new List<Point>();
            foreach (var point in Points)
            {
                if (foldX)
                {
                    if (point.X > idx)
                        point.X = 2 * idx - point.X;
                }
                else
                {
                    if (point.Y > idx)
                        point.Y = 2 * idx - point.Y;
                }

                if (!folded.Any(p => p.Equals(point)))
                    folded.Add(point);
            }
            Points = folded;
            return folded.Count;
        }

        public void DoAllFolds()
        {
            foreach (var fold in Folds)
            {
                DoFold(fold);
            }
        }

        public void  DumpPoints()
        {
            int maxX = Points.Max(p => p.X);
            int maxY = Points.Max(p => p.Y);
            Debug.WriteLine("---------------------------------");
            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    if (Points.Any(p => p.X == x && p.Y == y))
                        Debug.Write("#");
                    else
                        Debug.Write(" ");
                }
                Debug.WriteLine(".");
            }
            Debug.WriteLine("---------------------------------");
        }
    }
}
