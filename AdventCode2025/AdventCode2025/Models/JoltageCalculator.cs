using System;
using System.Collections.Generic;
using System.Text;

namespace AdventCode2025.Models;

public  class JoltageCalculator
{
    public JoltageCalculator()
    {
        
    }

    public int CalculateJoltage(string battery)
    {
        int joltage = 0;

        var batteryJoltage = battery.ToCharArray();

        for (int i = 0; i < batteryJoltage.Length - 1; i++)
        {
            int iJolt = int.Parse(batteryJoltage[i].ToString()) * 10;
            for (int j = i + 1; j < batteryJoltage.Length; j++)
            {
                int jJolt = int.Parse(batteryJoltage[j].ToString());

                int testJolt = jJolt + iJolt;
                if (testJolt > joltage)
                {
                    joltage =testJolt;
                }
            }
        }
        return joltage;
    }

    /// <summary>
    /// Remember the order of the 12 must be preserved
    /// </summary>
    /// <param name="battery"></param>
    /// <returns></returns>
    public long CalculateTop12Joltage(string battery)
    {
        long joltage = 0;
        // TODO David must make this work
        var batteryJoltage = battery.ToCharArray();
        var digitChars = (new String(' ', batteryJoltage.Length)).ToCharArray();

        // find highest digit with at least 11 other after it
        int firstHighest = 0;
        for (int i = 0; i < batteryJoltage.Length - 1; i++)
        {
            int iJolt = int.Parse(batteryJoltage[i].ToString()) * 10;
            for (int j = i + 1; j < batteryJoltage.Length; j++)
            {
                int jJolt = int.Parse(batteryJoltage[j].ToString());

                int testJolt = jJolt + iJolt;
                if (testJolt > joltage)
                {
                    joltage = testJolt;
                }
            }
        }
        return joltage;
    }
}
