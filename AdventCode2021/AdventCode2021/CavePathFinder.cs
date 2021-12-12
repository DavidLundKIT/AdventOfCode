using System;
using System.Collections.Generic;
using System.Text;

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
            string lcNode = node.ToLower();
            if (Path.Contains(node))
            {
                // only uppercase can be visited multiple times
                if (String.Equals(node, lcNode, StringComparison.InvariantCulture))
                {
                    // in the path and lower case, stop here.
                    return false;
                }
            }
            
            // we can go here again
            Path.Push(node);

            if (node == "end")
            {
                // found a path
                AddPathToPaths();
                Path.Pop();
                return false;
            }

            foreach (var nodeNext in MapNodes[node])
            {
                FindPath(nodeNext);
            }
            return false;
        }

        public void AddPathToPaths()
        {
            // hit end make the path
            var nodes = Path.ToArray();
            var path = string.Join(",", nodes);
            if (Paths.ContainsKey(path))
                Paths[path]++;
            else
                Paths.Add(path, 1);
        }
    }
}
