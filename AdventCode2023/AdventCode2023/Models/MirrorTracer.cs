using static AdventCode2023.Models.MirrorTracer;

namespace AdventCode2023.Models
{
    public class MirrorTracer
    {
        public enum BeamDirection
        {
            Up,
            Right,
            Down,
            Left
        }

        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public List<string> CaveFloor { get; set; }
        public Dictionary<Tuple<int, int>, InputBeams> EnergizedTiles { get; set; }
        public Queue<Tuple<int, int, BeamDirection>> BeamPaths { get; set; }

        public MirrorTracer(string[] lines)
        {
            CaveFloor = new List<string>(lines);
            MaxY = lines.Length;
            MaxX = lines[0].Length;
            EnergizedTiles = new Dictionary<Tuple<int, int>, InputBeams>();
            BeamPaths = new Queue<Tuple<int, int, BeamDirection>>();
        }

        public int FindBestEdgeToEnergize()
        {
            int maxTiles = 0;

            for (int x = 0; x < MaxX; ++x)
            {
                StartTracing(x, 0, BeamDirection.Down);
                if (maxTiles < EnergizedTiles.Count)
                {
                    maxTiles = EnergizedTiles.Count;
                }
                StartTracing(x, MaxY - 1, BeamDirection.Up);
                if (maxTiles < EnergizedTiles.Count)
                {
                    maxTiles = EnergizedTiles.Count;
                }
            }
            for (int y = 0; y < MaxY; ++y)
            {
                StartTracing(0, y, BeamDirection.Right);
                if (maxTiles < EnergizedTiles.Count)
                {
                    maxTiles = EnergizedTiles.Count;
                }
                StartTracing(MaxX - 1, y, BeamDirection.Right);
                if (maxTiles < EnergizedTiles.Count)
                {
                    maxTiles = EnergizedTiles.Count;
                }
            }
            return maxTiles;
        }

        public void StartTracing(int x, int y, BeamDirection direction)
        {
            EnergizedTiles.Clear();
            BeamPaths.Clear();
            var tp = new Tuple<int, int, BeamDirection>(x, y, direction);
            BeamPaths.Enqueue(tp);
            do
            {
                tp = BeamPaths.Dequeue();
                var nextTiles = TraceBeam(tp.Item1, tp.Item2, tp.Item3);
                if (nextTiles.Any())
                {
                    foreach (var tpNext in nextTiles)
                    {
                        BeamPaths.Enqueue(tpNext);
                    }
                }
            } while (BeamPaths.Count > 0);
        }

