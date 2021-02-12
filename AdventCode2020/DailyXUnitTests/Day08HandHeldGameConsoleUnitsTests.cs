using AdventOfCode2020;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DailyXUnitTests
{
    public class Day08HandHeldGameConsoleUnitsTests
    {
        private string[] TestProgram = new string[]
        {
            "nop +0",
            "acc +1",
            "jmp +4",
            "acc +3",
            "jmp -3",
            "acc -99",
            "acc +1",
            "jmp -4",
            "acc +6"
        };

        [Fact(Skip = "Daily completed")]
        public void ReadProgramData_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day08Data.txt");
            Assert.Equal(626, lines.Length);
        }

        [Fact(Skip = "Daily completed")]
        public void CreateProgramInstuctions_Ok()
        {
            List<Instruction> program = TestProgram.Select(l => new Instruction(l)).ToList();
            Assert.Equal(9, program.Count);
            var sut = new GameConsole(program);
            sut.Run();
            Assert.Equal(5, sut.Acc);
        }

        [Fact(Skip = "Daily completed")]
        public void GameConsole_Part1_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day08Data.txt");
            Assert.Equal(626, lines.Length);
            List<Instruction> program = lines.Select(l => new Instruction(l)).ToList();
            Assert.Equal(626, program.Count);
            var sut = new GameConsole(program);
            sut.Run();
            Assert.True(sut.Bad);
            Assert.Equal(1654, sut.Acc);
        }

        [Fact(Skip = "Daily completed")]
        public void CreateFixProgramInstuctions_Ok()
        {
            int instructionToChange = 0;
            bool bad = true;
            long acc = 0;
            do
            {
                List<Instruction> program = TestProgram.Select(l => new Instruction(l)).ToList();
                Assert.Equal(9, program.Count);
                for (int idx = instructionToChange; idx < program.Count; idx++)
                {
                    if (program[idx].Cmd == "jmp")
                    {
                        program[idx].Cmd = "nop";
                        instructionToChange = idx + 1;
                        break;
                    }
                    if (program[idx].Cmd == "nop")
                    {
                        program[idx].Cmd = "jmp";
                        instructionToChange = idx + 1;
                        break;
                    }
                }
                var sut = new GameConsole(program);
                sut.Run();
                bad = sut.Bad;
                acc = sut.Acc;
            } while (bad);
            Assert.Equal(8, acc);
        }

        [Fact(Skip = "Daily completed")]
        public void GameConsoleFixProgram_Part2_Ok()
        {
            var lines = DailyDataUtilities.ReadLinesFromFile("Day08Data.txt");
            Assert.Equal(626, lines.Length);
            int instructionToChange = 0;
            bool bad = true;
            long acc = 0;
            do
            {
                List<Instruction> program = lines.Select(l => new Instruction(l)).ToList();
                Assert.Equal(626, program.Count);
                for (int idx = instructionToChange; idx < program.Count; idx++)
                {
                    if (program[idx].Cmd == "jmp")
                    {
                        program[idx].Cmd = "nop";
                        instructionToChange = idx + 1;
                        break;
                    }
                    if (program[idx].Cmd == "nop")
                    {
                        program[idx].Cmd = "jmp";
                        instructionToChange = idx + 1;
                        break;
                    }
                }
                var sut = new GameConsole(program);
                sut.Run();
                bad = sut.Bad;
                acc = sut.Acc;
            } while (bad);
            Assert.Equal(833, acc);
            Assert.Equal(224, instructionToChange);
        }
    }
}
