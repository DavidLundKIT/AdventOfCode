using AdventCode2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // wrong is 99540
            Assert.Equal(0, actual);
        }
    }
}
