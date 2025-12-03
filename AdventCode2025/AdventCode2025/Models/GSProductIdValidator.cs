using System.Diagnostics;
using System.Linq;

namespace AdventCode2025.Models;

public class GSProductIdValidator
{
    public static List<long> InvalidInDoubleSequenceIds(long startId, long endId)
    {
        List<long> invalidIds = new List<long>();
        for (long id = startId; id <= endId; id++)
        {
            if (IsInvalidInDoubleSequenceId(id))
            {
                invalidIds.Add(id);
            }
        }
        return invalidIds;
    }

    public static bool IsInvalidInDoubleSequenceId(long id)
    {
        string sid = id.ToString();
        if (sid.Length % 2 == 0)
        {
            int halfLength = sid.Length / 2;
            var leftSide = sid.Substring(0, halfLength);
            var rightSide = sid.Substring(halfLength, halfLength);
            if (string.Equals(leftSide, rightSide))
            {
                return true;
            }
        }
        return false;
    }

    public static List<long> InvalidExtraSequenceIds(long startId, long endId)
    {
        List<long> invalidIds = new List<long>();
        for (long id = startId; id <= endId; id++)
        {
            var parts = SplitToParts(id);
            if (IsInvalidExtraSequenceId(id, parts))
            {
                invalidIds.Add(id);
            }
        }
        return invalidIds;
    }

    public static bool IsInvalidExtraSequenceId(long id, List<int> parts)
    {
        string sid = id.ToString();
        var partsDict = new Dictionary<string, int>();
        foreach (var size in parts)
        {
            partsDict.Clear();
            for (int i = 0; i < sid.Length; i += size)
            {
                var subPart = sid.Substring(i, size);
                if (partsDict.ContainsKey(subPart))
                {
                    partsDict[subPart]++;
                }
                else
                {
                    partsDict[subPart] = 1;
                }
            }
            if (partsDict.Count == 1)
            {
                return true;
            }
        }
        return false;
    }

    public static List<int> SplitToParts(long id)
    {
        List<int> parts = new List<int>();
        string sid = id.ToString();
        int sidLength = sid.Length;
        for (int ipart = sidLength / 2; ipart >= 1; ipart--)
        {
            if (sidLength % ipart == 0)
            {
                parts.Add(ipart);
            }
        }
        return parts;
    }
}
