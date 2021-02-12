using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AdventCodeLib
{
    public class Day10HashKnot
    {
        private int[] addToEnd = new int[] { 17, 31, 73, 47, 23 };

        public List<int> CircularList { get; set; }
        public int Start { get; set; }
        public int Skip { get; set; }
        public int[,] Regions { get; set; }
        public Day10HashKnot()
        {
            CircularList = new List<int>();
            Start = 0;
            Skip = 0;
            Regions = new int[128, 128];
        }

        public void InitCircularList(int size)
        {
            Start = 0;
            Skip = 0;
            CircularList = new List<int>();
            for (int i = 0; i < size; i++)
            {
                CircularList.Add(i);
            }
        }

        public int Get16XorValue(int startIndex)
        {
            int result = (CircularList[startIndex] ^ CircularList[startIndex + 1]);

            for (int i = startIndex + 2; i < startIndex + 16; i++)
            {
                result = result ^ CircularList[i];
            }
            return result;
        }

        public void KnotHash(int length)
        {
            List<int> temp = new List<int>();

            // get the list
            for (int i = 0, idx = Start; i < length; i++, idx++)
            {
                if (idx >= CircularList.Count)
                {
                    idx = 0;
                }
                temp.Add(CircularList[idx]);
            }

            temp.Reverse();

            for (int i = 0, idx = Start; i < length; i++, idx++)
            {
                if (idx >= CircularList.Count)
                {
                    idx = 0;
                }
                CircularList[idx] = temp[i];
            }

            Start = (Start + length + Skip) % CircularList.Count;
            Skip++;
        }

        public string DenseHash(string inputsData)
        {
            InitCircularList(256);

            List<int> inputLens = new List<int>();
            var chars = inputsData.ToCharArray();
            foreach (char ch in chars)
            {
                inputLens.Add(ch);
            }
            inputLens.AddRange(addToEnd);

            for (int i = 0; i < 64; i++)
            {
                foreach (int length in inputLens)
                {
                    KnotHash(length);
                }
            }

            List<int> denseHash = new List<int>();
            for (int i = 0; i < 256; i += 16)
            {
                denseHash.Add(Get16XorValue(i));
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in denseHash)
            {
                string t = item.ToString("X");
                if (t.Length == 1)
                {
                    sb.Append("0");
                }
                sb.Append(t);
            }

            return sb.ToString().ToLower();
        }

        public string BinaryString(string denseHash)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < denseHash.Length; i += 2)
            {
                var s = denseHash.Substring(i, 2);
                byte b = byte.Parse(s, NumberStyles.HexNumber);
                string bs = Convert.ToString(b, 2);
                for (int j = 0; j < 8 - bs.Length; j++)
                {
                    sb.Append("0");
                }
                sb.Append(bs);
            }
            return sb.ToString();
        }

        public string GetBinaryHash(string inputData)
        {
            string hash = DenseHash(inputData);
            string bs = BinaryString(hash);
            return bs;
        }

        public int UsedBlocks(string binaryRow)
        {
            int blocks = 0;
            foreach (var ch in binaryRow.ToCharArray())
            {
                if (ch == '1')
                    blocks++;
            }
            return blocks;
        }

        public void AddRegion(int[,] regions, string binaryRow, int i)
        {
            var chars = binaryRow.ToCharArray();
            for (int j = 0; j < 128; j++)
            {
                regions[i, j] = (chars[j] == '1') ? -1 : 0;
            }
        }

        public int RegionsFound(int[,] regions)
        {
            int count = 0;

            for (int j = 0; j < 128; j++)
            {
                for (int k = 0; k < 128; k++)
                {
                    if (regions[j, k] == -1)
                    {
                        count = ChartRegion(regions, count, j, k);
                    }
                }
            }
            return count;
        }

        public int ChartRegion(int[,] regions, int count, int x, int y)
        {
            if (regions[x, y] != -1)
            {
                // old region or nothing
                return count;
            }
            // new region 
            count++;
            MarkBlocks(regions, count, x, y);
            return count;
        }

        public void MarkBlocks(int[,] regions, int count, int x, int y)
        {
            if (x < 0 || x > 127 || y < 0 || y > 127)
            {
                return;
            }
            if (regions[x, y] == count || regions[x, y] == 0)
            {
                return;
            }
            if (regions[x, y] == -1)
            {
                regions[x, y] = count;
                MarkBlocks(regions, count, x + 1, y);
                MarkBlocks(regions, count, x - 1, y);
                MarkBlocks(regions, count, x, y + 1);
                MarkBlocks(regions, count, x, y - 1);
            }
        }
    }
}
