using AdventCode2022.Models;

namespace AdventCode2022
{
    public class Day21MonkeyMathTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day21.txt");
            long actual = lines.Length;
            Assert.Equal(1933, actual);

            var mrs = new MonkeyRiddleSolver(lines);
            Assert.Equal(1933, mrs.ProgramDict.Count);
        }

        [Fact]
        public void ReadInDataFile_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day21test.txt");
            long actual = lines.Length;
            Assert.Equal(15, actual);

            var mrs = new MonkeyRiddleSolver(lines);
            Assert.Equal(15, mrs.ProgramDict.Count);
        }

        [Fact]
        public void SolveMonkeyRiddle_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day21test.txt");
            long actual = lines.Length;
            Assert.Equal(15, actual);

            var mrs = new MonkeyRiddleSolver(lines);
            Assert.Equal(15, mrs.ProgramDict.Count);

            actual = mrs.Solve("root");
            Assert.Equal(152, actual);
        }

        [Fact]
        public void SolveMonkeyRiddle_Part1_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day21.txt");
            long actual = lines.Length;
            Assert.Equal(1933, actual);

            var mrs = new MonkeyRiddleSolver(lines);
            Assert.Equal(1933, mrs.ProgramDict.Count);

            actual = mrs.Solve("root");
            Assert.Equal(160274622817992, actual);
            var list = mrs.ProgramDict.Values.Where(mt => mt.TimesCalled > 1).ToList();
            Assert.False(list.Any());
            var list2 = mrs.ProgramDict.Values.Where(mt => mt.TimesCalled == 0).ToList();
            Assert.False(list2.Any());

        }

        [Fact]
        public void SolveMonkeyRiddle_Human_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day21test.txt");
            long actual = lines.Length;
            Assert.Equal(15, actual);

            var mrs = new MonkeyRiddleSolver(lines);
            Assert.Equal(15, mrs.ProgramDict.Count);

            mrs.ProgramDict["humn"].Value = 301;
            var mt = mrs.ProgramDict["root"];

            long leftValue = mrs.Solve(mt.LeftKey);
            long rightValue = mrs.Solve(mt.RightKey);

            Assert.Equal(leftValue, rightValue);
        }

        [Fact]
        public void SolveMonkeyRiddle_SolveHuman_Test_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day21test.txt");
            long actual = lines.Length;
            Assert.Equal(15, actual);

            var mrs = new MonkeyRiddleSolver(lines);
            Assert.Equal(15, mrs.ProgramDict.Count);

            mrs.ProgramDict["root"].Operand = '=';

            actual = mrs.SolveForValue("humn");
            Assert.Equal(301, actual);
        }

        [Fact]
        public void SolveMonkeyRiddle_Human_Part2_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day21.txt");
            long actual = lines.Length;
            Assert.Equal(1933, actual);

            var mrs = new MonkeyRiddleSolver(lines);
            Assert.Equal(1933, mrs.ProgramDict.Count);

            mrs.ProgramDict["root"].Operand = '=';

            // left 107992431115158
            // right 52282191702834


            // wrong 8882214318977
            // wrong 8,882,214,319,976
            actual = mrs.SolveForValue("humn");
            Assert.Equal(3087390115721, actual);
        }

        [Fact]
        public void SolveMonkeyRiddle_LeftPart_Part2_OK()
        {
            var lines = Utils.ReadLinesFromFile("Day21.txt");
            long actual = lines.Length;
            Assert.Equal(1933, actual);

            var mrs = new MonkeyRiddleSolver(lines);
            Assert.Equal(1933, mrs.ProgramDict.Count);

            var mt = mrs.ProgramDict["root"];
            //mrs.ProgramDict["humn"].Value = 8882214318977;

            // left 107992431115158
            long leftValue = mrs.Solve(mt.LeftKey);
            // right 52282191702834
            long rightValue = mrs.Solve(mt.RightKey);

            //Assert.Equal(rightValue, leftValue);

            // wrong 8882214318977
            actual = mrs.SolveForValue("humn");
            Assert.Equal(3087390115721, actual);
        }

        [Fact(Skip = "Doesnt find a solution in hours")]
        public void GrindOutTheAnswer_part2_Ok()
        {
            long match = 52282191702834;
            long humn = 505;
            long result;
            do
            {
                humn++;
                result = (217 + ((((71994954081260 - (((((((((2 * ((((4 * ((((((((((((680 + (((((((((((276 + ((((195 + (745 + (((28 * (659 + (((2 * (((475 + (((((((441 + (2 * ((((387 + (((humn) - 217) * 40)) + 99) / 2) - 361))) / 5) + 926) / 3) - 73) * 2) + 421)) / 2) - 899)) - 389) / 7))) - 2) * 2))) / 8) - 705) * 3)) / 2) + 232) + 263) / 9) - 330) * 29) - 531) * 2) + 92) / 2)) + 276) / 5) - 216) * 3) + 177) / 2) - 966) * 2) - 978) / 4) + 961)) + 24) / 4) - 873)) + 713) * 3) - 507) / 9) + 41) * 14) - 381) / 3)) + 550) + 575) / 2)) * 3;
            } while (result != match);

            Assert.Equal(0, humn);
        }
    }
}
