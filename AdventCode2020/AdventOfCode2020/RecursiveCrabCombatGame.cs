using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class RecursiveCrabCombatGame
    {
        public Queue<int> Player1 { get; set; }
        public Queue<int> Player2 { get; set; }
        public Dictionary<string, int> Hands { get; set; }
        
        public RecursiveCrabCombatGame()
        {
            Player1 = new Queue<int>();
            Player2 = new Queue<int>();
            Hands = new Dictionary<string, int>();
        }

        public void Deal(string[] hand1, string[] hand2)
        {
            foreach (var card in hand1)
            {
                Player1.Enqueue(int.Parse(card));
            }

            foreach (var card in hand2)
            {
                Player2.Enqueue(int.Parse(card));
            }
            var hand0 = HandsKey();
            Hands.Add(hand0, 0);
        }

        public void Deal(IEnumerable<int> hand1, IEnumerable<int> hand2)
        {
            foreach (var card in hand1)
            {
                Player1.Enqueue(card);
            }

            foreach (var card in hand2)
            {
                Player2.Enqueue(card);
            }
            var hand0 = HandsKey();
            Hands.Add(hand0, 0);
        }

        public int PlayMatch()
        {
            bool start = true;
            while (Player1.Count > 0 && Player2.Count > 0)
            {
                if (start)
                {
                    start = false;
                }
                else
                {
                    // after one round check if the hands are the same
                    if (HandsMatch())
                    {
                        return 3;
                    }
                }

                int card1 = Player1.Dequeue();
                int  card2 = Player2.Dequeue();
                if (card1 <= Player1.Count && card2 <= Player2.Count)
                {
                    var rccg = new RecursiveCrabCombatGame();
                    rccg.Deal(Player1.ToArray().Take(card1), Player2.ToArray().Take(card2));
                    var winner = rccg.PlayMatch();
                    if (winner == 1)
                    {
                        Player1.Enqueue(card1);
                        Player1.Enqueue(card2);
                    }
                    else if (winner == 2)
                    {
                        Player2.Enqueue(card2);
                        Player2.Enqueue(card1);
                    }
                    else if (winner == 3)
                    {
                        Player1.Enqueue(card1);
                        Player1.Enqueue(card2);
                    }
                }
                else
                {
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
            }

            // who has the full hand
            return (Player1.Count > 0) ? 1 : 2;
        }

        public long ScoreForMatch(int winner)
        { 
            List<int> cards = new List<int>();
            if (winner == 2)
            {
                cards.AddRange(Player2.ToArray());
            }
            else
            {
                // 1 or 3
                cards.AddRange(Player1.ToArray());
            }
            long score = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                score += cards[i] * (cards.Count - i);
            }
            return score;
        }

        public string HandsKey()
        {
            var sp1 = string.Join("_", Player1.ToArray().Select(i => $"{i}").ToArray());
            var sp2 = string.Join("_", Player2.ToArray().Select(i => $"{i}").ToArray());
            return $"P1{sp1} P2{sp2}";
        }

        public bool HandsMatch()
        {
            var handsNow = HandsKey();
            if (Hands.ContainsKey(handsNow))
            {
                // matched a hand!
                return true;
            }
            Hands.Add(handsNow, 1);
            return false;
        }
    }
}
