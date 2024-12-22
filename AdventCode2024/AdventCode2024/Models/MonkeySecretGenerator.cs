namespace AdventCode2024.Models;

public record MonkeyChange(long c1, long c2, long c3, long c4);

public class MonkeySecretGenerator
{
    public long StartValue { get; set; }
    public List<long> Secrets { get; set; }
    public List<long> Prices { get; set; }
    public Dictionary<MonkeyChange, long> Changes { get; set; }

    public MonkeySecretGenerator(long startValue)
    {
        Secrets = new List<long>();
        Prices = new List<long>();
        Changes = new Dictionary<MonkeyChange, long>();
        StartValue = startValue;
    }

    public void GenerateSecrets(long count)
    {
        Secrets.Clear();
        Changes.Clear();
        Prices.Clear();
        for (int i = 0; i < count; i++)
        {
            long secret = 0;
            if (i == 0)
                secret = GenerateNext(StartValue);
            else
                secret = GenerateNext(Secrets[i - 1]);
            Secrets.Add(secret);
            long price = secret % 10;
            Prices.Add(price);
            if (i == 3)
            {
                // TODO david
                var mc = new MonkeyChange(Prices[i - 3] - StartValue, Prices[i - 2] - Prices[i - 3], Prices[i - 1] - Prices[i - 2], Prices[i] - Prices[i - 1]);
                if (!Changes.ContainsKey(mc))
                {
                    // add first match only
                    Changes.Add(mc, price);
                }
            }
            if (i >= 4)
            {
                // TODO david
                var mc = new MonkeyChange(Prices[i - 3] - Prices[i - 4], Prices[i - 2] - Prices[i - 3], Prices[i - 1] - Prices[i - 2], Prices[i] - Prices[i - 1]);
                if (!Changes.ContainsKey(mc))
                {
                    // add first match only
                    Changes.Add(mc, price);
                }
            }
        }
    }

    public long GenerateNext(long secret)
    {
        long val = secret * 64;
        val = Mix(secret, val);
        val = Prune(val);

        long val2 = val / 32;
        val2 = Mix(val, val2);
        val2 = Prune(val2);

        long val3 = val2 * 2048;
        val3 = Mix(val2, val3);
        val3 = Prune(val3);
        return val3;
    }

    public long Mix(long secret, long mixvalue)
    {
        return secret ^ mixvalue;
    }

    public long Prune(long secret)
    {
        return secret % 16777216;
    }

    public void MergeChanges(Dictionary<MonkeyChange, long> allChanges)
    {
        foreach (var kv in Changes)
        {
            if (allChanges.ContainsKey(kv.Key))
            {
                allChanges[kv.Key] += kv.Value;
            }
            else
            {
                allChanges.Add(kv.Key, kv.Value);
            }
        }
    }
}
