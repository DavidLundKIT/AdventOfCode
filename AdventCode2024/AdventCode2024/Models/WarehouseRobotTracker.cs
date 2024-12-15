using System.Diagnostics;
using System.Text;

namespace AdventCode2024.Models;

public class WarehouseRobotTracker
{
    public Dictionary<Point, char> Warehouse { get; set; }
    public int MaxX { get; set; }
    public int MaxY { get; set; }
    public List<char> Commands { get; set; }

    public WarehouseRobotTracker(string[] lines)
    {
        Warehouse = new Dictionary<Point, char>();
        Commands = new List<char>();
        MaxX = lines[0].Length;

        bool map = true;
        for (int y = 0; y < lines.Length; y++)
        {
            if (string.IsNullOrWhiteSpace(lines[y]))
            {
                map = false;
                continue;
            }
            if (map)
            {
                MaxY = y + 1;
                var chArr = lines[y].ToCharArray();
                for (int x = 0; x < chArr.Length; x++)
                {
                    Warehouse.Add(new Point(x, y), chArr[x]);
                }
            }
            else
            {
                // commands
                Commands.AddRange(lines[y].ToCharArray());
            }
        }
    }

    public void DoCommands()
    {
        Point robot = Warehouse.Where(kv => kv.Value == '@').Select(kv => kv.Key).Single();

        foreach (var cmd in Commands)
        {
            robot = MoveRobot(robot, cmd);
            //Debug.WriteLine($"--- cmd: {cmd}");
            //ShowWarehouse();
        }
    }

    public Point MoveRobot(Point robot, char cmd)
    {
        Point nextPt = PointToMoveTo(robot, cmd);
        if (MayMoveToPoint(nextPt, cmd))
        {
            Warehouse[nextPt] = Warehouse[robot];
            Warehouse[robot] = '.';
            return nextPt;
        }

        return robot;
    }

    private bool MayMoveToPoint(Point pt, char cmd)
    {
        char val = Warehouse[pt];
        if (val == '.')
            return true;
        if (val == '#')
            return false;

        if (val != 'O')
            throw new ArgumentOutOfRangeException(nameof(val));

        Point pushPt = PointToMoveTo(pt, cmd);
        return MayPushToPoint(pt, pushPt, cmd);
    }

    private bool MayPushToPoint(Point prevPt, Point pt, char cmd)
    {
        char val = Warehouse[pt];
        char prevVal = Warehouse[prevPt];
        if (val == '.')
        {
            Warehouse[pt] = prevVal;
            //Warehouse[prevPt] = '.';
            return true;
        }
        if (val == '#')
            return false;

        if (val != 'O')
            throw new ArgumentOutOfRangeException(nameof(val));

        Point pushPt = PointToMoveTo(pt, cmd);
        return MayPushToPoint(pt, pushPt, cmd);
    }

    public Point PointToMoveTo(Point pt, char cmd)
    {
        Point newPt;
        switch (cmd)
        {
            case '^':
                newPt = new Point(pt.X, pt.Y - 1);
                break;
            case '>':
                newPt = new Point(pt.X + 1, pt.Y);
                break;
            case '<':
                newPt = new Point(pt.X - 1, pt.Y);
                break;
            case 'v':
                newPt = new Point(pt.X, pt.Y + 1);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(cmd));
        }
        return newPt;
    }

    public long GpsSum()
    {
        long sum = Warehouse.Where(kv => kv.Value == 'O').Select(kv => Convert.ToInt64(100 * kv.Key.Y + kv.Key.X)).Sum();
        return sum;
    }

    public void ShowWarehouse()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("-----");
        for (int y = 0; y < MaxY; y++)
        {
            for (int x = 0; x < MaxX; x++)
            {
                sb.Append(Warehouse[new Point(x, y)]);
            }
            sb.AppendLine();
        }
        sb.AppendLine("-----");
        Debug.WriteLine(sb.ToString());
    }

}
