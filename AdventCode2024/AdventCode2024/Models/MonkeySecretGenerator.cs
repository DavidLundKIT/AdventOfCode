namespace AdventCode2024.Models;

public class MonkeySecretGenerator
{
    public long StartValue { get; set; }
    public List<long> Secrets { get; set; }
    public MonkeySecretGenerator(long startValue)
    {
        Secrets = new List<long>();
        StartValue = startValue;
    }

    public void GenerateSecrets(long count)
    {
        Secrets.Clear();
        for (int i = 0; i < count; i++)
        {
            long secret = 0;
            if (i == 0)
                secret = GenerateNext(StartValue);
            else
                secret = GenerateNext(Secrets[i - 1]);
            Secrets.Add(secret);
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
}
