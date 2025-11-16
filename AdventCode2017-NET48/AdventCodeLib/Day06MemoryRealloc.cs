using System.Collections.Generic;
using System.Text;

namespace AdventCodeLib
{
    public class Day06MemoryRealloc
    {

        public List<int> InputA { get; set; }

        public string input06A = "14 0 15 12 11 11 3 5 1 6 8 4 9 1 8 4";

        public Day06MemoryRealloc()
        {
            InputA = new List<int>();
            InputA.AddRange(new int[] { 14, 0, 15, 12, 11, 11, 3, 5, 1, 6, 8, 4, 9, 1, 8, 4 });
        }

        public int ReallocMemory(List<int> state0)
        {
            int steps = 0;
            Dictionary<string, List<int>> states = new Dictionary<string, List<int>>();

            List<int> state1 = new List<int>();
            state1.AddRange(state0);
            do
            {
                states.Add(state1.AsString(), state1);
                state1 = NextAllocState(state1);
                steps++;
            } while (!states.ContainsKey(state1.AsString()));

            return steps;
        }

        public int ReallocMemoryNext(List<int> state0)
        {
            int steps = 0;
            Dictionary<string, List<int>> states = new Dictionary<string, List<int>>();

            List<int> state1 = new List<int>();
            state1.AddRange(state0);
            do
            {
                states.Add(state1.AsString(), state1);
                state1 = NextAllocState(state1);
                steps++;
            } while (!states.ContainsKey(state1.AsString()));
            steps = 0;
            Dictionary<string, List<int>> states2 = new Dictionary<string, List<int>>();
            do
            {
                states2.Add(state1.AsString(), state1);
                state1 = NextAllocState(state1);
                steps++;
            } while (!states2.ContainsKey(state1.AsString()));

            return steps;
        }

        public List<int> NextAllocState(List<int> state0)
        {
            List<int> state1 = new List<int>();
            state1.AddRange(state0);
            int iMax = FindMax(state0);
            int blocks = state0[iMax];
            state1[iMax] = 0;
            iMax++;
            for (int i = 0; i < blocks; i++)
            {
                if (iMax >= state0.Count)
                {
                    iMax = 0;
                }
                state1[iMax]++;
                iMax++;
            }
            return state1;
        }

        public int FindMax(List<int> state)
        {
            int imax = 0;
            int maxValue = 0;
            maxValue = state[0];
            for (int i = 1; i < state.Count; i++)
            {
                if (state[i] > maxValue)
                {
                    imax = i;
                    maxValue = state[i];
                }
            }
            return imax;
        }
    }

    public static class Day06Extensions
    {
        public static string AsString(this List<int> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in list)
            {
                sb.AppendFormat("{0} ", i);
            }
            return sb.ToString().Trim();
        }
    }
}
