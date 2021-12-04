using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventCode2021
{
    public class GiantSquidBingo
    {
        public List<int> Numbers { get; set; }
        public List<Board> Boards { get; set; }

        public GiantSquidBingo()
        {
            Boards = new List<Board>();
        }

        public List<int> ParseNumbers(string line)
        {
            var list = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToList();
            return list;
        }

        public void InitGame(string[] input)
        {
            List<string> lines = new List<string>(input);
            Numbers = ParseNumbers(lines[0]);
            lines.RemoveAt(0);

            Board board = new Board();
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                var rowlist = ParseNumbers(line);
                board.AddRow(rowlist);
                if (board.Row == 5)
                {
                    Boards.Add(board);
                    board = new Board();
                }
            }
        }

        public Board Play()
        {
            foreach (var num in Numbers)
            {
                foreach (var board in Boards)
                {
                    board.Number(num);
                    if (board.IsBingo())
                    {
                        return board;
                    }
                }
            }
            return null;
        }

        public Board PlayToLose()
        {
            Board loser = null;
            foreach (var num in Numbers)
            {
                for (int i = Boards.Count - 1; i >= 0; i--)
                {
                    Boards[i].Number(num);
                    if (Boards[i].IsBingo())
                    {
                        loser = Boards[i];
                        Boards.RemoveAt(i);
                    }
                }
            }
            return loser;
        }
    }

    public class Board
    {
        public int Row { get; set; }
        public Dictionary<int, Square> Contents { get; set; }
        public int Picked { get; set; }
        public int LastPickedNumber { get; set; }
        public List<Square> BingoRow { get; set; }

        public Board()
        {
            Row = 0;
            Contents = new Dictionary<int, Square>();
        }

        public void AddRow(List<int> row)
        {
            int col = 0;
            foreach (var num in row)
            {
                Contents.Add(num, new Square(num, Row, col++));
            }
            Row++;
        }

        public void Number(int num)
        {
            if (Contents.ContainsKey(num))
            {
                Contents[num].picked = true;
                Picked++;
                LastPickedNumber = num;
            }
        }
        public bool IsBingo()
        {
            if (Picked < 5)
                return false;

            var picked = Contents.Values.Where(s => s.picked == true).ToList();
            for (int i = 0; i < 5; i++)
            {
                var row = picked.Where(s => s.row == i).ToList();
                if (row.Count == 5)
                {
                    BingoRow = row;
                    return true;
                }
                row = picked.Where(s => s.column == i).ToList();
                if (row.Count == 5)
                {
                    BingoRow = row;
                    return true;
                }
            }
            return false;
        }

        public int Score()
        {
            int sumNotPicked = Contents.Values.Where(s => s.picked == false).Sum(s => s.number);
            return sumNotPicked * LastPickedNumber;
        }
    }

    public class Square
    {
        public int number;
        public int row;
        public int column;
        public bool picked;

        public Square(int n, int r, int c)
        {
            number = n;
            row = r;
            column = c;
        }
    }
}
