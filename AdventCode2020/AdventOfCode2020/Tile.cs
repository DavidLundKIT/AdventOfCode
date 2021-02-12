using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public enum TileActions
    {
        RotateRight,
        RotateLeft,
        Flip1To3,
        Flip2To4
    }

    public class Tile
    {
        public int TileID { get; set; }
        public string Edge1 { get; set; }
        public string Edge2 { get; set; }
        public string Edge3 { get; set; }
        public string Edge4 { get; set; }
        public Tile NextTile1 { get; set; }
        public Tile NextTile2 { get; set; }
        public Tile NextTile3 { get; set; }
        public Tile NextTile4 { get; set; }

        public List<string> TileData { get; set; }

        public Tile(List<string> lines)
        {
            var parts = lines[0].Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
            TileID = int.Parse(parts[1]);

            TileData = new List<string>(lines.GetRange(1, 10));
        }

        public Tile(int tileId, string[] tileData)
        {
            TileID = tileId;
            TileData = new List<string>(tileData);
        }

        public void MakeEdges()
        {
            Edge1 = TileData[0];
            Edge3 = TileData[9];
            char[] chs2 = new char[10];
            char[] chs4 = new char[10];

            for (int idx = 0; idx < TileData.Count; idx++)
            {
                var chs = TileData[idx].ToCharArray();
                chs2[idx] = chs[9];
                chs4[idx] = chs[0];
            }
            Edge2 = new string(chs2);
            Edge4 = new string(chs4);
        }

        public static string ReverseEdge(string edge)
        {
            var chs = edge.ToCharArray();
            Array.Reverse(chs);
            return new string(chs);
        }

        public void RotateRight()
        {
            char[,] result = new char[10, 10];
            for (int i = 0; i < 10; i++)
            {
                var matrix = TileData[i].ToCharArray();
                for (int j = 0; j < 10; j++)
                {
                    result[j, 9-i] = matrix[j];
                }
            }
            ToTileData(result);
            MakeEdges();
        }

        public void RotateLeft()
        {
            char[,] result = new char[10, 10];
            for (int i = 0; i < 10; i++)
            {
                var matrix = TileData[i].ToCharArray();
                for (int j = 0; j < 10; j++)
                {
                    result[9-j, i] = matrix[j];
                }
            }
            ToTileData(result);
            MakeEdges();
        }

        public void ToTileData(char[,] result)
        {
            for (int i = 0; i < 10; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < 10; j++)
                {
                    sb.Append(result[i, j]);
                }
                TileData[i] = sb.ToString();
            }
        }

        public void Flip1To3()
        {
            TileData.Reverse();
            MakeEdges();
        }

        public void Flip2To4()
        {
            for (int i = 0; i < 10; i++)
            {
                TileData[i] = ReverseEdge(TileData[i]);
            }
            MakeEdges();
        }
    }
}
