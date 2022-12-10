namespace AdventCode2022.Models
{
    public class CathodeCpu
    {
        public long RegisterX { get; set; }
        public int Cycle { get; set; }
        public long CycleSignal { get; set; }
        public int PrgmIndex { get; set; }
        public string PrgmLineNow { get; set; }
        public string[] PrgmLines { get; set; }
        public Queue<long> PipeLine { get; set; }

        public CathodeCpu(string[] pgmLines)
        {
            PipeLine = new Queue<long>();
            PrgmLines = pgmLines;
            PrgmLineNow = pgmLines[0];
            Init();
        }

        public void Init()
        {
            PrgmIndex = -1;
            RegisterX = 1;
            Cycle = 0;
        }

        public long DoCycle()
        {
            if (PipeLine.Count == 0)
            {
                string cmd = PrgmLines[++PrgmIndex];
                PrgmLineNow = cmd;
                var parts = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (PrgmIndex >= PrgmLines.Length)
                {
                    PrgmIndex = 0;
                }
                if (parts[0] == "addx")
                {

                    PipeLine.Enqueue(0);
                    long val = long.Parse(parts[1]);
                    PipeLine.Enqueue(val);
                }
                if (parts[0] == "noop")
                {
                    PipeLine.Enqueue(0);
                }
            }
            Cycle++;
            CycleSignal = RegisterX;
            RegisterX += PipeLine.Dequeue();
            return RegisterX;
        }

        public long DoCycles(long steps)
        {
            for (long i = 0; i < steps; i++)
            {
                DoCycle();
            }
            return RegisterX;
        }
    }
}
