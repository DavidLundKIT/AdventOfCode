using AdventCodeLib;

namespace AdventCode2017;

public class AdventDay13UnitTests
{
    string pathdata = "Adventday13.txt";
    string pathtest = "Adventday13test.txt";
    public Day13Firewall sut { get; set; }

    public AdventDay13UnitTests()
    {
        sut = new Day13Firewall();
    }

    [Fact]
    public void Day13_TestRun01()
    {
        sut.ParseFirewall(pathtest);
        Assert.Equal(4, sut.Firewall.Count);
        Assert.Equal(0, sut.SeverityScore(0, 0));
        Assert.Equal(0, sut.SeverityScore(1, 1));
        Assert.Equal(0, sut.SeverityScore(2, 2));
        Assert.Equal(0, sut.SeverityScore(3, 3));
        Assert.Equal(0, sut.SeverityScore(4, 4));
        Assert.Equal(0, sut.SeverityScore(5, 5));
        Assert.Equal(24, sut.SeverityScore(6, 6));
    }

    [Fact]
    public void Day13_TestScannerPosition_Depth3()
    {
        sut.ParseFirewall(pathtest);
        Assert.True(sut.IsScannerThere(0, 3));
        Assert.False(sut.IsScannerThere(1, 3));
        Assert.False(sut.IsScannerThere(2, 3));
        Assert.False(sut.IsScannerThere(3, 3));
        Assert.True(sut.IsScannerThere(4, 3));
        Assert.False(sut.IsScannerThere(5, 3));
        Assert.False(sut.IsScannerThere(6, 3));
    }

    [Fact]
    public void Day13_TestScannerPosition_10step()
    {
        sut.ParseFirewall(pathtest);
        Assert.Equal(2, sut.ScannerPosition(10, 3));
        Assert.Equal(0, sut.ScannerPosition(10, 2));
        Assert.Equal(2, sut.ScannerPosition(10, 4));
    }

    [Fact]
    public void Day13_TestRun02()
    {
        sut.ParseFirewall(pathtest);
        Assert.Equal(4, sut.Firewall.Count);
        int score = 0;
        int maxLayer = sut.Firewall.Keys.Max();
        for (int i = 0; i < maxLayer + 1; i++)
        {
            score += sut.SeverityScore(i, i);
        }
        Assert.Equal(24, score);
    }

    [Fact]
    public void TrackDepth2movements()
    {
        Assert.Equal(0, sut.ScannerPosition(0, 2));
        Assert.Equal(1, sut.ScannerPosition(1, 2));
        Assert.Equal(0, sut.ScannerPosition(2, 2));
        Assert.Equal(1, sut.ScannerPosition(3, 2));
    }

    [Fact]
    public void TrackDepth3movements()
    {
        Assert.Equal(0, sut.ScannerPosition(0, 3));
        Assert.Equal(1, sut.ScannerPosition(1, 3));
        Assert.Equal(2, sut.ScannerPosition(2, 3));
        Assert.Equal(1, sut.ScannerPosition(3, 3));
        Assert.Equal(0, sut.ScannerPosition(4, 3));
        Assert.Equal(1, sut.ScannerPosition(5, 3));
        Assert.Equal(2, sut.ScannerPosition(6, 3));
        Assert.Equal(1, sut.ScannerPosition(7, 3));
        Assert.Equal(0, sut.ScannerPosition(8, 3));
        Assert.Equal(1, sut.ScannerPosition(9, 3));
    }

    [Fact]
    public void TrackDepth4Movements()
    {
        Assert.Equal(0, sut.ScannerPosition(0, 4));
        Assert.Equal(1, sut.ScannerPosition(1, 4));
        Assert.Equal(2, sut.ScannerPosition(2, 4));
        Assert.Equal(3, sut.ScannerPosition(3, 4));
        Assert.Equal(2, sut.ScannerPosition(4, 4));
        Assert.Equal(1, sut.ScannerPosition(5, 4));
        Assert.Equal(0, sut.ScannerPosition(6, 4));
        Assert.Equal(1, sut.ScannerPosition(7, 4));
        Assert.Equal(2, sut.ScannerPosition(8, 4));
        Assert.Equal(3, sut.ScannerPosition(9, 4));
        Assert.Equal(2, sut.ScannerPosition(10, 4));
        Assert.Equal(1, sut.ScannerPosition(11, 4));
        Assert.Equal(0, sut.ScannerPosition(12, 4));
    }

    [Fact]
    public void Day13_TestRun03()
    {
        sut.ParseFirewall(pathtest);
        Assert.Equal(4, sut.Firewall.Count);
        int score = 0;
        int maxLayer = sut.Firewall.Keys.Max();
        int delay = 6;
        do
        {
            delay++;
            score = 0;
            for (int i = 0; i < maxLayer + 1; i++)
            {
                score += sut.SeverityScore(i + delay, i);
            }
        } while (score != 0);
        Assert.Equal(10, delay);
    }

    [Fact]
    public void Day13_TestRun_SolutionA()
    {
        sut.ParseFirewall(pathdata);
        Assert.Equal(44, sut.Firewall.Count);
        int score = 0;
        int maxLayer = sut.Firewall.Keys.Max();
        for (int i = 0; i < maxLayer + 1; i++)
        {
            score += sut.SeverityScore(i, i);
        }
        Assert.Equal(2160, score);
    }

    [Fact]
    public void Day13_TestRun_SolutionB()
    {
        // 33600
        sut.ParseFirewall(pathdata);
        int score = 0;
        int maxLayer = sut.Firewall.Keys.Max();
        long delay = 0;
        do
        {
            delay++;
            score = 0;
            if (sut.ScannerPosition(delay, 3) == 0)
            {
                score = 1;
            }
            else
            {
                for (int i = 0; i < maxLayer + 1; i++)
                {
                    score = sut.SeverityScore(i + delay, i);
                    if (score > 0)
                    {
                        break;
                    }
                }
            }
        } while (score != 0);
        Assert.Equal(3907470, delay);
    }
}
