namespace AdventOfCode2020
{
    public class PasswordChecker
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public string Line { get; set; }
        public string Letter { get; set; }
        public string Password { get; set; }
        public PasswordChecker(string line)
        {
            Line = line;
            var parts = line.Split(new char[] { ' ', '-' });
            Min = int.Parse(parts[0]);
            Max = int.Parse(parts[1]);
            Letter = parts[2].Substring(0, 1);
            Password = parts[3];
        }

        public bool IsValid()
        {
            var chs = Password.ToCharArray();
            int count = 0;
            foreach (var ch in chs)
            {
                if (ch == Letter[0])
                {
                    count++;
                }
            }

            return (Min <= count && count <= Max);
        }

        public bool IsValidNew()
        {
            var chMin = Min - 1 < Password.Length ? Password[Min - 1] : ' ';
            var chMax = Max - 1 < Password.Length ? Password[Max - 1] : ' ';
            return (chMin == Letter[0] && chMax != Letter[0]) || (chMin != Letter[0] && chMax == Letter[0]);
        }
    }
}
