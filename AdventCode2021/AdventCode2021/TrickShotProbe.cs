using System.Diagnostics;

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
