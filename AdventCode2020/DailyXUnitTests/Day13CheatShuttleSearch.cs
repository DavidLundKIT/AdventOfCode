using AdventOfCode2020;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace DailyXUnitTests
{
    public class Day13CheatShuttleSearch
    {
        /// <summary>
        /// Algorithm works but never solved the problem
        /// </summary>
        [Fact(Skip = "Daily completed")]
        public void Test_ChineseRemainderTheorem_OK()
        {
            long[] n = { 3, 5, 7 };
            long[] a = { 2, 3, 2 };

            long result = ChineseRemainderTheorem.Solve(n, a);

            long counter = 0;
            long maxCount = n.Length - 1;
            while (counter <= maxCount)
            {
                Debug.WriteLine($"{result} ≡ {a[counter]} (mod {n[counter]})");
                counter++;
            }
            Assert.Equal(23, result);
        }

        /// <summary>
        /// Again never solved the problem
        /// </summary>
        [Fact(Skip = "Didn't Work")]
        public void Test2()
        {

            long[] n = { 19, 41, 37, 821, 13, 17, 29, 463, 23 };
            //long[] a = { 0, 9, 13, 19, 32, 36, 48, 50, 73 };
            long[] a = { 0, 9, 13, 19, 6, 2, 19, 50, 17 };

            long result = ChineseRemainderTheorem.Solve(n, a);

            long counter = 0;
            long maxCount = n.Length - 1;
            while (counter <= maxCount)
            {
                Debug.WriteLine($"{result} ≡ {a[counter]} (mod {n[counter]})");
                counter++;
            }
            Assert.Equal(0, result);
        }

        /// <summary>
        /// Used for the solution, by Sani found here: https://github.com/CKret/AdventOfCode
        /// </summary>
        [Fact(Skip = "Daily completed")]
        public void Day13_Sani_Part2_Ok()
        {
            string dataBusses = "19,x,x,x,x,x,x,x,x,41,x,x,x,37,x,x,x,x,x,821,x,x,x,x,x,x,x,x,x,x,x,x,13,x,x,x,17,x,x,x,x,x,x,x,x,x,x,x,29,x,463,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,23";

            List<string> input = new List<string>();
            input.Add(dataBusses);

            var result = input.Last(line => !string.IsNullOrWhiteSpace(line))
                   .Split(',')
                   .Select((id, i) => new KeyValuePair<int, int>(i, (id == "x") ? 1 : int.Parse(id)))
                   .Aggregate(new { Time = 0L, LCM = 1L },
                       (acc, curr) =>
                           new
                           {
                               Time = Enumerable.Range(0, int.MaxValue)
                                                .Select(x => acc.Time + (acc.LCM * x))
                                                .First((x) => (x + curr.Key) % curr.Value == 0),
                               LCM = acc.LCM * curr.Value
                           }
                   )
                   .Time;
            Assert.Equal(554865447501099, result);
        }

        [Fact(Skip = "Daily completed")]
        public void Day13_Inspection_Ok()
        {
            string dataBusses = "19,x,x,x,x,x,x,x,x,41,x,x,x,37,x,x,x,x,x,821,x,x,x,x,x,x,x,x,x,x,x,x,13,x,x,x,17,x,x,x,x,x,x,x,x,x,x,x,29,x,463,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,23";

            List<string> input = new List<string>();
            input.Add(dataBusses);

            var temp = input.Last(line => !string.IsNullOrWhiteSpace(line))
                   .Split(',')
                   .Select((id, i) => new KeyValuePair<int, int>(i, (id == "x") ? 1 : int.Parse(id))).ToList();
            var result = temp.Aggregate(new { Time = 0L, LCM = 1L },
                       (acc, curr) =>
                           new
                           {
                               Time = Enumerable.Range(0, int.MaxValue)
                                                .Select(x => acc.Time + (acc.LCM * x))
                                                .First((x) => (x + curr.Key) % curr.Value == 0),
                               LCM = acc.LCM * curr.Value
                           }
                   );
            Assert.Equal(554865447501099, result.Time);
            long primes = 19L * 41L * 37L * 821L * 13L * 17L * 29L * 463L * 23L;
            Assert.Equal(primes, result.LCM);
        }
    }
}
