namespace AdventCode2022.Models
{
    public class RopeMotion
    {
        public Dictionary<string, int> TailPlaces { get; set; }
        public Dictionary<string, int> HeadPlaces { get; set; }
        public int HeadX { get; set; }
        public int HeadY { get; set; }
        public int TailX { get; set; }
        public int TailY { get; set; }

        public RopeMotion(int startX, int startY)
        {
            HeadX = startX;
            HeadY = startY;
            TailX = startX;
            TailY = startY;
            TailPlaces = new Dictionary<string, int>();
            HeadPlaces = new Dictionary<string, int>();
            var key = MakeKey(startX, startY);
            TailPlaces.Add(key, 1);
            HeadPlaces.Add(key, 1);
        }

        public void ProcessCommands(string[] commands)
        {
            foreach (var cmd in commands)
            {
                ProcessCommand(cmd);
            }
        }

        public void ProcessCommand(string command)
        {
            var parts = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int steps = int.Parse(parts[1]);
            for (int i = 0; i < steps; i++)
            {
                // move head
                switch (parts[0])
                {
                    case "R":
                        HeadX++;
                        break;
                    case "L":
                        HeadX--;
                        break;
                    case "U":
                        HeadY++;
                        break;
                    case "D":
                        HeadY--;
                        break;
                    default:
                        break;
                }
                AddPosition(HeadPlaces, HeadX, HeadY);
                if (!IsTailTouchingHead())
                {
                    MoveTail(parts[0]);
                }
            }
        }

        public void MoveTail(string cmd)
        {
            // found Head

            if (TailY == HeadY)
            {
                // left or right
                if (cmd == "R")
                {
                    TailX++;
                }
                else
                {
                    TailX--;
                }
                AddPosition(TailPlaces, TailX, TailY);
                return;
            }

            if (TailX == HeadX)
            {
                // up or down
                if (cmd == "D")
                {
                    TailY--;
                }
                else
                {
                    TailY++;
                }
                AddPosition(TailPlaces, TailX, TailY);
                return;
            }

            // diagonals
            int dx = HeadX - TailX;
            int dy = HeadY - TailY;
            if (dx > 0)
                TailX++;
            else
                TailX--;
            if (dy > 0)
                TailY++;
            else
                TailY--;
            AddPosition(TailPlaces, TailX, TailY);
            return;
        }

        public bool IsTailTouchingHead()
        {
            for (int x = TailX - 1; x <= TailX + 1; x++)
            {
                for (int y = TailY - 1; y <= TailY + 1; y++)
                {
                    if (x == HeadX && y == HeadY)
                    {
                        return true;
                    }
                }
            };
            return false;
        }

        public void AddPosition(Dictionary<string, int> positions, int x, int y)
        {
            var key = MakeKey(x, y);
            if (positions.ContainsKey(key))
            {
                positions[key]++;
            }
            else
            {
                positions[key] = 1;
            }
        }
        public string MakeKey(int xIndex, int yIndex)
        {
            return $"({xIndex}, {yIndex})";
        }

    }
}
