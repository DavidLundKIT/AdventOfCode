using System;

namespace day03
{
    public class Claim
    {
        public string ClaimId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public static Claim MakeClaim(string row)
        {
            Claim c = new Claim();

            string[] data = row.Split(new char[]{ ' ', ':', 'x', ',', ':'});
            c.ClaimId = data[0];
            c.X = int.Parse(data[2]);
            c.Y = int.Parse(data[3]);
            c.Width = int.Parse(data[5]);
            c.Height = int.Parse(data[6]);
            return c;
        }
    }
}