using AdventOfCode2020;
using System.Collections.Generic;
using Xunit;

namespace DailyXUnitTests
{
    public class Day01ExpenseAccountUnitTests
    {
        [Fact(Skip = "Daily completed")]
        public void CreateInstance_ReadDataOK()
        {
            var sut = new ExpenseAccount();
            Assert.NotNull(sut);
            Assert.False(string.IsNullOrWhiteSpace(sut.PathToDailyData));

            sut.Expenses = DailyDataUtilities.ReadIntsFromFile("Day01Data.txt");
            Assert.Equal(200, sut.Expenses.Count);
            Assert.Equal(1769, sut.Expenses[199]);
        }

        [Fact(Skip = "Daily completed")]
        public void FindSumOfPairIs2020()
        {
            var sut = new ExpenseAccount();
            sut.Expenses = new List<int>()
            {
                1721,
                979,
                366,
                299,
                675,
                1456
            };

            var result = sut.FindPairWithSum(2020);
            Assert.Equal(514579, result);
        }

        [Fact(Skip = "Daily completed")]
        public void FindSumOfPairIs2020_Part1()
        {
            var sut = new ExpenseAccount();
            sut.Expenses = DailyDataUtilities.ReadIntsFromFile("Day01Data.txt");
            Assert.Equal(200, sut.Expenses.Count);
            Assert.Equal(1769, sut.Expenses[199]);

            var result = sut.FindPairWithSum(2020);
            Assert.Equal(926464, result);
        }

        [Fact(Skip = "Daily completed")]
        public void FindSumOfTripleIs2020()
        {
            var sut = new ExpenseAccount();
            sut.Expenses = new List<int>()
            {
                1721,
                979,
                366,
                299,
                675,
                1456
            };

            var result = sut.FindTripleWithSum(2020);
            Assert.Equal(241861950, result);
        }

        [Fact(Skip = "Daily completed")]
        public void FindSumOfTripleIs2020_Part1()
        {
            var sut = new ExpenseAccount();
            sut.Expenses = DailyDataUtilities.ReadIntsFromFile("Day01Data.txt");
            Assert.Equal(200, sut.Expenses.Count);
            Assert.Equal(1769, sut.Expenses[199]);

            var result = sut.FindTripleWithSum(2020);
            Assert.Equal(65656536, result);
        }
    }
}
