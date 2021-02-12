using System;

namespace AdventOfCode2019
{
    /// <summary>
    /// For part 2 no array can be that size, at least not in .NET
    /// so thinking about tracking the index and reversing the shuffle.
    /// Becuase this should lead me back to the original state where
    /// the index and the card are the same.
    /// And of course use longs. And no card deck.
    /// </summary>
    public class SlamShufflerIndex
    {
        private const string kDealCut = "cut";
        private const string kDealNewStack = "deal into new stack";
        private const string kDealWithIncrement = "deal with increment";

        /// <summary>
        /// 
        /// </summary>
        public long DeckSize { get; set; }

        /// <summary>
        /// Kept mainly for 
        /// </summary>
        public long StartingIndex { get; private set; }

        /// <summary>
        /// The index to be followed.
        /// </summary>
        public long TrackedIndex { get; set; }

        public SlamShufflerIndex(long deckSize, long indexToTrack)
        {
            DeckSize = deckSize;
            StartingIndex = indexToTrack;
            TrackedIndex = indexToTrack;
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

        public void ShuffleCommandReverse(string cmd)
        {
            if (string.IsNullOrWhiteSpace(cmd))
            {
                return;
            }
            if (cmd.Contains(kDealNewStack))
            {
                // same either way
                DealIntoNewStack();
                return;
            }
            if (cmd.Contains(kDealCut))
            {
                // inverse the cut by * -1
                int cutValue = int.Parse(cmd.Substring(kDealCut.Length));
                Cut(cutValue * -1);
                return;
            }
            if (cmd.Contains(kDealWithIncrement))
            {
                // inverse inc by * -1, but also need to fix up the method
                int incValue = int.Parse(cmd.Substring(kDealWithIncrement.Length));
                DealWithIncrement(incValue * -1);
                return;
            }
            throw new ArgumentOutOfRangeException($"Unknown cmd: {cmd}");
        }

        public void DealIntoNewStack()
        {
            TrackedIndex = DeckSize - (TrackedIndex + 1);
        }

        public void Cut(long cutValue)
        {
            long cutIndex;
            if (cutValue > 0)
            {
                cutIndex = TrackedIndex - cutValue;
                if (cutIndex < 0)
                {
                    cutIndex = DeckSize + TrackedIndex - cutValue;
                }
            }
            else
            {
                cutIndex = TrackedIndex - cutValue;
                if (cutIndex >= DeckSize)
                {
                    cutIndex = TrackedIndex - (DeckSize + cutValue);
                }
            }
            TrackedIndex = cutIndex;
        }

        public void DealWithIncrement(long inc)
        {
            if (TrackedIndex == 0)
            {
                // remains the same
                return;
            }
            long idx;
            if (inc > 0)
            {
                idx = (TrackedIndex * inc) % DeckSize;
                TrackedIndex = idx;
                return;
            }
            else
            {
                // Reversing, probably a better way but can't think of one now
                long absInc = Math.Abs(inc);
                for (long i = 0; i < absInc; i++)
                {
                    idx = (TrackedIndex + i * DeckSize) % absInc;
                    if (idx == 0)
                    {
                        idx = (TrackedIndex + i * DeckSize) / absInc;
                        TrackedIndex = idx;
                        return;
                    }
                }
            }
            throw new Exception("Back to the drawing board Dave!");
        }

        public void DealWithIncrementOrg(long inc)
        {
            if (TrackedIndex == 0)
            {
                // remains the same
                return;
            }
            long idx;
            if (inc > 0)
            {
                idx = (TrackedIndex * inc) % DeckSize;
                TrackedIndex = idx;
                return;
            }
            else
            {
                // Reversing, probably a better way but can't think of one now
                idx = 0;
                long absInc = Math.Abs(inc);
                for (long i = 1; i < DeckSize; i++)
                {
                    idx += absInc;
                    if (idx >= DeckSize)
                    {
                        idx = idx % DeckSize;
                    }
                    if (idx == TrackedIndex)
                    {
                        TrackedIndex = i;
                        return;
                    }
                }
            }
            throw new Exception("Back to the drawing board Dave!");
        }

        public long modInverse(long a, long n)
        {
            long i = n, v = 0, d = 1;
            while (a > 0)
            {
                long t = i / a, x = a;
                a = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }
    }
}
