using System.Diagnostics;

namespace AdventCode2022.Models
{
    /// <summary>
    /// From this blog //A* Search Pathfinding Example from : https://dotnetcoretutorials.com/2020/07/25/a-search-pathfinding-algorithm-in-c/ 
    /// </summary>
    public class HillClimbingAlogrithm
    {
        public List<string> Map { get; set; }
        public string StartStr { get; set; }
        public string FinishStr { get; set; }

        public Tile Start { get; set; }
        public Tile Finish { get; set; }

        public HillClimbingAlogrithm(string[] lines, string start, string finish)
        {
            Map = new List<string>(lines);
            StartStr = start;
            Start = new Tile();
            Start.Y = Map.FindIndex(x => x.Contains(StartStr));
            Start.X = Map[Start.Y].IndexOf(StartStr);

            FinishStr = finish;
            Finish = new Tile();
            Finish.Y = Map.FindIndex(x => x.Contains(FinishStr));
            Finish.X = Map[Finish.Y].IndexOf(FinishStr);

            Start.SetDistance(Finish.X, Finish.Y);
        }

        public int FindFewestSteps()
        {
            var activeTiles = new List<Tile>();
            activeTiles.Add(Start);
            var visitedTiles = new List<Tile>();

            while (activeTiles.Any())
            {
                var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();

                if (checkTile.X == Finish.X && checkTile.Y == Finish.Y)
                {
                    //We found the destination and we can be sure (Because the the OrderBy above)
                    //That it's the most low cost option. 
                    var tile = checkTile;
                    Debug.WriteLine("Retracing steps backwards...");
                    int steps = 0;
                    while (true)
                    {
                        Debug.WriteLine($"{tile.X} : {tile.Y}");
                        if (Map[tile.Y][tile.X] == ' ')
                        {
                            var newMapRow = Map[tile.Y].ToCharArray();
                            newMapRow[tile.X] = '*';
                            Map[tile.Y] = new string(newMapRow);
                        }
                        tile = tile.Parent;
                        if (tile == null)
                        {
                            Debug.WriteLine("Map looks like :");
                            Map.ForEach(x => Debug.WriteLine(x));
                            Debug.WriteLine("Done!");
                            return steps;
                        }
                        steps++;
                    }
                }

                visitedTiles.Add(checkTile);
                activeTiles.Remove(checkTile);

                var walkableTiles = GetWalkableTiles(Map, checkTile, Finish);

                foreach (var walkableTile in walkableTiles)
                {
                    //We have already visited this tile so we don't need to do so again!
                    if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                        continue;

                    //It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
                    if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                    {
                        var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
                        if (existingTile.CostDistance > checkTile.CostDistance)
                        {
                            activeTiles.Remove(existingTile);
                            activeTiles.Add(walkableTile);
                        }
                    }
                    else
                    {
                        //We've never seen this tile before so add it to the list. 
                        activeTiles.Add(walkableTile);
                    }
                }
            }

            Debug.WriteLine("No Path Found!");
            return 0;
        }
        public List<Tile> GetWalkableTiles(List<string> map, Tile currentTile, Tile targetTile)
        {
            var possibleTiles = new List<Tile>()
            {
                new Tile { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile, Cost = currentTile.Cost + 1 },
                new Tile { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile, Cost = currentTile.Cost + 1 },
                new Tile { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
                new Tile { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
            };

            possibleTiles.ForEach(tile => tile.SetDistance(targetTile.X, targetTile.Y));

            var maxX = map.First().Length - 1;
            var maxY = map.Count - 1;

            return possibleTiles
                    .Where(tile => tile.X >= 0 && tile.X <= maxX)
                    .Where(tile => tile.Y >= 0 && tile.Y <= maxY)
                    .Where(tile => IsWalkable(map, currentTile, tile) || map[tile.Y][tile.X] == FinishStr[0])
                    .ToList();
        }

        public bool IsWalkable(List<string> map, Tile currentTile, Tile targetTile)
        {
            char current = map[currentTile.Y][currentTile.X];
            char target = map[targetTile.Y][targetTile.X];
            return (char.IsLower(current) && char.IsLower(target) && Math.Abs(current - target) == 1);
        }
    }

    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Cost { get; set; }
        public int Distance { get; set; }
        public int CostDistance => Cost + Distance;
        public Tile Parent { get; set; }

        //The distance is essentially the estimated distance, ignoring walls to our target. 
        //So how many tiles left and right, up and down, ignoring walls, to get there. 
        public void SetDistance(int targetX, int targetY)
        {
            this.Distance = Math.Abs(targetX - X) + Math.Abs(targetY - Y);
        }
    }
}