namespace AdventCode2025.Models;

public class JoltageCalculator
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
                    joltage = testJolt;
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
        var batteryJoltage = battery.ToCharArray().Select(c => int.Parse(c.ToString())).ToList();
        int startIndex = 0;
        int batteryLen = 12;
        // find highest digit with at least 11 other after it
        for (int i = 0; i < batteryLen; i++)
        {
            int theIndex = FindNextHighestChar(batteryJoltage, startIndex, batteryLen - (i + 1));
            joltage = joltage * 10 + batteryJoltage[theIndex];
            startIndex = theIndex + 1;
        }
        return joltage;
    }

    public int FindNextHighestChar(List<int> batteryJoltage, int startIndex, int minLenLeft)
    {
        int highest = 0;
        int highestIndex = -1;
        for (int idx = startIndex; idx < batteryJoltage.Count - minLenLeft; idx++)
        {
            if (highest < batteryJoltage[idx])
            {
                highest = batteryJoltage[idx];
                highestIndex = idx;
            }
        }
        return highestIndex;
    }
}
