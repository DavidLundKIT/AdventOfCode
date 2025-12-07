namespace AdventCode2025.Models;

public class TachyonTracer
{
    public List<List<char>> Manifold { get; set; }

    public TachyonTracer(string[] lines)
    {
        Manifold = new List<List<char>>();

        foreach (var line in lines)
        {
            Manifold.Add(line.ToCharArray().ToList());
        }
    }

    public long TotalSplits()
    {
        long totalSplits = 0;
        for (int rowIdx = 0; rowIdx < Manifold.Count; rowIdx++)
        {
            var row = Manifold[rowIdx];
            var prevIdx = rowIdx - 1;
            if (prevIdx < 0)
                continue;

            var prevRow = Manifold[prevIdx];

            for (int colIdx = 0; colIdx < row.Count; colIdx++)
            {
                var prevCh = prevRow[colIdx];

                switch (prevCh)
                {
                    case 'S':
                        row[colIdx] = '|';
                        break;
                    case '|':
                        if (row[colIdx] == '^')
                        {
                            // beam splitter
                            totalSplits++;
                            if (colIdx - 1 >= 0)
                                row[colIdx - 1] = '|';
                            if (colIdx + 1 < row.Count)
                                row[colIdx + 1] = '|';
                        }
                        else
                            row[colIdx] = '|';
                        break;
                    default:
                        break;
                }
            }
        }
        return totalSplits;
    }

    public long TotalTimelines()
    {
        List<long> Timelines = Enumerable.Range(0, Manifold[0].Count).Select(i => (long)0).ToList();
        List<long> prevTimeLines = Enumerable.Range(0, Manifold[0].Count).Select(i => (long)0).ToList();

        for (int rowIdx = 0; rowIdx < Manifold.Count; rowIdx++)
        {
            var row = Manifold[rowIdx];
            var prevIdx = rowIdx - 1;
            if (prevIdx < 0)
                continue;

            var prevRow = Manifold[prevIdx];
            for (int colIdx = 0; colIdx < row.Count; colIdx++)
            {
                var prevCh = prevRow[colIdx];

                switch (prevCh)
                {
                    case 'S':
                        row[colIdx] = '|';
                        Timelines[colIdx] = ++prevTimeLines[colIdx];
                        break;
                    case '|':
                        if (row[colIdx] == '^')
                        {
                            // beam splitter
                            if (colIdx - 1 >= 0)
                            {
                                row[colIdx - 1] = '|';
                                Timelines[colIdx - 1] += prevTimeLines[colIdx];
                            }
                            if (colIdx + 1 < row.Count)
                            {
                                row[colIdx + 1] = '|';
                                Timelines[colIdx + 1] += prevTimeLines[colIdx];
                            }
                            Timelines[colIdx] = 0;
                        }
                        else
                        {
                            row[colIdx] = '|';
                            Timelines[colIdx] += prevTimeLines[colIdx];
                        }
                        break;
                    default:
                        break;
                }
            }
            prevTimeLines = Timelines;
            Timelines = Enumerable.Range(0, Manifold[0].Count).Select(i => (long)0).ToList();
        }
        long totalTimelines = prevTimeLines.Sum();
        return totalTimelines;
    }
}
