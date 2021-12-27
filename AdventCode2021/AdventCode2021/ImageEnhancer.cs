using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventCode2021
{
    public class ImageEnhancer
    {
        public char[] ImageAlgorithm { get; set; }
        public Dictionary<Point, int> Image { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public ImageEnhancer(string[] lines)
        {
            ImageAlgorithm = lines[0].ToCharArray();
            Image = new Dictionary<Point, int>();

            MaxX = lines[3].Length;
            MaxY = lines.Length - 2;
            for (int y = 2; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    if (lines[y][x] == '#')
                    {
                        Image.Add(new Point(x, y - 2), 1);
                    }
                }
            }
        }

        public void EnchanceImage(int step)
        {
            var enhancedImage = new Dictionary<Point, int>();

            int xmin = Image.Keys.Min(p => p.X) - 1;
            int xmax = Image.Keys.Max(p => p.X) + 1;
            int ymin = Image.Keys.Min(p => p.Y) - 1;
            int ymax = Image.Keys.Max(p => p.Y) + 1;
            if (step == 0)
            {
                xmin -= 4;
                xmax += 4;
                ymin -= 4;
                ymax += 4;
            }
            //AddInfiniteSpace(step, xmin, xmax, ymin, ymax);
            for (int y = ymin; y <= ymax; y++)
            {
                for (int x = xmin; x <= xmax; x++)
                {
                    if (IsEnhancedPixel(x, y, step))
                    {
                        Point p = new Point(x, y);
                        enhancedImage.Add(p, 1);
                    }
                }
            }
            Image = enhancedImage;
        }

        public bool IsEnhancedPixel(int x, int y, int step)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = y - 1; j <= y + 1; j++)
            {
                for (int i = x - 1; i <= x + 1; i++)
                {
                    var p = new Point(i, j);
                    if (Image.ContainsKey(p))
                    {
                        sb.Append("1");
                    }
                    else
                    {
                        sb.Append("0");
                    }
                }
            }
            int val = Convert.ToInt32(sb.ToString(), 2);
            return ('#' == ImageAlgorithm[val]);
        }

        public int ImagePixelCount(int steps)
        {
            int count = 0;
            foreach (var kvp in Image)
            {
                if (-steps <= kvp.Key.X && kvp.Key.X <= MaxX + steps && -steps <= kvp.Key.Y && kvp.Key.Y <= MaxY + steps)
                {
                    count++;
                }
            }
            return count;
        }

        public void DumpImage()
        {
            int Xmin = Image.Keys.Min(p => p.X);
            int Xmax = Image.Keys.Max(p => p.X);
            int Ymin = Image.Keys.Min(p => p.Y);
            int Ymax = Image.Keys.Max(p => p.Y);

            Debug.WriteLine("-------------------------");
            for (int y = Ymin; y <= Ymax; y++)
            {
                for (int x = Xmin; x <= Xmax; x++)
                {
                    Point p = new Point(x, y);
                    if (Image.ContainsKey(p))
                    {
                        Debug.Write("#");
                    }
                    else
                    {
                        Debug.Write(".");
                    }
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("-------------------------");
        }
    }

}
