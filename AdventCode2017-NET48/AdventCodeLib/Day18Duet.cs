using System.Collections.Generic;

namespace AdventCodeLib
{
    public class Day18Duet
    {
        public Day18Duet()
        {
            Instructions = new List<Instruction>();
            Registers = new Dictionary<string, long>();
        }

        public long? Recovered { get; set; }
        public long Sound { get; set; }
        public long Sends { get; set; }
        public List<Instruction> Instructions { get; set; }
        public Dictionary<string, long> Registers { get; set; }

        public void ParseDuet(IEnumerable<string> rows)
        {
            Instructions.Clear();

            foreach (var row in rows)
            {
                var ins = Instruction.CreateCmd(row);
                if (!string.IsNullOrEmpty(ins.RegA) && !Registers.ContainsKey(ins.RegA))
                {
                    Registers.Add(ins.RegA, 0);
                }
                if (!string.IsNullOrEmpty(ins.RegB) && !Registers.ContainsKey(ins.RegA))
                {
                    Registers.Add(ins.RegB, 0);
                }
                Instructions.Add(ins);
            }
        }

        public void PlayDuet()
        {
            long step = 0;
            do
            {
                step = PlayDuetStep(step);
            } while (step >= 0 && step < Instructions.Count);
        }

        public long PlayDuetStep(long step)
        {
            if (step < 0 || step >= Instructions.Count)
            {
                return step;
            }
            Instruction cmd = Instructions[(int)step];
            long next = step;
            switch (cmd.CmdType)
            {
                case DuetCmds.snd:
                    Sends = Registers[cmd.RegA];
                    next++;
                    break;
                case DuetCmds.set:
                    if (cmd.B.HasValue)
                    {
                        Registers[cmd.RegA] = cmd.B.Value;
                    }
                    else
                    {
                        Registers[cmd.RegA] = Registers[cmd.RegB];
                    }
                    next++;
                    break;
                case DuetCmds.add:
                    if (cmd.B.HasValue)
                    {
                        Registers[cmd.RegA] += cmd.B.Value;
                    }
                    else
                    {
                        Registers[cmd.RegA] += Registers[cmd.RegB];
                    }
                    next++;
                    break;
                case DuetCmds.mul:
                    if (cmd.B.HasValue)
                    {
                        Registers[cmd.RegA] *= cmd.B.Value;
                    }
                    else
                    {
                        Registers[cmd.RegA] *= Registers[cmd.RegB];
                    }
                    next++;
                    break;
                case DuetCmds.mod:
                    if (cmd.B.HasValue)
                    {
                        Registers[cmd.RegA] %= cmd.B.Value;
                    }
                    else
                    {
                        Registers[cmd.RegA] %= Registers[cmd.RegB];
                    }
                    next++;
                    break;
                case DuetCmds.rcv:
                    if (Registers[cmd.RegA] != 0)
                    {
                        Recovered = Sends;
                        return -1;
                    }
                    else
                    {
                        next++;
                    }

                    break;
                case DuetCmds.jgz:
                    long test = cmd.A ?? Registers[cmd.RegA];
                    if (test > 0)
                    {
                        // jump
                        if (cmd.B.HasValue)
                        {
                            next += cmd.B.Value;
                        }
                        else
                        {
                            next += Registers[cmd.RegB];
                        }
                    }
                    else
                    {
                        next++;
                    }
                    break;
                default:
                    break;
            }
            return next;
        }
    }
}
