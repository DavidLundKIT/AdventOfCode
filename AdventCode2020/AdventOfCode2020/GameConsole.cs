using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class GameConsole
    {
        public long Acc { get; set; }
        public int InstrIndex { get; set; }
        public List<Instruction> Program { get; set; }
        public long Ticker { get; set; }
        public bool Bad { get; set; }

        public Instruction NextStep
        {
            get
            {
                return (0 <= InstrIndex && InstrIndex <= Program.Count)? Program[InstrIndex]: null;
            }
        }

        public GameConsole(List<Instruction> program)
        {
            Program = program;
            Acc = 0;
            InstrIndex = 0;
        }

        public void Reset()
        {
            Acc = 0;
            InstrIndex = 0;
        }

        public void Run()
        {
            Ticker = 0;
            Bad = false;
            do
            {
                if (NextStep.Count != 0)
                {
                    Bad = true;
                    break;
                }
                NextStep.Count = ++Ticker;
                switch (NextStep.Cmd)
                {
                    case "nop":
                        InstrIndex += 1;
                        break;
                    case "acc":
                        Acc += NextStep.Operand;
                        InstrIndex += 1;
                        break;
                    case "jmp":
                        InstrIndex += (int)NextStep.Operand;
                        break;
                    default:
                        throw new ArgumentException($"Unknown command: {NextStep.Cmd}, {InstrIndex}");
                }
            } while (InstrIndex < Program.Count);
        }
    }
}
