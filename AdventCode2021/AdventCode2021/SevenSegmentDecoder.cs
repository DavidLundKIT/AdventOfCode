using System;
using System.Collections.Generic;
using System.Text;

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
    }

    public class Display
    {
        public List<string> UniqueValues { get; set; }
        public List<string> DisplayValues { get; set; }
        public Dictionary<int, string> Digits { get; set; }

        public Display(string line)
        {
            var parts = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
            var uvs = parts[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            UniqueValues = new List<string>(uvs);

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
            foreach (var digit in UniqueValues)
            {
                int len = digit.Length;
                switch (len)
                {
                    case 2:
                        // 1
                        Digits.Add(1, digit);
                        break;
                    case 3:
                        // 7
                        Digits.Add(7, digit);
                        break;
                    case 4:
                        // 4
                        Digits.Add(4, digit);
                        break;
                    case 7:
                        // 8
                        Digits.Add(8, digit);
                        break;
                    default:
                        break;
                }
            }
        }

        public int Decode()
        {
            FindUniqueDigits();
            return 0;
        }
    }
}
