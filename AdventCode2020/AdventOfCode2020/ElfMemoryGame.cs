using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class ElfMemoryGame
    {
        public Dictionary<long, long> Game { get; set; }
        public long Turn { get; set; }
        public long LastNumber { get; set; }

        public ElfMemoryGame()
        {
            Game = new Dictionary<long, long>();
            Turn = 0;
            LastNumber = 0;
        }

        public void SeedStartNumbers(long[] startNumbers)
        {
            Game.Clear();
            for (int i = 0; i < startNumbers.Length - 1; i++)
            {
                Game.Add(startNumbers[i], i + 1);
            }
            Turn = startNumbers.Length;
            LastNumber = startNumbers[startNumbers.Length - 1];
        }

        public long RunToTurn(long turnDesired)
        {
            do
            {
                Turn += 1;
                var key = LastNumber;
                if (!Game.ContainsKey(key))
                {
                    // new number
                    Game.Add(key, Turn - 1);
                    LastNumber = 0;
                }
                else
                {
                    LastNumber = (Turn - 1) - Game[key];
                    Game[key] = Turn - 1;
                }
            } while (Turn < turnDesired);
            return LastNumber;
        }
    }
}
