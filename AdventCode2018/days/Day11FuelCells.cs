using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace days.day10
{
    public class FuelCellCalculator
    {
        public int Power(int x, int y, int gridSerialNumber)
        {
            int rackId = x + 10;
            int powerLevel = rackId * y;
            powerLevel += gridSerialNumber;
            powerLevel *=rackId;
            // get the hundreds digit
            int hundredsdigit = (powerLevel/100)%10;
            return hundredsdigit - 5;
        }

        public void ComputeGrid(int[,] grid, int gridSerialNumber)
        {
            for (int i = 1; i <= 300; i++)
            {
                for (int j = 1; j <= 300; j++)           
                {
                    grid[i,j] = Power(i, j, gridSerialNumber);
                }
            }
        }

        public int FindMaxFuelCells3x3(int[,] grid, out int tlX, out int tlY, out int size)
        {
            int maxPower = int.MinValue;
            tlX = 0;
            tlY = 0;
            int power;
            size = 3;

            for (int i = 1; i <= 298; i++)
            {
                for (int j = 1; j <= 298; j++)           
                {
                    power = 0;
                    for (int di = 0; di < size; di++)
                    {
                        for (int dj = 0; dj < size; dj++)
                        {
                            power += grid[i+di, j+dj];
                        }
                    }
                    if (power > maxPower)
                    {
                        maxPower = power;
                        tlX = i;
                        tlY = j;
                    }
                }
            }
            return maxPower;
        }

        public int FindMaxFuelCells(int[,] grid, out int tlX, out int tlY, out int maxSize)
        {
            int maxPower = int.MinValue;
            tlX = 0;
            tlY = 0;
            maxSize = 0;
            int power;

            for (int size = 3; size < 300; size++)
            {
                for (int i = 1; i <= (300 - size + 1); i++)
                {
                    for (int j = 1; j <= (300 - size + 1); j++)           
                    {
                        power = 0;
                        for (int di = 0; di < size; di++)
                        {
                            for (int dj = 0; dj < size; dj++)
                            {
                                power += grid[i+di, j+dj];
                            }
                        }
                        if (power > maxPower)
                        {
                            maxPower = power;
                            tlX = i;
                            tlY = j;
                            maxSize = size;
                        }
                    }
                }
            }
            return maxPower;
        }
    }
}
