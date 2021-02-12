using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    public class MagicSmokeComputer
    {
        public enum ProgramMode
        {
            Start,
            Stop,
            NeedInput,
            Continue
        }

        private long[] _values;
        private Queue<long> _inputQueue;
        private Queue<long> _outputQueue;
        private long _relativeBase;

        public MagicSmokeComputer()
        {
            _values = new long[0];
            _inputQueue = new Queue<long>();
            _outputQueue = new Queue<long>();
            _relativeBase = 0;
        }

        public MagicSmokeComputer(List<long> pgm)
            : this()
        {
            // copy the program into own buffer
            CopyProgram(pgm);
        }

        public List<long> ProgramValues
        {
            get
            {

                return new List<long>(_values);
            }
            set
            {
                CopyProgram(value);
            }
        }

        public long Noun
        {
            get { return _values[1]; }
            set { _values[1] = value; }
        }

        public long Verb
        {
            get { return _values[2]; }
            set { _values[2] = value; }
        }

        public long Coins
        {
            get { return _values[0]; }
            set { _values[0] = value; }
        }

        public long NextCmd { get; set; }

        public long InputPort
        {
            set
            {
                _inputQueue.Enqueue(value);
            }
        }

        public long OutputPort()
        {
            return _outputQueue.Dequeue();
        }

        public long OutputQueueSize()
        {
            return _outputQueue.Count();
        }

        public ProgramMode Run(ProgramMode mode = ProgramMode.Start)
        {
            ProgramMode modeNow;
            if (mode == ProgramMode.Start)
            {
                NextCmd = 0;
                modeNow = ProgramMode.Continue;
            }
            do
            {
                long index = NextCmd;
                modeNow = DoCommand(index);
            } while (modeNow == ProgramMode.Continue);
            return modeNow;
        }

        public ProgramMode DoCommand(long index)
        {
            if (index >= _values.LongLength)
            {
                throw new ArgumentOutOfRangeException($"Out of range - index: {index}");
            }
            long cmd = _values[index];
            long opcode = _values[index] % 100;

            switch (opcode)
            {
                case 1:
                    // add
                    NextCmd = index + 4;
                    long sum = GetValue(index + 1, 1, cmd) + GetValue(index + 2, 2, cmd);
                    _values[GetIndex(index + 3, 3, cmd)] = sum;
                    break;
                case 2:
                    //multiply
                    NextCmd = index + 4;
                    long product = GetValue(index + 1, 1, cmd) * GetValue(index + 2, 2, cmd);
                    _values[GetIndex(index + 3, 3, cmd)] = product;
                    break;
                case 3:
                    // get input
                    if (_inputQueue.TryDequeue(out long store))
                    {
                        NextCmd = index + 2;
                        _values[GetIndex(index + 1, 1, cmd)] = store;
                    }
                    else
                    {
                        // waiting for input
                        return ProgramMode.NeedInput;
                    }
                    break;
                case 4:
                    // send output
                    NextCmd = index + 2;
                    long output = GetValue(index + 1, 1, cmd);
                    _outputQueue.Enqueue(output);
                    break;
                case 5:
                    // jump if true
                    if (GetValue(index + 1, 1, cmd) != 0)
                    {
                        NextCmd = GetValue(index + 2, 2, cmd);
                    }
                    else
                    {
                        NextCmd = index + 3;
                    }
                    break;
                case 6:
                    // jump if false
                    if (GetValue(index + 1, 1, cmd) == 0)
                    {
                        NextCmd = GetValue(index + 2, 2, cmd);
                    }
                    else
                    {
                        NextCmd = index + 3;
                    }
                    break;
                case 7:
                    // less than
                    if (GetValue(index + 1, 1, cmd) < GetValue(index + 2, 2, cmd))
                    {
                        _values[GetIndex(index + 3, 3, cmd)] = 1;
                    }
                    else
                    {
                        _values[GetIndex(index + 3, 3, cmd)] = 0;
                    }
                    NextCmd = index + 4;
                    break;
                case 8:
                    // equals
                    if (GetValue(index + 1, 1, cmd) == GetValue(index + 2, 2, cmd))
                    {
                        _values[GetIndex(index + 3, 3, cmd)] = 1;
                    }
                    else
                    {
                        _values[GetIndex(index + 3, 3, cmd)] = 0;
                    }
                    NextCmd = index + 4;
                    break;
                case 9:
                    // update relative base
                    long factor = GetValue(index + 1, 1, cmd);
                    _relativeBase += factor;
                    NextCmd = index + 2;
                    break;
                case 99:
                    return ProgramMode.Stop;
                default:
                    throw new ArgumentOutOfRangeException($"Out of range - cmd: {cmd}, index: {index}");
            }
            return ProgramMode.Continue;
        }

        public long GetValue(long index, long param, long cmd)
        {
            long idx2 = 0;
            CheckRAM(index);
            long mode = GetParameterMode(cmd, param);
            switch (mode)
            {
                case 0:
                    // position mode
                    idx2 = _values[index];
                    CheckRAM(idx2);
                    return _values[idx2];
                case 1:
                    // immediate mode the param is the value
                    return _values[index];
                case 2:
                    idx2 = _relativeBase + _values[index];
                    CheckRAM(idx2);
                    return _values[idx2];
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }
        }

        public int GetIndex(long index, long param, long cmd)
        {
            long idx2;
            CheckRAM(index);
            long mode = GetParameterMode(cmd, param);
            switch (mode)
            {
                case 0:
                    // position mode
                    idx2 = _values[index];
                    CheckRAM(idx2);
                    return Convert.ToInt32(idx2);
                case 1:
                    // immediate mode the param is the value
                    return Convert.ToInt32(index);
                case 2:
                    idx2 = _relativeBase + _values[index];
                    CheckRAM(idx2);
                    return Convert.ToInt32(idx2);
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }
        }

        private void CheckRAM(long index)
        {
            if (index >= _values.LongLength)
            {
                // expand memory
                int memBoost = Convert.ToInt32(index - _values.LongLength + 1024);
                Array.Resize<long>(ref _values, memBoost);
                //long[] vals = new long[memBoost];
                //_values.(vals);
            }
            if (index < 0)
            {
                throw new ArgumentException($"_values index is negative: {index}");
            }
        }

        public long GetParameterMode(long cmd, long param)
        {
            long mode = 0;
            switch (param)
            {
                case 1:
                    mode = (cmd % 1000) / 100;
                    break;
                case 2:
                    mode = (cmd % 10000) / 1000;
                    break;
                case 3:
                    mode = (cmd % 100000) / 10000;
                    break;
                default:
                    break;
            }
            return mode;
        }

        public void CopyProgram(List<long> pgm)
        {
            _values = new long[pgm.Count * 2];
            for (int i = 0; i < pgm.Count; i++)
            {
                _values[i] = pgm[i];
            }
        }
    }
}
