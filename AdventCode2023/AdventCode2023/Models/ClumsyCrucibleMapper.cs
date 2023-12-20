using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2023.Models
{
    /// <summary>
    /// From this blog //A* Search Pathfinding Example from : https://dotnetcoretutorials.com/2020/07/25/a-search-pathfinding-algorithm-in-c/ 
    /// </summary>
    public class ClumsyCrucibleMapper
    {
        public List<string> Map { get; set; }

        public Tile Start { get; set; }
        public Tile Finish { get; set; }

        /// <summary>
        /// Start: top left
        /// Finish: bottom right
        /// </summary>
        /// <param name="lines"></param>
        public ClumsyCrucibleMapper(string[] lines)
        {
            Map = new List<string>(lines);
            Start = new Tile();
            Start.Y = 0;
            Start.X = 0;

            Finish = new Tile();
            Finish.Y = Map.Count - 1;
            Finish.X = Map[0].Length - 1;

            Start.SetDistance(Finish.X, Finish.Y);
        }

        //public ClumsyCrucibleMapper(string[] lines, Tile start, string finish)
        //{
        //    Map = new List<string>(lines);
        //    StartStr = "S";
        //    Start = start;
        //    FinishStr = finish;
        //    Finish = new Tile();
        //    Finish.Y = Map.FindIndex(x => x.Contains(FinishStr));
        //    Finish.X = Map[Finish.Y].IndexOf(FinishStr);

        //    Start.SetDistance(Finish.X, Finish.Y);
        //}

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
                    //We found the destination and we can be sure (Because the OrderBy above)
                    //That it's the most low cost option. 
                    var tile = checkTile;
                    Debug.WriteLine("Retracing steps backwards...");
                    int steps = 0;
                    int heatloss = 0;
                    while (true)
                    {
                        Debug.WriteLine($"{tile.X} : {tile.Y}");
                        heatloss += (int)Map[tile.Y][tile.X]- '0';
                            var newMapRow = Map[tile.Y].ToCharArray();
                            newMapRow[tile.X] = '*';
                            Map[tile.Y] = new string(newMapRow);
                        tile = tile.Parent;
                        if (tile == null)
                        {
                            Debug.WriteLine("Map looks like :");
                            Map.ForEach(x => Debug.WriteLine(x));
                            Debug.WriteLine("Done!");
                            return heatloss;
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
            return int.MaxValue;
        }

        public List<Tile> GetWalkableTiles(List<string> map, Tile currentTile, Tile targetTile)
        {
            var possibleTiles = new List<Tile>()
            {

                // map[currentTile.Y][currentTile.X]
                new Tile { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile }, // Cost = (int)(map[currentTile.Y-1][currentTile.X]-'0') },
                new Tile { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile }, // Cost = (int)(map[currentTile.Y+1][currentTile.X]-'0') },
                new Tile { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile }, // Cost = (int)(map[currentTile.Y][currentTile.X - 1] - '0') },
                new Tile { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile } // Cost = (int)(map[currentTile.Y][currentTile.X+1]-'0') },
            };

            var maxX = map.First().Length - 1;
            var maxY = map.Count - 1;
            possibleTiles = possibleTiles
                    .Where(tile => tile.X >= 0 && tile.X <= maxX)
                    .Where(tile => tile.Y >= 0 && tile.Y <= maxY).ToList();

            possibleTiles.ForEach(tile => tile.SetCost(map, currentTile));
            possibleTiles.ForEach(tile => tile.SetDistance(targetTile.X, targetTile.Y));


            return possibleTiles
                    .Where(tile => tile.X >= 0 && tile.X <= maxX)
                    .Where(tile => tile.Y >= 0 && tile.Y <= maxY)
                    .Where(tile => IsWalkable(map, currentTile, tile))
                    .ToList();
        }



        public bool IsWalkable(List<string> map, Tile currentTile, Tile targetTile)
        {
            if (currentTile.Parent != null && targetTile.X == currentTile.Parent.X && targetTile.Y == currentTile.Parent.Y)
            {
                // can't turn around only forward, left or right
                return false; 
            }
            if (LessThan3X(targetTile) && LessThan3Y(targetTile))
            {
                // 3 in a row either X or Y so must turn
                return true;
            }
            return false;
        }

        public bool LessThan3X(Tile targetTile)
        {
            int count = 0;
            var parent = targetTile.Parent;
            while (parent != null && parent.X == targetTile.X)
            {
                count++;
                if (count == 4)
                {
                    return false;
                }
                parent = parent.Parent;
            }
            return true;
        }

        public bool LessThan3Y(Tile targetTile)
        {
            int count = 0;
            var parent = targetTile.Parent;
            while (parent != null && parent.Y == targetTile.Y)
            {
                count++;
                if (count == 4)
                {
                    return false;
                }
                parent = parent.Parent;
            }
            return true;
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

        public void SetCost(List<string> map, Tile currentTile)
        {
            Cost = ((int)(map[this.Y][this.X] - '0')) + currentTile.Cost;
        }
    }
}
