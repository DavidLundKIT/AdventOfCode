using Microsoft.Z3;
using System.Text.RegularExpressions;

namespace AdventCode2025;

/// <summary>
/// This solution uses the Z3 SMT solver to solve part 2 of day 10.
/// Andreas L. is the source of this code/idea.
/// It works on my data but I still don't fully understand it.
/// </summary>
public class Day10UsingZ3SATstuff
{
    [Fact]
    public void Day10_Part2_TestData_Z3_OK()
    {
        string input = Models.Utils.ReadAllTextFromFile("Day10test.txt");
        long resultB = RunB(input);
        Assert.Equal(33, resultB);
    }

    [Fact]
    public void Day10_Part2_Solution_Z3_OK()
    {
        string input = Models.Utils.ReadAllTextFromFile("Day10.txt");
        long resultB = RunB(input);
        Assert.Equal(16063, resultB);
    }

    private long RunB(string input)
    {
        Machine[] machines = input.Split("\r\n").Select(Machine.Parse).ToArray();

        using Context context = new Context();
        long sum = 0;
        foreach (Machine machine in machines)
            sum += RunB(context, machine);
        return sum;
    }

    private long RunB(Context context, Machine machine)
    {
        using Solver solver = context.MkSolver();

        int maxJoltage = machine.Joltages.Max();

        IntExpr[] presses = Enumerable.Range(0, machine.Buttons.Length).Select(i =>
        {
            IntExpr expr = context.MkIntConst($"presses[{i}]");
            solver.Assert(expr >= 0);
            solver.Assert(expr <= maxJoltage);
            return expr;
        }).ToArray();

        for (int i = 0; i < machine.Joltages.Length; i++)
        {
            ArithExpr joltageSum = context.MkInt(0);
            for (int j = 0; j < machine.Wires.Length; j++)
                if (machine.Wires[j].Contains(i))
                    joltageSum += presses[j];
            IntNum joltageTarget = context.MkInt(machine.Joltages[i]);
            solver.Assert(context.MkEq(joltageSum, joltageTarget));
        }

        ArithExpr totalPresses = presses.Cast<ArithExpr>().Aggregate((a, b) => a + b);
        int totalPressesTarget = maxJoltage;
        while (true)
        {
            solver.Push();
            solver.Assert(context.MkEq(totalPresses, context.MkInt(totalPressesTarget)));
            if (solver.Check() == Status.SATISFIABLE)
                return totalPressesTarget;
            solver.Pop();
            totalPressesTarget++;
        }
    }

    public record Machine(int Target, int[] Buttons, int[][] Wires, int[] Joltages)
    {
        public static Machine Parse(string s)
        {
            Match match = Regex.Match(s, @"^\[(?<target>.+)\] (?<buttons>.+) {(?<joltages>.+)}$", RegexOptions.Compiled);
            if (!match.Success)
                throw new Exception($"Invalid machine: {s}");

            string targetString = match.Groups["target"].Value.Replace(".", "0").Replace("#", "1");
            int target = Convert.ToInt32(targetString, 2);

            string[] parts = match.Groups["buttons"].Value.Split(' ');
            int[] buttons = new int[parts.Length];
            int[][] wires = new int[parts.Length][];
            for (int i = 0; i < buttons.Length; i++)
            {
                wires[i] = parts[i].Split(['(', ',', ')'], StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < wires[i].Length; j++)
                    buttons[i] |= 1 << (targetString.Length - wires[i][j] - 1);
            }

            int[] joltages = match.Groups["joltages"].Value.Split(',').Select(int.Parse).ToArray();

            return new Machine(target, buttons, wires, joltages);
        }

        public bool Press(ref int state, int button)
        {
            state ^= Buttons[button];
            return state == Target;
        }
    }

}
