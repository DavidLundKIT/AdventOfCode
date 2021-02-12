using System.Collections.Generic;

namespace days.day10
{
    public class StarData
    {
        public StarData(string row)
        {
            // position=< 40203, -29878> velocity=<-4,  3>
            var vals= row.Split(new char[]{ '<', '>', ','});
            X = int.Parse(vals[1]);
            Y = int.Parse(vals[2]);
            dX = int.Parse(vals[4]);
            dY = int.Parse(vals[5]);
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int dX { get; set; }
        public int dY { get; set; }
    }

    public class Messages
    {
        public List<StarData> ParseStarData(string datapath)
        {
            List<StarData> data = new List<StarData>();

            var rows = DataHelpers.ReadLinesFromFile(datapath);
            foreach (var row in rows)
            {
                data.Add(new StarData(row));
            }
            return data;
        }
    }
}
