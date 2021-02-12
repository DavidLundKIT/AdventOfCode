using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCodeLib
{
    public class Day02SpreadSheetChecksum
    {
        public int RowCheckSum(string row)
        {
            List<int> ivals = RowToIntList(row);
            int min = ivals.Min();
            int max = ivals.Max();
            int sum = max - min;
            return sum;
        }

        private List<int> RowToIntList(string row)
        {
            var vals = row.Split(null);
            int sum = vals.Length;
            List<int> ivals = new List<int>();
            foreach (var item in vals)
            {
                ivals.Add(int.Parse(item));
            }
            return ivals;
        }

        public int RowCheckSumDiv(string row)
        {
            int checksum = 0;
            List<int> ivals = RowToIntList(row);
            ivals.Sort();
            for (int i = 0; i < ivals.Count -1; i++)
            {
                for (int j = i+1; j < ivals.Count; j++)
                {
                    try
                    {
                        if (ivals[j] % ivals[i] == 0)
                        {
                            checksum += ivals[j] / ivals[i];
                        }
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }
            }
            return checksum;
        }

        public int CheckSum(IEnumerable<string> rows)
        {
            int checksum = 0;
            foreach (var row in rows)
            {
                checksum += RowCheckSum(row);
            }
            return checksum;
        }

        public int CheckSumFile(string filepath)
        {
            int checksum = 0;
            var rows = DataTools.ReadAllLines(filepath);
            checksum = CheckSum(rows);
            return checksum;
        }

        public int CheckSumFileDiv(string filepath)
        {
            int checksum = 0;
            var rows = DataTools.ReadAllLines(filepath);
            foreach (var row in rows)
            {
                checksum += RowCheckSumDiv(row);
            }
            return checksum;
        }
    }
}
