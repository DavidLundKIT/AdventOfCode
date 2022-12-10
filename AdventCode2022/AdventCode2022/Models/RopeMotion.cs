namespace AdventCode2022.Models
{
    public class RopeMotion
    {
        public Dictionary<string, int> TailPlaces { get; set; }
        public List<int> HeadX { get; set; }
        public List<int> HeadY { get; set; }
        public int TailIndex { get; set; }

        public RopeMotion(int startX, int startY, int size)
        {
            HeadX = new List<int>();
            HeadY = new List<int>();
            for (int i = 0; i < size; i++)
            {
                HeadX.Add(startX);
                HeadY.Add(startY);
            }
            TailIndex = size - 1;
            TailPlaces = new Dictionary<string, int>();
            var key = MakeKey(startX, startY);
            TailPlaces.Add(key, 1);
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
                        HeadX[0]++;
                        break;
                    case "L":
                        HeadX[0]--;
                        break;
                    case "U":
                        HeadY[0]++;
                        break;
                    case "D":
                        HeadY[0]--;
                        break;
                    default:
                        break;
                }
                for (int idx = 1; idx < HeadX.Count; idx++)
                {
                    if (!IsTailTouchingHead(idx))
                    {
                        MoveTail(idx);
                    }
                }
            }
        }

        public void MoveTail(int idx)
        {
            if (HeadY[idx - 1] == HeadY[idx])
            {
                // left or right
                if (HeadX[idx - 1] - HeadX[idx] > 0)
                {
                    HeadX[idx]++;
                }
                else
                {
                    HeadX[idx]--;
                }
                if (idx == TailIndex)
                    AddPosition(TailPlaces, HeadX[idx], HeadY[idx]);
                return;
            }

            if (HeadX[idx - 1] == HeadX[idx])
            {
                // up or down
                if (HeadY[idx - 1] - HeadY[idx] > 0)
                {
                    HeadY[idx]++;
                }
                else
                {
                    HeadY[idx]--;
                }
                if (idx == TailIndex)
                    AddPosition(TailPlaces, HeadX[idx], HeadY[idx]);
                return;
            }

            // diagonals
            int dx = HeadX[idx - 1] - HeadX[idx];
            int dy = HeadY[idx - 1] - HeadY[idx];
            if (dx > 0)
                HeadX[idx]++;
            else
                HeadX[idx]--;
            if (dy > 0)
                HeadY[idx]++;
            else
                HeadY[idx]--;
            if (idx == TailIndex)
                AddPosition(TailPlaces, HeadX[idx], HeadY[idx]);
            return;
        }

        public bool IsTailTouchingHead(int idx)
        {
            for (int x = HeadX[idx] - 1; x <= HeadX[idx] + 1; x++)
            {
                for (int y = HeadY[idx] - 1; y <= HeadY[idx] + 1; y++)
                {
                    if (x == HeadX[idx - 1] && y == HeadY[idx - 1])
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
