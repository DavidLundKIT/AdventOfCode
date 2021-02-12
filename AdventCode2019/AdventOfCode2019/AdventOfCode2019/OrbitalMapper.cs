using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public class OrbitalMapper
    {
        public static NameValueCollection FillOrbitMap(string[] orbits)
        {
            NameValueCollection nvc = new NameValueCollection();
            foreach (var orbit in orbits)
            {
                var orbs = orbit.Split(")");
                nvc.Add(orbs[0], orbs[1]);
                nvc.Add(orbs[1], string.Empty);
            }
            return nvc;
        }

        public static void PrintKeysAndValues(NameValueCollection myCol)
        {
            Debug.WriteLine("   [INDEX] KEY        VALUE");
            for (int i = 0; i < myCol.Count; i++)
            {
                Debug.WriteLine("   [{0}]     {1,-10} {2}", i, myCol.GetKey(i), myCol.Get(i));
            }
            Debug.WriteLine("Done");
        }

        public static int CountOrbits(NameValueCollection map, string key, int count)
        {
            foreach (var orbKey in map.AllKeys)
            {
                string[] orbs = map.GetValues(orbKey);
                if (orbs.Contains(key))
                {
                    return CountOrbits(map, orbKey, count + 1);
                }
            }
            return count;
        }

        public static List<string> GetOrbits(NameValueCollection map, string key, List<string> orbits)
        {
            foreach (var orbKey in map.AllKeys)
            {
                string[] orbs = map.GetValues(orbKey);
                if (orbs.Contains(key))
                {
                    orbits.Add(orbKey);
                    return GetOrbits(map, orbKey, orbits);
                }
            }
            return orbits;
        }
    }
}
