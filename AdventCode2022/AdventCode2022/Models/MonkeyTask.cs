namespace AdventCode2022.Models
{
    public class MonkeyTask
    {
        public string Key { get; set; }
        public string LeftKey { get; set; }
        public string RightKey { get; set; }
        public long Value { get; set; }
        public char Operand { get; set; }
        public int TimesCalled { get; set; }

        public MonkeyTask(string line)
        {
            var parts = line.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                Key = parts[0];
                Value = long.Parse(parts[1]);
                Operand = 'v';
                LeftKey = string.Empty;
                RightKey = string.Empty;
            }
            else if (parts.Length == 4)
            {
                Key = parts[0];
                Value = 0;
                Operand = parts[2][0];
                LeftKey = parts[1];
                RightKey = parts[3];
            }
            TimesCalled = 0;
        }
    }
}
