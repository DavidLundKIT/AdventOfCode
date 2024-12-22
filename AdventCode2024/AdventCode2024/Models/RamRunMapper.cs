using System.Diagnostics;

namespace AdventCode2024.Models;

public class RamRunMapper
{
    public List<string> Map { get; set; }
    public List<Point> ByteBombs { get; set; }
    public RamRunMapper(string[] lines, int maxX, int maxY)
    {
        Map = new List<string>();
        ByteBombs = new List<Point>();
        for (int i = 0; i < maxY; i++)
        {
            var row = new string(' ', maxX);
            Map.Add(row);
        }
        AddToMapAt('S', 0, 0);
        AddToMapAt('E', maxX - 1, maxY - 1);

        foreach (var line in lines)
        {
            var parts = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            ByteBombs.Add(new Point(int.Parse(parts[0]), int.Parse(parts[1])));
        }
    }

    public void DropBytes(int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            var pt = ByteBombs[i];
            AddToMapAt('#', pt.X, pt.Y);
        }
    }

    public void AddToMapAt(char ch, int x, int y)
    {
        var chArr = Map[y].ToCharArray();
        chArr[x] = ch;
        Map[y] = new string(chArr);
    }

    public int MapWalk()
    {
        return AstarMapWalk(Map);
    }

    public int AstarMapWalk(List<string> map)
    {
        var start = new Tile();
        start.Y = map.FindIndex(x => x.Contains("S"));
        start.X = map[start.Y].IndexOf("S");


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
                    if (map[tile.Y][tile.X] == ' ')
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
            new Tile { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile, Cost = currentTile.Cost + 1 },
            new Tile { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile, Cost = currentTile.Cost + 1},
            new Tile { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
            new Tile { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
        };

        possibleTiles.ForEach(tile => tile.SetDistance(targetTile.X, targetTile.Y));

        var maxX = map.First().Length - 1;
        var maxY = map.Count - 1;

        return possibleTiles
                .Where(tile => tile.X >= 0 && tile.X <= maxX)
                .Where(tile => tile.Y >= 0 && tile.Y <= maxY)
                .Where(tile => map[tile.Y][tile.X] == ' ' || map[tile.Y][tile.X] == 'E')
                .ToList();
    }
}
