using AdventCode2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2022
{
    public class Day20GrovePositioningSystemTests
    {
        public List<int> TestData { get; set; } = new List<int> { 1, 2, -3, 3, -2, 0, 4 };

        [Fact]
        public void ReadInDataFile_OK()
        {
            var lines = Utils.ReadIntsFromFile("Day20.txt");
            int actual = lines.Count;
            Assert.Equal(5000, actual);

            var gps = new GrovePositioningSystem(lines);

            Assert.Equal(5000, gps.OrderList.Count);

            var listZeros = lines.Where(l => l == 0).ToList();
            Assert.Equal(1, listZeros.Count);
        }

        [Fact]
        public void FindGroveCoords_Test_OK()
        {
            var gps = new GrovePositioningSystem(TestData);

            Assert.Equal(7, gps.OrderList.Count);

            for (int i = 0; i < 7; i++)
            {
                gps.DoMove(i);
            }

            List<int> expected = new List<int>() { 1, 2, -3, 4, 0, 3, -2 };
            var actual = gps.OrderList.Select(n => n.Item2).ToList();
            var results = expected.Zip(actual).Select(p => p.First== p.Second);
            foreach (var result in results)
            {
                Assert.True(result);
            }
        }

        [Fact]
        public void FindGroveCoords_1K_2K_3K_Test_OK()
        {
            var gps = new GrovePositioningSystem(TestData);

            Assert.Equal(7, gps.OrderList.Count);

            for (int i = 0; i < gps.OriginalOrder.Count; i++)
            {
                gps.DoMove(i);
            }
            List<int> expected = new List<int>() { 1, 2, -3, 4, 0, 3, -2 };
            var actual = gps.OrderList.Select(n => n.Item2).ToList();
            var results = expected.Zip(actual).Select(p => p.First == p.Second);
            foreach (var result in results)
            {
                Assert.True(result);
            }
            int value1k = gps.FindNthValueAfterZero(1000);
            Assert.Equal(4, value1k);
            int value2k = gps.FindNthValueAfterZero(2000);
            Assert.Equal(-3, value2k);
            int value3k = gps.FindNthValueAfterZero(3000);
            Assert.Equal(2, value3k);
            Assert.Equal(3, value1k + value2k + value3k);
        }

        [Fact]
        public void FindGroveCoords_1K_2K_3K_Part1_OK()
        {
            var lines = Utils.ReadIntsFromFile("Day20.txt");
            var gps = new GrovePositioningSystem(lines);

            Assert.Equal(5000, gps.OrderList.Count);

            for (int i = 0; i < gps.OriginalOrder.Count; i++)
            {
                gps.DoMove(i);
            }
            int value1k = gps.FindNthValueAfterZero(1000);
            int value2k = gps.FindNthValueAfterZero(2000);
            int value3k = gps.FindNthValueAfterZero(3000);

            // -11641 is wrong
            // -5753
            Assert.Equal(int.MinValue, value1k + value2k + value3k);
        }

        [Fact]
        public void CheckTuppleEquality()
        {
            Tuple<int, int> t1 = new Tuple<int, int>(1, 2);
            Tuple<int, int> t2 = new Tuple<int, int>(1, 2);

            Assert.Equal(t1, t2);
        }
    }
}
