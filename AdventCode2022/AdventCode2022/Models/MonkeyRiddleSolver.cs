using System.Diagnostics;

namespace AdventCode2022.Models
{
    public class MonkeyRiddleSolver
    {
        public Dictionary<string, MonkeyTask> ProgramDict { get; set; }

        public MonkeyRiddleSolver(string[] lines)
        {
            ProgramDict = new Dictionary<string, MonkeyTask>();

            foreach (string line in lines)
            {
                var mt = new MonkeyTask(line);
                ProgramDict.Add(mt.Key, mt);
            }
        }

        public long Solve(string key)
        {
            var mt = ProgramDict[key];
            ProgramDict[key].TimesCalled++;

            if (mt.Operand == 'v')
            {
                if (key == "humn")
                {
                    Debug.WriteLine("In humn");
                }
                return mt.Value;
            }

            long leftValue = Solve(mt.LeftKey);
            long rightValue = Solve(mt.RightKey);
            long result = 0;

            switch (mt.Operand)
            {
                case '+':
                    result = leftValue + rightValue;
                    break;
                case '-':
                    result = leftValue - rightValue;
                    break;
                case '*':
                    result = leftValue * rightValue;
                    break;
                case '/':
                    result = leftValue / rightValue;
                    break;
                default:
                    Debug.WriteLine($"Operand: {mt.Operand}");
                    break;
            }
            return result;
        }
    }
}
