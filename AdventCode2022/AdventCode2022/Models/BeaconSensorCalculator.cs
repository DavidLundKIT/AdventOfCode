using System.Linq;

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

            foreach (var kvp in SensorBeaconDict)
            {
                var sensor = kvp.Key;
                var beacon = kvp.Value;
                long manhattenBeacon = ManhattenDistance(sensor, beacon);
                // sensing range reaches the row
                long xDistance = (1 + manhattenBeacon) * 2;
                for (long x = sensor.Item1 - xDistance; x < sensor.Item1 + xDistance; x++)
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
                if (SensedPoints.ContainsKey(beacon))
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

        public long FindFrequency(int vMin, int vMax)
        {
            bool sensed = false;
            for (int x = vMin; x <= vMax; x++)
            {
                for (int y = vMin; y <= vMax; y++)
                {
                    var tNow = new Tuple<long, long>(x, y);
                    sensed = false;
                    foreach (var kvp in SensorBeaconDict)
                    {
                        var sensor = kvp.Key;
                        var beacon = kvp.Value;
                        long manhattenBeacon = ManhattenDistance(sensor, beacon);
                        long dist = ManhattenDistance(sensor, tNow);
                        if (dist <= manhattenBeacon)
                        {
                            sensed= true;
                            break;
                        }
                    }
                    if (!sensed)
                    {
                        long freq = x * 4000000 + y;
                        return freq;
                    }
                }
            }
            return 0;
        }

        public long FindFrequencyFirstTry(long vMin, long vMax)
        {
            PrepSearchSquare(vMin, vMax);

            foreach (var kvp in SensorBeaconDict)
            {
                var sensor = kvp.Key;
                var beacon = kvp.Value;
                long manhattenBeacon = ManhattenDistance(sensor, beacon);
                long xMin = (sensor.Item1 - manhattenBeacon) < vMin ? vMin : sensor.Item1 - manhattenBeacon;
                long xMax = (sensor.Item1 + manhattenBeacon) > vMax ? vMax : sensor.Item1 + manhattenBeacon;
                long yMin = (sensor.Item2 - manhattenBeacon) < vMin ? vMin : sensor.Item2 - manhattenBeacon;
                long yMax = (sensor.Item2 + manhattenBeacon) > vMax ? vMax : sensor.Item2 + manhattenBeacon;
                for (long x = xMin; x <= xMax; x++)
                {
                    for (long y = yMin; y <= yMax; y++)
                    {
                        var tNow = new Tuple<long, long>(x, y);
                        long dist = ManhattenDistance(sensor, tNow);
                        if (dist <= manhattenBeacon)
                        {
                            SensedPoints[tNow] += 1;
                        }
                    }
                }
            }
            var notSensed = SensedPoints.Where(k => k.Value == 0);
            if (notSensed.Any())
            {
                var tFirst = notSensed.SingleOrDefault();
                long freq = tFirst.Key.Item1 * 4000000 + tFirst.Key.Item2;
                return freq;
            }
            return 0;
        }

        public void PrepSearchSquare(long vMin, long vMax)
        {
            SensedPoints.Clear();
            for (long x = vMin; x <= vMax; x++)
            {
                for (long y = vMin; y <= vMax; y++)
                {
                    var tNow = new Tuple<long, long>(x, y);
                    SensedPoints.Add(tNow, 0);
                }
            }
        }
    }
}
