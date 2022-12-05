using System.Text;

namespace AdventCode2022.Models
{
    public class SupplyCrane
    {
        public List<Stack<char>> Stacks { get; set; }

        public SupplyCrane(int stackSize)
        {
            Stacks = new List<Stack<char>>(stackSize);
            if (9 == stackSize)
            {
                // test
                Stacks.Add(new Stack<char>(new[] { 'Z', 'J', 'N', 'W', 'P', 'S' }));
                Stacks.Add(new Stack<char>(new[] { 'G', 'S', 'T' }));
                Stacks.Add(new Stack<char>(new[] { 'V', 'Q', 'R', 'L', 'H' }));

                Stacks.Add(new Stack<char>(new[] { 'V', 'S', 'T', 'D' }));
                Stacks.Add(new Stack<char>(new[] { 'Q', 'Z', 'T', 'D', 'B', 'M', 'J' }));
                Stacks.Add(new Stack<char>(new[] { 'M', 'W', 'T', 'J', 'D', 'C', 'Z', 'L' }));

                Stacks.Add(new Stack<char>(new[] { 'L', 'P', 'M', 'W', 'G', 'T', 'J' }));
                Stacks.Add(new Stack<char>(new[] { 'N', 'G', 'M', 'T', 'B', 'F', 'Q', 'H' }));
                Stacks.Add(new Stack<char>(new[] { 'R', 'D', 'G', 'C', 'P', 'B', 'Q', 'W' }));
            }
            else
            {
                Stacks.Add(new Stack<char>(new[] { 'Z', 'N' }));
                Stacks.Add(new Stack<char>(new[] { 'M', 'C', 'D' }));
                Stacks.Add(new Stack<char>(new[] { 'P' }));
            }
        }

        public void DoCmd(string cmd)
        {
            var parts = cmd.Split(new char[] { ' ' });
            int amount= int.Parse(parts[1]);
            int from = int.Parse(parts[3]);
            int to = int.Parse(parts[5]);

            for (int item = 0; item < amount; item++)
            {
                var crate = Stacks[from - 1].Pop();
                Stacks[to-1].Push(crate);
            }
        }

        public void DoCmd9001(string cmd)
        {
            var parts = cmd.Split(new char[] { ' ' });
            int amount = int.Parse(parts[1]);
            int from = int.Parse(parts[3]);
            int to = int.Parse(parts[5]);

            var tempStack = new Stack<char>();
            for (int item = 0; item < amount; item++)
            {
                var crate = Stacks[from - 1].Pop();
                tempStack.Push(crate);
            }

            while (tempStack.Count> 0)
            {
                var crate = tempStack.Pop();
                Stacks[to - 1].Push(crate);
            }
        }

        public string PeekStackTops()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Stacks.Count; i++)
            {
                sb.Append(Stacks[i].Peek());
            }
            return sb.ToString();
        }
    }
}
