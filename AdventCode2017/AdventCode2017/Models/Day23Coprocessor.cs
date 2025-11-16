using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AdventCodeLib
{
    public class Day23Coprocessor
    {
        public Day23Coprocessor()
        {
            Instructions = new List<Instruction>();
            Registers = new Dictionary<string, int>();
        }

        public List<Instruction> Instructions { get; set; }
        public Dictionary<string, int> Registers { get; set; }
        public long MulCount { get; set; }
        public void ParseProgram(string path)
        {
            var rows = DataTools.ReadAllLines(path);
            ResetRegisters();
            ParseProgram(rows);
        }

        public void ParseProgram(IEnumerable<string> rows)
        {
            Instructions.Clear();
            foreach (var row in rows)
            {
                var ins = Instruction.CreateCmd(row);
                Instructions.Add(ins);
            }
        }

        public void ResetRegisters()
        {
            Registers.Clear();
            Registers.Add("a", 0);
            Registers.Add("b", 0);
            Registers.Add("c", 0);
            Registers.Add("d", 0);
            Registers.Add("e", 0);
            Registers.Add("f", 0);
            Registers.Add("g", 0);
            Registers.Add("h", 0);
        }

        public int PlayStep(int step)
        {
            if(step<0 || step >= Instructions.Count)
            {
                return step;
            }

            int next = step;
            Instruction ins = Instructions[step];

            switch (ins.CmdType)
            {
                case DuetCmds.set:
                    if (ins.B.HasValue)
                    {
                        Registers[ins.RegA] = ins.B.Value;
                    }
                    else
                    {
                        Registers[ins.RegA] = Registers[ins.RegB];
                    }
                    next++;
                    break;
                case DuetCmds.mul:
                    if (ins.B.HasValue)
                    {
                        Registers[ins.RegA] *= ins.B.Value;
                    }
                    else
                    {
                        Registers[ins.RegA] *= Registers[ins.RegB];
                    }
                    MulCount++;
                    next++;
                    break;
                case DuetCmds.jnz:
                    int test = ins.A ?? Registers[ins.RegA];
                    if (test != 0)
                    {
                        // jump
                        if (ins.B.HasValue)
                        {
                            next += (int)ins.B.Value;
                        }
                        else
                        {
                            next += (int)Registers[ins.RegB];
                        }
                    }
                    else
                    {
                        next++;
                    }
                    break;
                case DuetCmds.sub:
                    if (ins.B.HasValue)
                    {
                        Registers[ins.RegA] -= ins.B.Value;
                    }
                    else
                    {
                        Registers[ins.RegA] -= Registers[ins.RegB];
                    }
                    next++;
                    break;
                default:
                    break;
            }

            return next;
        }

        public void PlayProgram()
        {
            long count = 0;
            int step = 0;
            do
            {
                step = PlayStep(step);
                count++;
                if(count %1000 ==0)
                {
                    Debug.WriteLine($"Step: {step}, regh: {Registers["h"]}, Count: {count}");
                }
            } while (step >= 0 && step < Instructions.Count);
        }
    }
}
