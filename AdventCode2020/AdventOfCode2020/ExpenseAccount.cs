using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class ExpenseAccount
    {
        public string PathToDailyData { get; set; }

        public List<int> Expenses { get; set; }
        public int Index1 { get; set; }
        public int Index2 { get; set; }
        public int Index3 { get; set; }

        public ExpenseAccount()
        {
            PathToDailyData = @"C:\Repos\AdventOfCode\AdventCode2020\AdventOfCode2020\DailyXUnitTests\Data";
        }

        // finds first pair
        public int FindPairWithSum(int sum)
        {
            int iEnd = Expenses.Count;
            for (int Index1 = 0; Index1 < iEnd - 1; Index1++)
            {
                for (int Index2 = Index1 + 1; Index2 < iEnd; Index2++)
                {
                    if (Expenses[Index1] + Expenses[Index2] == sum)
                    {
                        return Expenses[Index1] * Expenses[Index2];
                    }
                }
            }
            throw new Exception("Pair not found");
        }

        // finds first triple
        public int FindTripleWithSum(int sum)
        {
            int iEnd = Expenses.Count;
            for (int Index1 = 0; Index1 < iEnd - 2; Index1++)
            {
                for (int Index2 = Index1 + 1; Index2 < iEnd - 1; Index2++)
                {
                    for (int Index3 = Index2 + 1; Index3 < iEnd; Index3++)
                    {
                        if (Expenses[Index1] + Expenses[Index2] + Expenses[Index3] == sum)
                        {
                            return Expenses[Index1] * Expenses[Index2] * Expenses[Index3];
                        }
                    }
                }
            }
            throw new Exception("Pair not found");
        }
    }
}
