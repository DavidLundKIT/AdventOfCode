using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class DockingDataUnit
    {
        public Dictionary<long, long> DockingData { get; set; }
        public string Mask { get; set; }
        public char[] MaskArray { get; set; }

        public DockingDataUnit()
        {
            DockingData = new Dictionary<long, long>();
        }

        public long ProcessData(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentNullException(nameof(line));

            if (line.StartsWith("mask = "))
            {
                // update the mask
                Mask = line.Substring(7);
                MaskArray = Mask.ToCharArray();
                return 0;
            }
            // line of data 
            var parts = line.Split(new char[] { '=' });
            long mem = long.Parse(parts[0].Replace("mem[", "").Replace("]", "").Trim());
            long value = long.Parse(parts[1].Trim());
            string bval = Convert.ToString(value, 2).PadLeft(36).Replace(" ", "0");
            var bvalarr = bval.ToCharArray();
            int len = Math.Max(bvalarr.Length, MaskArray.Length);
            for (int i = 0; i < len; i++)
            {
                bvalarr[i] = MaskArray[i] == 'X' ? bvalarr[i] : MaskArray[i];
            }
            bval = string.Join(null, bvalarr);
            value = Convert.ToInt64(bval, 2);
            if (DockingData.ContainsKey(mem))
            {
                DockingData[mem] = value;
            }
            else
            {
                DockingData.Add(mem, value);
            }
            return value;
        }

        public long ProcessData2(string line)
        {
            // decoder 2
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentNullException(nameof(line));

            if (line.StartsWith("mask = "))
            {
                // update the mask
                Mask = line.Substring(7);
                MaskArray = Mask.ToCharArray();
                return 0;
            }
            // line of data 
            var parts = line.Split(new char[] { '=' });
            long mem = long.Parse(parts[0].Replace("mem[", "").Replace("]", "").Trim());
            long value = long.Parse(parts[1].Trim());

            string bmem = Convert.ToString(mem, 2).PadLeft(36).Replace(" ", "0");
            var bmemarr = bmem.ToCharArray();
            int len = Math.Max(bmemarr.Length, MaskArray.Length);
            for (int i = 0; i < len; i++)
            {
                switch (MaskArray[i])
                {
                    case '0':
                        // 0 don't change anything
                        break;
                    case '1':
                        bmemarr[i] = '1';
                        break;
                    default:
                        bmemarr[i] = 'X';
                        break;
                }
            }
            bmem = string.Join(null, bmemarr);
            var memArr = GenerateMemoryAddresses(bmem);
            foreach (var addr in memArr)
            {
                if (DockingData.ContainsKey(addr))
                {
                    DockingData[addr] = value;
                }
                else
                {
                    DockingData.Add(addr, value);
                }
            }
            return value;
        }

        public List<long> GenerateMemoryAddresses(string bmemadr)
        {
            List<string> bmemAddresses = new List<string>();
            bmemAddresses.Add(bmemadr);

            do
            {
                int idx = bmemAddresses[0].IndexOf('X');
                int lenNow = bmemAddresses.Count;
                var regex = new Regex(Regex.Escape("X"));
                for (int i = 0; i < lenNow; i++)
                {
                    var bmem0 = regex.Replace(bmemAddresses[i], "0", 1);
                    bmemAddresses.Add(bmem0);
                    var bmem1 = regex.Replace(bmemAddresses[i], "1", 1);
                    bmemAddresses[i] = bmem1;
                }
            } while (bmemAddresses.Any(b => b.IndexOf('X') >= 0));

            List<long> memAddresses = new List<long>();
            foreach (var bmem in bmemAddresses)
            {
                memAddresses.Add(Convert.ToInt64(bmem, 2));
            }
            return memAddresses;
        }

        public long Sum()
        {
            long sum = DockingData.Values.Sum();
            return sum;
        }
    }
}
