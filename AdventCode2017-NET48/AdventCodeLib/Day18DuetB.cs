using System.Collections.Generic;

namespace AdventCodeLib
{
    public class Day18DuetB
    {
        public Day18DuetB()
        {
            Instructions = new List<Instruction>();
            Registers = new Dictionary<string, long>();
            RecieveQueue = new Queue<long>();
        }

        public Queue<long> SendQueue { get; set; }
        public Queue<long> RecieveQueue { get; set; }
        public List<Instruction> Instructions { get; set; }
        public Dictionary<string, long> Registers { get; set; }
        public long Sends { get; set; }
        public bool Blocked { get; set; }

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
                    SendQueue.Enqueue(cmd.A ?? Registers[cmd.RegA]);
                    Sends++;
                    next++;
                    break;
                case DuetCmds.set:
                    Registers[cmd.RegA] = cmd.B ?? Registers[cmd.RegB];
                    next++;
                    break;
                case DuetCmds.add:
                    Registers[cmd.RegA] += cmd.B ?? Registers[cmd.RegB];
                    next++;
                    break;
                case DuetCmds.mul:
                    Registers[cmd.RegA] *= cmd.B ?? Registers[cmd.RegB];
                    next++;
                    break;
                case DuetCmds.mod:
                    Registers[cmd.RegA] %= cmd.B ?? Registers[cmd.RegB];
                    next++;
                    break;
                case DuetCmds.rcv:
                    if (RecieveQueue.Count > 0)
                    {
                        Blocked = false;
                        Registers[cmd.RegA] = RecieveQueue.Dequeue();
                        next++;
                    }
                    else
                    {
                        Blocked = true;
                        return next;
                    }
                    break;
                case DuetCmds.jgz:
                    long test = cmd.A ?? Registers[cmd.RegA];
                    if (test > 0)
                    {
                        // jump
                        next += cmd.B ?? Registers[cmd.RegB];
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
