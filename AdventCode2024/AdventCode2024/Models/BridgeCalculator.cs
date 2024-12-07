namespace AdventCode2024.Models;

public class BridgeCalculator
{
    public long Expected { get; set; }
    public List<long> Factors { get; set; }
    public bool ThirdOperand { get; set; }

    public BridgeCalculator(string line)
    {
        var equation = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
        Expected = long.Parse(equation[0]);
        Factors = equation[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => long.Parse(s)).ToList();
    }

    public bool Calculate(bool ops3 = false)
    {
        ThirdOperand = ops3;
        bool result = Calculate(Factors[0], 0);
        return result;
    }

    public bool Calculate(long previous, int index)
    {
        if (index == Factors.Count - 1)
        {
            return Expected == previous;
        }
        // not done
        long total = previous * Factors[index + 1];
        bool result = Calculate(total, index + 1);
        if (!result)
        {
            total = previous + Factors[index + 1];
            result = Calculate(total, index + 1);
        }
        if (!result && ThirdOperand)
        {
            total = long.Parse($"{previous}{Factors[index + 1]}");
            result = Calculate(total, index + 1);
        }
        return result;
    }

}
