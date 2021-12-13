using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCode2021
{
    public class CavePathFinder
    {
        public Dictionary<string, List<string>> MapNodes { get; set; }
        public Stack<string> Path;
        public Dictionary<string, int> Paths;

        public CavePathFinder(string[] lines)
        {
            MapNodes = new Dictionary<string, List<string>>();
            Paths = new Dictionary<string, int>();
            Path = new Stack<string>();

            foreach (var line in lines)
            {
                var parts = line.Split('-', StringSplitOptions.RemoveEmptyEntries);
                AddNodePair(parts[0], parts[1]);
                AddNodePair(parts[1], parts[0]);
            }
        }

        public void AddNodePair(string a, string b)
        {
            if (!MapNodes.ContainsKey(a))
            {
                // need to set things up
                var nodes = new List<string>();
                MapNodes.Add(a, nodes);
            }
            MapNodes[a].Add(b);
        }

        public bool FindPath(string node)
        {
            if (node == "end")
            {
                // found a path
                Path.Push(node);
                AddPathToPaths();
                Path.Pop();
                return false;
            }

            string lcNode = node.ToLower();
            // only uppercase can be visited multiple times
            bool onlyOnce = String.Equals(node, lcNode, StringComparison.InvariantCulture);

            // is it in the list already?
            List<string> nextNodes;
            do
            {
                var meNodes = Path.Where(n => n == node).ToList();
                if (meNodes.Count >= 1 && onlyOnce)
                    return false;
                if (MapNodes[node].Count == meNodes.Count)
                {
                    return false;
                }
                nextNodes = MapNodes[node].GetRange(meNodes.Count, MapNodes[node].Count - meNodes.Count);
                Path.Push(node);
                FindPath(nextNodes[0]);
            } while (nextNodes.Count > 0);
            return false;
        }

        public void AddPathToPaths()
        {
            // hit end make the path
            List<string> nodes = new List<string>(Path.ToArray());
            nodes.Reverse();
            var path = string.Join(",", nodes);
            if (Paths.ContainsKey(path))
                Paths[path]++;
            else
                Paths.Add(path, 1);
        }
    }
}
