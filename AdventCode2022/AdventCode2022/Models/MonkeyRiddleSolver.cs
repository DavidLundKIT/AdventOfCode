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
                case '=':
                    result = leftValue / rightValue;
                    break;
                default:
                    Debug.WriteLine($"Operand: {mt.Operand}");
                    break;
            }
            return result;
        }


        public long SolveForValue(string key, bool isLeftKey)
        {
            long leftValue = 0;
            long rightValue = 0;
            long result = 0;
            if (key == "root")
            {
                var root = ProgramDict["root"];
                if (isLeftKey)
                {
                    rightValue = Solve(root.RightKey);
                    return rightValue;
                }
                else
                {
                    leftValue = Solve(root.LeftKey);
                    return leftValue;
                }
            }
            var mt = ProgramDict.Values.Where(mt => mt.LeftKey == key).SingleOrDefault();
            if (mt != null)
            {
                // left key
                rightValue = Solve(mt.RightKey);
                leftValue = SolveForValue(mt.Key, true);
                switch (mt.Operand)
                {
                    case '+':
                        result = leftValue - rightValue;
                        break;
                    case '-':
                        result = leftValue + rightValue;
                        break;
                    case '*':
                        result = leftValue / rightValue;
                        break;
                    case '/':
                        result = leftValue * rightValue;
                        break;
                    case '=':
                        result = rightValue;
                        break;
                    default:
                        Debug.WriteLine($"Operand: {mt.Operand}");
                        break;
                }
                return result;
            }
            mt = ProgramDict.Values.Where(mt => mt.RightKey == key).SingleOrDefault();
            if (mt == null)
            {
                throw new ArgumentNullException(nameof(mt));
            }
            // right key
            rightValue = SolveForValue(mt.Key, false);
            leftValue = Solve(mt.LeftKey);

            switch (mt.Operand)
            {
                case '+':
                    result = leftValue - rightValue;
                    break;
                case '-':
                    result = leftValue + rightValue;
                    break;
                case '*':
                    result = leftValue / rightValue;
                    break;
                case '/':
                    result = leftValue * rightValue;
                    break;
                case '=':
                    result = leftValue;
                    break;
                default:
                    Debug.WriteLine($"Operand: {mt.Operand}");
                    break;
            }
            return result;
        }
    }
}
