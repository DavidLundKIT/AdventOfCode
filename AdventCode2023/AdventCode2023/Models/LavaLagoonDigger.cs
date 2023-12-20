namespace AdventCode2023.Models
{
    public class LavaLagoonDigger
    {
        public List<DigInstruction> DigInstructions { get; set; }
        public List<Point> Points { get; set; }

        public LavaLagoonDigger(string[] lines)
        {
            DigInstructions = new List<DigInstruction>();
            Points = new List<Point>();             
            foreach (var line in lines)
            {
                DigInstructions.Add(new DigInstruction(line));
            }
        }

        public void MakePerimeter()
        {
            Points.Clear();

            
            Point prev = new Point(0, 0);

            Points.Add(prev);
            foreach (var cmd in DigInstructions)
            {
                var now = new Point(prev, cmd);
                Points.Add(now);
                prev = now;
            }
        }


        public int CalculateLagoon()
        {
            int size = 0;

            var points = Points;

            //points.Add(points[0]);
            // Not going to work every thing is 0
            //var area = Math.Abs(points.Take(points.Count - 1)
            //   .Select((p, i) => (points[i + 1].X - p.X) * (points[i + 1].Y + p.Y))
            //   .Sum() / 2);
            return size;
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(Point last, DigInstruction cmd)
        {
            X = last.X;
            Y = last.Y;
            switch (cmd.Direction)
            {
                case "U":
                    Y += cmd.Length;
                    break;
                case "D":
                    Y -= cmd.Length;
                    break;
                case "L":
                    X -= cmd.Length;
                    break;
                case "R":
                    X += cmd.Length;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cmd));
            }
        }
    }

    public class DigInstruction
    {
        public string Direction { get; set; }
        public int Length { get; set; }
        public string Color { get; set; }

        public DigInstruction(string line)
        {
            var temp = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Direction = temp[0];
            Length = int.Parse(temp[1]);
            Color = temp[2];
        }
    }
}
