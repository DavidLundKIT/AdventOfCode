namespace AdventCode2024.Models;

public class ReportHandler
{
    public ReportHandler()
    {
    }

    public bool IsSafe(string row)
    {
        var list = ParseRow(row);
        var differences = LevelDifferences(list);
        return IsSafe(differences);
    }

    public bool IsSafeWithTolerance(string row)
    {
        var list = ParseRow(row);
        var differences = LevelDifferences(list);
        if (IsSafe(differences))
            return true;

        // try removing one
        for (int i = 0; i < list.Count; i++)
        {
            int[] tempArr = new int[list.Count];
            list.CopyTo(tempArr);
            var tempList = new List<int>(tempArr);
            tempList.RemoveAt(i);
            differences = LevelDifferences(tempList);
            if (IsSafe(differences))
                return true;
        }

        return false;
    }

    public bool IsSafe(List<int> differences)
    {
        bool isIncreasing = false;
        bool isDecreasing = false;

        foreach (var diff in differences)
        {
            if (Math.Abs(diff) > 3)
            {
                return false;
            }
            if (diff == 0)
            {
                return false;
            }
            if (1 <= diff && diff <= 3)
            {
                isDecreasing = true;
            }
            if (-3 <= diff && diff <= -1)
            {
                isIncreasing = true;
            }
        }

        return isIncreasing == !isDecreasing;
    }

    public List<int> ParseRow(string row)
    {
        var vals = row.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var list = vals.Select(s => int.Parse(s)).ToList();
        return list;
    }

    public List<int> LevelDifferences(List<int> inputs)
    {
        var list = new List<int>();
        for (int ii = 0; ii < inputs.Count - 1; ii++)
        {
            list.Add(inputs[ii] - inputs[ii + 1]);
        }
        return list;
    }
}
