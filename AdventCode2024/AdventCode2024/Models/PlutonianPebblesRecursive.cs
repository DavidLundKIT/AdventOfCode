namespace AdventCode2024.Models;

public record PebbleStep(long inValue, int step);

/// <summary>
/// When the Part 2 using PlutonianPebbleRules swamped my pc,
/// I thought recursion would work; I didn't really need all the stones.
/// Done properly, it should at most be a call stack of 75-76 steps about.
/// Worked fine for Tests and Part 1 but, still took forever.
/// My PC RAM was stable withhalf of all RAM available.
/// BUT: it is still x 75! or more steps.
/// -- Ran all night but didn't stop.
/// Google about recursion optimization and they suggested Memoization,
/// hence I added the PebbleSteps dictionary of results.
/// Miracle it is super fast now. And works
/// 11-12 hours no result to 48ms with correct answer.
/// </summary>
public class PlutonianPebblesRecursive
{
    public List<long> StartValues { get; set; }
    public Dictionary<PebbleStep, long> PebbleSteps { get; set; }

    public PlutonianPebblesRecursive(string line)
    {
        StartValues = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => long.Parse(s)).ToList();
        PebbleSteps = new Dictionary<PebbleStep, long>();
    }

    public long DoBlinks(int times)
    {
        long total = 0;

        PebbleSteps.Clear();
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

        var pebbleStepNow = new PebbleStep(currentValue, times);
        if (PebbleSteps.ContainsKey(pebbleStepNow))
        {
            return PebbleSteps[pebbleStepNow];
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
        if (!PebbleSteps.ContainsKey(pebbleStepNow))
        {
            PebbleSteps.Add(pebbleStepNow, result);
        }
        return result;
    }
}
