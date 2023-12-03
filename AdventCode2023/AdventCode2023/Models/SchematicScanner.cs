using System.Text.RegularExpressions;

namespace AdventCode2023.Models
{
    public class SchematicScanner
    {
        public List<int> Parts { get; set; }
        public Dictionary<Tuple<int, int>, GearRatio> GearRatios { get; set; }
        public string[] Schematic { get; set; }
        public int xMax { get; set; }
        public int yMax { get; set; }

        public SchematicScanner(string[] schematic)
        {
            Parts = new List<int>();
            GearRatios = new Dictionary<Tuple<int, int>, GearRatio>();

            Schematic = schematic;
            yMax = schematic.Length;
            xMax = schematic[0].Length;
        }

        public void ScanSchematic()
        {
            for (int iline = 0; iline < Schematic.Length; iline++)
            {
                ScanSchematicLine(Schematic[iline], iline);
            }
        }

        public void ScanSchematicLine(string line, int iline)
        {
            var matches = Regex.Matches(line, @"\d+");
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    int part = int.Parse(match.Value);
                    if (isPart(match.Index, iline, match.Length))
                    {
                        Parts.Add(part);
                    }
                }
            }
        }

        private bool isPart(int index, int iline, int length)
        {
            int x0 = (index - 1) < 0 ? 0 : index - 1;
            int xN = (index + length + 1) < xMax ? index + length + 1 : xMax;
            int y0 = (iline - 1) < 0 ? 0 : iline - 1;
            int yN = (iline + 1) < yMax - 1 ? iline + 1 : yMax - 1;

            for (int y = y0; y <= yN; y++)
            {
                for (int x = x0; x < xN; x++)
                {
                    char ch = Schematic[y][x];
                    if (ch != '.' && !char.IsDigit(ch))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void GetGearRatios()
        {
            for (int iline = 0; iline < Schematic.Length; iline++)
            {
                FindGearRatio(Schematic[iline], iline);
            }
        }

        public void FindGearRatio(string line, int iline)
        {
            var matches = Regex.Matches(line, @"\d+");
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    int gear = int.Parse(match.Value);
                    var pt = isGearPart(match.Index, iline, match.Length);
                    if (pt != null)
                    {
                        if (GearRatios.ContainsKey(pt))
                        {
                            // second match
                            GearRatios[pt].Gear2 = gear;
                        }
                        else
                        {
                            GearRatios.Add(pt, new GearRatio(gear));
                        }
                    }
                }
            }
        }

        public Tuple<int, int>? isGearPart(int index, int iline, int length)
        {
            int x0 = (index - 1) < 0 ? 0 : index - 1;
            int xN = (index + length + 1) < xMax ? index + length + 1 : xMax;
            int y0 = (iline - 1) < 0 ? 0 : iline - 1;
            int yN = (iline + 1) < yMax - 1 ? iline + 1 : yMax - 1;

            for (int y = y0; y <= yN; y++)
            {
                for (int x = x0; x < xN; x++)
                {
                    char ch = Schematic[y][x];
                    if (ch == '*')
                    {
                        return new Tuple<int, int>(x, y);
                    }
                }
            }
            return null;
        }

        public int GearRatioSum()
        {
            int sum = 0;

            if (GearRatios.Count > 0)
            {
                foreach (GearRatio gr in GearRatios.Values)
                {
                    sum += gr.Ratio();
                }
            }
            return sum;
        }
    }

    public class GearRatio
    {
        public int Gear1 { get; set; }
        public int Gear2 { get; set; }

        public GearRatio(int gear)
        {
            Gear1 = gear;
            Gear2 = 0;
        }

        public int Ratio()
        {
            return Gear1 * Gear2;
        }
    }
}
