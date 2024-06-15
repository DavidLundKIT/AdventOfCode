using System.Diagnostics;

namespace AdventCode2023.Models
{
    public class PipeMazeWalker
    {
        public List<char[]> PipeMaze { get; set; }
        public Tuple<int, int> Start { get; set; }
        public Tuple<int, int> Last { get; set; }

        public Dictionary<char, string> LeftChoices { get; set; }
        public Dictionary<char, string> RightChoices { get; set; }
        public Dictionary<char, string> UpChoices { get; set; }
        public Dictionary<char, string> DownChoices { get; set; }
        public Dictionary<Tuple<int, int>, char> MazePath { get; set; }

        public PipeMazeWalker(string[] lines)
        {
            PipeMaze = new List<char[]>();
            MazePath = new Dictionary<Tuple<int, int>, char>();

            int idx = 0;
            int sX = -1;
            int sY = -1;
            foreach (var line in lines)
            {
                PipeMaze.Add(line.ToCharArray());
                int x = line.IndexOf('S');
                if (x >= 0)
                {
                    sX = x;
                    sY = idx;
                }
                idx++;
            }
            Start = Tuple.Create(sX, sY);
            Last = Tuple.Create(sX, sY);
            LeftChoices = new Dictionary<char, string>()
            {
                { '-', "-LFS" }, { 'J', "-LFS"}, { '7',"-LFS"}, { 'S', "-LFS"}
            };
            RightChoices = new Dictionary<char, string>()
            {
                { '-', "-J7S" }, { 'L', "-J7S"}, { 'F',"-J7S"}, { 'S', "-J7S"}
            };
            UpChoices = new Dictionary<char, string>()
            {
                { '|', "|7FS" }, { 'L', "|7FS"}, { 'J',"|7FS"}, { 'S', "|7FS"}
            };
            DownChoices = new Dictionary<char, string>()
            {
                { '|', "|LJS" }, { '7', "|LJS"}, { 'F',"|LJS"}, { 'S', "|LJS"}
            };
        }

        public int WalkPipeMaze()
        {
            MazePath.Clear();
            var now = Start;
            MazePath.Add(now, PipeMaze[now.Item2][now.Item1]);
            int steps = 0;
            do
            {
                now = FindNextStep(now);
                if (!MazePath.ContainsKey(now))
                    MazePath.Add(now, PipeMaze[now.Item2][now.Item1]);
                steps++;
            } while (!Start.Equals(now));
            return steps / 2;
        }

        public Tuple<int, int> FindNextStep(Tuple<int, int> now)
        {
            /*
                | is a vertical pipe connecting north and south.
                - is a horizontal pipe connecting east and west.
                L is a 90-degree bend connecting north and east.
                J is a 90-degree bend connecting north and west.
                7 is a 90-degree bend connecting south and west.
                F is a 90-degree bend connecting south and east.
                . is ground; there is no pipe in this tile.
                S is the starting position of the animal; there is a pipe on this tile, but your sketch doesn't show what shape the pipe has.
            */

            // <==
            char nowCh = PipeMaze[now.Item2][now.Item1];
            Tuple<int, int> next;
            if (now.Item1 - 1 >= 0)
            {
                next = new Tuple<int, int>(now.Item1 - 1, now.Item2);
                if (!Last.Equals(next))
                {
                    char ch = PipeMaze[next.Item2][next.Item1];
                    if (LeftChoices.ContainsKey(nowCh) && LeftChoices[nowCh].Contains(ch))
                    {
                        // I can move this way
                        Last = now;
                        return next;
                    }
                }
            }
            // up
            if (now.Item2 - 1 >= 0)
            {
                next = new Tuple<int, int>(now.Item1, now.Item2 - 1);
                if (!Last.Equals(next))
                {
                    char ch = PipeMaze[next.Item2][next.Item1];
                    if (UpChoices.ContainsKey(nowCh) && UpChoices[nowCh].Contains(ch))
                    {
                        // I can move this way
                        Last = now;
                        return next;
                    }
                }
            }
            // ==>
            if (now.Item1 + 1 < PipeMaze[0].Length)
            {
                next = new Tuple<int, int>(now.Item1 + 1, now.Item2);
                if (!Last.Equals(next))
                {
                    char ch = PipeMaze[next.Item2][next.Item1];
                    if (RightChoices.ContainsKey(nowCh) && RightChoices[nowCh].Contains(ch))
                    {
                        // I can move this way
                        Last = now;
                        return next;
                    }
                }
            }

            // down
            if (now.Item2 + 1 < PipeMaze.Count)
            {
                next = new Tuple<int, int>(now.Item1, now.Item2 + 1);
                if (!Last.Equals(next))
                {
                    char ch = PipeMaze[next.Item2][next.Item1];
                    if (DownChoices.ContainsKey(nowCh) && DownChoices[nowCh].Contains(ch))
                    {
                        // I can move this way
                        Last = now;
                        return next;
                    }
                }
            }

            throw new ArgumentOutOfRangeException(nameof(next));
        }

        public void DumpMaze()
        {
            Debug.WriteLine("=====================================");
            for (int y = 0; y < PipeMaze.Count();  y++)
            {
                for (int x = 0; x < PipeMaze[y].Length; x++)
                {
                    var tp = new Tuple<int, int>(x, y);
                    if (MazePath.ContainsKey(tp))
                    {
                        Debug.Write(MazePath[tp]);
                    }
                    else
                    {
                        Debug.Write('.');
                    }
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("=====================================");
        }
    }
}
