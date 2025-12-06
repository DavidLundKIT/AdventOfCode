namespace AdventCode2025.Models;

public class CephalapodCalculator
{
    public List<List<long>> Factors { get; set; }
    public List<string> Operands { get; set; }

    public CephalapodCalculator(string[] lines)
    {
        Factors = new List<List<long>>();
        Operands = new List<string>();

        foreach (var line in lines)
        {
            var tempArr = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (tempArr[0] == "*" || tempArr[0] == "+")
                Operands = tempArr.ToList();
            else
            {
                var factorList = tempArr.Select(f => long.Parse(f)).ToList();
                Factors.Add(factorList);
            }
        }
    }

    public long CalculateProblem(int index)
    {
        long result = 0;
        if (Operands[index] == "*")
        {
            result = 1;
            foreach (var factorList in Factors)
            {
                result *= factorList[index];
            }
        }
        else if (Operands[index] == "+")
        {
            result = 0;
            foreach (var factorList in Factors)
            {
                result += factorList[index];
            }
        }
        return result;
    }

    public long CalculateSumOfAllProblems()
    {
        long totalSum = 0;
        for (int i = 0; i < Operands.Count; i++)
        {
            totalSum += CalculateProblem(i);
        }
        return totalSum;
    }
}
