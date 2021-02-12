using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace AdventOfCode2020
{
    /// <summary>
    /// Testing day 20 solution from this github: https://github.com/Perska/AoC2020
    /// </summary>
    public class JurassicJigsawPerska
    {
        const int CardSize = 10;
        List<(char sym, long id)[][,]> panels = new List<(char, long)[][,]>();
        Dictionary<(int x, int y), (char sym, long id)> image = new Dictionary<(int x, int y), (char sym, long id)>();
        Dictionary<long, bool> usedCards = new Dictionary<long, bool>();

        public long Roughness { get; set; }
        public long Corners { get; set; }

        public void Day20(List<string> input)
        {
            // first array is the panel permutation (unchanged, rotated 90°, flipped vert, rot+vert, hori, rot+hori, vert+hori, rot+vert+hori)
            int line = 0;
            while (line < input.Count)
            {
                if (input[line].StartsWith("Tile"))
                {
                    long panelNum = long.Parse(input[line].Substring(5, 4));
                    var panel = new (char sym, long id)[8][,];
                    //var card = new (char, int)[CardSize, CardSize];
                    line++;
                    for (int k = 0; k < 8; k++)
                    {
                        panel[k] = new (char, long)[CardSize, CardSize];
                        for (int i = 0; i < CardSize; i++)
                        {
                            for (int j = 0; j < CardSize; j++)
                            {
                                panel[k][j, i] = (input[line + i][j], panelNum);
                            }
                        }
                    }
                    for (int i = 1; i < 8; i++)
                    {
                        if ((i & 1) == 1)
                            panel[i] = RotateMatrix(panel[i]);
                        if ((i & 2) == 2)
                            panel[i] = FlipVert(panel[i]);
                        if ((i & 4) == 4)
                            panel[i] = FlipHori(panel[i]);
                    }
                    //Debug.WriteLine(panelNum);
                    panels.Add(panel);
                }
                line++;
            }

            /*foreach (var card in panels)
			{
				Debug.WriteLine(card[0][0, 0].id);
				for (int k = 0; k < 8; k++)
				{
					Debug.WriteLine(k);
					for (int i = 0; i < CardSize; i++)
					{
						for (int j = 0; j < CardSize; j++)
						{
							Debug.Write(card[k][j, i].sym);
						}
						Debug.WriteLine();
					}
					Debug.WriteLine();
				}
			}*/
            PlaceCard(0, 0, panels[0][0], true);

            int minx;
            int miny;
            int maxx;
            int maxy;
            int last = -1;
            while (usedCards.Count != last)
            {
                last = usedCards.Count;
                minx = image.Min(item => item.Key.x / CardSize) - 1;
                miny = image.Min(item => item.Key.y / CardSize) - 1;
                maxx = image.Max(item => item.Key.x / CardSize) + 1;
                maxy = image.Max(item => item.Key.y / CardSize) + 1;
                for (int i = miny; i <= maxy; i++)
                {
                    for (int j = minx; j <= maxx; j++)
                    {
                        foreach (var item in panels)
                        {
                            for (int k = 0; k < 8; k++)
                            {
                                if (PlaceCard(j, i, item[k])) goto panelPicked;
                            }
                        }
                    panelPicked:;
                    }
                }
            }
            minx = image.Min(item => item.Key.x);
            miny = image.Min(item => item.Key.y);
            maxx = image.Max(item => item.Key.x);
            maxy = image.Max(item => item.Key.y);
            /*for (int i = miny; i <= maxy; i++)
			{
				for (int j = minx; j <= maxx; j++)
				{
					Debug.Write(image.TryGetValue((j, i), out var c) ? c.sym : ' ');//].sym);
					if (Mod(j, CardSize) == CardSize - 1) Debug.Write(' ');
				}
				Debug.WriteLine();
				if (Mod(i, CardSize) == CardSize-1) Debug.WriteLine();
			}*/

            Corners = image[(minx, miny)].id * image[(maxx, miny)].id * image[(minx, maxy)].id * image[(maxx, maxy)].id;
            Debug.WriteLine(Corners);

            List<List<char>> _map = new List<List<char>>();
            int seaRough = 0;

            for (int i = miny; i <= maxy; i++)
            {
                if (Mod(i, 10) == 0 || Mod(i, 10) == 9) continue;
                List<char> row = new List<char>();
                for (int j = minx; j <= maxx; j++)
                {
                    if (Mod(j, 10) == 0 || Mod(j, 10) == 9) continue;
                    row.Add(image[(j, i)].sym);
                    if (image[(j, i)].sym == '#') seaRough++;
                }
                _map.Add(row);
            }
            char[][,] map = new char[8][,];
            for (int k = 0; k < 8; k++)
            {
                map[k] = new char[_map.Count, _map.Count];
                for (int i = 0; i < _map.Count; i++)
                {
                    for (int j = 0; j < _map.Count; j++)
                    {
                        map[k][j, i] = _map[i][j];
                    }
                }
            }
            for (int i = 1; i < 8; i++)
            {
                map[i] = map[0];
                if ((i & 1) == 1)
                    map[i] = RotateMatrix(map[i]);
                if ((i & 2) == 2)
                    map[i] = FlipVert(map[i]);
                if ((i & 4) == 4)
                    map[i] = FlipHori(map[i]);
            }
            string[] monster = new string[]
            {
                "                  # ",
                "#    ##    ##    ###",
                " #  #  #  #  #  #   "
            };
            int[] roughness = new int[8];
            for (int i = 0; i < 8; i++)
            {
                int hits = 0;
                for (int y = 0; y < _map.Count - monster.Length; y++)
                {
                    for (int x = 0; x < _map.Count - monster[0].Length; x++)
                    {
                        int subHits = 0;
                        for (int j = 0; j < monster.Length; j++)
                        {
                            for (int k = 0; k < monster[0].Length; k++)
                            {
                                bool spotHasRough = map[i][x + k, y + j] == '#';
                                bool spotRequiresRough = monster[j][k] == '#';
                                if (spotHasRough && spotRequiresRough) subHits++;
                                if (spotRequiresRough && !spotHasRough)
                                {
                                    goto skip;
                                }
                            }
                        }
                        hits += subHits;
                    skip:;
                    }
                }
                roughness[i] = seaRough - hits;
            }
            Roughness = roughness.Min();
            Debug.WriteLine(Roughness);
        }

        public bool PlaceCard(int x, int y, (char sym, long id)[,] card, bool skipPlaceCheck = false)
        {
            if (usedCards.ContainsKey(card[0, 0].id)) return false;
            if (image.ContainsKey((x * CardSize, y * CardSize))) return false;
            if (!skipPlaceCheck)
            {

                for (int i = 0; i < CardSize; i++)
                {
                    (char sym, long id) thing;
                    if (image.TryGetValue((x * CardSize + i, y * CardSize - 1), out thing))
                    {
                        if (thing.sym != card[i, 0].sym) return false;
                    }
                    else if (image.TryGetValue((x * CardSize + i, (y + 1) * CardSize), out thing))
                    {
                        if (thing.sym != card[i, CardSize - 1].sym) return false;
                    }
                    else if (image.TryGetValue((x * CardSize - 1, y * CardSize + i), out thing))
                    {
                        if (thing.sym != card[0, i].sym) return false;
                    }
                    else if (image.TryGetValue(((x + 1) * CardSize, y * CardSize + i), out thing))
                    {
                        if (thing.sym != card[CardSize - 1, i].sym) return false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            usedCards[card[0, 0].id] = true;
            for (int i = 0; i < CardSize; i++)
            {
                for (int j = 0; j < CardSize; j++)
                {
                    image[(x * CardSize + i, y * CardSize + j)] = card[i, j];
                }
            }
            return true;
        }

        public int Mod(int a, int b)
        {
            return (int)(a - Math.Floor(a * 1.0 / b) * b);
        }

        public T[,] FlipVert<T>(T[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new ArgumentException();
            T[,] ret = new T[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ret[j, i] = matrix[n - j - 1, i];
                }
            }

            return ret;
        }

        public T[,] FlipHori<T>(T[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new ArgumentException();
            T[,] ret = new T[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ret[i, j] = matrix[i, n - j - 1];
                }
            }

            return ret;
        }

        /// <summary>
        /// Rotates an array by 90 degrees.
        /// Modified to be generic and automatically get the array dimension size.
        /// https://stackoverflow.com/a/42535
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public T[,] RotateMatrix<T>(T[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new ArgumentException();
            T[,] ret = new T[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    ret[j, i] = matrix[i, n - j - 1];
                }
            }

            return ret;
        }
    }
}
