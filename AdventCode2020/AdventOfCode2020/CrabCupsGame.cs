using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class CrabCupsGame
    {
        public string Original { get; set; }
        public List<int> Cups { get; set; }
        public int CurrentCup { get; set; }

        public CrabCupsGame(string data, bool fill = false)
        {
            Original = data;
            Cups = Original.ToCharArray().Select(ch => int.Parse(new string(ch, 1))).ToList();
            if (fill)
            {
                Cups.AddRange(Enumerable.Range(10, 999991));
            }
            CurrentCup = Cups[0];
        }

        public int[] Extract3Cups()
        {
            var idx = Cups.IndexOf(CurrentCup);
            int[] cups3 = new int[3];
            var count = (Cups.Count - (idx + 1)) >= 3 ? 3 : (Cups.Count - (idx + 1));
            Cups.CopyTo(idx + 1, cups3, 0, count);
            Cups.RemoveRange(idx + 1, count);
            if (count < 3)
            {
                count = 3 - count;
                Cups.CopyTo(0, cups3, 3 - count, count);
                Cups.RemoveRange(0, count);
            }

            return cups3;
        }

        public int FindDestination(int maxValue)
        {
            int destCup = CurrentCup;
            do
            {
                destCup--;
                if (destCup < 1)
                {
                    destCup = maxValue;
                }
            } while (Cups.IndexOf(destCup) == -1);
            return destCup;
        }

        public void InsertCups(int[] cups3, int destCup)
        {
            Cups.InsertRange(Cups.IndexOf(destCup) + 1, cups3);
        }

        public void UpdateCurrentCup()
        {
            var idx = Cups.IndexOf(CurrentCup) + 1;
            CurrentCup = (idx < Cups.Count) ? Cups[idx] : Cups[0];
        }

        public void DoMove(int maxValue)
        {
            var cups3 = Extract3Cups();
            var destCup = FindDestination(maxValue);
            InsertCups(cups3, destCup);
            UpdateCurrentCup();
        }

        public string CupsAfterOne()
        {
            int[] list = new int[8];
            var iOne = Cups.IndexOf(1) + 1;
            for (int i = 0; i < list.Length; i++)
            {
                int idx = (iOne + i) % 9;
                list[i] = Cups[idx];
            }
            string val = string.Join("", list.Select(i => i.ToString()).ToArray());
            return val;
        }
    }
}
