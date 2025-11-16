using System.Collections.Generic;
using System.Linq;

namespace AdventCodeLib
{
    public enum TuringState
    {
        A,
        B,
        C,
        D,
        E,
        F
    }
    public class Day25Turing
    {

        public Day25Turing()
        {
            Tape = new SortedDictionary<int, int>();
            Cursor = 0;
            State = TuringState.A;
        }

        public SortedDictionary<int,int> Tape { get; set; }
        public int Cursor { get; set; }
        public TuringState State { get; set; }

        private int GetValue(int key)
        {
            if(Tape.ContainsKey(key))
            {
                return Tape[key];
            }
            Tape.Add(key, 0);
            return 0;
        }

        public int CheckSum()
        {
            int sum = Tape.Values.Sum();
            return sum;
        }

        public int TuringStep()
        {
            int value = -1;
            switch (State)
            {
                case TuringState.A:
                    value = StateA();
                    break;
                case TuringState.B:
                    value = StateB();
                    break;
                case TuringState.C:
                    break;
                case TuringState.D:
                    break;
                case TuringState.E:
                    break;
                case TuringState.F:
                    break;
                default:
                    break;
            }
            return value;
        }

        public int StateA()
        {
            int value = GetValue(Cursor);
            if (value == 0)
            {
                Tape[Cursor] = 1;
                Cursor++;
                State = TuringState.B;
            }
            else
            {
                Tape[Cursor] = 0;
                Cursor--;
                State = TuringState.B;
            }
            return value;
        }

        public int StateB()
        {
            int value = GetValue(Cursor);
            if (value == 0)
            {
                Tape[Cursor] = 1;
                Cursor--;
                State = TuringState.A;
            }
            else
            {
                Tape[Cursor] = 1;
                Cursor++;
                State = TuringState.A;
            }
            return value;
        }
    }

    public class Day25TuringA
    {

        public Day25TuringA()
        {
            Tape = new SortedDictionary<int, int>();
            Cursor = 0;
            State = TuringState.A;
        }

        public SortedDictionary<int, int> Tape { get; set; }
        public int Cursor { get; set; }
        public TuringState State { get; set; }

        private int GetValue(int key)
        {
            if (Tape.ContainsKey(key))
            {
                return Tape[key];
            }
            Tape.Add(key, 0);
            return 0;
        }

        public int CheckSum()
        {
            int sum = Tape.Values.Sum();
            return sum;
        }

        public int TuringStep()
        {
            int value = -1;
            switch (State)
            {
                case TuringState.A:
                    value = StateA();
                    break;
                case TuringState.B:
                    value = StateB();
                    break;
                case TuringState.C:
                    value = StateC();
                    break;
                case TuringState.D:
                    value = StateD();
                    break;
                case TuringState.E:
                    value = StateE();
                    break;
                case TuringState.F:
                    value = StateF();
                    break;
                default:
                    break;
            }
            return value;
        }

        public int StateA()
        {
            int value = GetValue(Cursor);
            if (value == 0)
            {
                Tape[Cursor] = 1;
                Cursor++;
                State = TuringState.B;
            }
            else
            {
                Tape[Cursor] = 0;
                Cursor--;
                State = TuringState.B;
            }
            return value;
        }

        public int StateB()
        {
            int value = GetValue(Cursor);
            if (value == 0)
            {
                Tape[Cursor] = 1;
                Cursor--;
                State = TuringState.C;
            }
            else
            {
                Tape[Cursor] = 0;
                Cursor++;
                State = TuringState.E;
            }
            return value;
        }

        public int StateC()
        {
            int value = GetValue(Cursor);
            if (value == 0)
            {
                Tape[Cursor] = 1;
                Cursor++;
                State = TuringState.E;
            }
            else
            {
                Tape[Cursor] = 0;
                Cursor--;
                State = TuringState.D;
            }
            return value;
        }

        public int StateD()
        {
            int value = GetValue(Cursor);
            if (value == 0)
            {
                Tape[Cursor] = 1;
                Cursor--;
                State = TuringState.A;
            }
            else
            {
                Tape[Cursor] = 1;
                Cursor--;
                State = TuringState.A;
            }
            return value;
        }

        public int StateE()
        {
            int value = GetValue(Cursor);
            if (value == 0)
            {
                Tape[Cursor] = 0;
                Cursor++;
                State = TuringState.A;
            }
            else
            {
                Tape[Cursor] = 0;
                Cursor++;
                State = TuringState.F;
            }
            return value;
        }

        public int StateF()
        {
            int value = GetValue(Cursor);
            if (value == 0)
            {
                Tape[Cursor] = 1;
                Cursor++;
                State = TuringState.E;
            }
            else
            {
                Tape[Cursor] = 1;
                Cursor++;
                State = TuringState.A;
            }
            return value;
        }
    }
}
