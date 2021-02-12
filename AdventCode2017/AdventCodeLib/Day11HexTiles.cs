using System;
using System.Collections.Generic;

namespace AdventCodeLib
{
    public class Day11HexTiles
    {
        public string ReadInputData(string path)
        {
            var rows = DataTools.ReadAllLines(path);
            return rows[0];
        }

        public List<string> GetCommands(string data)
        {
            List<string> list = new List<string>();
            list.AddRange(data.Split(new char[] { ',' }));
            return list;
        }

        public int FindSteps(List<string> cmds)
        {
            // these reduce opposite steps
            int iNS = cmds.FindAll(c => c.Equals("n")).Count - cmds.FindAll(c => c.Equals("s")).Count;
            int iNeSw = cmds.FindAll(c => c.Equals("ne")).Count - cmds.FindAll(c => c.Equals("sw")).Count;
            int iNwSe = cmds.FindAll(c => c.Equals("nw")).Count - cmds.FindAll(c => c.Equals("se")).Count;

            while (iNeSw > 0 && iNwSe > 0)
            {
                // 1 each makes a N
                iNeSw--;
                iNwSe--;
                iNS++;
            }

            while (iNeSw < 0 && iNwSe < 0)
            {
                // 1 each makes a S
                iNeSw++;
                iNwSe++;
                iNS--;
            }

            while(iNS > 0 && iNwSe < 0)
            {
                // 1 each makes a Ne
                iNS--;
                iNwSe++;
                iNeSw++;
            }

            while (iNS > 0 && iNeSw < 0)
            {
                // 1 each makes a Nw
                iNS--;
                iNwSe++;
                iNeSw++;
            }

            while (iNS < 0 && iNwSe > 0)
            {
                // 1 each makes a Sw
                iNS++;
                iNwSe--;
                iNeSw--;
            }

            while (iNS < 0 && iNeSw > 0)
            {
                // 1 each makes a Se
                iNS++;
                iNwSe--;
                iNeSw--;
            }

            return Math.Abs(iNS) + Math.Abs(iNeSw) + Math.Abs(iNwSe);
        }
    }
}
