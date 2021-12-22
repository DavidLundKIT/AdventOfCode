using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCode2021
{
    public class DiracDice
    {
        public long Player1 { get; set; }
        public long Player2 { get; set; }
        public long Score1 { get; set; }
        public long Score2 { get; set; }
        public long Universes1 { get; set; }
        public long Universes2 { get; set; }

        public DiracDice(int pos1, int pos2)
        {
            Player1 = pos1;
            Player2 = pos2;
            Score1 = 0;
            Score2 = 0;
        }

        public long GameDetermined()
        {
            int dice = 1;
            int rolls = 3;
            do
            {
                Player1 = (Player1 + 3 * dice + 3) % 10;
                Score1 += Player1 == 0 ? 10 : Player1;
                if (Score1 >= 1000)
                {
                    // Player2 loses
                    return Score2 * rolls;
                }

                dice += 3;
                rolls += 3;
                Player2 = (Player2 + 3 * dice + 3) % 10;
                Score2 += Player2 == 0 ? 10 : Player2;
                if (Score2 >= 1000)
                {
                    return Score1 * rolls;
                }

                dice += 3;
                rolls += 3;
            } while (dice > 0);

            return -1;
        }

        public long GameQuantum()
        {
            long dice = 1;
            long rolls = 3;
            do
            {
                Player1 = (Player1 + 3 * dice + 3) % 10;
                Score1 += Player1 == 0 ? 10 : Player1;
                if (Score1 >= 1000)
                {
                    // Player2 loses
                    return Score2 * rolls;
                }

                dice += 3;
                rolls += 3;
                Player2 = (Player2 + 3 * dice + 3) % 10;
                Score2 += Player2 == 0 ? 10 : Player2;
                if (Score2 >= 1000)
                {
                    return Score1 * rolls;
                }

                dice += 3;
                rolls += 3;
            } while (dice > 0);

            return -1;
        }
    }
}
