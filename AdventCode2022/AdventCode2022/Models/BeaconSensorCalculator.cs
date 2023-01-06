using System.Diagnostics;

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

        public void FindPointsOutOfRangeByOne(Tuple<long, long> sensor, Tuple<long, long> beacon, long vMin, long vMax)
        {
            long md = ManhattenDistance(sensor, beacon) + 1;
            for (long i = 0; i <= md; ++i)
            {
                var t1 = new Tuple<long, long>(sensor.Item1 + i, sensor.Item2 + (md - i));
                CheckQuadrant(t1, vMin, vMax);
                var t2 = new Tuple<long, long>(sensor.Item1 - i, sensor.Item2 + (md - i));
                CheckQuadrant(t2, vMin, vMax);
                var t3 = new Tuple<long, long>(sensor.Item1 + i, sensor.Item2 - (md - i));
                CheckQuadrant(t3, vMin, vMax);
                var t4 = new Tuple<long, long>(sensor.Item1 - i, sensor.Item2 - (md - i));
                CheckQuadrant(t4, vMin, vMax);
            }
        }

        public void CheckQuadrant(Tuple<long, long> tNow, long vMin, long vMax)
        {
            if (vMin <= tNow.Item1 && tNow.Item1 <= vMax
                && vMin <= tNow.Item2 && tNow.Item2 <= vMax)
            {
                SensedPoints.TryAdd(tNow, 0);
            }
        }

        public void MarkThoseInRange(Tuple<long, long> sensor, Tuple<long, long> beacon)
        {
            long md = ManhattenDistance(sensor, beacon);
            foreach (var sp in SensedPoints.Keys)
            {
                if (SensedPoints[sp] == 0)
                {
                    // no one has marked this as sensed
                    long dist = ManhattenDistance(sensor, sp);
                    if (dist <= md)
                    {
                        SensedPoints[sp]++;
                    }
                }
            }
        }

        public void RemoveSensedPoints()
        {
            var keysMarked = SensedPoints.Where(t => t.Value > 0).Select(t => t.Key);
            foreach (var key in keysMarked)
            {
                SensedPoints.Remove(key);
            }
        }

        /// <summary>
        /// Working on the assumption that there is only one free point in the intersection of all sensors.
        /// within the given square (vMin, vMax).
        /// So for each sensor find all points just out of sensing range in the given square.
        /// Then see if those points are seen by any of the sensors.
        /// </summary>
        public long FindPointsBetweenSensors(long vMin, long vMax)
        {
            SensedPoints.Clear();
            foreach (var kvp in SensorBeaconDict)
            {
                var sensor = kvp.Key;
                var beacon = kvp.Value;
                MarkThoseInRange(sensor, beacon);
                RemoveSensedPoints();
                FindPointsOutOfRangeByOne(sensor, beacon, vMin, vMax);
            }

            Debug.WriteLine($"Points to be sensed: {SensedPoints.Count}");
            foreach (var kvp in SensorBeaconDict)
            {
                var sensor = kvp.Key;
                var beacon = kvp.Value;
                MarkThoseInRange(sensor, beacon);
                RemoveSensedPoints();
            }

            var kvpBeacon = SensedPoints.Where(kvp => kvp.Value == 0).Single();
            return kvpBeacon.Key.Item1 * 4000000 + kvpBeacon.Key.Item2;
        }

        /// <summary>
        /// Working on the assumption that there is only one free point in the intersection of all sensors.
        /// So check 1-1 for the closest but not quite intersections.
        /// Then see if those points are seen by any of the sensors.
        /// </summary>
        public void FindPointsBetweenSensorsSingle()
        {
            SensedPoints.Clear();
            foreach (var kvpLeft in SensorBeaconDict)
            {
                int foundOpen = 0;
                var sensorLeft = kvpLeft.Key;
                var beaconLeft = kvpLeft.Value;
                long distLeft = ManhattenDistance(sensorLeft, beaconLeft);

                foreach (var kvpRight in SensorBeaconDict)
                {
                    var sensorRight = kvpRight.Key;
                    var beaconRight = kvpRight.Value;
                    if (sensorLeft == sensorRight)
                    {
                        // same sensor
                        continue;
                    }
                    long distRight = ManhattenDistance(sensorRight, beaconRight);

                    long distSensors = ManhattenDistance(sensorLeft, sensorRight);
                    if (distSensors > distLeft + distRight)
                    {
                        // sensing ranges do not overlap
                        long diff = distSensors - (distLeft + distRight);
                        if (diff <= 2)
                        {
                            Debug.WriteLine($"diff is: {diff}");
                            foundOpen++;
                            // make the points.
                            MakeAndAddPoints(sensorLeft, distLeft, sensorRight, distRight);
                        }
                    }
                }
                Debug.WriteLine($"Found open spot: {foundOpen}");
            }
            Debug.WriteLine("Done");
        }

        /// <summary>
        /// Need to find the points in between the two sensors.
        /// Not the center. Duh!
        /// </summary>
        /// <param name="sensorLeft"></param>
        /// <param name="distLeft"></param>
        /// <param name="sensorRight"></param>
        /// <param name="distRight"></param>
        public void MakeAndAddPoints(Tuple<long, long> sensorLeft, long distLeft, Tuple<long, long> sensorRight, long distRight)
        {
            // TODO David would this work if I could get the points between the range of the 2 sensors?
            long xMin = Math.Min(sensorLeft.Item1, sensorRight.Item1);
            long xMax = Math.Min(sensorLeft.Item1, sensorRight.Item1);
            long yMin = Math.Min(sensorLeft.Item2, sensorRight.Item2);
            long yMax = Math.Min(sensorLeft.Item2, sensorRight.Item2);
            Tuple<long, long> tCenter = new Tuple<long, long>(xMin + Math.Abs(sensorLeft.Item1 - sensorRight.Item1) / 2, yMin + Math.Abs(sensorLeft.Item2 - sensorRight.Item2) / 2);
            long mdl = ManhattenDistance(tCenter, sensorLeft);
            long mdr = ManhattenDistance(tCenter, sensorRight);
            if (mdl > distLeft && mdr > distRight)
            {
                SensedPoints.Add(tCenter, 1);
            }
        }

        /// <summary>
        /// Way too long 6.6 E13 tests x Number of sensors.
        /// Previous version got bogged in prepping a test square.
        /// </summary>
        /// <param name="vMin"></param>
        /// <param name="vMax"></param>
        /// <returns></returns>
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
                            sensed = true;
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
    }
}
