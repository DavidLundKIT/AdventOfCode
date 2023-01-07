using System.Diagnostics;

namespace AdventCode2022.Models
{
    public class ElfDiffuser
    {
        public Dictionary<Tuple<long, long>, long> ElfMoves { get; set; } = new Dictionary<Tuple<long, long>, long>();
        public Dictionary<Tuple<long, long>, Tuple<long, long>?> Elves { get; set; }
        public DirectionChoice FirstMovementChoice { get; set; }
        public enum DirectionChoice : int
        {
            North = 0,
            South = 1,
            West = 2,
            East = 3,
        }

        public ElfDiffuser(string[] lines)
        {
            FirstMovementChoice = DirectionChoice.North;

            Elves = new Dictionary<Tuple<long, long>, Tuple<long, long>?>();
            for (int y = 0; y < lines.Length; y++)
            {
                var chElves = lines[y].ToCharArray();
                for (int x = 0; x < chElves.Length; x++)
                {
                    if (chElves[x] == '#')
                    {
                        var elf = new Tuple<long, long>(x, y);
                        Elves.Add(elf, null);
                    }
                }
            }
        }

        public void DoARound()
        {
            ElfMoves.Clear();
            foreach (var elf in Elves.Keys)
            {
                bool result = ElfsNextMove(elf);
            }
            if (ElfMoves.Count == 0)
            {
                return;
            }
            var ElvesNow = new Dictionary<Tuple<long, long>, Tuple<long, long>?>();
            foreach (var kvp in Elves)
            {
                var elf = kvp.Key;
                var move = kvp.Value;
                if (move == null)
                {
                    ElvesNow.Add(elf, null);
                }
                else
                {
                    if (ElfMoves[move] > 1)
                    {
                        // can't move
                        ElvesNow.Add(elf, null);
                    }
                    else
                    {
                        // moved
                        ElvesNow.Add(move, null);
                    }
                }
            }
            Elves.Clear();
            Elves = ElvesNow;
            FirstMovementChoice = NextChoice(FirstMovementChoice);
        }

        public long EmptyTilesNow()
        {
            long xMin = Elves.Keys.Select(t => t.Item1).Min();
            long xMax = Elves.Keys.Select(t => t.Item1).Max();
            long yMin = Elves.Keys.Select(t => t.Item2).Min();
            long yMax = Elves.Keys.Select(t => t.Item2).Max();

            long tiles = (Math.Abs(xMax - xMin) + 1) * (Math.Abs(yMax - yMin) + 1);
            return tiles - Elves.Count;
        }

        public void DumpElvesNow(string msg)
        {
            long xMin = Elves.Keys.Select(t => t.Item1).Min();
            long xMax = Elves.Keys.Select(t => t.Item1).Max();
            long yMin = Elves.Keys.Select(t => t.Item2).Min();
            long yMax = Elves.Keys.Select(t => t.Item2).Max();
            Debug.WriteLine("===============");
            Debug.WriteLine(msg);
            Debug.WriteLine("===============");
            for (long y = yMin; y <= yMax; y++)
            {
                for (long x = xMin; x <= xMax; x++)
                {
                    if (Elves.ContainsKey(new Tuple<long, long>(x, y)))
                    {
                        Debug.Write("#");
                    }
                    else
                    {
                        Debug.Write('.');
                    }
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("===============");
        }

        public bool ClearInDirection(DirectionChoice choice, Tuple<long, long> elf, out Tuple<long, long>? nextMove)
        {
            Tuple<long, long> t1;
            Tuple<long, long> t2;
            Tuple<long, long> t3;
            switch (choice)
            {
                case DirectionChoice.North:
                    t1 = new Tuple<long, long>(elf.Item1 - 1, elf.Item2 - 1);
                    t2 = new Tuple<long, long>(elf.Item1, elf.Item2 - 1);
                    t3 = new Tuple<long, long>(elf.Item1 + 1, elf.Item2 - 1);
                    break;
                case DirectionChoice.South:
                    t1 = new Tuple<long, long>(elf.Item1 - 1, elf.Item2 + 1);
                    t2 = new Tuple<long, long>(elf.Item1, elf.Item2 + 1);
                    t3 = new Tuple<long, long>(elf.Item1 + 1, elf.Item2 + 1);
                    break;
                case DirectionChoice.West:
                    t1 = new Tuple<long, long>(elf.Item1 - 1, elf.Item2 - 1);
                    t2 = new Tuple<long, long>(elf.Item1 - 1, elf.Item2);
                    t3 = new Tuple<long, long>(elf.Item1 - 1, elf.Item2 + 1);
                    break;
                case DirectionChoice.East:
                    t1 = new Tuple<long, long>(elf.Item1 + 1, elf.Item2 - 1);
                    t2 = new Tuple<long, long>(elf.Item1 + 1, elf.Item2);
                    t3 = new Tuple<long, long>(elf.Item1 + 1, elf.Item2 + 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(choice));
            }
            if (!Elves.ContainsKey(t1) && !Elves.ContainsKey(t2) && !Elves.ContainsKey(t3))
            {
                // clear this direction
                nextMove = t2;
                return true;
            }
            nextMove = null;
            return false;
        }

        public bool ElfsNextMove(Tuple<long, long> elf)
        {
            Tuple<long, long>? nextMove = null;

            bool allClear = true;
            DirectionChoice choice = FirstMovementChoice;
            do
            {
                bool isClear = ClearInDirection(choice, elf, out Tuple<long, long>? moveInThisDirection);
                if (!isClear)
                {
                    allClear = false;
                }
                else
                {
                    // still clear don't change flag
                    if (nextMove == null)
                    {
                        nextMove = moveInThisDirection;
                    }
                }
                choice = NextChoice(choice);

            } while (choice != FirstMovementChoice);

            if (!allClear)
            {
                if (nextMove != null)
                {
                    Elves[elf] = nextMove;
                    if (ElfMoves.ContainsKey(nextMove))
                    {
                        ElfMoves[nextMove]++;
                    }
                    else
                    {
                        ElfMoves.Add(nextMove, 1);
                    }
                }
                //else couldn't move
            }
            else
            {
                // don't move
                Elves[elf] = null;
            }
            return allClear;
        }

        public DirectionChoice NextChoice(DirectionChoice choice)
        {
            DirectionChoice nextChoice;
            switch (choice)
            {
                case DirectionChoice.North:
                    nextChoice = DirectionChoice.South;
                    break;
                case DirectionChoice.South:
                    nextChoice = DirectionChoice.West;
                    break;
                case DirectionChoice.West:
                    nextChoice = DirectionChoice.East;
                    break;
                case DirectionChoice.East:
                    nextChoice = DirectionChoice.North;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(choice));
            }
            return nextChoice;
        }
    }
}
