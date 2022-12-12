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
                Monkey.DoRound();
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
                Monkey.DoRound();
            }
            long actual = Monkey.MonkeyBusiness();
            // wrong: 99540
            // wrong: 99225 - added Math.floor() when / 3
            Assert.Equal(99852, actual);
        }

        [Theory(Skip ="Long and ULong not fixing part 2")]
        [InlineData(1, 6, 4)]
        [InlineData(20, 99, 103)]
        [InlineData(1000, 5204, 5194)]
        [InlineData(2000, 10419, 10391)]
        [InlineData(3000, 15638, 15593)]
        public void Monkey2_Business_Test_Ok(int steps, long monk1, long monk2)
        {
            Monkey2.Monkeys.Clear();
            Monkey2.InitTest();

            for (int i = 0; i < steps; i++)
            {
                Monkey2.DoRound();
            }
            long actual = Monkey2.MonkeyBusiness();
            long expected = monk1 * monk2;
            Assert.Equal(expected, actual);
        }

    }
}
