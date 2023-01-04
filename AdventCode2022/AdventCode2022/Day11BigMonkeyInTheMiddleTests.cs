using AdventCode2022.Models;
using System.Numerics;

namespace AdventCode2022
{
    public class Day11BigMonkeyInTheMiddleTests
    {
        [Theory(Skip ="Takes too long")]
        [InlineData(1, 6, 4)]
        [InlineData(20, 99, 103)]
        [InlineData(100, 0, 0)]
        [InlineData(200, 0, 0)]
        [InlineData(300, 0, 0)] // 6ms
        [InlineData(400, 0, 0)] // 25 ms
        [InlineData(500, 0, 0)] // 127 ms
        [InlineData(600, 0, 0)] // 460 ms
        [InlineData(700, 0, 0)] // 3,4 sec
        [InlineData(800, 0, 0)] // 22.1 sec
        [InlineData(900, 0, 0)] // 2.9 minutes
        [InlineData(1000, 5204, 5192)] // 20.5
        //[InlineData(2000, 10419, 10391)]
        //[InlineData(3000, 15638, 15593)]
        public void Big_Monkey_Business_Test_Ok(int steps, long monk1, long monk2)
        {
            BigMonkey.Monkeys.Clear();
            BigMonkey.InitTest();

            for (int i = 0; i < steps; i++)
            {
                BigMonkey.DoRound();
            }
            BigInteger actual = BigMonkey.MonkeyBusiness();
            BigInteger expected = monk1 * monk2;
            Assert.Equal(expected, actual);
        }
    }
}
