using System.Diagnostics;

namespace AdventOfCode2020
{
    public class SeatingSystem
    {
        public const int kGenerations = 2;
        public const char Floor = '.';
        public const char EmptySeat = 'L';
        public const char OccupiedSeat = '#';

        public char[,,] Seating { get; set; }

        public int RowSize { get; set; }
        public int Rows { get; set; }
        public int Now { get; set; }
        public int Next { get; set; }

        public SeatingSystem(string[] lines)
        {
            Rows = lines.Length;
            RowSize = lines[0].Length;
            Seating = new char[kGenerations, Rows, RowSize];
            Now = 0;
            Next = 1;
            for (int row = 0; row < Rows; row++)
            {
                var seats = lines[row].ToCharArray();
                for (int idx = 0; idx < RowSize; idx++)
                {
                    Seating[Now, row, idx] = seats[idx];
                }
            }
        }

        public void Toggle()
        {
            Now = Now == 0 ? 1 : 0;
            Next = Next == 0 ? 1 : 0;
        }

        /// <summary>
        /// Only finds first difference
        /// </summary>
        /// <returns></returns>
        public bool Compare()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int idx = 0; idx < RowSize; idx++)
                {
                    if (Seating[Now, row, idx] != Seating[Next, row, idx])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int CountOccupiedSeats(int generation)
        {
            int seats = 0;

            for (int row = 0; row < Rows; row++)
            {
                for (int idx = 0; idx < RowSize; idx++)
                {
                    if (Seating[generation, row, idx] == OccupiedSeat)
                    {
                        seats++;
                    }
                }
            }
            return seats;
        }

        public void CalcNextRound(bool advanced = false)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int idx = 0; idx < RowSize; idx++)
                {
                    if (!advanced)
                        Seating[Next, row, idx] = CalcSeatStatus(Now, row, idx);
                    else
                        Seating[Next, row, idx] = CalcSeatStatusAdv(Now, row, idx);
                }
            }
        }

        private char CalcSeatStatus(int gen, int row, int idx)
        {
            if (Seating[gen, row, idx] == Floor)
            {
                return Floor;
            }
            int neighbors = IsOccupied(gen, row - 1, idx - 1);
            neighbors += IsOccupied(gen, row - 1, idx);
            neighbors += IsOccupied(gen, row - 1, idx + 1);
            neighbors += IsOccupied(gen, row, idx - 1);
            neighbors += IsOccupied(gen, row, idx + 1);
            neighbors += IsOccupied(gen, row + 1, idx - 1);
            neighbors += IsOccupied(gen, row + 1, idx);
            neighbors += IsOccupied(gen, row + 1, idx + 1);
            if (neighbors == 0 && Seating[gen, row, idx] == EmptySeat)
            {
                // nobody around sit down
                return OccupiedSeat;
            }
            if (neighbors >= 4)
            {
                // should empty if full
                return EmptySeat;
            }
            //
            return Seating[gen, row, idx];
        }

        private char CalcSeatStatusAdv(int gen, int row, int idx)
        {
            if (Seating[gen, row, idx] == Floor)
            {
                return Floor;
            }
            int neighbors = IsOccupiedAdv(gen, row, idx, -1, -1);
            neighbors += IsOccupiedAdv(gen, row, idx, -1, 0);
            neighbors += IsOccupiedAdv(gen, row, idx, -1, 1);
            neighbors += IsOccupiedAdv(gen, row, idx, 0, -1);
            neighbors += IsOccupiedAdv(gen, row, idx, 0, 1);
            neighbors += IsOccupiedAdv(gen, row, idx, 1, -1);
            neighbors += IsOccupiedAdv(gen, row, idx, 1, 0);
            neighbors += IsOccupiedAdv(gen, row, idx, 1, 1);
            if (neighbors == 0 && Seating[gen, row, idx] == EmptySeat)
            {
                // nobody around sit down
                return OccupiedSeat;
            }
            if (neighbors >= 5)
            {
                // should empty if full
                return EmptySeat;
            }
            //
            return Seating[gen, row, idx];
        }

        private int IsOccupiedAdv(int gen, int row, int idx, int drow, int didx)
        {
            int seatStatus = -1;
            do
            {
                row += drow;
                idx += didx;
                seatStatus = IsOccupiedCheck(gen, row, idx);
            } while (seatStatus == -1);
            return seatStatus;
        }

        private int IsOccupiedCheck(int gen, int row, int idx)
        {
            if (gen < 0 || gen > 1)
                return 0;
            if (row < 0 || row >= Rows)
                return 0;
            if (idx < 0 || idx >= RowSize)
                return 0;
            if (Seating[gen, row, idx] == OccupiedSeat)
                return 1;
            if (Seating[gen, row, idx] == Floor)
                return -1;
            return 0;
        }

        private int IsOccupied(int gen, int row, int idx)
        {
            if (gen < 0 || gen > 1)
                return 0;
            if (row < 0 || row >= Rows)
                return 0;
            if (idx < 0 || idx >= RowSize)
                return 0;
            if (Seating[gen, row, idx] == OccupiedSeat)
                return 1;
            return 0;
        }

        public void DumpGenerations()
        {
            Debug.WriteLine("Now:");
            for (int row = 0; row < Rows; row++)
            {
                for (int idx = 0; idx < RowSize; idx++)
                {
                    Debug.Write(Seating[Now, row, idx]);
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("");
            Debug.WriteLine("Next:");
            for (int row = 0; row < Rows; row++)
            {
                for (int idx = 0; idx < RowSize; idx++)
                {
                    Debug.Write(Seating[Next, row, idx]);
                }
                Debug.WriteLine("");
            }
            Debug.WriteLine("");
        }
    }
}
