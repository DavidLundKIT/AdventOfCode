using AdventOfCode2019;
using System;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day22SlamShuffleUnitTests
    {
        [Fact]
        public void Day22Part1_DealToNewStack()
        {
            SlamShuffler sut = new SlamShuffler(10);

            sut.DealIntoNewStack();

            for (int i = 0; i <= 9; i++)
            {
                Assert.Equal(9 - i, sut.DeckOfCards[i]);
            }
        }

        [Fact]
        public void Day22Part1_Cut3()
        {
            SlamShuffler sut = new SlamShuffler(10);

            sut.Cut(3);

            Assert.Equal(3, sut.DeckOfCards[0]);
            Assert.Equal(4, sut.DeckOfCards[1]);
            Assert.Equal(5, sut.DeckOfCards[2]);
            Assert.Equal(6, sut.DeckOfCards[3]);
            Assert.Equal(7, sut.DeckOfCards[4]);
            Assert.Equal(8, sut.DeckOfCards[5]);
            Assert.Equal(9, sut.DeckOfCards[6]);
            Assert.Equal(0, sut.DeckOfCards[7]);
            Assert.Equal(1, sut.DeckOfCards[8]);
            Assert.Equal(2, sut.DeckOfCards[9]);
        }

        [Fact]
        public void Day22Part1_CutMinus4()
        {
            SlamShuffler sut = new SlamShuffler(10);

            sut.Cut(-4);

            Assert.Equal(6, sut.DeckOfCards[0]);
            Assert.Equal(7, sut.DeckOfCards[1]);
            Assert.Equal(8, sut.DeckOfCards[2]);
            Assert.Equal(9, sut.DeckOfCards[3]);
            Assert.Equal(0, sut.DeckOfCards[4]);
            Assert.Equal(1, sut.DeckOfCards[5]);
            Assert.Equal(2, sut.DeckOfCards[6]);
            Assert.Equal(3, sut.DeckOfCards[7]);
            Assert.Equal(4, sut.DeckOfCards[8]);
            Assert.Equal(5, sut.DeckOfCards[9]);
        }

        [Fact]
        public void Day22Part1_DealIncrement3()
        {
            SlamShuffler sut = new SlamShuffler(10);

            sut.DealWithIncrement(3);

            Assert.Equal(0, sut.DeckOfCards[0]);
            Assert.Equal(7, sut.DeckOfCards[1]);
            Assert.Equal(4, sut.DeckOfCards[2]);
            Assert.Equal(1, sut.DeckOfCards[3]);
            Assert.Equal(8, sut.DeckOfCards[4]);
            Assert.Equal(5, sut.DeckOfCards[5]);
            Assert.Equal(2, sut.DeckOfCards[6]);
            Assert.Equal(9, sut.DeckOfCards[7]);
            Assert.Equal(6, sut.DeckOfCards[8]);
            Assert.Equal(3, sut.DeckOfCards[9]);
        }

        [Fact]
        public void Day22Part1_Example01()
        {
            int[] expectedCards = new int[] { 0, 3, 6, 9, 2, 5, 8, 1, 4, 7 };
            string[] cmds = new string[]
            {
                "deal with increment 7",
                "deal into new stack",
                "deal into new stack"
            };
            SlamShuffler sut = new SlamShuffler(10);

            foreach (string cmd in cmds)
            {
                sut.ShuffleCommand(cmd);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(expectedCards[i], sut.DeckOfCards[i]);
            }
        }

        [Fact]
        public void Day22Part1_Example02()
        {
            int[] expectedCards = new int[] { 3, 0, 7, 4, 1, 8, 5, 2, 9, 6 };
            string[] cmds = new string[]
            {
                "cut 6",
                "deal with increment 7",
                "deal into new stack"
            };
            SlamShuffler sut = new SlamShuffler(10);

            foreach (string cmd in cmds)
            {
                sut.ShuffleCommand(cmd);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(expectedCards[i], sut.DeckOfCards[i]);
            }
        }

        [Fact]
        public void Day22Part1_Example03()
        {
            int[] expectedCards = new int[] { 6, 3, 0, 7, 4, 1, 8, 5, 2, 9 };
            string[] cmds = new string[]
            {
                "deal with increment 7",
                "deal with increment 9",
                "cut -2"
            };
            SlamShuffler sut = new SlamShuffler(10);

            foreach (string cmd in cmds)
            {
                sut.ShuffleCommand(cmd);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(expectedCards[i], sut.DeckOfCards[i]);
            }
        }

        [Fact]
        public void Day22Part1_Example04()
        {
            int[] expectedCards = new int[] { 9, 2, 5, 8, 1, 4, 7, 0, 3, 6 };
            string[] cmds = new string[]
            {
                "deal into new stack",
                "cut -2",
                "deal with increment 7",
                "cut 8",
                "cut -4",
                "deal with increment 7",
                "cut 3",
                "deal with increment 9",
                "deal with increment 3",
                "cut -1"
            };
            SlamShuffler sut = new SlamShuffler(10);

            foreach (string cmd in cmds)
            {
                sut.ShuffleCommand(cmd);
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(expectedCards[i], sut.DeckOfCards[i]);
            }
        }

        [Fact]
        public void Day22Part1_TestSolution()
        {
            string[] cmds = DayDataUtilities.ReadLinesFromFile("day22.txt");
            Assert.NotNull(cmds);
            Assert.Equal(100, cmds.Length);
            SlamShuffler sut = new SlamShuffler(10007);

            foreach (string cmd in cmds)
            {
                sut.ShuffleCommand(cmd);
            }

            int actual = sut.DeckOfCards.FindIndex(c => c == 2019);
            Assert.Equal(3324, actual);
            //sut.DumpDeckOfCards(@"c:\work\cards.csv");
        }

        [Fact]
        public void Day22Part1_TestSolutionByFollowingIndex()
        {
            string[] cmds = DayDataUtilities.ReadLinesFromFile("day22.txt");
            Assert.NotNull(cmds);
            Assert.Equal(100, cmds.Length);
            SlamShufflerIndex sut = new SlamShufflerIndex(10007, 2019);

            foreach (string cmd in cmds)
            {
                sut.ShuffleCommand(cmd);
            }

            long actual = sut.TrackedIndex;
            Assert.Equal(3324, actual);
        }

        [Fact]
        public void Day22Part1_TestSolutionByFollowingIndexInReverse()
        {
            string[] cmds = DayDataUtilities.ReadLinesFromFile("day22.txt");
            Assert.NotNull(cmds);
            Assert.Equal(100, cmds.Length);
            SlamShufflerIndex sut = new SlamShufflerIndex(10007, 3324);

            for (int i = cmds.Length - 1; i >= 0; i--)
            {
                sut.ShuffleCommandReverse(cmds[i]);
            }
            long actual = sut.TrackedIndex;
            Assert.Equal(2019, actual);
        }

        [Fact]
        public void Day22Part2_ReverseDealInc()
        {
            SlamShufflerIndex sut = new SlamShufflerIndex(10007, 3324);
            sut.DealWithIncrement(63);
            Assert.Equal(9272, sut.TrackedIndex);
            sut.DealWithIncrement(-63);
            Assert.Equal(3324, sut.TrackedIndex);
        }

        [Fact]
        public void Day22Part2_TestSolutionJustOnce()
        {
            // both are primes, 99% sure.
            long deckSize = 119315717514047;
            long shuffleTimes = 101741582076661;

            string[] cmds = DayDataUtilities.ReadLinesFromFile("day22.txt");
            Assert.NotNull(cmds);
            Assert.Equal(100, cmds.Length);

            SlamShufflerIndex sut = new SlamShufflerIndex(deckSize, 2020);
            for (int i = cmds.Length - 1; i >= 0; i--)
            {
                sut.ShuffleCommandReverse(cmds[i]);
            }

            long actual = sut.TrackedIndex;
            Assert.Equal(27321782275977, actual);

        }

        [Fact]
        public void Day22Part2_TestSolutionForwardOnce()
        {
            // both are primes, 99% sure.
            long deckSize = 119315717514047;
            long shuffleTimes = 101741582076661;

            string[] cmds = DayDataUtilities.ReadLinesFromFile("day22.txt");
            Assert.NotNull(cmds);
            Assert.Equal(100, cmds.Length);

            SlamShufflerIndex sut = new SlamShufflerIndex(deckSize, 2020);
            foreach (var cmd in cmds)
            {
                sut.ShuffleCommand(cmd);
            }

            long actual = sut.TrackedIndex;
            Assert.Equal(113106724260569, actual);
        }

        [Fact]
        public void Day22Part2_TestTime()
        {
            long shuffleTimes = 101741582076661;
            TimeSpan ts = new TimeSpan(shuffleTimes);
            Assert.Equal(117, ts.Days);
        }

        [Fact(Skip ="Taking too long")]
        public void Day22Part2_TestSolution()
        {
            // both are primes, 99% sure.
            long deckSize = 119315717514047;
            long shuffleTimes = 101741582076661;

            string[] cmds = DayDataUtilities.ReadLinesFromFile("day22.txt");
            Assert.NotNull(cmds);
            Assert.Equal(100, cmds.Length);

            SlamShufflerIndex sut = new SlamShufflerIndex(deckSize, 2020);
            for (long shuffle = 0; shuffle < shuffleTimes; shuffle++)
            {
                for (int i = cmds.Length - 1; i >= 0; i--)
                {
                    sut.ShuffleCommandReverse(cmds[i]);
                }
            }

            long actual = sut.TrackedIndex;
            Assert.Equal(-666, actual);

        }
    }
}
