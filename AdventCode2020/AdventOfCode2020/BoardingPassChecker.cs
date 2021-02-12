using System;

namespace AdventOfCode2020
{
    public class BoardingPassChecker
    {
        public int CalculateSeatID(string pass, out int row, out int seat)
        {
            row = 127;
            seat = 7;
            var chs = pass.ToUpper().ToCharArray();

            var srow = pass.ToUpper().Substring(0, 7).Replace("F", "0").Replace("B", "1");
            var sseat = pass.ToUpper().Substring(7, 3).Replace("L", "0").Replace("R", "1"); ;

            row = Convert.ToInt32(srow, 2);
            seat = Convert.ToInt32(sseat, 2);
            int seatId = row * 8 + seat;
            return seatId;
        }
    }
}
