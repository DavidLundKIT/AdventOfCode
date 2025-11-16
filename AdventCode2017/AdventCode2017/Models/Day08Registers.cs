using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCodeLib
{
    public class Day08Registers
    {
        public Day08Registers()
        {
            Registers = new Dictionary<string, int>();
        }

        public Dictionary<string, int> Registers { get; set; }
        public string[] ReadData(string path)
        {
            var rows = DataTools.ReadAllLines(path);
            return rows;
        }

        public int GetRegister(string reg)
        {

            if (Registers.ContainsKey(reg))
            {
                return Registers[reg];
            }
            Registers.Add(reg, 0);
            return 0;
        }

        public int UpdateRegister(string reg, int val)
        {
            int now = GetRegister(reg) + val;
            Registers[reg] = now;
            return now;
        }

        public int ParseCmd(string row)
        {
            var cmd = row.Split(null);
            if (cmd.Length != 7)
            {
                throw new Exception($"Length not 7: {row}");
            }

            int regCheck = int.Parse(cmd[6]);
            int regUpdate = int.Parse(cmd[2]);

            if (!CheckIf(cmd[4], cmd[5], regCheck))
            {
                return 0;
            }

            int i;
            if (cmd[1] == "inc")
            {
                i = UpdateRegister(cmd[0], regUpdate);
            }
            else if (cmd[1] == "dec")
            {
                i = UpdateRegister(cmd[0], -regUpdate);
            }
            else
            {
                throw new Exception($"Not inc or dec: {row}");
            }
            return i;
        }

        public bool CheckIf(string reg, string cmd, int val)
        {
            int ireg = GetRegister(reg);

            switch (cmd)
            {
                case "<":
                    return (ireg < val);
                case "<=":
                    return (ireg <= val);
                case "==":
                    return (ireg == val);
                case "!=":
                    return (ireg != val);
                case ">":
                    return (ireg > val);
                case ">=":
                    return (ireg >= val);

                default:
                    throw new Exception($"Unknown cmd: {cmd}");
            }
        }

        public int MaxRegisterValue()
        {
            int max = Registers.Max(i => i.Value);
            return max;
        }
    }
}
