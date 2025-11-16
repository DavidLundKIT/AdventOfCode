using System;

namespace AdventCodeLib
{
    public class Point
    {

        public Point(int size)
        {
            if (size < 1 || (size % 2 == 0))
            {
                throw new ArgumentOutOfRangeException(nameof(size));
            }

            Size = size;
            MinValue = 1;
            MaxValue = size * size;
        }

        public int MaxValue { get; private set; }
        public int MinValue { get; private set; }
        public int Size { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Index { get; private set; }

        public void SetIndex(int index)
        {
            Index = index;
            if (index < MinValue || index > MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            int shell = FindShellFor(index);
            SetPoint(shell);
        }

        private void SetPoint(int upperBound)
        {
            int middle = Size / 2;
            int lowerBound = upperBound - 2;
            if (upperBound == 1)
            {
                X = middle;
                Y = middle;
                return;
            }
            int lastCellUnder = lowerBound * lowerBound;
            int lastCell = upperBound * upperBound;
            if (Index == lastCell)
            {
                X = middle + (upperBound / 2);
                Y = middle + (upperBound / 2);
                return;
            }
            int outsideSize = lastCell - lastCellUnder;
            int cornerFactor = outsideSize / 4;
            int toMiddle = cornerFactor / 2;
            int offset = Index - lastCellUnder;
            int sideOffset = offset % cornerFactor;
            int side = offset / cornerFactor;
            switch (side)
            {
                case 0:
                    X = middle + (upperBound / 2);
                    Y = middle + (upperBound / 2) - sideOffset;
                    break;
                case 1:
                    Y = middle - (upperBound / 2);
                    X = middle + (upperBound / 2) - sideOffset;
                    break;
                case 2:
                    X = middle - (upperBound / 2);
                    Y = middle - (upperBound / 2) + sideOffset;
                    break;
                case 3:
                    Y = middle + (upperBound / 2);
                    X = middle - (upperBound / 2) + sideOffset;
                    break;
                default:
                    break;
            }
        }

        private int FindShellFor(int index)
        {
            for (int i = 1; i <= Size; i += 2)
            {
                if (index <= i * i)
                {
                    return i;
                }
            };
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

    public class Day03Memory
    {
        public Day03Memory()
        {
            Matrix = null;
        }

        public int Size { get; set; }
        public int[,] Matrix { get; set; }

        public int SquareHoldingInputCell(int cell)
        {
            double factor = Math.Sqrt(cell);
            int ifactor = Convert.ToInt32(Math.Ceiling(factor));
            if (ifactor % 2 == 0)
                ifactor++;
            return ifactor;
        }

        /// <summary>
        /// This means straight into center not offset.
        /// So like example for 23 should be 2.
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public int StepsIntoCenter(int cell)
        {
            int shellFactor = SquareHoldingInputCell(cell);
            return StepsIntoCenterFromShell(shellFactor);
        }

        public int ManhattenDistance(int cell)
        {
            int shell = SquareHoldingInputCell(cell);
            int stepsDown = StepsIntoCenterFromShell(shell);
            int stepsOver = StepsOverToCenter(shell, cell);
            return stepsDown + stepsOver;
        }

        private int StepsOverToCenter(int shell, int cell)
        {
            if (shell == 1)
            {
                return 0;
            }
            int lastCellUnder = (shell - 2) * (shell - 2);
            int lastCell = (shell * shell);
            int outsideSize = lastCell - lastCellUnder;
            int cornerFactor = outsideSize / 4;
            int toMiddle = cornerFactor / 2;
            int offset = cell - lastCellUnder;
            int sideOffset = offset % cornerFactor;
            int stepsOver = sideOffset % toMiddle;
            int partOffset = offset / toMiddle;
            if (partOffset % 2 == 0)
            {
                // must add something
                stepsOver = toMiddle - stepsOver;
            }

            return stepsOver;
        }

        private int StepsIntoCenterFromShell(int shell)
        {
            int stepsDown = shell / 2;
            return stepsDown;
        }

        public void CreateMatrix(int size)
        {
            Size = size;
            Matrix = new int[size, size];
        }

        public void FillTestValues()
        {
            int lastCell = Size * Size;
            Point p = GetPointAt(1);
            Matrix[p.X, p.Y] = 1;
            for (int index = 2; index <= lastCell; index++)
            {
                p.SetIndex(index);
                Matrix[p.X, p.Y] = SumAroundPoint(index);
            }
        }

        public Point GetPointAt(int index)
        {
            Point p = new Point(Size);
            p.SetIndex(index);
            return p;
        }

        public int GetMatrixValueAt(int index)
        {
            Point p = GetPointAt(index);
            return Matrix[p.X, p.Y];
        }

        public int SumAroundPoint(int index)
        {
            Point p = GetPointAt(index);
            int sum = 0;

            for (int x = p.X - 1; x <= p.X + 1; x++)
            {
                if ((x < 0 ) || (x > Size -1))
                {
                    continue;
                }
                for (int y = p.Y - 1; y <= p.Y + 1; y++)
                {
                    if ((y < 0) || (y > Size - 1))
                    {
                        continue;
                    }
                    sum += Matrix[x, y];
                }
            }

            return sum;
        }
    }
}
