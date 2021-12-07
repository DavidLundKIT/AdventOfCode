using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCode2021
{
    public class CrabAligner
    {
        public List<int> Crabs { get; set; }
        public int MinCrab { get; set; }
        public int MaxCrab { get; set; }

        public CrabAligner(int[] crabData)
        {
            Crabs = new List<int>(crabData);
            MinCrab = Crabs.Min();
            MaxCrab = Crabs.Max();
        }

        public int FindFuelToAlign()
        {
            int minFuel = int.MaxValue;

            for (int iCrab = MinCrab; iCrab <= MaxCrab; iCrab++)
            {
                int fuel = Crabs.Sum(c => c < iCrab ? iCrab - c : c - iCrab);
                if (fuel < minFuel)
                {
                    minFuel = fuel;
                }
            }

            return minFuel;
        }

        public int FindFuelToAlignMoreFuel()
        {
            int minFuel = int.MaxValue;

            for (int iCrab = MinCrab; iCrab <= MaxCrab; iCrab++)
            {
                int fuel = Crabs.Sum(c => (Math.Abs(c-iCrab) + 1)*Math.Abs( c - iCrab) /2);
                if (fuel < minFuel)
                {
                    minFuel = fuel;
                }
            }

            return minFuel;
        }
    }
}
