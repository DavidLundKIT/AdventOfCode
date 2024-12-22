using AdventCode2024.Models;

namespace AdventCode2024;

public class Day22MonkeyMarketUnitTest
{
    [Fact]
    public void SecretNumbers_Mix_Test_OK()
    {
        var msg = new MonkeySecretGenerator(123);

        long actual = msg.Mix(42, 15);
        Assert.Equal(37, actual);
    }

    [Fact]
    public void SecretNumbers_Prune_Test_OK()
    {
        var msg = new MonkeySecretGenerator(123);

        long actual = msg.Prune(100000000);
        Assert.Equal(16113920, actual);
    }

    [Fact]
    public void SecretNumbers_Test123_OK()
    {
        var secrets = Utils.ReadLongsFromFile("Day22test123.txt");
        Assert.NotEmpty(secrets);
        Assert.Equal(10, secrets.Count);

        var msg = new MonkeySecretGenerator(123);

        msg.GenerateSecrets(10);

        Assert.NotEmpty(msg.Secrets);
        Assert.Equal(10, msg.Secrets.Count);

        for (int i = 0; i < secrets.Count; i++)
        {
            Assert.Equal(secrets[i], msg.Secrets[i]);
        }
    }

    [Theory]
    [InlineData(1, 8685429)]
    [InlineData(10, 4700978)]
    [InlineData(100, 15273692)]
    [InlineData(2024, 8667524)]
    public void SecretNumbers_2000vals_OK(long startSecret, long secret20)
    {
        var msg = new MonkeySecretGenerator(startSecret);
        msg.GenerateSecrets(2000);

        Assert.Equal(secret20, msg.Secrets[1999]);
    }

    [Fact]
    public void Day22_Part1_MonkeyMarket_OK()
    {
        var secrets = Utils.ReadLongsFromFile("Day22.txt");
        Assert.NotEmpty(secrets);
        Assert.Equal(2406, secrets.Count);

        long total = 0;
        foreach (var startSecret in secrets)
        {
            var msg = new MonkeySecretGenerator(startSecret);
            msg.GenerateSecrets(2000);
            total += msg.Secrets[1999];
        }

        Assert.Equal(20215960478, total);
    }

    [Fact]
    public void SecretSalesPriceComboMax_OK()
    {
        List<long> secrets = new List<long>() { 1, 2, 3, 2024 };

        long total = 0;
        Dictionary<MonkeyChange, long> AllChanges = new Dictionary<MonkeyChange, long>();

        foreach (var startSecret in secrets)
        {
            var msg = new MonkeySecretGenerator(startSecret);
            msg.GenerateSecrets(2000);
            total += msg.Secrets[1999];
            msg.MergeChanges(AllChanges);
        }
        long actual = AllChanges.Values.Max();
        Assert.Equal(23, actual);
    }

    [Fact]
    public void Day22_Part2_MonkeyMarket_OK()
    {
        var secrets = Utils.ReadLongsFromFile("Day22.txt");
        Assert.NotEmpty(secrets);
        Assert.Equal(2406, secrets.Count);

        long total = 0;
        Dictionary<MonkeyChange, long> AllChanges = new Dictionary<MonkeyChange, long>();

        foreach (var startSecret in secrets)
        {
            var msg = new MonkeySecretGenerator(startSecret);
            msg.GenerateSecrets(2000);
            total += msg.Secrets[1999];
            msg.MergeChanges(AllChanges);
        }

        Assert.Equal(20215960478, total);
        long actual = AllChanges.Values.Max();
        Assert.Equal(2221, actual);
    }
}
