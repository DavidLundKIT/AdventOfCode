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

    /// <summary>
    /// Gave up on a clever way to do this, just brute force it
    /// Should be able to do this with modulus arithmetic but answers are off.
    /// </summary>
    /// <param name="startPos"></param>
    /// <returns></returns>
    public int TimesPassingStoppingOnZero(int startPos)
    {
        int zeroed = 0;
        int prevPos = startPos;
        int nowPos;

        foreach (var instruction in Instructions)
        {
            var operation = instruction[0];

            bool isLeft = operation == 'L';
            var dist = int.Parse(instruction[1..]);
            if (isLeft)
            {
                nowPos = prevPos - dist;
                for (int i = prevPos - 1; i >= nowPos; i--)
                {
                    if ((i % 100) == 0)
                        zeroed++;
                }
            }
            else
            {
                nowPos = prevPos + dist;
                for (int i = prevPos + 1; i <= nowPos; i++)
                {
                    if ((i % 100) == 0)
                        zeroed++;
                }
            }
            prevPos = nowPos % 100;
            if (prevPos < 0)
                prevPos += 100;
        }
        return zeroed;
    }
}
