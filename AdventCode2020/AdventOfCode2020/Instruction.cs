namespace AdventOfCode2020
{
    public class Instruction
    {
        public Instruction(string line)
        {
            Count = 0;
            var parts = line.Split(new char[] { ' ' });
            Cmd = parts[0].Trim().ToLower();
            Operand = long.Parse(parts[1]);
        }

        public string Cmd { get; set; }
        public long Operand { get; set; }
        public long Count { get; set; }

        public override string ToString()
        {
            return $"cmd: {Cmd}, op: {Operand}, cnt: {Count}";
        }
    }
}
