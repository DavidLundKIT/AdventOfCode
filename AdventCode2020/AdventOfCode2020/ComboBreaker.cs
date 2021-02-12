using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public class ComboBreaker
    {
        public long CardKey { get; set; }
        public long DoorKey { get; set; }
        public long EncryptionKey { get; set; }
        
        public ComboBreaker(long cardKey, long doorKey)
        {
            CardKey = cardKey;
            DoorKey = doorKey;
        }


        public long GetEncryptionKey()
        {
            long loopSize = ResolveLoopSize(CardKey);
            long encryptionKey = 1;
            for (long i = 0; i < loopSize; i++)
            {
                encryptionKey *= DoorKey;
                encryptionKey %= 20201227L;
            }
            return encryptionKey;
        }

        public long ResolveLoopSize(long cardKey)
        {
            long resolved = 1;
            long count = 0;
            while(resolved != cardKey)
            {
                resolved *= 7;
                resolved %= 20201227L;
                count++;
            }
            return count;
        }
    }
}
