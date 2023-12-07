using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2023.Models
{
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
            for (int rank  = 0; rank < Hands.Count; ++rank)
            {
                totalWinnings += (rank + 1) * Hands[rank].Bid;
            }
            return totalWinnings;
        }
    }

    public class CamelCardHand: IComparable<CamelCardHand>
    {
        public string Hand { get; set; }
        public long Bid { get; set; }

        public CamelCardHand(string line)
        {
            var temp = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Hand = temp[0];
            Bid = long.Parse(temp[1]);
        }

        public int CompareTo(CamelCardHand? other)
        {
            throw new NotImplementedException();
        }
    }

}