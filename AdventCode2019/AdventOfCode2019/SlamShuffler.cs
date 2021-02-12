using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AdventOfCode2019
{
    public class SlamShuffler
    {
        private const string kDealCut = "cut";
        private const string kDealNewStack = "deal into new stack";
        private const string kDealWithIncrement = "deal with increment";

        public int DeckSize { get; set; }
        public SlamShuffler(int deckSize)
        {
            InitDeckOfCards(deckSize);
        }

        public List<int> DeckOfCards { get; set; }

        public void InitDeckOfCards(int deckSize)
        {
            DeckSize = deckSize;
            DeckOfCards = new List<int>();
            int[] cards = new int[deckSize];
            for (int i = 0; i < deckSize; i++)
            {
                cards[i] = i;
            }
            DeckOfCards.AddRange(cards);
        }

        public void ShuffleCommand(string cmd)
        {
            if (string.IsNullOrWhiteSpace(cmd))
            {
                return;
            }
            if (cmd.Contains(kDealNewStack))
            {
                DealIntoNewStack();
                return;
            }
            if (cmd.Contains(kDealCut))
            {
                int cutValue = int.Parse(cmd.Substring(kDealCut.Length));
                Cut(cutValue);
                return;
            }
            if (cmd.Contains(kDealWithIncrement))
            {
                int incValue = int.Parse(cmd.Substring(kDealWithIncrement.Length));
                DealWithIncrement(incValue);
                return;
            }
            throw new ArgumentOutOfRangeException($"Unknown cmd: {cmd}");
        }

        public void DealIntoNewStack()
        {
            DeckOfCards.Reverse();
        }

        public void Cut(int cutValue)
        {
            if (cutValue > 0)
            {
                var cutCards = DeckOfCards.GetRange(0, cutValue);
                DeckOfCards.RemoveRange(0, cutValue);
                DeckOfCards.AddRange(cutCards);
            }
            else
            {
                var cutCards = DeckOfCards.GetRange(DeckOfCards.Count + cutValue, Math.Abs(cutValue));
                DeckOfCards.RemoveRange(DeckOfCards.Count + cutValue, Math.Abs(cutValue));
                DeckOfCards.InsertRange(0, cutCards);
            }
        }

        public void DealWithIncrement(int inc)
        {
            int[] cards = new int[DeckSize];
            int idx = 0;
            for (int i = 0; i < DeckOfCards.Count; i++)
            {
                cards[idx] = DeckOfCards[i];
                idx += inc;
                if (idx >= DeckSize)
                {
                    idx = idx % DeckSize;
                }
            }
            DeckOfCards = new List<int>(cards);
        }

        public void DumpDeckOfCards(string path)
        {
            using (var sw = File.CreateText(path))
            {
                sw.WriteLine("i;Card;");
                for (int i = 0; i < DeckSize; i++)
                {
                    sw.WriteLine($"{i};{DeckOfCards[i]};");
                }
                sw.Flush();
                sw.Close();
            }

        }
    }
}
