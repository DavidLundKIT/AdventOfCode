using System;
using System.Collections.Generic;
using System.IO;

namespace days.day06
{
    public class ChronalCoordination
    {
        public List<ChronalCoords> ParseDataFile(string datapath)
        {
            List<ChronalCoords> list = new List<ChronalCoords>();
            var rows = File.ReadAllLines(datapath);
            foreach (var row in rows)
            {
                var xy = row.Split(new char[] { ','});
                ChronalCoords cc = new ChronalCoords();
                cc.X = int.Parse(xy[0].Trim());
                cc.Y = int.Parse(xy[1].Trim());
                list.Add(cc);
            }
            return list;
        } 

        public ChronalCoords FindMaxXY(List<ChronalCoords> coords)
        {
            ChronalCoords max = new ChronalCoords();

            foreach (var item in coords)
            {
                if (max.X < item.X)
                    max.X = item.X;
                if (max.Y < item.Y)
                    max.Y = item.Y;
            }

            return max;
        }

        public int ManhattanDistance(int x, int y, ChronalCoords pt)
        {
            int dist = Math.Abs(x - pt.X) + Math.Abs(y - pt.Y);
            return dist;
        }

        public int ClosestCoord(int x, int y, List<ChronalCoords> coords)
        {
            int closestDist = int.MaxValue;
            int closestCoord = -1;
            for (int i = 0; i < coords.Count; i++)
            {
                int dist = ManhattanDistance(x, y, coords[i]);
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closestCoord = i;
                }
                else if (dist == closestDist)
                {
                    closestCoord = -1;
                }

            }
            return closestCoord;
        }

        public int SumDistanceToCoord(int x, int y, List<ChronalCoords> coords)
        {
            int dist = 0;
            for (int i = 0; i < coords.Count; i++)
            {
                dist += ManhattanDistance(x, y, coords[i]);
            }
            return dist;
        }
    }
}
