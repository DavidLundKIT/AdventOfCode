using System.Collections.Generic;

namespace AdventCodeLib
{
    public class Day05JumpMaze
    {
        public Day05JumpMaze()
        {
            Jumps = new List<int>();
        }

        public List<int> Jumps { get; set; }

        public List<int> ReadJumpStack(string path)
        {
            List<int> jumps = new List<int>();

            var lines = DataTools.ReadAllLines(path);
            foreach (var line in lines)
            {
                jumps.Add(int.Parse(line));
            }
            return jumps;
        }

        public int StepsUntilExits()
        {
            int steps =0;
            int index = 0;
            int jump;
            do
            {
                jump = Jumps[index]++;
                index += jump;
                steps++;
            } while (index >= 0 && index < Jumps.Count);
            return steps;
        }

        public int StepsUntilExitsB()
        {
            int steps = 0;
            int index = 0;
            int jump;
            do
            {
                jump = Jumps[index];
                if (jump >= 3)
                {
                    Jumps[index]--;
                }
                else
                {
                    Jumps[index]++;
                }
                index += jump;
                steps++;
            } while (index >= 0 && index < Jumps.Count);
            return steps;
        }
    }
}
