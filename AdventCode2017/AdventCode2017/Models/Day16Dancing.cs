using System;

namespace AdventCodeLib
{
    public enum CommandType
    {
        Spin,
        Exchange,
        Partner
    }

    public class Command
    {

        public string Org { get; set; }
        public CommandType cmd { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char A { get; set; }
        public char B { get; set; }

        public static Command CreateCmd(string cmd)
        {
            string[] vals;
            Command c = new Command();
            c.Org = cmd;
            string cmdCh = cmd.Substring(0, 1);
            switch (cmdCh)
            {
                case "s":
                    c.cmd = CommandType.Spin;
                    c.X = int.Parse(cmd.Substring(1));
                    break;
                case "x":
                    c.cmd = CommandType.Exchange;
                    vals = cmd.Substring(1).Split(new char[] { '/' });
                    c.X = int.Parse(vals[0]);
                    c.Y = int.Parse(vals[1]);
                    break;
                case "p":
                    c.cmd = CommandType.Partner;
                    vals = cmd.Substring(1).Split(new char[] { '/' });
                    c.A = vals[0].ToCharArray()[0];
                    c.B = vals[1].ToCharArray()[0];
                    break;
                default:
                    throw new ArgumentOutOfRangeException(cmd);
            }
            return c;
        }

    }

    public class Day16Dancing
    {
        public char[] Spin(char[] state0, int length, int x)
        {
            int j;
            char[] state1 = new char[length];
            for (int i = 0; i < length; i++)
            {
                j = Math.Abs((i + x) % length);
                state1[j] = state0[i];
            }
            return state1;
        }

        public char[] Spin(char[] state0, int length, string cmd)
        {
            int x = int.Parse(cmd.Substring(1));
            return Spin(state0, length, x);
        }

        public char[] Exchange(char[] state0, int a, int b)
        {
            char temp = state0[a];
            state0[a] = state0[b];
            state0[b] = temp;
            return state0;
        }

        public char[] Exchange(char[] state0, string cmd)
        {
            var vals = cmd.Substring(1).Split(new char[] { '/' });
            int a = int.Parse(vals[0]);
            int b = int.Parse(vals[1]);
            return Exchange(state0, a, b);
        }

        public char[] Partner(char[] state0, int length, string cmd)
        {
            var vals = cmd.Substring(1).Split(new char[] { '/' });
            char chA = vals[0].ToCharArray()[0];
            char chB = vals[1].ToCharArray()[0];
            int a = 0;
            int b = 0;
            for (int i = 0; i < length; i++)
            {
                if(state0[i] == chA)
                {
                    a = i;
                }
                if (state0[i] == chB)
                {
                    b = i;
                }
            }
            return Exchange(state0, a, b);
        }

        public char[] Partner(char[] state0, int length, char chA, char chB)
        {
            int a = 0;
            int b = 0;
            for (int i = 0; i < length; i++)
            {
                if (state0[i] == chA)
                {
                    a = i;
                }
                if (state0[i] == chB)
                {
                    b = i;
                }
            }
            return Exchange(state0, a, b);
        }

        public char[] ProcessCmd(char[] state0, int length, string cmd)
        {
            string cmdCh = cmd.Substring(0, 1);
            switch (cmdCh)
            {
                case "s":
                    return Spin(state0, length, cmd);
                case "x":
                    return Exchange(state0, cmd);
                case "p":
                    return Partner(state0, length, cmd);
                default:
                    throw new ArgumentOutOfRangeException(cmd);
            }
        }

        public char[] ProcessCmd(char[] state0, int length, Command cmd)
        {
            switch (cmd.cmd)
            {
                case CommandType.Spin:
                    return Spin(state0, length, cmd.X);
                case CommandType.Exchange:
                    return Exchange(state0, cmd.X, cmd.Y);
                case CommandType.Partner:
                    return Partner(state0, length, cmd.A, cmd.B);
                default:
                    throw new ArgumentOutOfRangeException(cmd.Org);
            }
        }

        public char[] TransformX(char[] s0, char[] s1,char[] sn0, int length)
        {
            char[] sn1 = new char[length];

            for (int i = 0; i < length; i++)
            {
                sn1[i] = (char) (sn0[i] + (s1[sn0[i] - 'a'] - s0[sn0[i] - 'a']));  
            }
            return sn1;
        }
    }
}
