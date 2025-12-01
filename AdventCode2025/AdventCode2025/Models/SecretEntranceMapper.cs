namespace AdventCode2025.Models;

public class SecretEntranceMapper
{
    public List<string> Instructions { get; set; }

    public SecretEntranceMapper(string[] lines)
    {
        Instructions = new List<string>(lines);
    }

    public int TimesMovedToZero(int startPos)
    {
        int zeroed = 0;

        foreach (var instruction in Instructions)
        {
            var operation = instruction[0];

            bool isLeft = operation == 'L';
            var dist = int.Parse(instruction[1..]);
            if (isLeft)
                startPos -= dist;
            else
                startPos += dist;
            // wrap values
            startPos = startPos % 100;
            if (startPos < 0)
                startPos += 100;

            if (startPos == 0)
                zeroed++;
        }
        return zeroed;
    }

    public int TimesPassingStoppingOnZero(int startPos)
    {
        int zeroed = 0;
        int prevPos = startPos;
        int nowPos;
        int mod100;

        foreach (var instruction in Instructions)
        {
            var operation = instruction[0];

            bool isLeft = operation == 'L';
            var dist = int.Parse(instruction[1..]);
            if (isLeft)
                nowPos = prevPos - dist;
            else
                nowPos = prevPos + dist;

            // look for passing zero
            if (prevPos == 0)
            {
                
                if (dist >= 100)
                {
                    mod100 = Math.Abs(dist / 100);
                    if (mod100 > 0)
                        zeroed += mod100;
                }
                prevPos = nowPos % 100;
                if (prevPos < 0)
                    prevPos += 100;
            }
            else
            {
                if (dist >= 100)
                {
                    mod100 = Math.Abs(dist / 100);
                    if (mod100 > 0)
                        zeroed += mod100;
                }
                prevPos = nowPos % 100;
                if ((prevPos <= 0 && nowPos > 0) || (prevPos >= 0 && nowPos < 0))
                    zeroed++;
                if (prevPos < 0)
                    prevPos += 100;
            }
        }
        return zeroed;
    }
}
