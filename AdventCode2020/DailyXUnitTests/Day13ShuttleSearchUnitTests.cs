using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DailyXUnitTests
{

    public class Day13ShuttleSearchUnitTests
    {
        private long testTimeStamp = 939;
        private string testBusses = "7,13,x,x,59,x,31,19";
        private long dataTimeStamp = 1001612;
        private string dataBusses = "19,x,x,x,x,x,x,x,x,41,x,x,x,37,x,x,x,x,x,821,x,x,x,x,x,x,x,x,x,x,x,x,13,x,x,x,17,x,x,x,x,x,x,x,x,x,x,x,29,x,463,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,23";

        [Fact(Skip = "Daily completed")]
        public void Day13ParseData_OK()
        {
            var tmp = testBusses.Split(new char[] { ',', 'x' });
            var busses = tmp.Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => long.Parse(s)).ToList();
            Assert.Equal(5, busses.Count);
        }

        [Fact(Skip = "Daily completed")]
        public void Day13_FindNextBus_Example_OK()
        {
            var tmp = testBusses.Split(new char[] { ',', 'x' });
            var busses = tmp.Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => long.Parse(s)).ToList();
            Assert.Equal(5, busses.Count);
            long ts = testTimeStamp;

            long wait = long.MaxValue;
            long bus = 0;
            foreach (var b in busses)
            {
                long tnow = ((ts / b) + 1) * b - ts;
                if (tnow < wait)
                {
                    wait = tnow;
                    bus = b;
                }
            }
            Assert.Equal(295, bus * wait);
        }

        [Fact(Skip = "Daily completed")]
        public void Day13ParseRealData_OK()
        {
            var tmp = dataBusses.Split(new char[] { ',', 'x' });
            var busses = tmp.Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => long.Parse(s)).ToList();
            Assert.Equal(9, busses.Count);
        }

        [Fact(Skip = "Daily completed")]
        public void Day13_FindNextBus_Part1_OK()
        {
            var tmp = dataBusses.Split(new char[] { ',', 'x' });
            var busses = tmp.Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => long.Parse(s)).ToList();
            Assert.Equal(9, busses.Count);

            long ts = dataTimeStamp;

            long wait = long.MaxValue;
            long bus = 0;
            foreach (var b in busses)
            {
                long tnow = ((ts / b) + 1) * b - ts;
                if (tnow < wait)
                {
                    wait = tnow;
                    bus = b;
                }
            }
            Assert.Equal(6568, bus * wait);
        }

        [Fact(Skip = "Daily completed")]
        public void Day13ParseDataWithOffset_OK()
        {
            var tmp = testBusses.Split(new char[] { ',' });
            var bussesAndXs = tmp.Select(s => s == "x"? 0: long.Parse(s)).ToList();
            Assert.Equal(8, bussesAndXs.Count);
            
            Dictionary<long, long> busses = new Dictionary<long, long>();

            for (int i = 0; i < bussesAndXs.Count; i++)
            {
                if (bussesAndXs[i] != 0)
                {
                    busses.Add(bussesAndXs[i], i);
                }
            }
            Assert.Equal(5, busses.Count);

            bool good = true;
            long busMax = busses.Keys.Max();
            for (long idx = 1; idx < long.MaxValue; idx++)
            {
                good = true;
                long ts = busMax * idx - busses[busMax];
                foreach (var bus in busses)
                {
                    if ((ts + bus.Value) % bus.Key != 0)
                    {
                        good = false;
                        break;
                    }
                }
                if (good == true)
                {
                    Assert.Equal(1068781, ts);
                    break;
                }
            }
        }

        /// <summary>
        /// My brute force that never ended after working 4+ hours
        /// </summary>
        [Fact(Skip = "Never finished")]
        public void Day13ParseRealDataWithOffset_OK()
        {
            var tmp = dataBusses.Split(new char[] { ',' });
            var bussesAndXs = tmp.Select(s => s == "x" ? 0 : long.Parse(s)).ToList();
            Assert.Equal(74, bussesAndXs.Count);

            Dictionary<long, long> busses = new Dictionary<long, long>();

            for (int i = 0; i < bussesAndXs.Count; i++)
            {
                if (bussesAndXs[i] != 0)
                {
                    busses.Add(bussesAndXs[i], i);
                }
            }
            Assert.Equal(9, busses.Count);

            bool good = true;
            long busMax = busses.Keys.Max();
            for (long idx = 1; idx < long.MaxValue; idx++)
            {
                good = true;
                // largest of all prime bus ids
                long ts = busMax * idx - busses[busMax];
                foreach (var bus in busses)
                {
                    if ((ts + bus.Value) % bus.Key != 0)
                    {
                        good = false;
                        break;
                    }
                }
                if (good == true)
                {
                    Assert.Equal(0, ts);
                    break;
                }
            }
        }
    }
}
