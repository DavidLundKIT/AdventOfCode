using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace AdventOfCode2020
{
    public class JurassicJigsaw
    {
        public SortedDictionary<int, Tile> OrgTiles { get; set; }
        public SortedDictionary<int, Tile> Tiles { get; set; }
        public SortedDictionary<string, List<Tuple<int, int, bool>>> Edges { get; set; }
        public Tile StartCorner { get; set; }
        public int NumberPerSide { get; set; }
        public int NumberCornerTiles { get; set; }
        public int NumberSideTiles { get; set; }
        public Dictionary<int, List<TileActions>> Changes { get; set; }

        public JurassicJigsaw()
        {
            OrgTiles = new SortedDictionary<int, Tile>();
            Edges = new SortedDictionary<string, List<Tuple<int, int, bool>>>();
            Changes = new Dictionary<int, List<TileActions>>();
        }

        public void ReadTiles(List<string> lines)
        {
            for (int i = 0; i < lines.Count; i += 12)
            {
                Tile t = new Tile(lines.GetRange(i, 11));
                OrgTiles.Add(t.TileID, t);
            }
            NumberPerSide = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(OrgTiles.Count)));
            NumberCornerTiles = 4;
            NumberSideTiles = 4 * NumberPerSide - NumberCornerTiles;
            Tiles = MakeWorkingTiles(OrgTiles);
        }

        public SortedDictionary<int, Tile> MakeWorkingTiles(SortedDictionary<int, Tile> orgTiles)
        {
            var workingTiles = new SortedDictionary<int, Tile>();
            foreach (var tile in orgTiles)
            {
                workingTiles.Add(tile.Key, new Tile(tile.Key, tile.Value.TileData.ToArray()));
            }
            return workingTiles;
        }

        public void ProcessEdges()
        {
            Edges.Clear();
            foreach (var tile in Tiles)
            {
                tile.Value.MakeEdges();
                AddEdge(tile.Value.Edge1, tile.Value.TileID, 1, false);
                AddEdge(tile.Value.Edge2, tile.Value.TileID, 2, false);
                AddEdge(tile.Value.Edge3, tile.Value.TileID, 3, false);
                AddEdge(tile.Value.Edge4, tile.Value.TileID, 4, false);
            }
        }

        public void DoChanges()
        {
            if (Changes.Count > 0)
            {
                var maxChanges = Changes.Values.Max(v => v.Count);
                var tile = Changes.First(kvp => kvp.Value.Count == maxChanges);
                var action = Tiles[tile.Key];
                switch (tile.Value[0])
                {
                    case TileActions.RotateRight:
                        Tiles[tile.Key].RotateRight();
                        break;
                    case TileActions.RotateLeft:
                        Tiles[tile.Key].RotateLeft();
                        break;
                    case TileActions.Flip1To3:
                        Tiles[tile.Key].Flip1To3();
                        break;
                    case TileActions.Flip2To4:
                        Tiles[tile.Key].Flip2To4();
                        break;
                    default:
                        break;
                }
            }
            Changes.Clear();
        }

        public bool FindActions()
        {
            Changes.Clear();
            foreach (var edge in Edges)
            {
                var tileId = edge.Value[0].Item1;
                if (edge.Value.Count == 2)
                {
                    var t0 = edge.Value[0];
                    var t1 = edge.Value[1];

                    switch (t0.Item2)
                    {
                        case 1:
                            switch (t1.Item2)
                            {
                                case 1:
                                    // match but on same position, flip1t
                                    AddTileAction(t1.Item1, TileActions.Flip1To3);
                                    break;
                                case 2:
                                    AddTileAction(t1.Item1, TileActions.RotateRight);
                                    break;
                                case 3:
                                    // cool
                                    break;
                                case 4:
                                    AddTileAction(t1.Item1, TileActions.RotateLeft);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                            break;
                        case 2:
                            switch (t1.Item2)
                            {
                                case 1:
                                    AddTileAction(t1.Item1, TileActions.RotateLeft);
                                    break;
                                case 2:
                                    AddTileAction(t1.Item1, TileActions.Flip2To4);
                                    break;
                                case 3:
                                    AddTileAction(t1.Item1, TileActions.RotateRight);
                                    break;
                                case 4:
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                            break;
                        case 3:
                            switch (t1.Item2)
                            {
                                case 1:
                                    break;
                                case 2:
                                    AddTileAction(t1.Item1, TileActions.RotateLeft);
                                    break;
                                case 3:
                                    AddTileAction(t1.Item1, TileActions.Flip1To3);
                                    break;
                                case 4:
                                    AddTileAction(t1.Item1, TileActions.RotateRight);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                            break;
                        case 4:
                            switch (t1.Item2)
                            {
                                case 1:
                                    AddTileAction(t1.Item1, TileActions.RotateRight);
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    AddTileAction(t1.Item1, TileActions.RotateLeft);
                                    break;
                                case 4:
                                    AddTileAction(t1.Item1, TileActions.Flip2To4);
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (edge.Value.Count > 2)
                {
                    // what is up?
                    throw new ArgumentOutOfRangeException();
                }
            }
            return Changes.Count > 0;
        }

        public void AddTileAction(int tileId, TileActions action)
        {
            if (Changes.ContainsKey(tileId))
            {
                Changes[tileId].Add(action);
            }
            else
            {
                List<TileActions> list = new List<TileActions>();
                list.Add(action);
                Changes.Add(tileId, list);
            }
        }

        public void ProcessMatches()
        {
            foreach (var edge in Edges)
            {
                var tileId = edge.Value[0].Item1;
                foreach (var tile in Tiles)
                {
                    if (tile.Key == tileId)
                    {
                        // same tile, skip
                        continue;
                    }
                    if (edge.Key.Equals(tile.Value.Edge1))
                    {
                        AddEdge(edge.Key, tile.Key, 1, true);
                    }
                    if (edge.Key.Equals(tile.Value.Edge2))
                    {
                        AddEdge(edge.Key, tile.Key, 2, true);
                    }
                    if (edge.Key.Equals(tile.Value.Edge3))
                    {
                        AddEdge(edge.Key, tile.Key, 3, true);
                    }
                    if (edge.Key.Equals(tile.Value.Edge4))
                    {
                        AddEdge(edge.Key, tile.Key, 4, true);
                    }
                }
            }
        }

        public void ProcessReverseMatches()
        {
            foreach (var edge in Edges)
            {
                var tileId = edge.Value[0].Item1;
                foreach (var tile in Tiles)
                {
                    if (tile.Key == tileId)
                    {
                        // same tile, skip
                        continue;
                    }
                    if (edge.Key.Equals(Tile.ReverseEdge(tile.Value.Edge1)))
                    {
                        AddEdge(edge.Key, tile.Key, 1, true);
                    }
                    if (edge.Key.Equals(Tile.ReverseEdge(tile.Value.Edge2)))
                    {
                        AddEdge(edge.Key, tile.Key, 2, true);
                    }
                    if (edge.Key.Equals(Tile.ReverseEdge(tile.Value.Edge3)))
                    {
                        AddEdge(edge.Key, tile.Key, 3, true);
                    }
                    if (edge.Key.Equals(Tile.ReverseEdge(tile.Value.Edge4)))
                    {
                        AddEdge(edge.Key, tile.Key, 4, true);
                    }
                }
            }
        }

        public void AddEdge(string edge, int tileId, int edgeNumber, bool match)
        {
            if (Edges.ContainsKey(edge))
            {
                // exists add this tile if not there already
                if (!Edges[edge].Any(t => t.Item1 == tileId && t.Item2 == edgeNumber))
                {
                    Edges[edge].Add(Tuple.Create(tileId, edgeNumber, match));
                }
            }
            else
            {
                List<Tuple<int, int, bool>> list = new List<Tuple<int, int, bool>>();
                list.Add(Tuple.Create(tileId, edgeNumber, match));
                Edges.Add(edge, list);
            }
        }

        public long FindCornerTotal()
        {
            var corners = FindCorners();
            long total = 1;
            foreach (var corner in corners)
            {
                total *= corner;
            }
            return total;
        }

        public List<long> FindCorners()
        {
            Dictionary<long, int> corners = new Dictionary<long, int>();
            foreach (var edge in Edges)
            {
                if (edge.Value.Count == 1)
                {
                    long tileId = edge.Value[0].Item1;
                    if (corners.ContainsKey(tileId))
                    {
                        corners[tileId] += 1;
                    }
                    else
                    {
                        corners.Add(tileId, 1);
                    }
                }
            }
            var list = corners.Where(c => c.Value == 2).Select(c => c.Key).ToList();
            return list;
        }

        public Tile MatchTiles()
        {
            var corners = FindCorners();
            StartCorner = Tiles[Convert.ToInt32(corners[0])];
            foreach (var tile in Tiles)
            {
                MatchEdges(tile.Value);
            }
            return StartCorner;
        }

        public Tile MatchEdges(Tile tileNow)
        {
            if (tileNow == null)
            {
                return null;
            }
            if (tileNow.NextTile1 == null)
            {
                var t1 = Edges[tileNow.Edge1].SingleOrDefault(t => t.Item3 == true);
                tileNow.NextTile1 = ConnectTiles(tileNow, t1);
            }
            if (tileNow.NextTile2 == null)
            {
                var t1 = Edges[tileNow.Edge2].SingleOrDefault(t => t.Item3 == true);
                tileNow.NextTile2 = ConnectTiles(tileNow, t1);
            }
            if (tileNow.NextTile3 == null)
            {
                var t1 = Edges[tileNow.Edge3].SingleOrDefault(t => t.Item3 == true);
                tileNow.NextTile3 = ConnectTiles(tileNow, t1);
            }
            if (tileNow.NextTile4 == null)
            {
                var t1 = Edges[tileNow.Edge4].SingleOrDefault(t => t.Item3 == true);
                tileNow.NextTile4 = ConnectTiles(tileNow, t1);
            }
            return tileNow;
        }

        public Tile ConnectTiles(Tile tNow, Tuple<int, int, bool> tup)
        {
            if (tup is null)
            {
                return null;
            }
            var tile = Tiles[tup.Item1];
            switch (tup.Item2)
            {
                case 1:
                    tile.NextTile1 = tNow;
                    break;
                case 2:
                    tile.NextTile2 = tNow;
                    break;
                case 3:
                    tile.NextTile3 = tNow;
                    break;
                case 4:
                    tile.NextTile4 = tNow;
                    break;
                default:
                    break;
            }
            return tile;
        }

        public void DumpEdges()
        {
            Debug.WriteLine("Edges dictionary");
            foreach (var edge in Edges)
            {
                Debug.WriteLine($"e: {edge.Key}");
                foreach (var tup in edge.Value)
                {
                    Debug.WriteLine($"TileId: {tup.Item1}, edge: {tup.Item2}, matched: {tup.Item3}.");
                }
            }
            Debug.WriteLine("----");
        }

        public void DumpDoubleFalseEdges()
        {
            Debug.WriteLine("Edges Double False dictionary");
            foreach (var edge in Edges.Where(e => (e.Value.Count == 2 && !e.Value.Any(t => t.Item3))))
            {
                Debug.WriteLine($"e: {edge.Key}");
                foreach (var tup in edge.Value)
                {
                    Debug.WriteLine($"TileId: {tup.Item1}, edge: {tup.Item2}, matched: {tup.Item3}.");
                }
            }
            Debug.WriteLine("----");
        }


        //public void DumpTilesEdges()
        //{
        //    Debug.WriteLine("Dump Tile Edge matches");
        //    foreach (var tile in Tiles)
        //    {
        //        Debug.WriteLine($"e: {tile.Key}");
        //        foreach (var edge in tile.Value)
        //        {
        //            Debug.WriteLine($"TileId: {tup.Item1}, edge: {tup.Item2}, matched: {tup.Item3}.");
        //        }
        //    }
        //    Debug.WriteLine("----");
        //}

        public void DumpTileIds()
        {
            Debug.WriteLine("TileIds");
            Debug.Write($" {StartCorner.TileID} ");
            bool foundRow = false;
            if (StartCorner.NextTile1 != null)
            {
                DumpRowTiles(StartCorner, StartCorner.NextTile1);
                foundRow = true;
            }
            if (StartCorner.NextTile2 != null)
            {
                if (foundRow)
                {
                    DumpColumnTiles(StartCorner, StartCorner.NextTile2);
                    return;
                }
                else
                {
                    DumpRowTiles(StartCorner, StartCorner.NextTile2);
                    foundRow = true;
                }
            }
            if (StartCorner.NextTile3 != null)
            {
                if (foundRow)
                {
                    DumpColumnTiles(StartCorner, StartCorner.NextTile3);
                    return;
                }
                else
                {
                    DumpRowTiles(StartCorner, StartCorner.NextTile3);
                    foundRow = true;
                }
            }
            if (StartCorner.NextTile4 != null)
            {
                if (foundRow)
                {
                    DumpColumnTiles(StartCorner, StartCorner.NextTile4);
                    return;
                }
                else
                {
                    DumpRowTiles(StartCorner, StartCorner.NextTile4);
                    foundRow = true;
                }
            }
        }

        public void DumpRowTiles(Tile prev, Tile now)
        {
            if (now == null)
            {
                Debug.WriteLine("");
                return;
            }
            Debug.Write($" {now.TileID} ");
            if (prev.TileID == now.NextTile1?.TileID)
            {
                DumpRowTiles(now, now.NextTile3);
            }
            else if (prev.TileID == now.NextTile2?.TileID)
            {
                DumpRowTiles(now, now.NextTile4);
            }
            else if (prev.TileID == now.NextTile3?.TileID)
            {
                DumpRowTiles(now, now.NextTile1);
            }
            else if (prev.TileID == now.NextTile4?.TileID)
            {
                DumpRowTiles(now, now.NextTile2);
            }
        }

        public void DumpColumnTiles(Tile prev, Tile now)
        {
            if (now == null)
            {
                Debug.WriteLine("");
                return;
            }
            // Should be a corner or an edge
            Debug.Write($" {now.TileID} ");
            if (prev.TileID == now.NextTile1?.TileID)
            {
                if (now.NextTile2 != null)
                {
                    DumpRowTiles(now, now.NextTile2);
                    DumpColumnTiles(now, now.NextTile3);
                }
                else
                {
                    DumpRowTiles(now, now.NextTile4);
                    DumpColumnTiles(now, now.NextTile3);
                }
            }
            else if (prev.TileID == now.NextTile2?.TileID)
            {
                if (now.NextTile1 != null)
                {
                    DumpRowTiles(now, now.NextTile1);
                    DumpColumnTiles(now, now.NextTile4);
                }
                else
                {
                    DumpRowTiles(now, now.NextTile3);
                    DumpColumnTiles(now, now.NextTile4);
                }
            }
            else if (prev.TileID == now.NextTile3?.TileID)
            {
                if (now.NextTile2 != null)
                {
                    DumpRowTiles(now, now.NextTile2);
                    DumpColumnTiles(now, now.NextTile1);
                }
                else
                {
                    DumpRowTiles(now, now.NextTile4);
                    DumpColumnTiles(now, now.NextTile1);
                }
            }
            else if (prev.TileID == now.NextTile4?.TileID)
            {
                if (now.NextTile1 != null)
                {
                    DumpRowTiles(now, now.NextTile1);
                    DumpColumnTiles(now, now.NextTile2);
                }
                else
                {
                    DumpRowTiles(now, now.NextTile3);
                    DumpColumnTiles(now, now.NextTile2);
                }
            }
        }
    }
}
