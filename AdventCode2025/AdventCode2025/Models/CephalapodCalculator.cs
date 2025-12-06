using System.Text;

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

public class CephalapodCalculatorV2
{
    public List<string> Factors { get; set; }
    public List<string> Operands { get; set; }

    public int Index { get; set; }
    public int NextPos { get; set; }
    public int LineLength { get; set; }

    public CephalapodCalculatorV2(string[] lines)
    {
        Factors = new List<string>();
        Operands = new List<string>();
        Index = 0;
        NextPos = 0;
        LineLength = lines[0].Length;

        foreach (var line in lines)
        {
            var tempArr = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (tempArr[0] == "*" || tempArr[0] == "+")
                Operands = tempArr.ToList();
            else
            {
                Factors.Add(line);
            }
        }
    }

    public long CalculateNextProblem()
    {
        long result = 0;
        var operand = Operands[Index];
        if (operand == "*")
        {
            result = 1;
        }
        else
        {
            result = 0;
        }
        for (int ipos = NextPos; ipos < LineLength; ipos++, NextPos++)
        {
            var factor = new StringBuilder();
            foreach (var factorLine in Factors)
            {
                factor.Append(factorLine[ipos]);
            }
            if (long.TryParse(factor.ToString(), out long factorValue) == false)
            {
                NextPos++;
                break;
            }
            if (operand == "*")
            {
                result *= factorValue;
            }
            else if (operand == "+")
            {
                result += factorValue;
            }
        }
        Index++;
        return result;
    }
}
