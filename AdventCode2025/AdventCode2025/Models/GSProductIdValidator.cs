namespace AdventCode2025.Models;

public class GSProductIdValidator
{
    public GSProductIdValidator()
    {

    }

    public static List<long> InvalidInDoubleSequenceIds(long startId, long endId)
    {
        List<long> invalidIds = new List<long>();
        for (long id = startId; id <= endId; id++)
        {
            string sid = id.ToString();
            if (sid.Length % 2 == 0)
            {
                int halfLength = sid.Length / 2;
                var leftSide = sid.Substring(0, halfLength);
                var rightSide = sid.Substring(halfLength, halfLength);
                if (string.Equals(leftSide, rightSide))
                {
                    invalidIds.Add(id);
                }
            }
        }
        return invalidIds;
    }
}
