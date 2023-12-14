namespace AdventCode2023.Models
{
    public class HauntedWastelandMapper
    {
        public string Instructions { get; set; }

        public Dictionary<string, Tuple<string, string>> Mapper { get; set; }
        public HauntedWastelandMapper(string[] lines)
        {
            Mapper = new Dictionary<string, Tuple<string, string>>();
            Instructions = lines[0];

            for (int i = 2; i < lines.Length; i++)
            {
                var temp = lines[i].Split(new char[] { ' ', ',', '=', '(', ')' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                Mapper.Add(temp[0], new Tuple<string, string>(temp[1], temp[2]));
            }
        }

        public int StepsToEnd(string startKey, string endKey)
        {
            int steps = 0;
            string key = startKey;
            do
            {
                foreach (char ch in Instructions)
                {
                    steps++;
                    var map = Mapper[key];
                    if (ch == 'R')
                    {
                        key = map.Item2;
                    }
                    else
                    {
                        key = map.Item1;
                    }
                    if (key.Equals(endKey))
                    {
                        return steps;
                    }
                }
            } while (true);
        }


        public long StepsToAllEndWithZ()
        {
            List<string> keys = Mapper.Keys.Where(k => k.EndsWith("A")).ToList();
            List<long> steps = new List<long>();

            foreach (string key in keys)
            {
                long step = StepsToEndWithZ(key);
                steps.Add(step);
            }

            long totalSteps = steps[0];
            for (int i = 1; i < steps.Count; ++i)
            {
                totalSteps = LCM(totalSteps, steps[i]);
            }
            return totalSteps;
        }

        public long StepsToEndWithZ(string startKey)
        {
            long steps = 0;
            string key = startKey;
            do
            {
                foreach (char ch in Instructions)
                {
                    steps++;
                    var map = Mapper[key];
                    if (ch == 'R')
                    {
                        key = map.Item2;
                    }
                    else
                    {
                        key = map.Item1;
                    }
                    if (key.EndsWith("Z"))
                    {
                        return steps;
                    }
                }
            } while (true);
        }

        /// <summary>
        /// Didn't work within several hours on the actual data.
        /// </summary>
        /// <returns></returns>
        public int SimultaneousStepsToEnd()
        {
            int steps = 0;
            List<string> keys = Mapper.Keys.Where(k => k.EndsWith("A")).ToList();
            int allAs = keys.Count;

            do
            {
                foreach (char ch in Instructions)
                {
                    steps++;
                    for (int i = 0; i < allAs; i++)
                    {
                        if (ch == 'R')
                        {
                            keys[i] = Mapper[keys[i]].Item2;
                        }
                        else
                        {
                            keys[i] = Mapper[keys[i]].Item1;
                        }
                    }
                    int allZs = keys.Where(k => k.EndsWith("Z")).ToList().Count;
                    if (allZs == allAs)
                    {
                        return steps;
                    }
                }
            } while (true);
        }

        /// <summary>
        /// Greatest common factor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public long GCF(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Least common multiple
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public long LCM(long a, long b)
        {
            return (a / GCF(a, b)) * b;
        }
    }
}
