using System.Diagnostics;

namespace AdventCode2024.Models;

public enum Compass
{
    North,
    East,
    South,
    West
}

public class ReindeerMazeMapper
{
    public List<string> Map { get; set; }
    public int Cost { get; set; }

    public ReindeerMazeMapper(string[] lines)
    {
        Map = new List<string>(lines);
    }

    public int WalkMaze()
    {
        return AstarMapWalk(Map);
    }

    public int AstarMapWalk(List<string> map)
    {
        var start = new Tile();
        start.Y = map.FindIndex(x => x.Contains("S"));
        start.X = map[start.Y].IndexOf("S");
        start.Direction = Compass.East;

        var finish = new Tile();
        finish.Y = map.FindIndex(x => x.Contains("E"));
        finish.X = map[finish.Y].IndexOf("E");

        start.SetDistance(finish.X, finish.Y);

        var activeTiles = new List<Tile>();
        activeTiles.Add(start);
        var visitedTiles = new List<Tile>();

        while (activeTiles.Any())
        {
            var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();

            if (checkTile.X == finish.X && checkTile.Y == finish.Y)
            {
                //We found the destination and we can be sure (Because the the OrderBy above)
                //That it's the most low cost option. 
                var tile = checkTile;
                Debug.WriteLine("Retracing steps backwards...");
                int count = 0;
                while (true)
                {
                    Debug.WriteLine($"{tile.X} : {tile.Y}");
                    if (map[tile.Y][tile.X] == '.')
                    {
                        var newMapRow = map[tile.Y].ToCharArray();
                        newMapRow[tile.X] = 'O';
                        map[tile.Y] = new string(newMapRow);
                    }
                    tile = tile.Parent;
                    if (tile == null)
                    {
                        Debug.WriteLine("Map looks like :");
                        map.ForEach(x => Debug.WriteLine(x));
                        Debug.WriteLine("Done!");
                        Cost = checkTile.Cost;
                        return count;
                    }
                    count++;
                }
            }

            visitedTiles.Add(checkTile);
            activeTiles.Remove(checkTile);

            var walkableTiles = GetWalkableTiles(map, checkTile, finish);

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
        return -666;
    }

    public void ShowMap()
    {
        Debug.WriteLine("----------------------");
        foreach (var row in Map)
        {
            Debug.WriteLine($"-{row}-");
        }
        Debug.WriteLine("----------------------");
    }

    public List<Tile> GetWalkableTiles(List<string> map, Tile currentTile, Tile targetTile)
    {
        var possibleTiles = new List<Tile>()
        {
            new Tile { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile },
            new Tile { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile },
            new Tile { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile },
            new Tile { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile },
        };

        possibleTiles.ForEach(tile => tile.SetDistanceAndCost(targetTile.X, targetTile.Y));

        var maxX = map.First().Length - 1;
        var maxY = map.Count - 1;

        return possibleTiles
                .Where(tile => tile.X >= 0 && tile.X <= maxX)
                .Where(tile => tile.Y >= 0 && tile.Y <= maxY)
                .Where(tile => map[tile.Y][tile.X] == '.' || map[tile.Y][tile.X] == 'E')
                .ToList();
    }
}
