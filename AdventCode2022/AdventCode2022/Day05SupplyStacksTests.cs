using AdventCode2022.Models;

namespace AdventCode2022
{
    public class Day05SupplyStacksTests
    {
        [Fact]
        public void ReadInDataFile_OK()
        {
            var elfSections = Utils.ReadLinesFromFile("Day05.txt");
            int expected = 512;
            int actual = elfSections.Length;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("move 1 from 2 to 1", 1, 2, 1)]
        [InlineData("move 3 from 1 to 3", 3, 1, 3)]
        [InlineData("move 2 from 2 to 1", 2, 2, 1)]
        [InlineData("move 1 from 1 to 2", 1, 1, 2)]
        public void ParseCommands_OK(string cmd, int amount, int from, int to)
        {
            var sut = new SupplyCrane(3);
            var parts = cmd.Split(new char[] { ' ' });
            Assert.Equal(amount, int.Parse(parts[1]));
            Assert.Equal(from, int.Parse(parts[3]));
            Assert.Equal(to, int.Parse(parts[5]));
        }

        [Fact]
        public void ApplyCommands_OK()
        {
            var cmds = new string[] {
                "move 1 from 2 to 1","move 3 from 1 to 3","move 2 from 2 to 1", "move 1 from 1 to 2"
            };

            var sut = new SupplyCrane(3);

            foreach (var cmd in cmds)
            {
                sut.DoCmd(cmd);
            }
            Assert.Equal('C', sut.Stacks[0].Peek());
            Assert.Equal('M', sut.Stacks[1].Peek());
            Assert.Equal('Z', sut.Stacks[2].Peek());
            var actual = sut.PeekStackTops();
            Assert.Equal("CMZ", actual);
        }

        [Fact]
        public void ApplyCommandsFromFile_OK()
        {
            var cmds = Utils.ReadLinesFromFile("Day05test.txt");

            var sut = new SupplyCrane(3);

            foreach (var cmd in cmds)
            {
                if (cmd.StartsWith("move"))
                    sut.DoCmd(cmd);
            }
            Assert.Equal('C', sut.Stacks[0].Peek());
            Assert.Equal('M', sut.Stacks[1].Peek());
            Assert.Equal('Z', sut.Stacks[2].Peek());
            var actual = sut.PeekStackTops();
            Assert.Equal("CMZ", actual);
        }

        [Fact]
        public void SupplyStacks_Part1_OK()
        {
            var cmds = Utils.ReadLinesFromFile("Day05.txt");

            var sut = new SupplyCrane(9);

            foreach (var cmd in cmds)
            {
                if (cmd.StartsWith("move"))
                    sut.DoCmd(cmd);
            }
            var actual = sut.PeekStackTops();
            Assert.Equal("MQTPGLLDN", actual);
        }

        [Fact]
        public void ApplyCommands_9001_OK()
        {
            var cmds = new string[] {
                "move 1 from 2 to 1","move 3 from 1 to 3","move 2 from 2 to 1", "move 1 from 1 to 2"
            };

            var sut = new SupplyCrane(3);

            foreach (var cmd in cmds)
            {
                sut.DoCmd9001(cmd);
            }
            Assert.Equal('M', sut.Stacks[0].Peek());
            Assert.Equal('C', sut.Stacks[1].Peek());
            Assert.Equal('D', sut.Stacks[2].Peek());
            var actual = sut.PeekStackTops();
            Assert.Equal("MCD", actual);
        }

        [Fact]
        public void ApplyCommands_9001_FromFile_OK()
        {
            var cmds = Utils.ReadLinesFromFile("Day05test.txt");

            var sut = new SupplyCrane(3);

            foreach (var cmd in cmds)
            {
                if (cmd.StartsWith("move"))
                    sut.DoCmd9001(cmd);
            }
            Assert.Equal('M', sut.Stacks[0].Peek());
            Assert.Equal('C', sut.Stacks[1].Peek());
            Assert.Equal('D', sut.Stacks[2].Peek());
            var actual = sut.PeekStackTops();
            Assert.Equal("MCD", actual);
        }

        [Fact]
        public void SupplyStacks_Crane9001_Part2_OK()
        {
            var cmds = Utils.ReadLinesFromFile("Day05.txt");

            var sut = new SupplyCrane(9);

            foreach (var cmd in cmds)
            {
                if (cmd.StartsWith("move"))
                    sut.DoCmd9001(cmd);
            }
            var actual = sut.PeekStackTops();
            Assert.Equal("LVZPSTTCZ", actual);
        }

    }
}
