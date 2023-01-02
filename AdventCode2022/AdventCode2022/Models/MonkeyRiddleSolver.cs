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


        public long SolveForValue(string key)
        {
            long leftValue = 0;
            long rightValue = 0;
            long result = 0;
            var mt = ProgramDict.Values.Where(mt => mt.LeftKey == key).SingleOrDefault();
            if (mt != null)
            {
                if (mt.Key == "root")
                {
                    rightValue = Solve(mt.RightKey);
                    return rightValue;
                }
                // left key
                rightValue = Solve(mt.RightKey);
                leftValue = SolveForValue(mt.Key);
            }
            else
            {
                mt = ProgramDict.Values.Where(mt => mt.RightKey == key).SingleOrDefault();
                if (mt == null)
                {
                    throw new ArgumentNullException(nameof(mt));
                }
                if (mt.Key == "root")
                {
                    leftValue = Solve(mt.LeftKey);
                    return leftValue;
                }
                // right key
                leftValue = Solve(mt.LeftKey);
                rightValue = SolveForValue(mt.Key);
            }

            switch (mt.Operand)
            {
                case '+':
                    result = key == mt.LeftKey ? (leftValue - rightValue) : (rightValue - leftValue);
                    //result = key == mt.LeftKey ? (rightValue - leftValue) : (leftValue - rightValue);
                    //result = leftValue - rightValue;
                    //result = rightValue - leftValue;
                    break;
                case '-':
                    result = rightValue + leftValue;
                    break;
                case '*':
                    //result = isLeftKey ? (leftValue / rightValue) : (rightValue / leftValue);
                    //result = key == mt.LeftKey ? (leftValue / rightValue) : (rightValue / leftValue);
                    result = leftValue > rightValue ? (leftValue / rightValue) : (rightValue / leftValue);
                    //result = leftValue / rightValue;
                    //result = rightValue / leftValue;
                    break;
                case '/':
                    result = rightValue * leftValue;
                    break;
                default:
                    Debug.WriteLine($"Operand: {mt.Operand}");
                    break;
            }
            return result;
        }
    }
}
