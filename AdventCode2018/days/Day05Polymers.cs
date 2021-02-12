using days;
using System;

namespace day05
{
    public class Day05Polymers
    {
        public string[] ReadDataFile(string datapath)
        {
            var rows = DataHelpers.ReadLinesFromFile(datapath);
            return rows;
        }

        public string React(string poly)
        {
            bool reacted = false;
            string result = poly;
            do
            {
                reacted = false;
                int len = result.Length;
                if (len >= 2)
                {
                    for (int i = 0, j=1; i < len - 1 && j < len; i++, j++)
                    {
                        char chi = result[i];
                        char chj = result[j];
                        if (chi != chj && Char.ToUpper(chi) == Char.ToUpper(chj))
                        {
                            result = result.Remove(i,2);
                            reacted = true;
                            break;
                        }
                    }
                }
            } while (reacted);
            return result;
        }

        public string RemoveUnit(string poly, string unit)
        {
            string result = poly.Replace(unit, "");
            result = result.Replace(unit.ToUpper(), "");
            return result;
        }


    }
}
