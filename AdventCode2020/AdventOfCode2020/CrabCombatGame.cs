using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class CrabCombatGame
    {
        public Queue<long> Player1 { get; set; }
        public Queue<long> Player2 { get; set; }

        public CrabCombatGame()
        {
            Player1 = new Queue<long>();
            Player2 = new Queue<long>();
        }

        public void Deal(string[] hand1, string[] hand2)
        {
            foreach (var card in hand1)
            {
                Player1.Enqueue(long.Parse(card));
            }

            foreach (var card in hand2)
            {
                Player2.Enqueue(long.Parse(card));
            }
        }

        public long PlayMatch()
        {
            while (Player1.Count > 0 && Player2.Count > 0)
            {
                long card1 = Player1.Dequeue();
                long card2 = Player2.Dequeue();
                if (card1 > card2)
                {
                    Player1.Enqueue(card1);
                    Player1.Enqueue(card2);
                }
                else
                {
                    Player2.Enqueue(card2);
                    Player2.Enqueue(card1);
                }
            }

            List<long> cards = new List<long>();
            if (Player1.Count > 0)
            {
                cards.AddRange(Player1.ToArray());
            }
            else
            {
                cards.AddRange(Player2.ToArray());
            }
            long score = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                score += cards[i] * (cards.Count - i);
            }
            return score;
        }
    }
}
