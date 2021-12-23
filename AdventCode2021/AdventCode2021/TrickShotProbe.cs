using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventCode2021
{
    public class TrickShotProbe
    {
        public int Velx { get; set; }
        public int Vely { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Sec { get; set; }

        public TrickShotProbe(int vx, int vy)
        {
            Velx = vx;
            Vely = vy;
            X = 0;
            Y = 0;
            Sec = 0;
            Debug.WriteLine($"S {Sec}: V {Velx}, {Vely} - P: {X}, {Y}");
        }

        public void DoSecondX()
        {
            X += Velx;
            if (Velx > 0)
            {
                Velx--;
            }
            else if (Velx < 0)
            {
                Velx++;
            }
        }

        public void DoSecondY()
        {
            Y += Vely;
            Vely--;
        }

        public void DoSecond()
        {
            Sec++;
            DoSecondX();
            DoSecondY();
            Debug.WriteLine($"S {Sec}: V {Velx}, {Vely} - P: {X}, {Y}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static Dictionary<int, List<Tuple<int, int, int>>> FindValidVelocityXs(Target target)
        {
            Dictionary<int, List<Tuple<int, int, int>>> dictVoT = new Dictionary<int, List<Tuple<int, int, int>>>();

            foreach (var velX in Enumerable.Range(10, target.X2))
            {
                var sut = new TrickShotProbe(velX, 0);
                int sec = 0;
                do
                {
                    sec++;
                    sut.DoSecondX();
                    if (target.InsideX(sut.X))
                    {
                        Debug.WriteLine($"velX: {velX}, t: {sec}, X: {sut.X}");
                        if (!dictVoT.ContainsKey(velX))
                            dictVoT.Add(velX, new List<Tuple<int, int, int>>());

                        dictVoT[velX].Add(new Tuple<int, int, int>(velX, sec, sut.X));
                    }

                } while (sut.X <= target.X2 && sut.Velx > 0);
            }
            return dictVoT;
        }

        public static Dictionary<int, List<Tuple<int, int, int>>> FindValidVelocityYs(Target target)
        {
            Dictionary<int, List<Tuple<int, int, int>>> dictVoT = new Dictionary<int, List<Tuple<int, int, int>>>();

            foreach (var velY in Enumerable.Range(-130, 1000))
            {
                var sut = new TrickShotProbe(0, velY);
                int sec = 0;
                int maxY = int.MinValue;
                do
                {
                    sec++;
                    sut.DoSecondY();
                    if (sut.Y > maxY)
                        maxY = sut.Y;
                    if (target.InsideY(sut.Y))
                    {
                        Debug.WriteLine($"velY: {velY}, t: {sec}, Y: {sut.Y},  maxY: {maxY}");
                        if (!dictVoT.ContainsKey(velY))
                            dictVoT.Add(velY, new List<Tuple<int, int, int>>());

                        dictVoT[velY].Add(new Tuple<int, int, int>(velY, sec, maxY));
                    }

                } while (sut.Y >= target.Y1);
            }
            return dictVoT;
        }
    }

    public class Target
    {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }

        public Target(int x1, int x2, int y1, int y2)
        {
            X1 = x1;
            X2 = x2;
            Y1 = y1;
            Y2 = y2;
        }

        public bool InsideX(int x)
        {
            return (X1 <= x && x <= X2);
        }

        public bool InsideY(int y)
        {
            return (Y1 <= y && y <= Y2);
        }

        public bool Inside(int x, int y)
        {
            return InsideX(x) && InsideY(y);
        }
    }
}
