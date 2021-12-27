using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCode2021
{
    public class CavePathFinder
    {
        public Dictionary<string, List<string>> MapNodes { get; set; }
        public Dictionary<string, HashSet<string>> UsedNodes { get; set; }
        public Stack<string> Path;
        public Dictionary<string, int> Paths;

        public CavePathFinder(string[] lines)
        {
            MapNodes = new Dictionary<string, List<string>>();
            UsedNodes = new Dictionary<string, HashSet<string>>();
            Paths = new Dictionary<string, int>();
            Path = new Stack<string>();

            foreach (var line in lines)
            {
                var parts = line.Split('-', StringSplitOptions.RemoveEmptyEntries);
                if (!parts[1].Equals("start"))
                    AddNodePair(parts[0], parts[1]);
                if (!parts[0].Equals("start"))
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

        public void FindAllPaths()
        {
            var startPaths = MapNodes["start"];

            foreach (var node in startPaths)
            {
                Path.Clear();
                UsedNodes.Clear();
                Path.Push("start");
                FindPath(node);
            }
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
                if (!UsedNodes.ContainsKey(node))
                {
                    // not ever done
                    Path.Push(node);
                    UsedNodes.Add(node, new HashSet<string>());
                    nextNodes = MapNodes[node];
                    UsedNodes[node].Add(nextNodes[0]);
                    FindPath(nextNodes[0]);
                }
                else
                {
                    // record in dict here before
                    var meNodes = Path.Where(n => n == node).ToList();
                    if (meNodes.Count >= 1 && onlyOnce)
                        return false;
                    var myNodes = new HashSet<string>(MapNodes[node]);
                    myNodes.ExceptWith(UsedNodes[node].ToList());
                    nextNodes = myNodes.ToList();
                    if (nextNodes.Count > 0)
                    {
                        Path.Push(node);
                        UsedNodes[node].Add(nextNodes[0]);
                        FindPath(nextNodes[0]);
                    }
                }
            } while (nextNodes.Count > 0);
            return false;
        }
    }
}
