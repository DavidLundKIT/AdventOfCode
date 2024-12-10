namespace AdventCode2024.Models;

public class DiskFragmenter
{
    public int TotalBlocks { get; set; }
    public List<int> BlockGroups { get; set; }
    public int[] TheDisk { get; set; }
    public string OrgData { get; set; }

    public DiskFragmenter(string inData)
    {
        OrgData = inData;

        BlockGroups = inData.ToCharArray().Select(c => int.Parse(Convert.ToString(c))).ToList();

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
}
