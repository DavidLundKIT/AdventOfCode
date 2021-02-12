using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode2020
{
    public class ConwayCubes4D
    {
        public const int kGenerations = 2;

        public List<Dictionary<Tuple<int, int, int, int>, bool>> Cubes { get; set; }
        public int Now { get; set; }
        public int Next { get; set; }

        public int Imin { get; set; }
        public int Imax { get; set; }
        public int Jmin { get; set; }
        public int Jmax { get; set; }
        public int Kmin { get; set; }
        public int Kmax { get; set; }
        public int Nmin { get; set; }
        public int Nmax { get; set; }

        public ConwayCubes4D()
        {
            Cubes = new List<Dictionary<Tuple<int, int, int, int>, bool>>();
            Cubes.Add(new Dictionary<Tuple<int, int, int, int>, bool>());
            Cubes.Add(new Dictionary<Tuple<int, int, int, int>, bool>());
            Now = 0;
            Next = 1;
        }

        public void Toggle()
        {
            Now = Now == 0 ? 1 : 0;
            Next = Next == 0 ? 1 : 0;
        }

        public void CreateStartCubes(string[] lines)
        {
            int k = 0;
            int n = 0;
            Now = 0;
            Next = 1;
            Cubes[Now].Clear();
            Cubes[Next].Clear();
            for (int j = 0; j < lines.Length; j++)
            {
                var states = lines[j].ToCharArray();
                for (int i = 0; i < states.Length; i++)
                {
                    if (states[i] == '#')
                    {
                        Cubes[Now].Add(Tuple.Create(i, j, k, n), true);
                    }
                }
            }
        }

        public int NumberActiveCubes(int gen)
        {
            return Cubes[gen].Count;
        }

        public void ResetMinMaxs()
        {
            Imin = int.MaxValue;
            Imax = int.MinValue;
            Jmin = int.MaxValue;
            Jmax = int.MinValue;
            Kmin = int.MaxValue;
            Kmax = int.MinValue;
            Nmin = int.MaxValue;
            Nmax = int.MinValue;
        }

        public int SetMinMax(Tuple<int, int, int, int> tNow)
        {
            Imin = Math.Min(Imin, tNow.Item1);
            Imax = Math.Max(Imax, tNow.Item1);
            Jmin = Math.Min(Jmin, tNow.Item2);
            Jmax = Math.Max(Jmax, tNow.Item2);
            Kmin = Math.Min(Kmin, tNow.Item3);
            Kmax = Math.Max(Kmax, tNow.Item3);
            Nmin = Math.Min(Nmin, tNow.Item4);
            Nmax = Math.Max(Nmax, tNow.Item4);
            return 0;
        }

        public void DoCycle()
        {
            Cubes[Next].Clear();
            ResetMinMaxs();

            _ = Cubes[Now].Keys.Select(kt => SetMinMax(kt)).ToArray();
            for (int n = Nmin - 1; n <= Nmax + 1; n++)
            {
                for (int k = Kmin - 1; k <= Kmax + 1; k++)
                {
                    for (int j = Jmin - 1; j <= Jmax + 1; j++)
                    {
                        for (int i = Imin - 1; i <= Imax + 1; i++)
                        {
                            var tKey = Tuple.Create(i, j, k, n);
                            bool activeNextTime = CheckCubeStatus(tKey);
                            if (activeNextTime)
                            {
                                Cubes[Next].Add(tKey, true);
                            }
                        }
                    }
                }
            }
        }

        public bool CheckCubeStatus(Tuple<int, int, int, int> tKey)
        {
            bool isActiveNow = Cubes[Now].ContainsKey(tKey);
            int neighbors = 0;
            for (int n = -1; n <= 1; n++)
            {
                for (int k = -1; k <= 1; k++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            var tNow = Tuple.Create(tKey.Item1 + i, tKey.Item2 + j, tKey.Item3 + k, tKey.Item4 + n);
                            if (!tNow.Equals(tKey))
                            {
                                if (Cubes[Now].ContainsKey(tNow))
                                {
                                    neighbors++;
                                }
                            }
                        }
                    }
                }
            }
            if (isActiveNow)
            {
                if (neighbors == 2 || neighbors == 3)
                    return true;
                else
                    return false;
            }
            if (neighbors == 3)
            {
                return true;
            }
            return false;
        }

        public void DumpGeneration()
        {
            ResetMinMaxs();
            _ = Cubes[Now].Keys.Select(kt => SetMinMax(kt)).ToArray();
            Debug.WriteLine("---------");
            Debug.WriteLine("J x-axis: ({0}, {1})", Jmin, Jmax);
            Debug.WriteLine("I y-axis: ({0}, {1})", Imin, Imax);
            Debug.WriteLine("K z-axis: ({0}, {1})", Kmin, Kmax);
            Debug.WriteLine("N w-axis: ({0}, {1})", Nmin, Nmax);

            for (int n = Nmin; n <= Nmax; n++)
            {
                for (int k = Kmin; k <= Kmax; k++)
                {
                    Debug.WriteLine("Z = {0}, W= {1}", k, n);
                    for (int j = Jmin; j <= Jmax; j++)
                    {
                        Debug.Write(j.ToString("D3"));
                        Debug.Write("|");
                        for (int i = Imin; i <= Imax; i++)
                        {
                            if (Cubes[Now].ContainsKey(Tuple.Create(i, j, k, n)))
                            {
                                Debug.Write("#");
                            }
                            else
                            {
                                Debug.Write(".");
                            }
                        }
                        Debug.WriteLine("");
                    }
                    Debug.WriteLine("");
                }
            }
        }
    }
}
