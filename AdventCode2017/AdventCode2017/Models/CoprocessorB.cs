namespace AdventCodeLib
{
    /// <summary>
    /// Doing as C# code instead
    /* 
        set b 84
        set c b
        jnz a 2
        jnz 1 5
        mul b 100
        sub b -100000
        set c b
        sub c -17000
        set f 1
        set d 2
        set e 2
        set g d
        mul g e
        sub g b
        jnz g 2
        set f 0
        sub e -1
        set g e
        sub g b
        jnz g -8
        sub d -1
        set g d
        sub g b
        jnz g -13
        jnz f 2
        sub h -1
        set g b
        sub g c
        jnz g 2
        jnz 1 3
        sub b -17
        jnz 1 -23
    */
    /// </summary>
    public class CoprocessorB
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public int E { get; set; }
        public int F { get; set; }
        public int G { get; set; }
        public int H { get; set; }
        public CoprocessorB()
        {

        }

        public void PlayProgram()
        {
            if (B == 0 || C == 0)
                return;
            do
            {
                F = 1;
                D = 2;
                do
                {
                    //E = 2;
                    //do
                    //{
                    //    G = D;
                    //    G = (G * E) - B;
                    //    if (G == 0)
                    //    {
                    //        F = 0;
                    //    }
                    //    E += 1;
                    //    G = E - B;
                    //} while (G != 0);
                    // above rewritten to these 4 lines
                    G = B % D;
                    if (G == 0)
                    {
                        F = 0;
                    }
                    D += 1;
                    G = D - B;
                } while (G != 0);

                if (F == 0)
                {
                    H += 1;
                }
                G = B - C;
                if (G == 0)
                {
                    break;
                }
                    B += 17;
            } while (G != 0);
        }
    }
}
