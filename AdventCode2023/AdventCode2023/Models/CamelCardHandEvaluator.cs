using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2023.Models
{
    public enum CamelCardHandType
    {
        HighCard = 1,
        OnePair = 2,
        TwoPair = 3,
        ThreeOfAKind = 4,
        FullHouse = 5,
        FourOfAKind = 6,
        FiveOfAKind = 7
    }

    public class CamelCardHandEvaluator
    {
        public List<CamelCardHand> Hands { get; set; }

        public CamelCardHandEvaluator(string[] lines)
        {
            Hands = new List<CamelCardHand>();
            foreach (string line in lines)
            {
                Hands.Add(new CamelCardHand(line));
            }
        }

        public long TotalWinnings()
        {
            long totalWinnings = 0;

            Hands.Sort();
            for (int rank = 0; rank < Hands.Count; ++rank)
            {
                totalWinnings += (rank + 1) * Hands[rank].Bid;
            }
            return totalWinnings;
        }
    }

    public class CamelCardHand : IComparable<CamelCardHand>
    {
        public string Hand { get; set; }
        public long Bid { get; set; }
        public CamelCardHandType HandType { get; set; }
        public Dictionary<char, int> Cards { get; set; }

        public CamelCardHand(string line)
        {
            var temp = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Hand = temp[0];
            Bid = long.Parse(temp[1]);
            Cards = ParseHand();
            HandType = EvaluateHand();
        }

        public Dictionary<char, int> ParseHand()
        {
            var cards = new Dictionary<char, int>();

            foreach (char ch in Hand)
            {
                if (cards.ContainsKey(ch))
                {
                    cards[ch] += 1;
                }
                else
                {
                    cards.Add(ch, 1);
                }
            }
            return cards;
        }

        public CamelCardHandType EvaluateHand()
        {
            int cc2;
            switch (Cards.Count)
            {
                case 1:
                    return CamelCardHandType.FiveOfAKind;
                case 2:
                    cc2 = Cards.Values.First();
                    if (cc2 == 1 || cc2 == 4)
                        return CamelCardHandType.FourOfAKind;
                    else 
                        //(cc2== 2 || cc2==3)
                        return CamelCardHandType.FullHouse;
                    throw new Exception("On card count of 2");
                case 3:
                    cc2 = Cards.Values.Where(c => c == 2).ToList().Count;
                    if (cc2 == 2)
                        return CamelCardHandType.TwoPair;
                    return CamelCardHandType.ThreeOfAKind;
                case 4:
                    return CamelCardHandType.OnePair;
                case 5:
                    return CamelCardHandType.HighCard;
                default:
                    break;
            }
            throw new Exception("Hand type not matched");
        }

        /// <summary>
        ///  A, K, Q, J, T, 9, 8, 7, 6, 5, 4, 3, or 2
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public int CardValue(char ch)
        {
            switch(ch)
            {
                case 'A': 
                    return 14;
                case 'K':
                    return 13;
                case 'Q':
                    return 12;
                case 'J':
                    return 11;
                case 'T':
                    return 10;
                default: 
                    return (int) ch - (int)'0';
            }
        }

        public int CompareTo(CamelCardHand? other)
        {
            if (other == null) 
                return 1;

            int cmp = ((int)HandType).CompareTo((int)other.HandType);
            if (cmp != 0) 
                return cmp;
            // high card compare
            for (int i = 0; i < Hand.Length; ++ i)
            {
                cmp = CardValue(Hand[i]).CompareTo(CardValue(other.Hand[i]));
                if (cmp != 0)
                    return cmp;
            }
            return 0;
        }
    }

}