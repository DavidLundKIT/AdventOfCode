using AdventOfCode2019;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day24PlanetOfDiscordUnittests
    {
        [Fact]
        public void Day24Part1_Example01()
        {
            string[] bugsMap = new string[]
            {
                "....#",
                "#..#.",
                "#..##",
                "..#..",
                "#...."
            };
            DiscordGameOfLife sut = new DiscordGameOfLife(bugsMap);

            sut.DumpBugs(0);
            sut.States[sut.BioDiversityRating()] = 0;
            for (int i = 1; i < 5; i++)
            {
                sut.LiveOneMin(i);
                sut.DumpBugs(i);
            }
        }

        [Fact]
        public void Day24Part1_BioDiversityRating()
        {
            string[] bugsMap = new string[]
            {
                ".....",
                ".....",
                ".....",
                "#....",
                ".#..."
            };

            DiscordGameOfLife sut = new DiscordGameOfLife(bugsMap);
            Assert.Equal(2129920, sut.BioDiversityRating());
            sut.DumpBugs(0);
        }

        [Fact]
        public void Day24Part1_Example01FindMatch()
        {
            string[] bugsMap = new string[]
            {
                "....#",
                "#..#.",
                "#..##",
                "..#..",
                "#...."
            };
            DiscordGameOfLife sut = new DiscordGameOfLife(bugsMap);

            sut.DumpBugs(0);
            sut.States[sut.BioDiversityRating()] = 0;
            int minute = 0;
            do
            {
                minute++;
            } while (!sut.LiveOneMin(minute));
            sut.DumpBugs(minute);
            Assert.Equal(2129920, sut.BioDiversityRating());
        }

        [Fact]
        public void Day24Part1_TestSolution()
        {
            string[] bugsMap = new string[]
            {
                "..#.#",
                ".#.##",
                "...#.",
                "...##",
                "#.###"
            };

            DiscordGameOfLife sut = new DiscordGameOfLife(bugsMap);
            sut.DumpBugs(0);
            sut.States[sut.BioDiversityRating()] = 0;
            int minute = 0;
            do
            {
                minute++;
            } while (!sut.LiveOneMin(minute));
            sut.DumpBugs(minute);
            Assert.Equal(17863741, sut.BioDiversityRating());
        }

        [Fact]
        public void Day24Part2_Example10Minutes()
        {
            string[] bugsMap = new string[]
            {
                "....#",
                "#..#.",
                "#..##",
                "..#..",
                "#...."
            };
            DiscordGameOfLifeMultiverse sut = new DiscordGameOfLifeMultiverse(bugsMap, 11);
            sut.DumpBugs(0);
            Assert.Equal(8, sut.BugCount());
            for (int i = 0; i < 10; i++)
            {
                sut.LiveOneMin();
            }
            sut.DumpBugs(10);
            Assert.Equal(99, sut.BugCount());
        }

        [Fact]
        public void Day24Part2_TestSolution()
        {
            string[] bugsMap = new string[]
            {
                "..#.#",
                ".#.##",
                "...#.",
                "...##",
                "#.###"
            };

            DiscordGameOfLifeMultiverse sut = new DiscordGameOfLifeMultiverse(bugsMap, 401);
            //sut.DumpBugs(0);
            Assert.Equal(12, sut.BugCount());
            for (int i = 0; i < 200; i++)
            {
                sut.LiveOneMin();
            }
            //sut.DumpBugs(200);
            Assert.Equal(2029, sut.BugCount());
        }
    }
}