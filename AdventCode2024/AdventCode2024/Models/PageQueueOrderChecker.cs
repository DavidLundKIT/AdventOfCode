
namespace AdventCode2024.Models;

public class PageQueueOrderChecker
{
    public Dictionary<PageRule, int> Rules { get; set; }
    public List<List<int>> Manuals { get; set; }
    public PageQueueOrderChecker(string[] lines)
    {
        Rules = new Dictionary<PageRule, int>();
        Manuals = new List<List<int>>();

        foreach (var line in lines)
        {
            ProcessLine(line);
        }
    }

    public void ProcessLine(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return;
        if (line.Contains("|"))
        {
            var pages = line.Split('|');
            Rules.Add(new PageRule(int.Parse(pages[0]), int.Parse(pages[1])), 0);
        }
        else
        {
            var manual = line.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToList();
            Manuals.Add(manual);
        }
    }

    public int CheckPageOrderOfManuals()
    {
        int sum = 0;

        foreach (var manual in Manuals)
        {
            if (IsManualOrderedCorrectly(manual))
            {
                int middle = manual[manual.Count / 2];
                sum += middle;
            }
        }
        return sum;
    }

    public bool IsManualOrderedCorrectly(List<int> manual)
    {
        for (int i = 0; i < manual.Count - 1; i++)
        {
            for (int j = i + 1; j < manual.Count; j++)
            {
                var pageRule = new PageRule(manual[i], manual[j]);
                if (!Rules.ContainsKey(pageRule))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public int ReOrderPagesOfBadManuals()
    {
        int sum = 0;
        List<List<int>> BadManuals = new List<List<int>>();
        List<List<int>> NewManuals = new List<List<int>>();

        foreach (var manual in Manuals)
        {
            if (!IsManualOrderedCorrectly(manual))
            {
                BadManuals.Add(manual);
            }
        }

        foreach (var badManual in BadManuals)
        {
            var manual = new List<int>(badManual);

            while (!IsManualOrderedCorrectly(manual))
            {
                manual = ReOrderBadManual(manual);
            }
            NewManuals.Add(manual);
            int middle = manual[manual.Count / 2];
            sum += middle;
        }

        return sum;
    }

    public List<int> ReOrderBadManual(List<int> badManual)
    {
        List<int> manual = new List<int>(badManual);

        for (int i = 0; i < manual.Count - 1; i++)
        {
            for (int j = i + 1; j < manual.Count; j++)
            {
                var pageRule = new PageRule(manual[i], manual[j]);
                if (!Rules.ContainsKey(pageRule))
                {
                    // missing rule, swap
                    int swap = manual[i];
                    manual[i] = manual[j];
                    manual[j] = swap;
                    return manual;
                }
            }
        }

        return manual;
    }
}

public record PageRule(int a, int b);