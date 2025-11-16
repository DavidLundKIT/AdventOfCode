using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay14UnitTests
{
    private string inputsData = "106,118,236,1,130,0,235,254,59,205,2,87,129,25,255,118";

    public Day10HashKnot sut { get; set; }

    public AdventDay14UnitTests()
    {
        sut = new Day10HashKnot();
    }

    [Fact]
    public void Day14_Day10TestSolutionB()
    {
        string actual = sut.DenseHash(inputsData);
        Assert.Equal("9d5f4561367d379cfbf04f8c471c0095", actual);
    }

    [Fact]
    public void Day14_TestRun01()
    {
        string input = "flqrgnkx-0";
        string actual = sut.DenseHash(input);
        string bin = sut.BinaryString(actual);
        Assert.Equal(128, bin.Length);
        Assert.Equal("11010100", bin.Substring(0, 8));

        input = "flqrgnkx-1";
        actual = sut.GetBinaryHash(input);
        Assert.Equal("01010101", actual.Substring(0, 8));

        input = "flqrgnkx-2";
        actual = sut.GetBinaryHash(input);
        Assert.Equal("00001010", actual.Substring(0, 8));
    }

    [Fact]
    public void Day14_TestRun02()
    {
        string key = "flqrgnkx";
        string input;
        string binaryRow;
        int blocks = 0;
        var regions = new int[128, 128];

        for (int i = 0; i < 128; i++)
        {
            input = $"{key}-{i}";
            binaryRow = sut.GetBinaryHash(input);
            blocks += sut.UsedBlocks(binaryRow);
            sut.AddRegion(regions, binaryRow, i);
        }
        Assert.Equal(8108, blocks);
        blocks = 0;
        for (int j = 0; j < 128; j++)
        {
            for (int k = 0; k < 128; k++)
            {
                if (regions[j, k] == -1)
                    blocks++;
            }
        }
        Assert.Equal(8108, blocks);

        int nRegions = sut.RegionsFound(regions);
        Assert.Equal(1242, nRegions);
    }

    [Fact]
    public void Day14_SolutionA()
    {
        string key = "oundnydw";
        string input;
        string binaryRow;
        int blocks = 0;
        var regions = new int[128, 128];

        for (int i = 0; i < 128; i++)
        {
            input = $"{key}-{i}";
            binaryRow = sut.GetBinaryHash(input);
            blocks += sut.UsedBlocks(binaryRow);
            sut.AddRegion(regions, binaryRow, i);
        }
        Assert.Equal(8106, blocks);

        int nRegions = sut.RegionsFound(regions);
        Assert.Equal(1164, nRegions);
    }
}
