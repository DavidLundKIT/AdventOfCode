using AdventOfCode2019;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day13CarePackageUnitTests
    {
        [Fact]
        public void Day13Part1_TestSolution()
        {
            List<long> pgm = DayDataUtilities.ReadMagicSmokePgmFromFile("day13.txt");
            Assert.NotNull(pgm);

            var sut = new MagicSmokeComputer(pgm);
            MagicSmokeComputer.ProgramMode status = MagicSmokeComputer.ProgramMode.Start;
            do
            {
                status = sut.Run(status);
            } while (status != MagicSmokeComputer.ProgramMode.Stop);
            Assert.Equal(MagicSmokeComputer.ProgramMode.Stop, status);

            // analyze the out put queue
            PointEqualityComparer peqc = new PointEqualityComparer();
            Dictionary<Point, int> dictGameBoard = new Dictionary<Point, int>(peqc);
            do
            {
                int x = (int)sut.OutputPort();
                int y = (int)sut.OutputPort();
                int tileId = (int)sut.OutputPort();
                Point p = new Point(x, y);
                if (dictGameBoard.ContainsKey(p))
                {
                    dictGameBoard[p] = tileId;

                }
                else
                {
                    dictGameBoard.Add(p, tileId);
                }
            } while (sut.OutputQueueSize() > 0);
            Assert.NotEmpty(dictGameBoard);
            int blocktiles = 0;
            foreach (var tile in dictGameBoard.Values)
            {
                if (tile == 2)
                {
                    blocktiles++;
                }

            }
            //int blockedTiles = dictGameBoard.Values.Select(t => t == 2).ToList().Count();
            Assert.Equal(268, blocktiles);
        }

        [Fact]
        public void Day13Part2_TestSolution()
        {
            List<long> pgm = DayDataUtilities.ReadMagicSmokePgmFromFile("day13.txt");
            Assert.NotNull(pgm);

            int blockedTiles;
            int val;
            var sut = new MagicSmokeComputer(pgm);
            Point pscore = new Point(-1, 0);
            Point ball = null;
            Point paddle = null;
            PointEqualityComparer peqc = new PointEqualityComparer();
            Dictionary<Point, int> dictGameBoard = new Dictionary<Point, int>(peqc);
            sut.Coins = 2;
            MagicSmokeComputer.ProgramMode status = MagicSmokeComputer.ProgramMode.Start;
            do
            {
                status = sut.Run(status);

                // dump out the screen
                while (sut.OutputQueueSize() > 0)
                {
                    int x = (int)sut.OutputPort();
                    int y = (int)sut.OutputPort();
                    int tileId = (int)sut.OutputPort();
                    Point p = new Point(x, y);
                    if (dictGameBoard.ContainsKey(p))
                    {
                        dictGameBoard[p] = tileId;
                    }
                    else
                    {
                        dictGameBoard.Add(p, tileId);
                    }
                }
                // print the score 
                //Console.Clear();
                //foreach (Point p in dictGameBoard.Keys)
                //{
                //    if (p.X != -1)
                //    {
                //        WriteAt(p, dictGameBoard[p]);
                //    }
                //}
                blockedTiles = 0;
                foreach (var item in dictGameBoard)
                {
                    if (item.Value == 2)
                    {
                        blockedTiles++;
                    }
                    if (item.Value == 3)
                    {
                        paddle = item.Key;
                    }
                    if (item.Value == 4)
                    {
                        ball = item.Key;
                    }
                }
                //Console.WriteLine();
                //Console.WriteLine();
                //Console.WriteLine("Score: {0}", dictGameBoard[pscore]);
                //Console.WriteLine("Tiles: {0}", blockedTiles);
                //Console.WriteLine();
                // put the input here
                if (ball.X < paddle.X)
                {
                    // left
                    val = -1;
                }
                else if (ball.X > paddle.X)
                {
                    // right
                    val = 1;
                }
                else
                {
                    val = 0;
                }
                sut.InputPort = val;
            } while (status != MagicSmokeComputer.ProgramMode.Stop);

            Assert.Equal(13989, dictGameBoard[pscore]);
        }
    }
}
