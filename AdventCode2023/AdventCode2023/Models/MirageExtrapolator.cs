namespace AdventCode2023.Models
{
    public class MirageExtrapolator
    {
        public List<long> StartValues { get; set; }
        public MirageExtrapolator(string line)
        {
            StartValues = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(n => long.Parse(n)).ToList();
        }

        public long Extrapolate()
        {
            List<long> values = new List<long>(StartValues);
            Stack<long> stack = new Stack<long>();
            do
            {
                stack.Push(values[values.Count - 1]);
                for (int i = 0; i < values.Count - 1; i++)
                {
                    values[i] = values[i + 1] - values[i];
                }
                values.RemoveAt(values.Count - 1);
            } while (values.Any(v => v != 0));

            long value = 0;
            while (stack.Count > 0)
            {
                value += stack.Pop();
            }
            return value;
        }

        public long ExtrapolateBack()
        {
            List<long> values = new List<long>(StartValues);
            Stack<long> stack = new Stack<long>();
            do
            {
                stack.Push(values[0]);
                for (int i = 0; i < values.Count - 1; i++)
                {
                    values[i] = values[i + 1] - values[i];
                }
                values.RemoveAt(values.Count - 1);
            } while (values.Any(v => v != 0));

            long start = 0;
            long value = 0;
            while (stack.Count > 0)
            {
                long result = stack.Pop();
                value = result - start;
                start = value;
            }
            return value;
        }
    }
}
