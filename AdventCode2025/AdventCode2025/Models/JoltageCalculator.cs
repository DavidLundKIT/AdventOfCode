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
}
