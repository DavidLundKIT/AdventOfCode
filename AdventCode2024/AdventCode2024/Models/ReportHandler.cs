using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
