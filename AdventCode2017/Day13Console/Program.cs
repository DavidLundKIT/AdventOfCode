using AdventCodeLib;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Day13Console
{
    class Program
    {
        static void Main()
        {
            Day17_SolutionB();
            Console.ReadLine();
        }

        public static void Day17_SolutionB()
        {
            Day17Spinlock sut = new Day17Spinlock
            {
                Factor = 376
            };

            for (int i = 1; i <= 50000000; i++)
            {
                sut.Spin(i);
                if (i % 10000 == 0)
                {
                    Console.WriteLine($"Index = {i}");
                    Console.WriteLine($"Buffer[0] is {sut.Buffer[0]}");
                    Console.WriteLine($"Buffer[1] is {sut.Buffer[1]}");
                }
            }
            Console.WriteLine($"End Buffer[0] is {sut.Buffer[0]}");
            Console.WriteLine($"EndBuffer[1] is {sut.Buffer[1]}");
        }

        public static void Day13SolutionB()
        {
            Day13Firewall sut = new Day13Firewall();
            string pathdata = "Adventday13.txt";

            // 33600
            sut.ParseFirewall(pathdata);
            int score;
            int maxLayer = sut.Firewall.Keys.Max();
            long delay = 0;
            do
            {
                delay++;
                score = 0;
                if (sut.ScannerPosition(delay, 3) == 0)
                {
                    score = 1;
                    Console.WriteLine($"Broke at d: {delay}, layer: 0, s: {score}");
                }
                else
                {
                    for (int i = 0; i < maxLayer + 1; i++)
                    {
                        score = sut.SeverityScore(i + delay, i);
                        if (score > 0)
                        {
                            Console.WriteLine($"Broke at d: {delay}, layer: {i}, s: {score}");
                            break;
                        }
                    }
                }
            } while (score != 0);
            Console.WriteLine($"The delay is {delay}");
        }

        public static void Day16SolutionB()
        {
            string pathdata = "Adventday16.txt";

            Day16Dancing sut = new Day16Dancing();
            string state0 = "abcdefghijklmnop";

            Dictionary<string, string> transforms = new Dictionary<string, string>();

            var rows = DataTools.ReadAllLines(pathdata);
            var cmds0 = rows[0].Split(new char[] { ',' });

            List<Command> cmds = new List<Command>();
            foreach (var cmd0 in cmds0)
            {
                cmds.Add(Command.CreateCmd(cmd0));
            }

            var chars = state0.ToCharArray();
            string key;
            string stateEnd;
            for (int i = 0; i < 1000000000; i++)
            {
                key = string.Join(string.Empty, chars);
                if (transforms.ContainsKey(key))
                {
                    chars = transforms[key].ToCharArray();
                }
                else
                {
                    foreach (var cmd in cmds)
                    {
                        chars = sut.ProcessCmd(chars, 16, cmd);
                    }
                    stateEnd = string.Join(string.Empty, chars);
                    transforms.Add(key, stateEnd);
                }
                if (i % 100000 == 0)
                {
                    stateEnd = string.Join(string.Empty, chars);
                    Console.WriteLine($"S: {stateEnd}, iter: {i}");
                }
            }
            string state1 = string.Join(string.Empty, chars);
            Console.WriteLine($"S: {state1}, iter: end");
        }
    }
}
