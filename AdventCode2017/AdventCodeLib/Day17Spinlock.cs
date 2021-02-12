using System.Collections.Generic;

namespace AdventCodeLib
{
    public class Day17Spinlock
    {
        public Day17Spinlock()
        {
            Buffer = new List<int>();
            Buffer.Add(0);
            Position = 0;
        }

        public int BufPos1 { get; set; }
        public int Position { get; set; }
        public int Factor { get; set; }
        public List<int> Buffer { get; set; }

        public void Spin(int value)
        {
            int length = Buffer.Count;
            if (length == 1)
            {
                Buffer.Add(value);
                Position = 1;
            }
            else
            {
                Position = ((Position + Factor) % length)+ 1;
                if (Position == length)
                {
                    Buffer.Add(value);
                }
                else
                {
                    Buffer.Insert(Position, value);
                }
            }
        }

        /// <summary>
        /// It seems 0 never moves from pos 0, 
        /// so the desired value will be in pos 1.
        /// </summary>
        /// <param name="value"></param>
        public void Spin2(int value)
        {
            int length = value;
            if (length == 1)
            {
                Position = 1;
                BufPos1 = value;
            }
            else
            {
                Position = ((Position + Factor) % length) + 1;
                if (Position == 1)
                {
                    BufPos1 = value;
                }
            }
        }
    }
}
