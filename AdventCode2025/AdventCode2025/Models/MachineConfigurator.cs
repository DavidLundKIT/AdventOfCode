using System.Diagnostics.CodeAnalysis;

namespace AdventCode2025.Models;

public class MachineConfigurator
{
    public string Lights { get; set; }
    public List<List<int>> Buttons { get; set; } = new List<List<int>>();
    public List<int> JoltageRequirements { get; set; }

    public MachineConfigurator(string line)
    {
        var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Lights = parts[0].Replace("[", "").Replace("]", "");
        JoltageRequirements = parts[parts.Length - 1].Split(new char[] { ',', '{', '}' }, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToList();
        for (int i = 1; i < parts.Length - 1; i++)
        {
            var list = parts[i].Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList();
            Buttons.Add(list);
        }
    }

    public string PushButton(int button, string inLights)
    {
        var outLights = inLights.ToCharArray();

        foreach (var idx in Buttons[button])
        {
            if (outLights[idx] == '.')
            {
                outLights[idx] = '#';
            }
            else
            {
                outLights[idx] = '.';
            }
        }
        return new string(outLights);
    }

    public int MinPressesForStartUpRnd()
    {
        var rnd = new Random(DateTime.Now.Millisecond);
        int minSteps = int.MaxValue;

        for (int i = 0; i < 1000; i++)
        {
            int steps = RandomButtonTrial(rnd);

            if (steps < minSteps)
                minSteps = steps;
        }

        return minSteps;
    }

    public int RandomButtonTrial(Random rnd)
    {

        int steps = 0;
        int maxButton = Buttons.Count - 1;
        int maxTimes = Buttons.Count * 10;

        var inLights = new string('.', Lights.Length);
        for (int i = 0; i < maxTimes; i++)
        {
            int idx = rnd.Next(0, maxButton);
            inLights = PushButton(idx, inLights);
            steps++;
            if (string.Equals(inLights, Lights))
            {
                // done 
                return steps;
            }
        }
        return steps;
    }

    public int MinPressesForStartUp()
    {
        int n = Lights.Length;

        // Pre-check for trivial case
        if (n == 0)
            return 0;

        // If lights fit in 64 bits, use bitmasks (fast).
        //if (n <= 64)
        //{
        //    ulong target = 0UL;
        //    for (int i = 0; i < n; i++)
        //    {
        //        if (Lights[i] == '#')
        //            target |= 1UL << i;
        //    }

        //    var buttonMasks = new List<ulong>(Buttons.Count);
        //    foreach (var btn in Buttons)
        //    {
        //        ulong mask = 0UL;
        //        foreach (var idx in btn)
        //        {
        //            if (idx >= 0 && idx < n)
        //                mask |= 1UL << idx;
        //        }
        //        buttonMasks.Add(mask);
        //    }

        //    var visited = new HashSet<ulong>();
        //    var q = new Queue<(ulong mask, int steps)>();
        //    q.Enqueue((0UL, 0));
        //    visited.Add(0UL);

        //    while (q.Count > 0)
        //    {
        //        var (mask, steps) = q.Dequeue();
        //        if (mask == target)
        //            return steps;

        //        foreach (var bmask in buttonMasks)
        //        {
        //            var next = mask ^ bmask;
        //            if (visited.Add(next))
        //                q.Enqueue((next, steps + 1));
        //        }
        //    }

        //    return -1; // unreachable
        //}
        //else
        //{
        // Fall back to string-based BFS for larger sizes
        string start = new string('.', n);
        var visited = new HashSet<string> { start };
        var q = new Queue<(string state, int steps)>();
        q.Enqueue((start, 0));

        while (q.Count > 0)
        {
            var (state, steps) = q.Dequeue();
            if (state == Lights)
                return steps;

            foreach (var btn in Buttons)
            {
                var arr = state.ToCharArray();
                foreach (var idx in btn)
                {
                    if (idx >= 0 && idx < n)
                        arr[idx] = arr[idx] == '.' ? '#' : '.';
                }
                var next = new string(arr);
                if (visited.Add(next))
                    q.Enqueue((next, steps + 1));
            }
        }

        return -1; // unreachable
        //}
    }

    public int MinPressesForJoltage()
    {
        int n = JoltageRequirements.Count;
        var comparer = new ListEqualityComparer();
        // Pre-check for trivial case
        if (n == 0)
            return 0;

        List<int> start = new List<int>();
        for (int i = 0; i < n; i++)
            start.Add(0);

        var visited = new HashSet<List<int>>(comparer);
        visited.Add(start);

        var q = new Queue<(List<int> state, int steps)>();
        q.Enqueue((start, 0));

        while (q.Count > 0)
        {
            var (state, steps) = q.Dequeue();
            if (comparer.Equals(state, JoltageRequirements))
                return steps;

            foreach (var btn in Buttons)
            {
                var next = new List<int> (state);
                foreach (var idx in btn)
                {
                    if (idx >= 0 && idx < n)
                        next[idx]++;
                }
                if (visited.Add(next))
                    q.Enqueue((next, steps + 1));
            }
        }

        return -1; // unreachable
    }

}

public class ListEqualityComparer : IEqualityComparer<List<int>>
{
    public bool Equals(List<int>? x, List<int>? y)
    {
        if (ReferenceEquals(x, y))
            return true;

        if (x is null || y is null)
            return false;
        if (x.Count != y.Count)
            return false;
        for (int i = 0; i < x.Count; i++)
        {
            if (x[i] != y[i])
                return false;
        }
        return true;
    }

    public int GetHashCode([DisallowNull] List<int> obj)
    {
        int hash = 0;
        foreach (var item in obj)
        {
            hash = hash ^ item;
        }
        return hash;
    }
}
