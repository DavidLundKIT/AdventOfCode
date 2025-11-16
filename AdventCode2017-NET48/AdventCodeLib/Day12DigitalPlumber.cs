using System.Collections.Generic;
using System.Linq;

namespace AdventCodeLib
{
    public class Proc
    {
        public Proc(string row)
        {
            Connections = new List<string>();
            ParseData(row);
        }

        public string ProcId { get; set; }
        public List<string> Connections { get; set; }

        public void ParseData(string row)
        {
            var sl = row.Split(new char[] { ' ', ',' });
            ProcId = sl[0];
            for (int i = 2; i < sl.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(sl[i]))
                {
                    Connections.Add(sl[i]);
                }
            }
        }
    }

    public class Day12DigitalPlumber
    {
        public Day12DigitalPlumber()
        {
            AllProcs = new Dictionary<string, Proc>();
            Group = new Dictionary<string, string>();
        }

        public Dictionary<string, Proc> AllProcs { get; set; }
        public Dictionary<string, string> Group { get; set; }

        public void ParseFile(string path)
        {
            var rows = DataTools.ReadAllLines(path);

            foreach (var row in rows)
            {
                Proc p = new Proc(row);
                AllProcs.Add(p.ProcId, p);
            }
        }

        public bool FindGroup(string procId)
        {
            Group.Clear();

            if (!AllProcs.ContainsKey(procId))
            {
                return false;
            }

            Proc p = AllProcs[procId];
            Group.Add(p.ProcId, p.ProcId);
            AddToGroup(p.Connections);
            return true;
        }

        public void AddToGroup(List<string> connections)
        {
            Proc p;
            foreach (string procId in connections)
            {
                if (!Group.ContainsKey(procId))
                {
                    p = AllProcs[procId];
                    Group.Add(p.ProcId, p.ProcId);
                    AddToGroup(p.Connections);
                }
            }
        }

        public int FindAllGroups()
        {
            int groups = 0;
            string procId;

            while(AllProcs.Count > 0)
            {
                procId = AllProcs.Keys.FirstOrDefault();
                if(FindGroup(procId))
                {
                    groups++;
                    foreach (var key in Group.Keys)
                    {
                        AllProcs.Remove(key);
                    }
                }
            }

            return groups;
        }
    }
}
