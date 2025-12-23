namespace AdventCode2025.Models;

public class JunctionBoxCircuitMaker
{
    public List<JunctionBox> JunctionBoxes { get; set; }
    public Dictionary<JunctionBoxKey, double> CircuitPairs { get; set; } = new Dictionary<JunctionBoxKey, double>();
    public List<HashSet<JunctionBox>> Circuits { get; set; } = new List<HashSet<JunctionBox>>();

    public JunctionBoxCircuitMaker(string[] lines)
    {
        JunctionBoxes = new List<JunctionBox>();

        foreach (string line in lines)
        {
            var parts = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var jb = new JunctionBox(long.Parse(parts[0]), long.Parse(parts[1]), long.Parse(parts[2]));
            JunctionBoxes.Add(jb);
        }
    }

    public void CalculateCircuitPairs()
    {
        CircuitPairs.Clear();
        for (int i = 0; i < JunctionBoxes.Count - 1; i++)
        {
            double dist = 0.0;
            var A = JunctionBoxes[i];
            for (int j = i + 1; j < JunctionBoxes.Count; j++)
            {
                var B = JunctionBoxes[j];
                dist = Distance(A, B);
                var key = new JunctionBoxKey(A, B);
                if (CircuitPairs.ContainsKey(key))
                {
                    if (CircuitPairs[key] > dist)
                    {
                        CircuitPairs[key] = dist;
                    }
                }
                else
                {
                    CircuitPairs.Add(key, dist);
                }
            }
        }
    }

    public double Distance(JunctionBox a, JunctionBox b)
    {
        double dist = Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.Z - b.Z, 2);
        return Math.Sqrt(dist);
    }

    public long CombineShortestCircuits(int size)
    {
        Circuits.Clear();

        var shortCircuits = CircuitPairs.OrderBy(c => c.Value).Take(size).ToDictionary();
        foreach (var sc in shortCircuits)
        {
            bool added = false;
            foreach (var hsCircuit in Circuits)
            {
                if (hsCircuit.Contains(sc.Key.A))
                {
                    hsCircuit.Add(sc.Key.B);
                    added = true;
                }
                else if (hsCircuit.Contains(sc.Key.B))
                {
                    hsCircuit.Add(sc.Key.A);
                    added = true;
                }
            }
            if (added == false)
            {
                var hs = new HashSet<JunctionBox>();
                hs.Add(sc.Key.A);
                hs.Add(sc.Key.B);
                Circuits.Add(hs);
            }

            ConnectCircuits();
        }



        var list = Circuits.Select(hs => hs.Count).OrderDescending().Take(3);
        long sum = 1;
        foreach (var c in list)
        {
            sum *= c;
        }
        return sum;
    }

    public int ConnectCircuits()
    {
        bool intersections;

        do
        {
            intersections = false;

            for (int i = 0; i < Circuits.Count; i++)
            {
                bool mergedThisI = false;

                for (int j = i + 1; j < Circuits.Count; j++)
                {
                    if (Circuits[i].Overlaps(Circuits[j]))
                    {
                        Circuits[i].UnionWith(Circuits[j]);
                        Circuits.RemoveAt(j);
                        intersections = true;
                        mergedThisI = true;
                        break;
                    }
                }

                if (mergedThisI)
                {
                    break;
                }
            }
        } while (intersections);
        return Circuits.Count();
    }

    public long CombineShortestUntilOneCircuit()
    {
        Circuits.Clear();
        int allJunctionBoxes = JunctionBoxes.Count;

        var shortCircuits = CircuitPairs.OrderBy(c => c.Value).ToDictionary();
        foreach (var sc in shortCircuits)
        {
            bool added = false;
            foreach (var hsCircuit in Circuits)
            {
                if (hsCircuit.Contains(sc.Key.A))
                {
                    hsCircuit.Add(sc.Key.B);
                    added = true;
                }
                else if (hsCircuit.Contains(sc.Key.B))
                {
                    hsCircuit.Add(sc.Key.A);
                    added = true;
                }
            }
            if (added == false)
            {
                var hs = new HashSet<JunctionBox>();
                hs.Add(sc.Key.A);
                hs.Add(sc.Key.B);
                Circuits.Add(hs);
            }

            int sets = ConnectCircuits();
            if (sets == 1 && Circuits[0].Count == allJunctionBoxes)
            {
                return sc.Key.A.X * sc.Key.B.X;
            }
        }
        return -1;
    }
}

public record JunctionBox(long X, long Y, long Z);
public record JunctionBoxKey(JunctionBox A, JunctionBox B);
