namespace AdventCode2023.Models
{
    public class LensLibraryProcessor
    {
        public string[] Lines { get; set; }
        public Dictionary<int, List<Tuple<string, int>>> LensBoxes { get; set; }

        public LensLibraryProcessor(string line)
        {
            Lines = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            LensBoxes = new Dictionary<int, List<Tuple<string, int>>>();
        }

        public void ProcessLensCmdsToBoxes()
        {
            string lens = string.Empty;
            int hash = -1;
            int lensValue = 0;
            LensBoxes.Clear();

            foreach (string line in Lines)
            {
                if (line.Contains("-"))
                {
                    lens = line.Substring(0, line.Length - 1);
                    hash = HashLine(lens);
                    if (LensBoxes.ContainsKey(hash))
                    {
                        var lensTuple = LensBoxes[hash].FirstOrDefault(l => l.Item1.Equals(lens));
                        if (lensTuple != null)
                        {
                            // remove it
                            LensBoxes[hash].Remove(lensTuple);
                            // remove LensBox if no Lenses left
                            if (!LensBoxes[hash].Any())
                            {
                                LensBoxes.Remove(hash);
                            }
                        }
                    }
                    // else no lens box to remove something
                }
                else
                {
                    // add a lens
                    var temp = line.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    lens = temp[0];
                    lensValue = int.Parse(temp[1]);
                    hash = HashLine(lens);
                    if (!LensBoxes.ContainsKey(hash))
                    {
                        List<Tuple<string, int>> lensList = new List<Tuple<string, int>>();
                        lensList.Add(new Tuple<string, int>(lens, lensValue));
                        LensBoxes.Add(hash, lensList);
                    }
                    else
                    {
                        var lensTuple = LensBoxes[hash].FirstOrDefault(l => l.Item1.Equals(lens));
                        if (lensTuple != null)
                        {
                            // found it, remove old
                            int idx = LensBoxes[hash].IndexOf(lensTuple);
                            LensBoxes[hash].RemoveAt(idx);
                            // add new one
                            LensBoxes[hash].Insert(idx, new Tuple<string, int>(lens, lensValue));
                        }
                        else
                        {
                            LensBoxes[hash].Add(new Tuple<string, int>(lens, lensValue));
                        }
                    }
                }
            }
        }

        public long CalcFocusingPower()
        {
            long totalFocusingPower = 0;

            foreach (var lensBox in LensBoxes)
            {
                for (int i = 0; i < lensBox.Value.Count; i++)
                {
                    int focusPower = (lensBox.Key + 1) * (i + 1) * lensBox.Value[i].Item2;
                    totalFocusingPower += focusPower;
                }
            }
            return totalFocusingPower;
        }

        public int HashAllLines()
        {
            int hashTotal = 0;

            foreach (string line in Lines)
            {
                hashTotal += HashLine(line);
            }
            return hashTotal;
        }

        public int HashLine(string line)
        {
            int hash = 0;
            foreach (char ch in line)
            {
                hash += (int)ch;
                hash *= 17;
                hash = hash % 256;
            }
            return hash;
        }
    }
}
