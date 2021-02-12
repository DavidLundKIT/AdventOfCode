using System.Collections.Generic;
using System.Linq;

namespace days.day09
{
    public class MarblesGame
    {
        public MarblesGame(long players, int lastMarble)
        {
            NumberOfPlayers = players;
            Players = new long[NumberOfPlayers];
            Marbles = new List<long>(lastMarble);
            Marbles.Add(0);
            Current = 0;
        }

        // 411 players; last marble is worth 71170 points
        public long NumberOfPlayers { get; set; }
        public int Current { get; set; }
        public long[] Players { get; set; }
        public List<long> Marbles { get; set; }

        public void AddMarble(long player, long marble)
        {
            int pos = Current;
            if (Marbles.Count == 1)
            {
                Marbles.Add(marble);
                Current = 1;
                return;
            }
            if (marble % 23 == 0)
            {
                // scoring opportunity
                Players[player - 1] += marble;
                pos -= 7;
                if (pos < 0)
                {
                    pos = Marbles.Count + pos;
                }
                Players[player - 1] += Marbles[pos];
                Marbles.RemoveAt(pos);
                Current = pos;
                if (Current == Marbles.Count)
                {
                    Current = 0;
                }
                return;
            }
            // add the marble
            pos += 2;
            if (pos == Marbles.Count)
            {
                Marbles.Add(marble);
            }
            else
            {
                if (pos > Marbles.Count)
                {
                    pos -= Marbles.Count;
                }
                Marbles.Insert(pos, marble);
            }
            Current = pos;
        }

        public long HighScore()
        {
            return Players.Max();
        }
    }
}
