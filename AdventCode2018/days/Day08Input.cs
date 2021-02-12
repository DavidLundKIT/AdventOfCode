using System;
using System.Collections.Generic;

namespace days.day08
{
    public interface IDay08Input
    {
        int GiveMe();
    }
    public class Day08Input: IDay08Input
    {
        public Day08Input(string row)
        {
            InputValues = new List<int>();
            string [] ints = row.Split(new char[] {' '});
            foreach (var item in ints)
            {
                InputValues.Add(int.Parse(item));
            }
            Index = 0;
        }

        public List<int> InputValues { get; set; }
        public int Index { get; set; }

        public int GiveMe()
        {
            return InputValues[Index++];
        }
    }
}
