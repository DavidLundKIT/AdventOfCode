using System;

namespace AdventOfCode2019
{
    public class FuelCounterUpper
    {
        public static long FuelCalculator(long mass)
        {
            long fuel = (mass / 3) - 2;
            return fuel > 0? fuel: 0;
        }

        public static long FuelFuelCalculator(long mass)
        {
            long totalFuel = 0;
            long fuel = mass;
            do
            {
                fuel = FuelCalculator(fuel);
                totalFuel += fuel;
            } while (fuel > 0);
            return totalFuel;
        }
    }
}
