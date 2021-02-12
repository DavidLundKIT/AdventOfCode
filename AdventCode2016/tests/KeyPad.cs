using System;

namespace tests
{
    public class KeyPad
    {
        public int KeyNow { get; set; }
        public KeyPad(int startValue)
        {
            KeyNow = startValue;
        }

        public virtual void Up()
        {
            int nextKey = KeyNow - 3;
            if (nextKey != -2 && nextKey != -1 && nextKey != 0)
            {
                // moved up ok
                KeyNow = nextKey;
            }
        }
        public virtual void Down()
        {
            int nextKey = KeyNow + 3;
            if (nextKey != 10 && nextKey != 11 && nextKey != 12)
            {
                // moved down ok
                KeyNow = nextKey;
            }
        }
        public virtual void Left()
        {
            int nextKey = KeyNow - 1;
            if (nextKey != 0 && nextKey != 3 && nextKey != 6)
            {
                // moved left ok
                KeyNow = nextKey;
            }
        }
        public virtual void Right()
        {
            int nextKey = KeyNow + 1;
            if (nextKey != 4 && nextKey != 7 && nextKey != 10)
            {
                // moved Right ok
                KeyNow = nextKey;
            }
        }

        public int ProcessCommand(string commandLine)
        {
            char [] cmds = commandLine.ToUpper().ToCharArray();
            foreach (var cmd in cmds)   
            {
                switch (cmd)
                {
                    case 'U':
                        Up();
                        break;
                    case 'D':
                        Down();
                        break;
                    case 'L':
                        Left();
                        break;
                    case 'R':
                        Right();
                        break;
                    default:
                    throw new ArgumentOutOfRangeException("cmd");
                }
            }
            return KeyNow;
        }

    }

    public class DiamondKeyPad : KeyPad
    {
        public DiamondKeyPad(int startValue)
            :base(startValue)
        {
            
        }
        public override void Up()
        {
            switch (KeyNow)
            {
                case 3:
                case 13:
                    KeyNow -= 2;
                    break;
                case 6:
                case 7:
                case 8:
                case 10:
                case 11:
                case 12:
                    KeyNow -= 4;
                    break;
                default:
                    // no up
                    break;
            }
        }
        public override void Down()
        {
            switch (KeyNow)
            {
                case 1:
                case 11:
                    KeyNow += 2;
                    break;
                case 2:
                case 3:
                case 4:
                case 6:
                case 7:
                case 8:
                    KeyNow += 4;
                    break;
                default:
                    // no down
                    break;
            }
        }

        public override void Left()
        {
            int nextKey = KeyNow - 1;
            if (nextKey != 0 && nextKey != 1 && nextKey != 4 && nextKey != 9 && nextKey != 12)
            {
                // moved left ok
                KeyNow = nextKey;
            }
        }
        public override void Right()
        {
            int nextKey = KeyNow + 1;
            if (nextKey != 2 && nextKey != 5 && nextKey != 10 && nextKey != 13 && nextKey != 14)
            {
                // moved Right ok
                KeyNow = nextKey;
            }
        }
    }
}