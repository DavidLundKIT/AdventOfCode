using System.Diagnostics;
using System.Text;

namespace AdventCode2024.Models;

public class WarehouseRobotTracker
{
    public Dictionary<Point, char> Warehouse { get; set; }
    public int MaxX { get; set; }
    public int MaxY { get; set; }
    public List<char> Commands { get; set; }

    public WarehouseRobotTracker(string[] lines, bool isWide = false)
    {
        Warehouse = new Dictionary<Point, char>();
        Commands = new List<char>();
        MaxX = isWide ? lines[0].Length * 2 : lines[0].Length;

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
                    if (isWide)
                    {
                        int dx = x * 2;
                        if (chArr[x] == '@')
                        {
                            Warehouse.Add(new Point(dx, y), chArr[x]);
                            Warehouse.Add(new Point(dx + 1, y), '.');
                        }
                        else if (chArr[x] == 'O')
                        {
                            Warehouse.Add(new Point(dx, y), '[');
                            Warehouse.Add(new Point(dx + 1, y), ']');
                        }
                        else
                        {
                            Warehouse.Add(new Point(dx, y), chArr[x]);
                            Warehouse.Add(new Point(dx + 1, y), chArr[x]);
                        }
                    }
                    else
                    {
                        Warehouse.Add(new Point(x, y), chArr[x]);
                    }
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
            PushToPoint(robot, nextPt, cmd);
            return nextPt;
        }

        return robot;
    }

    private bool MayMoveToPoint(Point pt, char cmd)
    {
        Point? pushPt;
        Point? pt2;

        char val = Warehouse[pt];
        if (val == '.')
            return true;
        if (val == '#')
            return false;

        if (val == 'O')
        {
            pushPt = PointToMoveTo(pt, cmd);
            return MayMoveToPoint(pushPt, cmd);
        }
        if (val == '[')
        {
            pushPt = PointToMoveTo(pt, cmd);
            if (cmd == '>' || cmd == '<')
            {
                return MayMoveToPoint(pushPt, cmd);
            }
            if (!MayMoveToPoint(pushPt, cmd))
                return false;
            pt2 = new Point(pt.X + 1, pt.Y);
            pushPt = PointToMoveTo(pt2, cmd);
            return MayMoveToPoint(pushPt, cmd);
        }
        if (val == ']')
        {
            pushPt = PointToMoveTo(pt, cmd);
            if (cmd == '>' || cmd == '<')
            {
                return MayMoveToPoint(pushPt, cmd);
            }
            if (!MayMoveToPoint(pushPt, cmd))
                return false;
            pt2 = new Point(pt.X - 1, pt.Y);
            pushPt = PointToMoveTo(pt2, cmd);
            return MayMoveToPoint(pushPt, cmd);
        }
        throw new ArgumentOutOfRangeException(nameof(val));
    }

    private void PushToPoint(Point prevPt, Point pt, char cmd)
    {
        char val = Warehouse[pt];
        char prevVal = Warehouse[prevPt];
        char val2;
        char prevVal2;
        Point pt2;
        if (val == '.')
        {
            Warehouse[pt] = prevVal;
            Warehouse[prevPt] = '.';
            return;
        }
        if (val == '#')
        {
            return;
        }
        if (val == 'O')
        {
            PushToPoint(pt, PointToMoveTo(pt, cmd), cmd);
            val = Warehouse[pt];
            if (val == '.')
            {
                Warehouse[pt] = prevVal;
                Warehouse[prevPt] = '.';
                return;
            }
        }
        if (val == '[')
        {
            if (cmd == '>' || cmd == '<')
            {
                PushToPoint(pt, PointToMoveTo(pt, cmd), cmd);
                val = Warehouse[pt];
                if (val == '.')
                {
                    Warehouse[pt] = prevVal;
                    Warehouse[prevPt] = '.';
                    return;
                }
            }
            PushToPoint(pt, PointToMoveTo(pt, cmd), cmd);
            val = Warehouse[pt];
            pt2 = new Point(pt.X + 1, pt.Y);
            PushToPoint(pt2, PointToMoveTo(pt2, cmd), cmd);
            val2 = Warehouse[pt2];
            if (val == '.' && val2 == '.')
            {
                Warehouse[pt] = prevVal;
                Warehouse[prevPt] = '.';
                return;
            }
            return;
        }
        if (val == ']')
        {
            if (cmd == '>' || cmd == '<')
            {
                PushToPoint(pt, PointToMoveTo(pt, cmd), cmd);
                val = Warehouse[pt];
                if (val == '.')
                {
                    Warehouse[pt] = prevVal;
                    Warehouse[prevPt] = '.';
                    return;
                }
            }
            PushToPoint(pt, PointToMoveTo(pt, cmd), cmd);
            val = Warehouse[pt];
            pt2 = new Point(pt.X - 1, pt.Y);
            PushToPoint(pt2, PointToMoveTo(pt2, cmd), cmd);
            val2 = Warehouse[pt2];
            if (val == '.' && val2 == '.')
            {
                Warehouse[pt] = prevVal;
                Warehouse[prevPt] = '.';
                return;
            }
            return;
        }
        throw new ArgumentOutOfRangeException(nameof(val));
    }

    public Point PointToMoveTo(Point pt, char cmd)
    {
        Point newPt;
        switch (cmd)
        {
            case '>':
                newPt = new Point(pt.X + 1, pt.Y);
                break;
            case '<':
                newPt = new Point(pt.X - 1, pt.Y);
                break;
            case 'v':
                newPt = new Point(pt.X, pt.Y + 1);
                break;
            case '^':
                newPt = new Point(pt.X, pt.Y - 1);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(cmd));
        }
        return newPt;
    }

    public long GpsSum(char boxCH = 'O')
    {
        long sum = Warehouse.Where(kv => kv.Value == boxCH).Select(kv => Convert.ToInt64(100 * kv.Key.Y + kv.Key.X)).Sum();
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
