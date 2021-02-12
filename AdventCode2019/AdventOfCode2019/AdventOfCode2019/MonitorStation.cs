using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace AdventOfCode2019
{
    public class MonitorStation
    {
        public MonitorStation(string[] map)
        {
            Asteroids = ParseAsteriodMap(map);
            BestStation = null;
        }

        public List<Point> Asteroids { get; set; }

        public Point BestStation { get; set; }

        public List<Point> ParseAsteriodMap(string[] map)
        {
            List<Point> asteroids = new List<Point>();

            for (int y = 0; y < map.Length; y++)
            {
                char[] rock = map[y].ToCharArray();
                for (int x = 0; x < rock.Length; x++)
                {
                    if (rock[x] == '#')
                    {
                        asteroids.Add(new Point(x, y));
                    }
                }
            }
            return asteroids;
        }

        public Point FindBestStation()
        {
            BestStation = null;

            foreach (var stn in Asteroids)
            {
                var dictLOS = CalculateLOS(stn);
                int sighted = CountSightings(dictLOS, stn);
                if (BestStation == null)
                {
                    BestStation = stn;
                }
                else
                {
                    if (BestStation.Steps0 < sighted)
                    {
                        BestStation = stn;
                    }
                }
            }
            return BestStation;
        }

        public SortedDictionary<double, List<Point>> CalculateLOS(Point station)
        {
            SortedDictionary<double, List<Point>> dictLOS = new SortedDictionary<double, List<Point>>();
            double slope;
            foreach (var rock in Asteroids)
            {
                if (rock.X == station.X && rock.Y == station.Y)
                {
                    // skip myself
                    continue;
                }
                if ((station.X - rock.X) == 0)
                {
                    if ((rock.dY - station.dY) > 0)
                        slope = double.MaxValue;
                    else
                        slope = double.MinValue;
                }
                else
                {
                    slope = (rock.dY - station.dY) / (rock.dX - station.dX);
                }

                if (!dictLOS.ContainsKey(slope))
                {
                    List<Point> inlineAsteroids = new List<Point>();
                    inlineAsteroids.Add(rock);
                    dictLOS.Add(slope, inlineAsteroids);
                }
                else
                {
                    dictLOS[slope].Add(rock);
                }
            }
            return dictLOS;
        }

        public int CountSightings(SortedDictionary<double, List<Point>> dictLOS, Point station)
        {
            int count = 0;
            foreach (var list in dictLOS.Values)
            {
                if (list.Count > 0)
                {
                    // see at least one
                    count += 1;
                    if (list.Count > 1)
                    {
                        // at most 2 because
                        bool gtX = false, gtY = false, leX = false, leY = false;
                        foreach (var rock in list)
                        {
                            if (station.X <= rock.X)
                            {
                                leX = true;
                            }
                            else
                            {
                                gtX = true;
                            }
                            if (station.Y <= rock.Y)
                            {
                                leY = true;
                            }
                            else
                            {
                                gtY = true;
                            }
                        }
                        if ((gtX == true && leX == true) || (gtY == true && leY == true))
                        {
                            // both sides of the middle
                            count += 1;
                        }
                    }
                }
            }
            station.Steps0 = count;
            return count;
        }

        public List<PolarPoint> MakeMapPolar(Point station)
        {
            List<PolarPoint> polarPts = new List<PolarPoint>();

            foreach (var pt in Asteroids)
            {
                if (pt.X == station.X && pt.Y == station.Y)
                {
                    continue;
                }
                PolarPoint polar = new PolarPoint(pt, station);
                polarPts.Add(polar);
            }

            
            return polarPts;
        }

        /// <summary>
        /// This dictionary has the angle as the key, and the polar points in the list
        /// </summary>
        /// <param name="polarPts"></param>
        /// <returns></returns>
        public SortedDictionary<double, List<PolarPoint>> MakePolarLOS(List<PolarPoint> polarPts)
        {
            SortedDictionary<double, List<PolarPoint>> dictLOS = new SortedDictionary<double, List<PolarPoint>>();
            foreach (var rock in polarPts)
            {
                if (!dictLOS.ContainsKey(rock.angle))
                {
                    List<PolarPoint> inlineAsteroids = new List<PolarPoint>();
                    inlineAsteroids.Add(rock);
                    dictLOS.Add(rock.angle, inlineAsteroids);
                }
                else
                {
                    dictLOS[rock.angle].Add(rock);
                }
            }
            return dictLOS;
        }

        public void DumpPolarLOS(SortedDictionary<double, List<PolarPoint>> dictPolar)
        {
            int count = 0;
            foreach (double angle in dictPolar.Keys)
            {
                Debug.WriteLine("idx: {0}, Angle: {1}", count, angle);
                count++;
                foreach (PolarPoint polarPoint in dictPolar[angle])
                {
                    Debug.Write("  ");
                    Debug.WriteLine(polarPoint.ToString());
                }
            }
        }
    }
}
