namespace AdventCode2022.Models
{
    public class CommandParser
    {
        private const long kMinSizeNeeded = 30000000;
        private const long kMaxDiskCapacity = 70000000;

        public Directory Root { get; set; }
        public Directory DirNow { get; set; }

        public CommandParser(string rootName)
        {
            Root = new Directory(rootName, null);
            DirNow = Root;
        }

        public void ParseIO(string input)
        {
            var cmdParts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmdParts.Length > 0)
            {
                if (string.Equals(cmdParts[0], "$"))
                {
                    // commands
                    HandleCommands(cmdParts);

                }
                else if (string.Equals(cmdParts[0], "dir"))
                {
                    // ls line of a directory - create it
                    DirNow.SubDirectories.Add(cmdParts[1], new Directory(cmdParts[1], DirNow));
                }
                else
                {
                    long size = long.Parse(cmdParts[0]);
                    DirNow.Files.Add(cmdParts[1], size);
                }
            }
        }

        public void HandleCommands(string[] cmdParts)
        {
            if (string.Equals(cmdParts[1], "cd"))
            {
                if (string.Equals(cmdParts[2], ".."))
                {
                    // go up
                    DirNow = DirNow.Parent;
                }
                else
                {
                    if (string.Equals(cmdParts[2], "/"))
                    {
                        // move to root
                        DirNow = Root;
                    }
                    else
                    {
                        // move to the directory, it should exist in sub dirs
                        DirNow = DirNow.SubDirectories[cmdParts[2]];
                    }
                }
            }
            else if (string.Equals(cmdParts[1], "ls"))
            {
                return;
            }
        }

        public long FindTotalForUnder100k()
        {
            long total = GetTotalForUnder100k(Root);
            return total;
        }

        public long GetTotalForUnder100k(Directory now)
        {
            long total = 0;
            if (now.Size <= 100000)
            {
                total += now.Size;
            }
            if (now.SubDirectories.Count > 0)
            {
                foreach (var subdir in now.SubDirectories.Values)
                {
                    total += GetTotalForUnder100k(subdir);
                }
            }
            return total;
        }

        public long FindSmallestDirectoryToDelete()
        {
            long totalNow = Root.Size;
            long minimalDirectorySizeNeeded = kMinSizeNeeded - (kMaxDiskCapacity - totalNow);

            long result = GetSmallestDirectory(Root, minimalDirectorySizeNeeded, totalNow);
            return result;
        }

        public long GetSmallestDirectory(Directory now, long minNeeded, long smallestNow)
        {
            long sizeNow = now.Size;
            if (sizeNow >= minNeeded && sizeNow < smallestNow)
            {
                smallestNow = sizeNow;
            }
            if (now.SubDirectories.Count > 0)
            {
                foreach (var subdir in now.SubDirectories.Values)
                {
                    smallestNow = GetSmallestDirectory(subdir, minNeeded, smallestNow);
                }
            }
            return smallestNow;
        }

    }
}
