using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class LobbyLayout
    {
        public Dictionary<Tuple<int, int>, int> Tiles { get; set; }

        public LobbyLayout()
        {
            Tiles = new Dictionary<Tuple<int, int>, int>();
        }

        public void ProcessDirections(string[] directions)
        {
            foreach (var line in directions)
            {
                var tile = FindTile(line, 0, 0);
                if (Tiles.ContainsKey(tile))
                {
                    Tiles[tile] += 1;
                }
                else
                {
                    Tiles.Add(tile, 1);
                }
            }
        }

        public Tuple<int, int> FindTile(string line, int x, int y)
        {
            var directions = line.ToCharArray();

            char prev = ' ';
            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case 'e':
                        if (prev == 'n')
                        {
                            y += 1;
                            if (Math.Abs(y % 2) != 0)
                            {
                                x += 1;
                            }
                        }
                        else if (prev == 's')
                        {
                            y -= 1;
                            if (Math.Abs(y % 2) != 0)
                            {
                                x += 1;
                            }
                        }
                        else
                        {
                            x += 1;
                        }
                        break;
                    case 'w':
                        if (prev == 'n')
                        {
                            y += 1;
                            if (Math.Abs(y % 2) == 0)
                            {
                                x -= 1;
                            }
                        }
                        else if (prev == 's')
                        {
                            y -= 1;
                            if (Math.Abs(y % 2) == 0)
                            {
                                x -= 1;
                            }
                        }
                        else
                        {
                            x -= 1;
                        }
                        break;
                    case 'n':
                        break;
                    case 's':
                        break;
                    default:
                        break;
                }
                prev = direction;
            }
            return Tuple.Create(x, y);
        }

        public int CountBlackTiles()
        {
            int count = Tiles.Values.Select(t => Math.Abs(t % 2)).Sum();
            return count;
        }

        public void ProcessGeneration()
        {
            int minX = Tiles.Keys.Select(t => t.Item1).Min();
            int maxX = Tiles.Keys.Select(t => t.Item1).Max();
            int minY = Tiles.Keys.Select(t => t.Item2).Min();
            int maxY = Tiles.Keys.Select(t => t.Item2).Max();

            var nextTiles = new Dictionary<Tuple<int, int>, int>();

            for (int x = minX - 1; x <= maxX + 1; x++)
            {
                for (int y = minY - 1; y <= maxY + 1; y++)
                {
                    var tnow = Tuple.Create(x, y);
                    bool isBlack = IsBlackTile(tnow);
                    int count = (IsBlackTile(FindTile("ne", x, y))) ? 1 : 0;
                    count += (IsBlackTile(FindTile("e", x, y))) ? 1 : 0;
                    count += (IsBlackTile(FindTile("se", x, y))) ? 1 : 0;
                    count += (IsBlackTile(FindTile("sw", x, y))) ? 1 : 0;
                    count += (IsBlackTile(FindTile("w", x, y))) ? 1 : 0;
                    count += (IsBlackTile(FindTile("nw", x, y))) ? 1 : 0;
                    if (isBlack && (count == 1 || count == 2))
                    {
                        // this remains black
                        nextTiles.Add(tnow, 1);
                    }
                    if (!isBlack && count == 2)
                    {
                        // white becomes black
                        nextTiles.Add(tnow, 1);
                    }
                }
            }
            Tiles.Clear();
            Tiles = nextTiles;
        }

        public bool IsBlackTile(Tuple<int, int> tile)
        {
            if (Tiles.TryGetValue(tile, out int count))
            {
                // found. odd number is black
                return (count % 2 == 1);
            }
            // if not found its white
            return false;
        }
    }
}
