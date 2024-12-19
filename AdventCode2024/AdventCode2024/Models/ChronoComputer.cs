﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2024.Models;

public record InitialComputerState(long RegisterA, long RegisterB, long RegisterC, string Program);

public class ChronoComputer
{
    public long RegA { get; set; }
    public long RegB { get; set; }
    public long RegC { get; set; }
    public string ProgramCode { get; set; }
    public List<long> TheProgram { get; set; }

    public int InstPtr { get; set; }
    public List<long> Output { get; set; }

    public ChronoComputer(long regA, long regB, long regC, string program)
    {
        RegA = regA;
        RegB = regB;
        RegC = regC;
        ProgramCode = program;
        TheProgram = ProgramCode.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(s => long.Parse(s)).ToList();
        InstPtr = 0;
        Output = new List<long>();
    }

    public ChronoComputer(InitialComputerState data)
    {
        RegA = data.RegisterA;
        RegB = data.RegisterB;
        RegC = data.RegisterC;
        ProgramCode = data.Program;
        TheProgram = ProgramCode.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(s => long.Parse(s)).ToList();
        InstPtr = 0;
        Output = new List<long>();
    }

    public void Run()
    {
        Output.Clear();
        InstPtr = 0;

        while (0 <= InstPtr && InstPtr < TheProgram.Count)
        {
            long result = DoInstruction(TheProgram[InstPtr], TheProgram[InstPtr + 1]);
        }
    }

    public long DoInstruction(long instruction, long operand)
    {
        long result = 0;

        switch (instruction)
        {
            case 0:
                // adv 
                result = RegA / (long)(Math.Pow(2, ComboOperand(operand)));
                RegA = result;
                break;
            case 1:
                // bxl
                result = RegB ^ LiteralOperand(operand);
                RegB = result;
                break;
            case 2:
                // bst
                result = ComboOperand(operand) % 8;
                RegB = result;
                break;
            case 3:
                // jnz
                if (RegA != 0)
                {
                    // jump
                    InstPtr = (int) LiteralOperand(operand);
                    return InstPtr;
                }
                break;
            case 4:
                // bxc - ignores operand
                result = RegB ^ RegC;
                RegB = result;
                break;
            case 5:
                // out 
                result = ComboOperand(operand) % 8;
                Output.Add(result);
                break;
            case 6:
                // bdv 
                result = RegA / (long)(Math.Pow(2, ComboOperand(operand)));
                RegB = result;
                break;
            case 7:
                // cdv 
                result = RegA / (long)(Math.Pow(2, ComboOperand(operand)));
                RegC = result;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(operand));
        }
        InstPtr += 2;
        return InstPtr;
    }

    public long LiteralOperand(long operand)
    {
        return operand;
    }

    public long ComboOperand(long operand)
    {
        switch (operand)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                return operand;
            case 4:
                return RegA;
            case 5:
                return RegB;
            case 6:
                return RegC;
            default:
                throw new ArgumentOutOfRangeException(nameof(operand));
        }
    }

    public string ShowOutput()
    {
        if (Output.Count == 0)
            return string.Empty;
        return string.Join(",", Output.Select(l=> l.ToString()).ToArray());
    }
}
