using System.Text.RegularExpressions;

namespace AdventCode2023.Models
{
    public class ScratchCardEvaluator
    {
        public string[] Lines { get; set; }
        public List<ScratchCard> Cards { get; set; }
        public ScratchCardEvaluator(string[] lines)
        {
            Lines = lines;
            Cards = new List<ScratchCard>();
            foreach (var line in lines)
            {
                Cards.Add(new ScratchCard(line));
            }
        }

        public int CalculateTotalCards()
        {
            int totalCards = 0;
            for (int iCard = 0; iCard < Cards.Count; iCard++)
            {
                var card = Cards[iCard];
                int wonCards = card.MatchingNumbers();
                if (wonCards > 0)
                {
                    for (int jCard = iCard + 1; jCard <= iCard + wonCards; jCard++)
                    {
                        Cards[jCard].Copies += card.Copies;
                    }
                }
                totalCards += card.Copies;
            }
            return totalCards;
        }
    }

    public class ScratchCard
    {
        public int Card { get; set; }
        public HashSet<int> WinningNumbers { get; set; }
        public HashSet<int> CardNumbers { get; set; }
        public int Copies { get; set; }

        public ScratchCard(string line)
        {
            var temp = line.Split(new char[] { ':', '|' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Card = int.Parse(Regex.Match(temp[0], @"\d+").Value);
            WinningNumbers = ParseNumbers(temp[1]);
            CardNumbers = ParseNumbers(temp[2]);
            Copies = 1;
        }

        public HashSet<int> ParseNumbers(string numpart)
        {
            var numbers = new HashSet<int>(numpart.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(n => int.Parse(n)));
            return numbers;
        }

        public int MatchingNumbers()
        {
            var hs = WinningNumbers.Intersect(CardNumbers);
            return hs.Count();
        }
        public int PointValue()
        {
            var count = MatchingNumbers();
            int points = 0;
            if (count > 0)
            {
                points = Convert.ToInt32(Math.Pow(2, count - 1));
            }
            return points;
        }
    }
}
