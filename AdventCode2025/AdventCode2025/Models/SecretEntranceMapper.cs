using System;
using System.Collections.Generic;
using System.Text;

namespace AdventCode2025.Models;

public class SecretEntranceMapper
{
    public List<string> Instructions { get; set; }
    
    public SecretEntranceMapper(string[] lines)
	{
        Instructions = new List<string>(lines);
    }

    public int TimesMovedToZero(int startPos)
    {
        int zeroed = 0;

        foreach (var instruction in Instructions)
        {
            var operation = instruction[0];

            bool isLeft = operation == 'L';
            var value = int.Parse(instruction[1..]);
            if (isLeft)
            {
                startPos -= value;
            }
            else
            {
                startPos += value;
            }
            // wrap values
            startPos = startPos % 100;
            if (startPos < 0)
            {
                startPos += 100;
            }

            if (startPos == 0)
            {
                zeroed++;
            }
        }
        return zeroed;
    }
}
