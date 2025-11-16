using System;

namespace AdventCodeLib
{
    public class Generator
    {
        public long Factor { get; set; }
        public long Start { get; set; }
        public long Check { get; set; }
        public long Present { get; set; }

        public Generator(long start, long factor)
        {
            Factor = factor;
            Start = start;
            Present = Start;
        }

        public long Generate()
        {
            long next = Present * Factor;
            Present = next % 2147483647;
            return Present;
        }

        public long Generate2()
        {
            long next = Present;

            do
            {
                next = (next * Factor) % 2147483647;
            } while (next % Check != 0);
            Present = next;
            return Present;
        }

        public static bool Match(Generator a, Generator b)
        {
            long lastFactor = (long)Math.Pow(2,16);
            long aval = a.Present % lastFactor; 
            long bval = b.Present % lastFactor;

            return aval == bval;
        }
    }

}
