using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class OperationOrderParser
    {
        public List<string> Operands { get; set; }
        public Stack<string> Operators { get; set; }

        public OperationOrderParser()
        {
            Operators = new Stack<string>();
            Operands = new List<string>();
        }

        public long Evaluate(string equation, bool advanced = false)
        {
            if (advanced)
            {
                ParseEquationAdv(equation);
            }
            else
            {
                ParseEquation(equation);
            }
            Stack<long> Numbers = new Stack<long>();

            foreach (var tmp in Operands)
            {
                switch (tmp)
                {
                    case "+":
                        Numbers.Push(Numbers.Pop() + Numbers.Pop());
                        break;
                    case "*":
                        Numbers.Push(Numbers.Pop() * Numbers.Pop());
                        break;
                    default:
                        Numbers.Push(long.Parse(tmp));
                        break;
                }
            }
            return Numbers.Pop();
        }

        public void ParseEquation(string equation)
        {
            string eq = equation.Replace("(", "( ");
            eq = eq.Replace(")", " )");

            var parts = eq.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                if (int.TryParse(part, out int ival))
                {
                    // number push
                    Operands.Add(part);
                }
                else
                {
                    if (part == "+" || part == "*")
                    {
                        if (Operators.Count > 0 && Operators.Peek() != "(")
                        {
                            Operands.Add(Operators.Pop());
                        }
                        Operators.Push(part);
                    }
                    else if (part == "(")
                    {
                        Operators.Push(part);
                    }
                    else if (part == ")")
                    {
                        // find the match
                        string op;
                        while (Operators.Count > 0 && (op = Operators.Pop()) != "(")
                        {
                            Operands.Add(op);
                        }
                    }
                }
            }

            while (Operators.Count > 0)
            {
                Operands.Add(Operators.Pop());
            }
        }

        public void ParseEquationAdv(string equation)
        {
            string eq = equation.Replace("(", "( ");
            eq = eq.Replace(")", " )");

            var parts = eq.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var part in parts)
            {
                if (int.TryParse(part, out int ival))
                {
                    // number push
                    Operands.Add(part);
                }
                else
                {
                    if (part == "+" || part == "*")
                    {
                        if (Operators.Count > 0 && Operators.Peek() != "(")
                        {
                            if (part == "*" && Operators.Peek() == "+")
                            {
                                Operands.Add(Operators.Pop());
                            }
                            else if(part == Operators.Peek())
                            {
                                Operands.Add(Operators.Pop());
                            }
                        }
                        Operators.Push(part);
                    }
                    else if (part == "(")
                    {
                        Operators.Push(part);
                    }
                    else if (part == ")")
                    {
                        // find the match
                        string op;
                        while (Operators.Count > 0 && (op = Operators.Pop()) != "(")
                        {
                            Operands.Add(op);
                        }
                    }
                }
            }

            while (Operators.Count > 0)
            {
                Operands.Add(Operators.Pop());
            }
        }
    }
}
