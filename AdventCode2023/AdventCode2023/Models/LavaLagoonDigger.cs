using System.Diagnostics;

namespace AdventCode2023.Models
{
    public class LavaLagoonDigger
    {
        public List<DigInstruction> DigInstructions { get; set; }
        public Dictionary<Tuple<long, long>, Point> Points { get; set; }

        public LavaLagoonDigger(string[] lines, bool fromColor = false)
        {
            DigInstructions = new List<DigInstruction>();
            Points = new Dictionary<Tuple<long, long>, Point>();

            foreach (var line in lines)
            {
                DigInstructions.Add(new DigInstruction(line, fromColor));
            }
        }

        public void MakePerimeter()
        {
            Points.Clear();


            Point prev = new Point(0, 0);

            Points.Add(prev.Key, prev);
            foreach (var cmd in DigInstructions)
            {
                var newPts = Point.DoDiggInstruction(prev, cmd);
                if (newPts.Any())
                {
                    foreach (var now in newPts)
                    {
                        if (!Points.ContainsKey(now.Key))
                        {
                            Points.Add(now.Key, now);
                        }
                        prev = now;
                    }
                }
            }
        }

        public void DumpLagoon()
        {
            long minX = Points.Keys.Min(tp => tp.Item1);
            long maxX = Points.Keys.Max(tp => tp.Item1);
            long minY = Points.Keys.Min(tp => tp.Item2);
            long maxY = Points.Keys.Max(tp => tp.Item2);

            Debug.WriteLine("================================");
            for (long y = minY; y <= maxY; y++)
            {
                for (long x = minX; x <= maxX; x++)
                {
                    var tp = new Point(x, y);
                    if (Points.ContainsKey(tp.Key))
                    {
                        Debug.Write("#");
                    }
                    else
                    {
                        Debug.Write('.');
                    }
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("================================");
        }


        public void FloodFillLagoon(Point start)
        {
            if (Points.ContainsKey(start.Key))
            {
                throw new ArgumentException("Should not already be in Points!");
            }

            Stack<Point> stack = new Stack<Point>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                Point p = stack.Pop();
                if (!Points.ContainsKey(p.Key))
                {
                    Points.Add(p.Key, p);
                    stack.Push(new Point(p.X - 1, p.Y));
                    stack.Push(new Point(p.X + 1, p.Y));
                    stack.Push(new Point(p.X, p.Y + 1));
                    stack.Push(new Point(p.X, p.Y - 1));
                }
            }

        }
    }

    public class Point
    {
        public long X { get; set; }
        public long Y { get; set; }

        public Point(long x, long y)
        {
            X = x;
            Y = y;
        }

        public Tuple<long, long> Key
        {
            get
            {
                return new Tuple<long, long>(X, Y);
            }
        }

        public static List<Point> DoDiggInstruction(Point last, DigInstruction cmd)
        {
            List<Point> points = new List<Point>();

            switch (cmd.Direction)
            {
                case "U":
                    for (long i = 1; i <= cmd.Length; i++)
                    {
                        points.Add(new Point(last.X, last.Y - i));
                    }
                    break;
                case "D":
                    for (long i = 1; i <= cmd.Length; i++)
                    {
                        points.Add(new Point(last.X, last.Y + i));
                    }
                    break;
                case "L":
                    for (long i = 1; i <= cmd.Length; i++)
                    {
                        points.Add(new Point(last.X - i, last.Y));
                    }
                    break;
                case "R":
                    for (long i = 1; i <= cmd.Length; i++)
                    {
                        points.Add(new Point(last.X + i, last.Y));
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cmd));
            }
            return points;
        }
    }

    public class DigInstruction
    {
        public string Direction { get; set; }
        public long Length { get; set; }
        public string Color { get; set; }


        public DigInstruction(string line, bool fromColor = false)
        {
            if (fromColor)
            {
                var temp = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Color = temp[2];
                var hexTemp = temp[2].Split(new char[] { '(', ')', '#' }, StringSplitOptions.RemoveEmptyEntries);
                string hex = hexTemp[0].Substring(0, 5);
                int dir = (int)hexTemp[0][5] - '0';
                Length = Convert.ToInt64(hex, 16);
                switch (dir)
                {
                    case 0:
                        Direction = "R";
                        break;
                    case 1:
                        Direction = "D";
                        break;
                    case 2:
                        Direction = "L";
                        break;
                    case 3:
                        Direction = "U";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(dir));
                }
            }
            else
            {
                var temp = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Direction = temp[0];
                Length = long.Parse(temp[1]);
                Color = temp[2];
            }
        }
    }
}
