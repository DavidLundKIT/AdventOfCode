using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2022.Models
{
    public class BeaconSensorCalculator
    {
        public Dictionary<Tuple<long, long>, Tuple<long, long>> SensorBeaconDict { get; set; }
        public Dictionary<Tuple<long, long>, int> SensedPoints { get; set; }

        public BeaconSensorCalculator()
        {
            SensedPoints = new Dictionary<Tuple<long, long>, int>();
            SensorBeaconDict = new Dictionary<Tuple<long, long>, Tuple<long, long>>();
        }

        public BeaconSensorCalculator(string[] lines)
        {
            SensorBeaconDict = new Dictionary<Tuple<long, long>, Tuple<long, long>>();
            SensedPoints = new Dictionary<Tuple<long, long>, int>();

            foreach (var line in lines)
            {
                var parts = line.Split(new string[] { "Sensor at x=", ", y=", ": closest beacon is at x=" }, StringSplitOptions.RemoveEmptyEntries);
                var sensor = new Tuple<long, long>(long.Parse(parts[0]), long.Parse(parts[1]));
                var beacon = new Tuple<long, long>(long.Parse(parts[2]), long.Parse(parts[3]));
                SensorBeaconDict.Add(sensor, beacon);
            }
        }

        public long PlacesBeaconCannotBeOnRow(long row)
        {
            SensedPoints.Clear();

            foreach (var sensor in SensorBeaconDict.Keys)
            {
                var beacon = SensorBeaconDict[sensor];
                long manhattenBeacon = ManhattenDistance(sensor, beacon);
                // sensing range reaches the row
                long xDistance = (1 + manhattenBeacon) * 2;
                for (long x = sensor.Item1 - xDistance; x < sensor.Item2 + xDistance; x++)
                {
                    var tNow = new Tuple<long, long>(x, row);
                    long dist = ManhattenDistance(sensor, tNow);
                    if (dist <= manhattenBeacon)
                    {
                        if (SensedPoints.ContainsKey(tNow))
                            SensedPoints[tNow]++;
                        else
                            SensedPoints.Add(tNow, 1);
                    }
                }
            }

            foreach (var beacon in SensorBeaconDict.Values)
            {
                if(SensedPoints.ContainsKey(beacon))
                {
                    SensedPoints.Remove(beacon);
                }
            }
            return SensedPoints.Count;
        }

        public long ManhattenDistance(Tuple<long, long> sensor, Tuple<long, long> beacon)
        {
            return Math.Abs(sensor.Item1 - beacon.Item1) + Math.Abs(sensor.Item2 - beacon.Item2);
        }
    }
}
