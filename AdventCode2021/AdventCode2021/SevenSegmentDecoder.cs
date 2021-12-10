using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCode2021
{
    public class SevenSegmentDecoder
    {
        public List<Display> Displays { get; set; }

        public SevenSegmentDecoder(string[] lines)
        {
            Displays = new List<Display>();

            foreach (var line in lines)
            {
                var disp = new Display(line);
                Displays.Add(disp);
            }
        }

        public int CountUniqueDigits()
        {
            int count = 0;
            foreach (var disp in Displays)
            {
                int val = disp.CountUniqueDigits();
                count += val;
            }
            return count;
        }

        public long SumAllDisplays()
        {
            long total = 0;
            foreach (var disp in Displays)
            {
                int val = disp.Decode();
                total += val;
            }
            return total;
        }
    }

    public class Display
    {
        public Dictionary<string,int> UniqueValues { get; set; }
        public List<string> DisplayValues { get; set; }
        public Dictionary<int, string> Digits { get; set; }

        public char A { get; set; }
        public char B { get; set; }
        public char C { get; set; }
        public char D { get; set; }
        public char E { get; set; }
        public char F { get; set; }
        public char G { get; set; }

        public Display(string line)
        {
            var parts = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
            var uvs = parts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            UniqueValues = new Dictionary<string, int>();
            foreach (var uv in uvs)
            {
                UniqueValues.Add(uv, -1);
            }

            var dvs = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            DisplayValues = new List<string>(dvs);
            Digits = new Dictionary<int, string>();
        }

        public int CountUniqueDigits()
        {
            int count = 0;

            foreach (var digit in DisplayValues)
            {
                int len = digit.Length;
                switch (len)
                {
                    case 2:
                        // 1
                        count++;
                        break;
                    case 3:
                        // 7
                        count++;
                        break;
                    case 4:
                        // 4
                        count++;
                        break;
                    case 7:
                        // 8
                        count++;
                        break;
                    default:
                        break;
                }
            }
            return count;
        }

        public void FindUniqueDigits()
        {
            // 1
            var digit = UniqueValues.Single(uv => uv.Key.Length == 2);
            Digits.Add(1, digit.Key);
            // 7
            digit = UniqueValues.SingleOrDefault(uv => uv.Key.Length == 3);
            Digits.Add(7, digit.Key);
            // 4
            digit = UniqueValues.SingleOrDefault(uv => uv.Key.Length == 4);
            Digits.Add(4, digit.Key);
            // 8
            digit = UniqueValues.SingleOrDefault(uv => uv.Key.Length == 7);
            Digits.Add(8, digit.Key);
        }

        public void FindA()
        {
            var hs1 = new HashSet<char>(Digits[1].ToCharArray());
            var hs7 = new HashSet<char>(Digits[7].ToCharArray());
            hs7.ExceptWith(hs1);
            if (hs7.Count == 1)
            {
                A = hs7.Single();
            }
        }

        public void FindGand9()
        {
            var coll = UniqueValues.Where(uv => uv.Key.Length == 6).ToList();
            foreach (var uv in coll)
            {
                var hs = new HashSet<char>(uv.Key.ToCharArray());
                var chs = new List<char>(Digits[4].ToCharArray());
                chs.Add(A);
                hs.ExceptWith(chs);
                if (hs.Count == 1)
                {
                    G = hs.Single();
                    Digits.Add(9, uv.Key);
                    return;
                }
            }
        }

        public void Find6and0()
        {
            var hs1 = new HashSet<char>(Digits[1].ToCharArray());
            var coll = UniqueValues.Where(uv => uv.Key.Length == 6).ToList();
            foreach (var uv in coll)
            {
                var hs = new HashSet<char>(Digits[8].ToCharArray());
                hs.ExceptWith(uv.Key.ToCharArray());
                char ch = hs.Single();
                if (hs1.Contains(ch))
                {
                    Digits.Add(6, uv.Key);
                    C = ch;
                }
                else if (Digits[9] == uv.Key)
                {
                    // 9 already found
                    ;
                }
                else
                { 
                    // D
                    D = ch;
                    Digits.Add(0, uv.Key);
                }
            }
        }

        public void FindTwoThreeFive()
        {
            var hs1 = new HashSet<char>(Digits[1].ToCharArray());
            var coll = UniqueValues.Where(uv => uv.Key.Length == 5).ToList();
            foreach (var uv in coll)
            {
                var hs = new HashSet<char>(uv.Key.ToCharArray());
                if (hs1.IsProperSubsetOf(hs))
                {
                    Digits.Add(3, uv.Key);
                }
                else if (hs.Contains(C))
                {
                    Digits.Add(2, uv.Key);
                }
                else
                {
                    Digits.Add(5, uv.Key);
                }
            }
        }

        public int ReadDisplay()
        {
            int value = DisplayToDigit(DisplayValues[0])*1000;
            value += DisplayToDigit(DisplayValues[1]) * 100;
            value += DisplayToDigit(DisplayValues[2]) * 10;
            value += DisplayToDigit(DisplayValues[3]);
            return value;
        }

        public int DisplayToDigit(string disp)
        {
            var hs = new HashSet<char>(disp.ToCharArray());
            foreach (var digit in Digits)
            {
                if (hs.SetEquals(digit.Value.ToCharArray()))
                {
                    return digit.Key;
                }
            }
            throw new ArgumentOutOfRangeException("disp");
        }

        public int Decode()
        {
            FindUniqueDigits();
            FindA();
            FindGand9();
            Find6and0();
            FindTwoThreeFive();
            int actual = ReadDisplay();
            return actual;
        }
    }
}
