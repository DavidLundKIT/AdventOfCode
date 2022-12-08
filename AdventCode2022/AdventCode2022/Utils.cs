namespace AdventCode2022
{
    public class Utils
    {
        public static string[] ReadLinesFromFile(string filename)
        {
            string baseDir = AppContext.BaseDirectory;
            string filePath = $"{baseDir}\\Data\\{filename}";
            string[] orbits = File.ReadAllLines(filePath);
            return orbits;
        }

        public static List<int> ReadIntsFromFile(string filename)
        {
            List<string> lines = ReadLinesFromFile(filename).ToList();
            return lines.Select(s => int.Parse(s)).ToList();
        }

        public static List<long> ReadLongsFromFile(string filename)
        {
            List<string> lines = ReadLinesFromFile(filename).ToList();
            return lines.Select(s => long.Parse(s)).ToList();
        }

        public static List<List<int>> ReadIntSquareFromFile(string filename)
        {
            List<List<int>> lists= new List<List<int>>();
            List<string> lines = ReadLinesFromFile(filename).ToList();
            foreach (string line in lines)
            {
                var lNow = new List<int>();
                for (int i = 0; i < line.Length; i++)
                {
                    lNow.Add(int.Parse(line.Substring(i, 1)));
                }
                lists.Add(lNow);
            }
            return lists;
        }
    }
}
