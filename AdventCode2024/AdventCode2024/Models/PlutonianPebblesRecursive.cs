using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2024.Models;

public class PlutonianPebblesRecursive
{
    public List<long> StartValues { get; set; }

    public PlutonianPebblesRecursive(string line)
    {
        StartValues = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => long.Parse(s)).ToList();
    }

    public long DoBlinks(int times)
    {
        long total = 0;

        foreach (var sv in StartValues)
        {
            long result = Blink(sv, times);
            total += result;
        }

        return total;
    }

    public long Blink(long currentValue, int times)
    {
        long result = 0;

        if (times == 0)
        {
            return 1;
        }

        string sval = currentValue.ToString();
        if (currentValue == 0)
        {
            currentValue = 1;
            result = Blink(currentValue, times-1);
        }
        else if (sval.Length % 2 == 0)
        {
            string sval1 = sval.Substring(0, sval.Length / 2);
            string sval2 = sval.Substring(sval.Length / 2).TrimStart('0');
            sval2 = string.IsNullOrWhiteSpace(sval2) ? "0" : sval2;
            result = Blink(long.Parse(sval2), times - 1);
            result += Blink(long.Parse(sval1), times - 1);
        }
        else
        {
            currentValue = currentValue * 2024;
            result = Blink(currentValue, times - 1);
        }
        return result;
    }
}
