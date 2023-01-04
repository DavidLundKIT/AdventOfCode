using AdventCode2022.Models;

namespace AdventCode2022
{
    public class Day11MonkeyInTheMiddleTests
    {
        [Fact]
        public void MonkeyBusiness_Test_Ok()
        {
            Monkey.Monkeys.Clear();
            Monkey.InitTest();

            for (int i = 0; i < 20; i++)
            {
                Monkey.DoRound(3);
            }
            long actual = Monkey.MonkeyBusiness();
            Assert.Equal(10605, actual);
        }

        [Fact]
        public void MonkeyBusiness_Part1_Ok()
        {
            Monkey.Monkeys.Clear();
            Monkey.InitPuzzle();

            for (int i = 0; i < 20; i++)
            {
                Monkey.DoRound(3);
            }
            long actual = Monkey.MonkeyBusiness();
            Assert.Equal(99852, actual);
        }

        [Theory()]
        [InlineData(1, 6, 4)]
        [InlineData(20, 99, 103)]
        [InlineData(1000, 5204, 5192)]
        [InlineData(2000, 10419, 10391)]
        [InlineData(3000, 15638, 15593)]
        [InlineData(10000, 52166, 52013)]
        public void Monkey_Business_Test_Ok(int steps, long monk1, long monk2)
        {
            Monkey.Monkeys.Clear();
            Monkey.InitTest();

            for (int i = 0; i < steps; i++)
            {
                Monkey.DoRound(1);
            }
            long actual = Monkey.MonkeyBusiness();
            long expected = monk1 * monk2;
            Assert.Equal(expected, actual);
        }

        [Theory()]
        [InlineData(23, 0)]
        [InlineData(19, 0)]
        [InlineData(17, 0)]
        [InlineData(13, 0)]
        public void Monkey_ModPrime_Test(long prime, long expected)
        {
            long value = 25 * 23 * 19 * 17 * 13;
            long allTestFactors = 23 * 19 * 17 * 13;
            long worryLevel = value % allTestFactors;
            long actual = worryLevel % prime;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MonkeyBusiness_Part2_Ok()
        {
            Monkey.Monkeys.Clear();
            Monkey.InitPuzzle();

            for (int i = 0; i < 10000; i++)
            {
                Monkey.DoRound(1);
            }
            long actual = Monkey.MonkeyBusiness();
            Assert.Equal(25935263541, actual);
        }
    }
}
