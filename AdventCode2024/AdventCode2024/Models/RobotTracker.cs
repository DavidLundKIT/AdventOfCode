using System.Diagnostics;
using System.Text;

namespace AdventCode2024.Models;

public record RobotStartValues(Point Position, Point Velocity);

/// <summary>
/// Day 14 RestRoomredoubt
/// </summary>
public class RobotTracker
{
    public List<RobotStartValues> StartValues { get; set; }
    public Dictionary<Point, int> Positions { get; set; }
    public int MaxX { get; set; }
    public int MaxY { get; set; }

    public RobotTracker(string[] lines, int maxX, int maxY)
    {
        StartValues = new List<RobotStartValues>();
        Positions = new Dictionary<Point, int>();
        MaxX = maxX;
        MaxY = maxY;

        foreach (string line in lines)
        {
            StartValues.Add(ParseRobotStartValues(line));
        }
    }

    public RobotStartValues ParseRobotStartValues(string line)
    {
        var vals = line.Split(new string[] { "p=", "v=", ",", " " }, StringSplitOptions.RemoveEmptyEntries);
        var startValues = new RobotStartValues(new Point(int.Parse(vals[0]), int.Parse(vals[1])), new Point(int.Parse(vals[2]), int.Parse(vals[3])));
        return startValues;
    }

    public Point MoveRobotFor(int secs, RobotStartValues rsv)
    {
        int x = ((rsv.Position.X + (secs * rsv.Velocity.X)) % MaxX);
        x = x < 0 ? MaxX + x : x;
        int y = ((rsv.Position.Y + (secs * rsv.Velocity.Y)) % MaxY);
        y = y < 0 ? MaxY + y : y;

        return new Point(x, y);
    }

    public void MoveAllRobotsFor(int secs)
    {
        Positions.Clear();
        foreach (var rsv in StartValues)
        {
            var pos = MoveRobotFor(secs, rsv);
            if (Positions.ContainsKey(pos))
            {
                Positions[pos]++;
            }
            else
            {
                Positions.Add(pos, 1);
            }
        }
    }

    public int Quadrant1Count()
    {
        int midX = MaxX / 2;
        int midY = MaxY / 2;

        var positionsInQuadrant = Positions.Where(pv => pv.Key.X >= 0 && pv.Key.X < midX && pv.Key.Y >= 0 && pv.Key.Y < midY).ToList();
        int count = positionsInQuadrant.Select(kv => kv.Value).Sum();
        return count;
    }

    public int Quadrant2Count()
    {
        int midX = MaxX / 2;
        int midY = MaxY / 2;

        var positionsInQuadrant = Positions.Where(pv => pv.Key.X > midX && pv.Key.X < MaxX && pv.Key.Y >= 0 && pv.Key.Y < midY).ToList();
        int count = positionsInQuadrant.Select(kv => kv.Value).Sum();
        return count;
    }

    public int Quadrant3Count()
    {
        int midX = MaxX / 2;
        int midY = MaxY / 2;

        var positionsInQuadrant = Positions.Where(pv => pv.Key.X >= 0 && pv.Key.X < midX && pv.Key.Y > midY && pv.Key.Y < MaxY).ToList();
        int count = positionsInQuadrant.Select(kv => kv.Value).Sum();
        return count;
    }

    public int Quadrant4Count()
    {
        int midX = MaxX / 2;
        int midY = MaxY / 2;

        var positionsInQuadrant = Positions.Where(pv => pv.Key.X > midX && pv.Key.X < MaxX && pv.Key.Y > midY && pv.Key.Y < MaxY).ToList();
        int count = positionsInQuadrant.Select(kv => kv.Value).Sum();
        return count;
    }
    public int SafetyFactor()
    {
        int total = Quadrant1Count();
        total *= Quadrant2Count();
        total *= Quadrant3Count();
        total *= Quadrant4Count();
        return total;
    }

    public void PlotRobotPositions(int secs)
    {
        int[,] screen = new int[MaxX, MaxY];
        foreach (var pos in Positions)
        {
            screen[pos.Key.X, pos.Key.Y] = pos.Value;
        }
        StringBuilder sb = new StringBuilder();
        for (int y = 0; y < MaxY; y++)
        {
            for (int x = 0; x < MaxX; x++)
            {
                if (0 == screen[x, y])

                    sb.Append(" ");
                else
                    sb.Append("#");
            }
            sb.AppendLine();
        }
        sb.AppendLine($"--- Seconds {secs}");
        sb.AppendLine("-----");
        File.AppendAllText(@"C:\temp\Day14Tree4.txt", sb.ToString());
    }

    public void PlotRobotPositionWindow(int secs)
    {
        int[,] screen = new int[MaxX, MaxY];
        foreach (var pos in Positions)
        {
            screen[pos.Key.X, pos.Key.Y] = pos.Value;
        }
        StringBuilder sb = new StringBuilder();
        for (int y = 0; y < MaxY; y++)
        {
            for (int x = 0; x < MaxX; x++)
            {
                if (0 == screen[x, y])

                    sb.Append(" ");
                else
                    sb.Append("#");
            }
            sb.AppendLine();
        }
        sb.AppendLine($"--- Seconds {secs}");
        sb.AppendLine("-----");
        Debug.WriteLine(sb.ToString());
    }
}
