using System.Linq;
using Xunit;

namespace day04.tests
{
    public class Day04UnitTests
    {
        [Theory(Skip = "Done")]
        [InlineData("Guard #797 begins shift", 797)]
        [InlineData("Guard #2579 begins shift", 2579)]
        [InlineData("Guard #2381 begins shift", 2381)]
        public void Day04_GetGuardId_Ok(string item, int expectedId)
        {
            var sut = new Day04GuardWorkSchedule();
            int guard = sut.GetGuardId(item);
            Assert.Equal(expectedId, guard);
        }

        [Fact(Skip = "Done")]
        public void Day04_ParseFile_OK()
        {
            string datapath = "day04a.txt";
            //string outpath = @"C:\Work\fun\AdventCode2018\data\day04aout.txt";
            var sut = new Day04GuardWorkSchedule();

            var rows = sut.ReadDataFile(datapath);
            Assert.NotNull(rows);
            Assert.Equal(1108, rows.Length);

            var events = sut.SortedEvents(rows);
            Assert.NotNull(events);
            Assert.Equal(1108, events.Count);
            //sut.WriteEvents(outpath, events);
            // foreach (var item in events)
            // {
            //     Debug.WriteLine($"key: {item.Key}, val: {item.Value}");
            // }
            var guardDict = sut.GaurdSumMinutes(events);
            var actualMaxMinutes = guardDict.Values.Max();
            var actualMaxGuard = guardDict.First(i => i.Value == actualMaxMinutes);
            Assert.Equal(2381, actualMaxGuard.Key);

            var minuteDict = sut.SleepiestMinuteForGuard(events, actualMaxGuard.Key);
            var mostFrequentMinuteCount = minuteDict.Values.Max();
            Assert.Equal(18, minuteDict.Values.Max());
            var actualMaxMinute = minuteDict.First(m => m.Value == mostFrequentMinuteCount);
            Assert.Equal(104764, actualMaxGuard.Key * actualMaxMinute.Key);
        }

        [Fact(Skip = "Done")]
        public void Day04_Part2_OK()
        {
            string datapath = "day04a.txt";
            var sut = new Day04GuardWorkSchedule();

            var rows = sut.ReadDataFile(datapath);
            Assert.NotNull(rows);
            Assert.Equal(1108, rows.Length);

            var events = sut.SortedEvents(rows);
            Assert.NotNull(events);
            Assert.Equal(1108, events.Count);
            var guardDict = sut.GaurdSumMinutes(events);
            int actualMaxGuard = 0;
            int actualMaxMinute = -1;
            int mostFrequentMinuteCount = 0;

            foreach (var guard in guardDict.Keys)
            {
                var minuteDict = sut.SleepiestMinuteForGuard(events, guard);
                var minuteCount = minuteDict.Values.Max();
                var minuteAtMax = minuteDict.First(m => m.Value == minuteCount);
                if (minuteCount > mostFrequentMinuteCount)
                {
                    actualMaxGuard = guard;
                    mostFrequentMinuteCount = minuteCount;
                    actualMaxMinute = minuteAtMax.Key;
                }
            }

            Assert.Equal(128617, actualMaxGuard * actualMaxMinute);
        }
    }
}
