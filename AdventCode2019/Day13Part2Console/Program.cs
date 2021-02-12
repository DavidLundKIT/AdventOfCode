using AdventOfCode2019;
using AdventOfCode2019XUnitTests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day13Part2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day13 Part 2 Start!");
            List<long> pgm = DayDataUtilities.ReadMagicSmokePgmFromFile("day13.txt");
            int blockedTiles = 0;
            int val = 0;
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
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Score: {0}", dictGameBoard[pscore]);
                Console.WriteLine("Tiles: {0}", blockedTiles);
                Console.WriteLine();
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

            Console.WriteLine("Day13 Part 2 Done!");
        }

        protected static void WriteAt(Point p, int tileId)
        {
            try
            {
                Console.SetCursorPosition(p.X, p.Y);
                switch (tileId)
                {
                    case 0:
                        Console.Write(" ");
                        break;
                    case 1:
                        Console.Write("#");
                        break;
                    case 2:
                        Console.Write("B");
                        break;
                    case 3:
                        Console.Write("-");
                        break;
                    case 4:
                        Console.Write("o");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("");
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

    }
}
