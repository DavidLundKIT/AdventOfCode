using System;

namespace AdventCodeLib
{
    public enum DuetCmds
    {
        snd,
        set,
        add,
        mul,
        mod,
        rcv,
        jgz,
        jnz,
        sub
    }

    public class Instruction
    {
        public string Org { get; set; }
        public DuetCmds CmdType { get; set; }
        public string RegA { get; set; }
        public string RegB { get; set; }
        public int? A { get; set; }
        public int? B { get; set; }

        public static Instruction CreateCmd(string cmd)
        {
            string[] vals = cmd.Split(new char[] { ' ' });
            Instruction c = new Instruction
            {
                Org = cmd,
                CmdType = (DuetCmds)Enum.Parse(typeof(DuetCmds), vals[0])
            };
            if (int.TryParse(vals[1], out int a))
            {
                c.A = a;
            }
            else
            {
                c.RegA = vals[1];
            }

            if (vals.Length == 3)
            {
                if (int.TryParse(vals[2], out int b))
                {
                    c.B = b;
                }
                else
                {
                    // as a reg
                    c.RegB = vals[2];
                }
            }
            return c;
        }
    }

}
