namespace AdventCode2024.Models;

public class DiskFragmenter
{
    public int TotalBlocks { get; set; }
    public List<int> BlockGroups { get; set; }
    public List<int> Indices { get; set; }
    public int[] TheDisk { get; set; }
    public string OrgData { get; set; }

    public DiskFragmenter(string inData)
    {
        OrgData = inData;

        BlockGroups = inData.ToCharArray().Select(c => int.Parse(Convert.ToString(c))).ToList();
        Indices = new List<int>();
        int sum = 0;
        foreach (var group in BlockGroups)
        {
            Indices.Add(sum);
            sum += group;
        }
        TotalBlocks = BlockGroups.Sum();
        TheDisk = new int[TotalBlocks];
    }

    public void FillTheDisk()
    {
        int idx = 0;
        int fileId = 0;
        for (int i = 0; i < BlockGroups.Count; i++)
        {
            int blockSize = BlockGroups[i];
            int value = 0;
            if (i % 2 == 0)
            {
                // file
                value = fileId++;
            }
            for (int j = 0; j < blockSize; j++)
            {
                TheDisk[idx++] = value;
            }
        }
    }

    public void FragmentTheDisk()
    {
        int firstFileSize = BlockGroups[0];
        int idx = TheDisk.Length - 1;
        for (int i = firstFileSize; i < TheDisk.Length; i++)
        {
            while (TheDisk[i] == 0 && i < idx)
            {
                // empty
                if (TheDisk[idx] != 0)
                {
                    TheDisk[i] = TheDisk[idx];
                    TheDisk[idx--] = 0;
                }
                else
                {
                    idx--;
                }
            }
        }
    }

    public long ChecksumTheDisk()
    {
        long sum = 0;
        for (int i = 0; i < TheDisk.Length; i++)
        {
            sum += Convert.ToInt64(TheDisk[i] * i);
        }
        return sum;
    }

    public void DeFragmentTheDisk()
    {
        int freeIndex = 1;
        int fileIndex = BlockGroups.Count - 1;
        int fileBlocks = BlockGroups[fileIndex];
        do
        {
            while (freeIndex < fileIndex)
            {
                if (BlockGroups[freeIndex] > 0 && BlockGroups[freeIndex] >= fileBlocks)
                {
                    // a place for the file
                    int insIndex = Indices[freeIndex];
                    int blocks = BlockGroups[fileIndex];
                    for (int i = insIndex, j = Indices[fileIndex]; i < insIndex + blocks; ++i, ++j)
                    {
                        TheDisk[i] = TheDisk[j];
                        TheDisk[j] = 0;
                        Indices[freeIndex]++;
                        BlockGroups[freeIndex]--;
                    }
                    break;
                }
                else
                {
                    // either no free space or not enough free space
                    freeIndex += 2;
                }
            }
            fileIndex -= 2;
            freeIndex = 1;
            fileBlocks = BlockGroups[fileIndex];
        } while (freeIndex < fileIndex);
    }
}
