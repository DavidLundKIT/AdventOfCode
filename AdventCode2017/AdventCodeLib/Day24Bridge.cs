using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCodeLib
{
    public class Component : ICloneable
    {
        public Component(string row)
        {
            Org = row;
            ParseRow(row);
        }

        public Component()
        {

        }

        public string Org { get; set; }
        public int PortA { get; set; }
        public int PortB { get; set; }

        public int Sum()
        {
            return PortA + PortB;
        }

        public int OtherPort(int val)
        {
            return PortA == val ? PortB : PortA;
        }

        public void ParseRow(string row)
        {
            var vals = row.Split(new char[] { '/' });
            PortA = int.Parse(vals[0]);
            PortB = int.Parse(vals[1]);
        }

        public object Clone()
        {
            Component clone = new Component();
            clone.Org = this.Org;
            clone.PortA = this.PortA;
            clone.PortB = this.PortB;
            return clone;
        }
        public override string ToString()
        {
            return Org;
        }
    }

    public class Day24Bridge
    {

        public Day24Bridge()
        {
            Components = new List<Component>();
            Bridges = new List<List<Component>>();
        }

        public List<Component> Components { get; set; }
        public List<List<Component>> Bridges { get; set; }
        public void ParseComponents(string path)
        {
            var rows = DataTools.ReadAllLines(path);

            foreach (var row in rows)
            {
                Components.Add(new Component(row));
            }
        }

        public void CreateBridges()
        {
            var startComps = Components.FindWithValue(0);
            foreach (var comp in startComps)
            {
                List<Component> bridge = new List<Component>();
                List<Component> bag = Components.Clone();
                var c1 = bag.Single(c => c.PortA == comp.PortA && c.PortB == comp.PortB);
                bridge.Add(c1);
                bag.Remove(c1);
                BuildBridge(bridge, bag, c1.OtherPort(0));
            }
        }

        private void BuildBridge(List<Component> bridge0, List<Component> bag0, int port)
        {
            var startComps = bag0.FindWithValue(port);
            if (startComps?.Count == 0)
            {
                // found nothing to add, done.
                Bridges.Add(bridge0);
                return;
            }

            foreach (var comp in startComps)
            {
                List<Component> bridge = bridge0.Clone();
                List<Component> bag = bag0.Clone();
                var c1 = bag.Single(c => c.PortA == comp.PortA && c.PortB == comp.PortB);
                bridge.Add(c1);
                bag.Remove(c1);
                BuildBridge(bridge, bag, c1.OtherPort(port));
            }
        }

        public int StrongestBridge()
        {
            var strength = Bridges.Max(b => b.BridgeStrength());
            return strength;
        }

        public int LongestStrongestBridge()
        {
            int length = Bridges.Max(l => l.Count);
            var longestBridges = Bridges.FindAll(lb => lb.Count == length);
            var strength = longestBridges.Max(b => b.BridgeStrength());
            return strength;
        }
    }

    public static class ComponentHelpers
    {
        public static List<Component> FindWithValue(this List<Component> list, int val)
        {
            return list.FindAll(l => l.PortA == val || l.PortB == val);
        }

        public static int BridgeStrength(this List<Component> bridge)
        {
            return bridge.Sum(c => c.Sum());
        }

        public static List<Component> Clone(this List<Component> list)
        {
            List<Component> cloneList = new List<Component>();
            foreach (var item in list)
            {
                cloneList.Add((Component)item.Clone());
            }
            return cloneList;
        }
    }
}
