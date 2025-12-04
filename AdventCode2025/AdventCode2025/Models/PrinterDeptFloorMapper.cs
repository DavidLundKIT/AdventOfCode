using System.Diagnostics;
using System.Text;

namespace AdventCode2025.Models;

public class PrinterDeptFloorMapper
{
    public Dictionary<Tile, char> WarehouseDict { get; set; }
    public PrinterDeptFloorMapper(string[] lines)
    {
        WarehouseDict = new Dictionary<Tile, char>();

        for (int y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                if (line[x] == '@')
                    WarehouseDict.Add(new Tile(x, y), line[x]);
            }
        }
    }

    public void PrintWarehouse()
    {
        Debug.WriteLine("--- Done ---");
        int maxX = WarehouseDict.Keys.Select(k => k.X).Max();
        int maxY = WarehouseDict.Keys.Select(k => k.Y).Max();

        for (int y = 0; y <= maxY; y++)
        {
            StringBuilder lineBuilder = new StringBuilder();
            for (int x = 0; x <= maxX; x++)
            {
                var tile = new Tile(x, y);
                if (WarehouseDict.ContainsKey(tile))
                {
                    lineBuilder.Append(WarehouseDict[tile]);
                }
                else
                {
                    lineBuilder.Append('.');
                }
            }
            Debug.WriteLine(lineBuilder.ToString());
        }
        Debug.WriteLine("--- Done ---");
    }

    public int CountAccessiblePaperRolls()
    {
        int freeRolls = 0;
        foreach (var tile in WarehouseDict.Keys)
        {
            int isBlockedSpace = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;
                    var adjacentTile = new Tile(tile.X + x, tile.Y + y);
                    if (WarehouseDict.ContainsKey(adjacentTile))
                    {
                        isBlockedSpace++;
                    }
                }
            }
            if (isBlockedSpace <= 3)
            {
                freeRolls++;
                WarehouseDict[tile] = 'x';
            }
        }

        return freeRolls;
    }

    public int RemoveWarehousePaperRolls()
    {
        int totalRolls = WarehouseDict.Count;

        int totalMovedRolls = 0;
        int movedRolls = 0;
        do
        {
            movedRolls = CountAccessiblePaperRolls();
            totalMovedRolls += movedRolls;
            if (movedRolls > 0)
            {
                var tilesToRemove = WarehouseDict.Where(li => li.Value == 'x').Select(li => li.Key);
                foreach (var tile in tilesToRemove)
                {
                    WarehouseDict.Remove(tile);
                }
            }
        } while (movedRolls > 0);

        var temp = totalRolls - WarehouseDict.Count;
        return totalMovedRolls;
    }
}

public record Tile(int X, int Y);
