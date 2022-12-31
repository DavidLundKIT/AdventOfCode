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

            actual = mrs.SolveForValue("humn", false);
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

            var mt = mrs.ProgramDict["root"];

            // 107992431115158
            long leftValue = mrs.Solve(mt.LeftKey);

            // 52282191702834
            long rightValue = mrs.Solve(mt.RightKey);


            Assert.Equal(leftValue, rightValue);


        }

    }
}
