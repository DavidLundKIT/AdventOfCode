namespace AdventCode2023.Models
{
    public class LensLibraryProcessor
    {
        public string[] Lines { get; set; }
        public LensLibraryProcessor(string line)
        {
            Lines = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
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
