using System;
using System.Collections.Generic;

namespace AdventCodeLib
{
    public class TupleComparer : IEqualityComparer<Tuple<int, int>>
    {
        public bool Equals(Tuple<int, int> x, Tuple<int, int> y)
        {
            return (x.Item1 == y.Item1 && x.Item2 == y.Item2);
        }

        public int GetHashCode(Tuple<int, int> obj)
        {
            return obj.Item1 ^ obj.Item2;
        }
    }

    public enum VirusState
    {
        Clean,
        Weakened,
        Infected,
        Flagged
    }

    public class Day22SporificaVirus
    {
        public Day22SporificaVirus()
        {
            Blocks = new Dictionary<Tuple<int, int>, VirusState>(new TupleComparer());
        }

        public Position CurrentNode { get; set; }
        public int DimX { get; set; }
        public int DimY { get; set; }
        public int InfectionBursts { get; set; }
        public Dictionary<Tuple<int, int>, VirusState> Blocks { get; set; }


        public void ParseData(string path)
        {
            var rows = DataTools.ReadAllLines(path);
            DimY = rows.Length;
            DimX = rows[0].Length;

            for (int y = 0; y < DimY; y++)
            {
                var chars = rows[y].ToCharArray();
                for (int x = 0; x < DimX; x++)
                {
                    Tuple<int, int> key = new Tuple<int, int>(x, y);
                    VirusState infected = chars[x] == '#' ? VirusState.Infected : VirusState.Clean;
                    Blocks.Add(key, infected);
                }
            }
            CurrentNode = new Position();
            CurrentNode.X = DimX / 2;
            CurrentNode.Y = DimY / 2;
            CurrentNode.Direction = Direction.Up;
            InfectionBursts = 0;
        }

        public VirusState DoBurst()
        {
            var key = CurrentNode.Now();
            VirusState state = VirusState.Clean;
            if (!Blocks.ContainsKey(key))
            {
                // no block node, so add it and infect it
                Blocks.Add(key, VirusState.Infected);
                CurrentNode.TurnLeft();
                CurrentNode.MoveForward();
                InfectionBursts++;
            }
            else
            {
                state = Blocks[key];
                if (state == VirusState.Infected)
                {
                    Blocks[key] = VirusState.Clean;
                    CurrentNode.TurnRight();
                    CurrentNode.MoveForward();
                }
                else
                {
                    Blocks[key] = VirusState.Infected;
                    CurrentNode.TurnLeft();
                    CurrentNode.MoveForward();
                    InfectionBursts++;
                }
            }
            return state;
        }

        public VirusState DoBurst2()
        {
            var key = CurrentNode.Now();
            VirusState state = VirusState.Clean;
            if (!Blocks.ContainsKey(key))
            {
                // no block node, so add it
                Blocks.Add(key, VirusState.Clean);
            }
            state = Blocks[key];
            switch (state)
            {
                case VirusState.Clean:
                    Blocks[key] = VirusState.Weakened;
                    CurrentNode.TurnLeft();
                    break;
                case VirusState.Weakened:
                    Blocks[key] = VirusState.Infected;
                    // no turning
                    InfectionBursts++;
                    break;
                case VirusState.Infected:
                    Blocks[key] = VirusState.Flagged;
                    CurrentNode.TurnRight();
                    break;
                case VirusState.Flagged:
                    Blocks[key] = VirusState.Clean;
                    CurrentNode.Reverse();
                    break;
                default:
                    break;
            }
            CurrentNode.MoveForward();
            return state;
        }
    }
}
