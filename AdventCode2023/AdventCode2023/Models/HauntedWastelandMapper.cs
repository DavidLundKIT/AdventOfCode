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

        public int SimultaneousStepsToEnd()
        {
            int steps = 0;

            return 0;
        }
    }


}