        /// <summary>
        /// Start point and direction as input.
        /// Trace the beam
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public List<Tuple<int, int, BeamDirection>> TraceBeam(int x, int y, BeamDirection direction)
        {
            List<Tuple<int, int, BeamDirection>> list = new List<Tuple<int, int, BeamDirection>>();

            if (!OnTheMap(x, y))
            {
                // 
                return list;
            }
            // on the map, emergized
            var tp = new Tuple<int, int>(x, y);
            if (EnergizedTiles.ContainsKey(tp))
            {
                // times crossed
                EnergizedTiles[tp].AddBeamDirection(direction);
            }
            else
            {
                // new
                EnergizedTiles.Add(tp, new InputBeams(direction));
            }

            if (EnergizedTiles[tp].HasHadABeamThisWay(direction))
            {
                // no need to continue
                return list;
            }

            char tile = CaveFloor[y][x];
            switch (tile)
            {
                case '/':
                    list.Add(NextMirrorTileSlash(x, y, direction));
                    break;
                case '\\':
                    list.Add(NextMirrorTileBackSlash(x, y, direction));
                    break;
                case '-':
                    list.AddRange(NextMirrorTileHorizontalSplit(x, y, direction));
                    break;
                case '|':
                    list.AddRange(NextMirrorTileVerticalSplit(x, y, direction));
                    break;
                case '.':
                    // simple continue
                    list.Add(NextTile(x, y, direction));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tile), $"Tile: {tile} is not expected.");
            }
            // done
            return list;
        }

        /// <summary>
        /// Slash is /
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private Tuple<int, int, BeamDirection> NextMirrorTileSlash(int x, int y, BeamDirection direction)
        {
            switch (direction)
            {
                case BeamDirection.Up:
                    direction = BeamDirection.Right;
                    x += 1;
                    break;
                case BeamDirection.Right:
                    direction = BeamDirection.Up;
                    y -= 1;
                    break;
                case BeamDirection.Down:
                    direction = BeamDirection.Left;
                    x -= 1;
                    break;
                case BeamDirection.Left:
                    direction = BeamDirection.Down;
                    y += 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), $"Direction: {direction} is not expected.");
            }
            return new Tuple<int, int, BeamDirection>(x, y, direction);
        }

        /// <summary>
        /// Slash is \
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private Tuple<int, int, BeamDirection> NextMirrorTileBackSlash(int x, int y, BeamDirection direction)
        {
            switch (direction)
            {
                case BeamDirection.Up:
                    direction = BeamDirection.Left;
                    x -= 1;
                    break;
                case BeamDirection.Right:
                    direction = BeamDirection.Down;
                    y += 1;
                    break;
                case BeamDirection.Down:
                    direction = BeamDirection.Right;
                    x += 1;
                    break;
                case BeamDirection.Left:
                    direction = BeamDirection.Up;
                    y -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), $"Direction: {direction} is not expected.");
            }
            return new Tuple<int, int, BeamDirection>(x, y, direction);
        }

        /// <summary>
        /// Split -
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private Tuple<int, int, BeamDirection>[] NextMirrorTileHorizontalSplit(int x, int y, BeamDirection direction)
        {
            List<Tuple<int, int, BeamDirection>> list = new List<Tuple<int, int, BeamDirection>>();

            switch (direction)
            {
                case BeamDirection.Up:
                case BeamDirection.Down:
                    direction = BeamDirection.Left;
                    list.Add(new Tuple<int, int, BeamDirection>(x - 1, y, direction));
                    direction = BeamDirection.Right;
                    list.Add(new Tuple<int, int, BeamDirection>(x + 1, y, direction));
                    break;
                case BeamDirection.Right:
                    list.Add(new Tuple<int, int, BeamDirection>(x + 1, y, direction));
                    break;
                case BeamDirection.Left:
                    list.Add(new Tuple<int, int, BeamDirection>(x - 1, y, direction));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), $"Direction: {direction} is not expected.");
            }
            return list.ToArray();
        }

        /// <summary>
        /// Split |
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private Tuple<int, int, BeamDirection>[] NextMirrorTileVerticalSplit(int x, int y, BeamDirection direction)
        {
            List<Tuple<int, int, BeamDirection>> list = new List<Tuple<int, int, BeamDirection>>();

            switch (direction)
            {
                case BeamDirection.Left:
                case BeamDirection.Right:
                    list.Add(new Tuple<int, int, BeamDirection>(x, y - 1, BeamDirection.Up));
                    list.Add(new Tuple<int, int, BeamDirection>(x, y + 1, BeamDirection.Down));
                    break;
                case BeamDirection.Up:
                    list.Add(new Tuple<int, int, BeamDirection>(x, y - 1, direction));
                    break;
                case BeamDirection.Down:
                    list.Add(new Tuple<int, int, BeamDirection>(x, y + 1, direction));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), $"Direction: {direction} is not expected.");
            }
            return list.ToArray();
        }

        private Tuple<int, int, BeamDirection> NextTile(int x, int y, BeamDirection direction)
        {
            switch (direction)
            {
                case BeamDirection.Up:
                    y -= 1;
                    break;
                case BeamDirection.Right:
                    x += 1;
                    break;
                case BeamDirection.Down:
                    y += 1;
                    break;
                case BeamDirection.Left:
                    x -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), $"Direction: {direction} is not expected.");
            }
            return new Tuple<int, int, BeamDirection>(x, y, direction);
        }

        public bool OnTheMap(int x, int y)
        {
            if (0 <= x && x < MaxX && 0 <= y && y < MaxY)
            {
                return true;
            }
            return false;
        }
    }
    public class InputBeams
    {
        public int BeamUp { get; set; } = 0;
        public int BeamDown { get; set; } = 0;
        public int BeamLeft { get; set; } = 0;
        public int BeamRight { get; set; } = 0;

        public InputBeams()
        {
            BeamUp = 0;
            BeamDown = 0;
            BeamLeft = 0;
            BeamRight = 0;
        }

        public InputBeams(BeamDirection direction)
            : base()
        {
            AddBeamDirection(direction);
        }

        public void AddBeamDirection(BeamDirection direction)
        {
            switch (direction)
            {
                case BeamDirection.Up:
                    BeamUp++;
                    break;
                case BeamDirection.Down:
                    BeamDown++;
                    break;
                case BeamDirection.Left:
                    BeamLeft++;
                    break;
                case BeamDirection.Right:
                    BeamRight++;
                    break;
                default:
                    break;
            }
        }

        public bool HasHadABeamThisWay(BeamDirection direction)
        {
            switch (direction)
            {
                case BeamDirection.Up:
                    return BeamUp > 1;
                case BeamDirection.Down:
                    return BeamDown > 1;
                case BeamDirection.Left:
                    return BeamLeft > 1;
                case BeamDirection.Right:
                    return BeamRight > 1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction));
            }
        }
    }
}
