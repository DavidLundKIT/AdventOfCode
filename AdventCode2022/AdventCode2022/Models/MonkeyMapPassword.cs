using System.Diagnostics;
using System.Text;

namespace AdventCode2022.Models
{
    public class MonkeyMapPassword
    {
        public enum DirectionChoice
        {
            Up,
            Right,
            Down,
            Left
        }

        public Dictionary<Tuple<long, long>, char> Map { get; set; }
        public List<string> Instructions { get; set; }

        public long Xmin { get; set; }
        public long Xmax { get; set; }
        public long Ymin { get; set; }
        public long Ymax { get; set; }
        public Tuple<long, long> PosNow { get; set; }
        public DirectionChoice Direction { get; set; }


        public MonkeyMapPassword(List<string> lines)
        {
            Instructions = MakeInstructions(lines[lines.Count - 1]);
            lines.RemoveAt(lines.Count - 1);

            Map = new Dictionary<Tuple<long, long>, char>();
            for (int y = 0; y < lines.Count; y++)
            {
                var line = lines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x] != ' ')
                    {
                        Map.Add(new Tuple<long, long>(x, y), line[x]);
                    }
                }
            }

            PosNow = new Tuple<long, long>(Map.Keys.Where(t => t.Item2 == 0).ToList().Min(t => t.Item1), 0);
            Direction = DirectionChoice.Right;
        }

        public List<string> MakeInstructions(string line)
        {
            Instructions = new List<string>();

            StringBuilder sb = new StringBuilder();
            foreach (var ch in line)
            {
                if (char.IsDigit(ch))
                {
                    sb.Append(ch);
                    continue;
                }
                if (ch == 'L')
                {
                    if (sb.Length > 0)
                    {
                        Instructions.Add(sb.ToString());
                        sb.Clear();
                    }
                    Instructions.Add("L");
                    continue;
                }
                if (ch == 'R')
                {
                    if (sb.Length > 0)
                    {
                        Instructions.Add(sb.ToString());
                        sb.Clear();
                    }
                    Instructions.Add("R");
                    continue;
                }
            }
            if (sb.Length > 0)
            {
                Instructions.Add(sb.ToString());
            }
            return Instructions;
        }

        public long MakePassword()
        {
            long password = (PosNow.Item2 + 1) * 1000 + (PosNow.Item1 + 1) * 4;
            switch (Direction)
            {
                case DirectionChoice.Up:
                    password += 3;
                    break;
                case DirectionChoice.Right:
                    break;
                case DirectionChoice.Down:
                    password += 1;
                    break;
                case DirectionChoice.Left:
                    password += 2;
                    break;
                default:
                    break;
            }
            return password;
        }

        public void ProcessCommands()
        {
            foreach (var cmd in Instructions)
            {
                //DumpMap();
                if (cmd == "R")
                {
                    TurnRight();
                    continue;
                }
                if (cmd == "L")
                {
                    TurnLeft();
                    continue;
                }
                long move = long.Parse(cmd);
                Move(move);
            }
            //DumpMap();
        }

        public void Move(long movement)
        {
            bool moved = false;
            for (long i = 0; i < movement; i++)
            {
                switch (Direction)
                {
                    case DirectionChoice.Up:
                        moved = MoveUp();
                        break;
                    case DirectionChoice.Right:
                        moved = MoveRight();
                        break;
                    case DirectionChoice.Down:
                        moved = MoveDown();
                        break;
                    case DirectionChoice.Left:
                        moved = MoveLeft();
                        break;
                    default:
                        break;
                }
                if (moved == false)
                    return;
            }
        }

        public bool MoveUp()
        {
            long xNow = PosNow.Item1;
            long yNow = PosNow.Item2;

            yNow--;
            var tNow = new Tuple<long, long>(xNow, yNow);
            if (Map.ContainsKey(tNow))
            {
                // check terrain
                if (Map[tNow] == '#')
                {
                    // hit a wall
                    return false;
                }
                else
                {
                    // move here 
                    PosNow = tNow;
                    Map[PosNow] = '^';
                    return true;
                }
            }

            // wrap movement
            yNow = Map.Keys.Where(t => t.Item1 == xNow).Max(p => p.Item2);
            var tWrap = new Tuple<long, long>(xNow, yNow);
            if (Map.ContainsKey(tWrap))
            {
                // check terrain
                if (Map[tWrap] == '#')
                {
                    // hit a wall
                    return false;
                }
                else
                {
                    // move here 
                    PosNow = tWrap;
                    return true;
                }
            }
            throw new ArgumentOutOfRangeException("MoveUp");
        }

        public bool MoveDown()
        {
            long xNow = PosNow.Item1;
            long yNow = PosNow.Item2;

            yNow++;
            var tNow = new Tuple<long, long>(xNow, yNow);
            if (Map.ContainsKey(tNow))
            {
                // check terrain
                if (Map[tNow] == '#')
                {
                    // hit a wall
                    return false;
                }
                else
                {
                    // move here 
                    PosNow = tNow;
                    Map[PosNow] = 'V';
                    return true;
                }
            }

            // wrap movement
            yNow = Map.Keys.Where(t => t.Item1 == xNow).Min(p => p.Item2);
            var tWrap = new Tuple<long, long>(xNow, yNow);
            if (Map.ContainsKey(tWrap))
            {
                // check terrain
                if (Map[tWrap] == '#')
                {
                    // hit a wall
                    return false;
                }
                else
                {
                    // move here 
                    PosNow = tWrap;
                    Map[PosNow] = 'V';
                    return true;
                }
            }
            throw new ArgumentOutOfRangeException("MoveDown");
        }

        public bool MoveLeft()
        {
            long xNow = PosNow.Item1;
            long yNow = PosNow.Item2;

            xNow--;
            var tNow = new Tuple<long, long>(xNow, yNow);
            if (Map.ContainsKey(tNow))
            {
                // check terrain
                if (Map[tNow] == '#')
                {
                    // hit a wall
                    return false;
                }
                else
                {
                    // move here 
                    PosNow = tNow;
                    Map[PosNow] = '<';
                    return true;
                }
            }

            // wrap movement
            xNow = Map.Keys.Where(t => t.Item2 == yNow).Max(p => p.Item1);
            var tWrap = new Tuple<long, long>(xNow, yNow);
            if (Map.ContainsKey(tWrap))
            {
                // check terrain
                if (Map[tWrap] == '#')
                {
                    // hit a wall
                    return false;
                }
                else
                {
                    // move here 
                    PosNow = tWrap;
                    Map[PosNow] = '<';
                    return true;
                }
            }
            throw new ArgumentOutOfRangeException("MoveLeft");
        }

        public bool MoveRight()
        {
            long xNow = PosNow.Item1;
            long yNow = PosNow.Item2;

            xNow++;
            var tNow = new Tuple<long, long>(xNow, yNow);
            if (Map.ContainsKey(tNow))
            {
                // check terrain
                if (Map[tNow] == '#')
                {
                    // hit a wall
                    return false;
                }
                else
                {
                    // move here 
                    PosNow = tNow;
                    Map[PosNow] = '>';
                    return true;
                }
            }

            // wrap movement
            xNow = Map.Keys.Where(t => t.Item2 == yNow).Min(p => p.Item1);
            var tWrap = new Tuple<long, long>(xNow, yNow);
            if (Map.ContainsKey(tWrap))
            {
                // check terrain
                if (Map[tWrap] == '#')
                {
                    // hit a wall
                    return false;
                }
                else
                {
                    // move here 
                    PosNow = tWrap;
                    Map[PosNow] = '>';
                    return true;
                }
            }
            throw new ArgumentOutOfRangeException("MoveRight");
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case DirectionChoice.Up:
                    Direction = DirectionChoice.Right;
                    Map[PosNow] = '>';
                    break;
                case DirectionChoice.Right:
                    Direction = DirectionChoice.Down;
                    Map[PosNow] = 'V';
                    break;
                case DirectionChoice.Down:
                    Direction = DirectionChoice.Left;
                    Map[PosNow] = '<';
                    break;
                case DirectionChoice.Left:
                    Direction = DirectionChoice.Up;
                    Map[PosNow] = '^';
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case DirectionChoice.Up:
                    Direction = DirectionChoice.Left;
                    Map[PosNow] = '<';
                    break;
                case DirectionChoice.Right:
                    Direction = DirectionChoice.Up;
                    Map[PosNow] = '^';
                    break;
                case DirectionChoice.Down:
                    Direction = DirectionChoice.Right;
                    Map[PosNow] = '>';
                    break;
                case DirectionChoice.Left:
                    Direction = DirectionChoice.Down;
                    Map[PosNow] = 'V';
                    break;
            }
        }

        public void InitBorders()
        {
            Xmin = Map.Keys.Min(p => p.Item1);
            Xmax = Map.Keys.Max(p => p.Item1);
            Ymin = Map.Keys.Min(p => p.Item2);
            Ymax = Map.Keys.Max(p => p.Item2);
        }

        public void DumpMap()
        {
            InitBorders();

            Debug.WriteLine("========= MAP =====================");
            for (long y = Ymin; y <= Ymax; y++)
            {
                for (long x = Xmin; x <= Xmax; x++)
                {
                    var pt = new Tuple<long, long>(x, y);
                    if (!Map.ContainsKey(pt))
                        Debug.Write(" ");
                    else
                        Debug.Write(Map[pt]);
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("========= DONE ====================");
        }
    }
}
