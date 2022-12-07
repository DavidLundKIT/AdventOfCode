namespace AdventCode2022.Models
{
    public class Directory
    {
        public Directory(string name, Directory parent)
        {
            Parent = parent;
            DirName = name;
            Files = new Dictionary<string, long>();
            SubDirectories = new Dictionary<string, Directory>();
        }

        public Directory Parent { get; set; }
        public string DirName { get; set; }
        public Dictionary<string, long> Files { get; set; }
        public Dictionary<string, Directory> SubDirectories { get; set; }

        public long Size
        {
            get
            {
                long size = Files.Values.Sum() + SubDirectories.Values.Sum(sd => sd.Size);
                return size;
            }
        }
    }
}
