using System.Collections.Generic;
using System.Linq;

namespace AdventCode2021
{
    public class SmokeDetector
    {
        public string[] Data { get; set; }
        public List<int> LowPoints { get; set; }
        public List<int> Basins { get; set; }
        public Dictionary<string, int> BasinPoints { get; set; }

        public SmokeDetector(string[] data)
        {
            Data = data;
            LowPoints = new List<int>();
            Basins = new List<int>();
            BasinPoints = new Dictionary<string, int>();
        }


        public int FindTotalRiskLevel()
        {
            int rows = Data.Length;
            int rowLength = Data[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rowLength; j++)
                {
                    if (IsLowUp(i, j) && IsLowDown(i, j) && IsLowRight(i, j) && IsLowLeft(i, j))
                    {
                        int val = (int)(Data[i][j] - '0');
                        LowPoints.Add(val);
                        FindBasinStart(i, j);
                    }
                }
            }
            int totalRisk = LowPoints.Count + LowPoints.Sum();

            return totalRisk;
        }

        private bool IsLowUp(int i, int j)
        {
            if (i - 1 < 0)
                return true;
            return (Data[i][j] < Data[i - 1][j]);
        }

        private bool IsLowDown(int i, int j)
        {
            if (i + 1 >= Data.Length)
                return true;
            return (Data[i][j] < Data[i + 1][j]);
        }

        private bool IsLowRight(int i, int j)
        {
            if (j - 1 < 0)
                return true;
            return (Data[i][j] < Data[i][j - 1]);
        }

        private bool IsLowLeft(int i, int j)
        {
            if (j + 1 >= Data[i].Length)
                return true;
            return (Data[i][j] < Data[i][j + 1]);
        }

        public int FindBasinStart(int i, int j)
        {
            BasinPoints.Clear();

            FindBasin(i, j);

            int basinSum = BasinPoints.Count();
            Basins.Add(basinSum);
            return basinSum;
        }

        public void FindBasin(int i, int j)
        {
            if (!WithinBounds(i, j))
            {
                return;
            }
            int val = (int)(Data[i][j] - '0');
            string key = $"({i}, {j})";

            if (BasinPoints.ContainsKey(key))
                return;

            BasinPoints.Add(key, val);

            FindBasin(i - 1, j);
            FindBasin(i, j + 1);
            FindBasin(i + 1, j);
            FindBasin(i, j - 1);
        }

        private bool WithinBounds(int i, int j)
        {
            if (i < 0)
                return false;
            if (i >= Data.Length)
                return false;
            if (j < 0)
                return false;
            if (j >= Data[i].Length)
                return false;
            if (Data[i][j] == '9')
                return false;
            return true;
        }
        public long FindTop3BasinValues()
        {
            Basins.Sort();
            long total = 1;
            var vals = Basins.Skip(Basins.Count - 3).Take(3);
            foreach (var val in vals)
            {
                total *= val;
            }
            return total;
        }
    }
}
