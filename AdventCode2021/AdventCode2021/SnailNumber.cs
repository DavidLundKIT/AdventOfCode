using System;
using System.IO;
using System.Text;

namespace AdventCode2021
{
    public class SnailNumber
    {
        public int A { get; set; }
        public int B { get; set; }
        public SnailNumber Parent { get; set; }
        public SnailNumber Left { get; set; }
        public SnailNumber Right { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            if (Left != null)
            {
                sb.Append(Left.ToString());
            }
            else
            {
                sb.Append(A);
            }
            sb.Append(",");
            if (Right != null)
            {
                sb.Append(Right.ToString());
            }
            else
            {
                sb.Append(B);
            }
            sb.Append(']');
            return sb.ToString();
        }

        public SnailNumber Split()
        {
            if (A > 9)
            {
                Left = MakeSplit(A, this);
                A = 0;
                return Left;
            }
            SnailNumber sn;
            if (Left != null)
            {
                sn = Left.Split();
                if (sn != null)
                {
                    return sn;
                }
            }
            if (B > 9)
            {
                Right = MakeSplit(B, this);
                B = 0;
                return Right;
            }
            if (Right != null)
            {
                sn = Right.Split();
                if (sn != null)
                {
                    return sn;
                }
            }
            return null;
        }

        public void Reduce()
        {
            SnailNumber explode = null;
            SnailNumber split = null;
            do
            {
                explode = Explode();
                if (explode == null)
                {
                    split = Split();
                }
            } while (explode != null || split != null);
        }

        public SnailNumber MakeSplit(int val, SnailNumber parent)
        {
            SnailNumber splitSn = new SnailNumber();

            splitSn.Parent = parent;
            splitSn.A = val / 2;
            splitSn.B = (val / 2) + val % 2;
            return splitSn;
        }

        public SnailNumber Explode()
        {
            SnailNumber explode = FindExplode(0);
            if (explode != null)
            {
                explode.ExplodeLeft(explode.A, explode);
                explode.ExplodeRight(explode.B, explode);
                explode.RemoveMe();
            }
            return explode;
        }

        public SnailNumber RemoveMe()
        {
            if (Parent != null && Parent.Left == this)
            {
                Parent.Left = null;
            }
            if (Parent != null && Parent.Right == this)
            {
                Parent.Right = null;
            }
            var temp = Parent;
            Parent = null;
            return temp;
        }

        public SnailNumber ExplodeLeft(int val, SnailNumber explode)
        {
            if (Parent == null)
            {
                return null;
            }
            SnailNumber sn;
            if (this == Parent.Left)
            {
                sn = Parent.ExplodeLeft(val, explode);
                if (sn == null)
                {
                    if (this == explode)
                    {
                        // not found set A to 0. 
                        Parent.A = 0;
                        return this;
                    }
                }
                return sn;
            }
            else
            {
                sn = Parent.AddRight(val, this);
                return sn;
            }
        }

        public SnailNumber ExplodeRight(int val, SnailNumber explode)
        {
            if (Parent == null)
            {
                return null;
            }
            SnailNumber sn;
            if (this == Parent.Right)
            {
                sn = Parent.ExplodeRight(val, explode);
                if (sn == null)
                {
                    if (this.Right == explode)
                    {
                        // not found set B to 0. 
                        B = 0;
                        return this;
                    }
                }
                return sn;
            }
            else
            {
                sn = Parent.AddLeft(val, this);
                return sn;
            }

        }

        public SnailNumber AddRight(int val, SnailNumber snr)
        {
            if (Right != null)
            {
                if (Right == snr)
                {
                    if (Left == null)
                    {
                        A += val;
                        return this;
                    }
                    return Left.AddRight(val, snr);
                }
                return Right.AddRight(val, snr);
            }
            // right is null found most right to the left of the exploder
            B += val;
            return this;
        }


        public SnailNumber AddLeft(int val, SnailNumber snr)
        {
            if (Left != null)
            {
                if (Left == snr)
                {
                    if (Right == null)
                    {
                        B += val;
                        return this;
                    }
                    return Right.AddLeft(val, snr);
                }
                return Left.AddLeft(val, snr);
            }
            // Left is null found most Left most to the right of the exploder
            A += val;
            return this;
        }

        public SnailNumber FindExplode(int level)
        {
            if (level == 4)
            {
                return this;
            }
            ++level;
            SnailNumber explode = null;
            if (Left != null)
            {
                explode = Left.FindExplode(level);
                if (explode != null)
                    return explode;
            }
            if (Right != null)
            {
                explode = Right.FindExplode(level);
                if (explode != null)
                    return explode;
            }
            return null;
        }

        public SnailNumber Add(SnailNumber b)
        {
            SnailNumber sn = new SnailNumber();
            sn.Left = this;
            this.Parent = sn;
            sn.Right = b;
            sn.Right.Parent = sn;
            return sn;
        }

        public long Magnitude()
        {
            long mag = 0;
            if (Left != null)
                mag = 3*Left.Magnitude();
            else
                mag = 3*A;

            if (Right != null)
                mag += 2 * Right.Magnitude();
            else
                mag += 2 * B;
            return mag;
        }

        public static SnailNumber Builder(string line)
        {
            using StringReader sreader = new StringReader(line);
            SnailNumber root = Parser(sreader, false);
            return root;
        }

        public static SnailNumber Parser(StringReader srdr, bool readLeftBrace)
        {
            SnailNumber sn = new SnailNumber();
            bool left = true;
            while (srdr.Peek() != -1)
            {
                var ch = (char)srdr.Read();
                switch (ch)
                {
                    case '[':
                        if (readLeftBrace)
                        {
                            // start of a new snailnumber
                            if (left)
                            {
                                sn.Left = Parser(srdr, true);
                                sn.Left.Parent = sn;
                                left = false;
                            }
                            else
                            {
                                sn.Right = Parser(srdr, true);
                                sn.Right.Parent = sn;
                            }
                        }
                        else
                        {
                            readLeftBrace = true;
                        }
                        break;
                    case ']':
                        return sn;
                    case ',':
                        left = false;
                        break;
                    case ' ':
                        break;
                    default:
                        // digits?
                        if (char.IsDigit(ch))
                        {
                            int val = (int)ch - '0';
                            if ((srdr.Peek() != -1) && (char.IsDigit((char)srdr.Peek())))
                            {
                                // debugging tests 
                                val = (val * 10) + (int) ((char)srdr.Read() -'0');
                            }
                            if (left)
                            {
                                sn.A = val;
                                left = false;
                            }
                            else
                            {
                                sn.B = val;
                            }
                        }
                        else
                        {
                            throw new ArgumentException($"Char: {ch} is not expected");
                        }
                        break;
                }
            }
            return sn;
        }
    }
}
